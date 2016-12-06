//  Sits on page, binds page elements to post controller.
function createPostBinder($) {
    var self = this;

    this.postService = new postService($);
    this.hasCreated = false;
    this.postId = -1;

    this.title = $("#title");
    this.textContent = $("#textContent");
    this.htmlContent = $("#htmlContent");

    this.createBtn = $("#createNew");
    this.message = $("#message");

    this.boldBtn = $("#bold");

    this.textToHtmlContentIntervalId = -1;
    this.htmlToTextContentIntervalId = -1;

    this.createPost = function(){
        var createResponse = self.postService.createPost(self.createModel());

        //createResponse.then(function (data) {
        //    self.message.text("Post created!");
        //    self.postId = data;
        //    self.hasCreated = true;

        //    self.changeToUpdate();
        //});
    }

    this.updatePost = function () {
        var updateResponse = self.postService.updatePost(self.createModel());

        updateResponse.then(function (data) {
            self.message.text("Post updated!");
        });
    }

    this.createModel = function () {
        if (self.postId > 0) {
            return new postModel(self.title[0].value, self.htmlContent[0].value, [], "", self.postId);
        }
        
        return new postModel(self.title[0].value, self.htmlContent[0].value, [], "");
    }

    this.changeToUpdate = function () {
        self.createBtn.text("Update");

        self.createBtn.unbind('click');
        self.createBtn.click(this.updatePost);
    }

    this.onBoldClick = function () {
        var edit = document.getElementById("textContent").contentWindow;
        edit.focus();
        edit.document.execCommand("bold", false, "");
    }

    //  Copies the iframe contents to the text area contents
    this.startTextToHtmlContentCopy = function () {
        if (self.htmlToTextContentIntervalId > 0) {
            clearInterval(self.htmlToTextContentIntervalId);
            self.htmlToTextContentIntervalId = -1;
        }

        self.textToHtmlContentIntervalId = setInterval(function () {
            console.log("text -> html")
            $("#htmlContent").val($("#textContent").contents().find("body").html());
        }, 1000);
    }

    //  Copies the text are contents to the iframe contents
    this.startHtmlToTextContentCopy = function () {
        if (self.textToHtmlContentIntervalId > 0) {
            clearInterval(self.textToHtmlContentIntervalId);
            self.textToHtmlContentIntervalId = -1;
        }
        
        self.htmlToTextContentIntervalId = setInterval(function () {
            console.log("html -> Text")
            $("#textContent").contents().find("body").html($("#htmlContent").val());
        }, 1000);
    }

    function checkFocus() {
        //  If iframe active
        if (document.activeElement == document.getElementsByTagName("iframe")[0]) {
            //  If copy function not already running.
            if (self.textToHtmlContentIntervalId < 0) {
                self.startTextToHtmlContentCopy();
            }
        }
    }

    this.init = function(){
        this.createBtn.click(this.createPost);
        document.getElementById("textContent").contentWindow.document.designMode = "on";
        document.getElementById("textContent").contentWindow.close();

        $("#textContent").click(function () {
            console.log("text has focus.");
        });

        $("#htmlContent").focus(this.startHtmlToTextContentCopy);

        self.boldBtn.click(self.onBoldClick);
        
        var edit = document.getElementById("textContent").contentWindow;
        edit.focus();

        setInterval(checkFocus, 1000);
    }

    self.init();
}

var createPost = new createPostBinder($);