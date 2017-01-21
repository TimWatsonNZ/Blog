(function () {
    "use strict";
    var app = angular.module("writePostApp");
    var controllerId = "writePostController";

    app.controller(controllerId, ["postService", controller]);
    
    function controller(postService) {
        var self = this;

        this.isCreating = true;
        this.isTextActive = true;

        this.title = "";
        this.blogId = -1;

        this.message = "";

        this.textToHtmlContentIntervalId = -1;
        this.htmlToTextContentIntervalId = -1;

        this.init = function(isUpdate, blogId, title, content) {
            document.getElementById("textContent").contentWindow.document.designMode = "on";
            document.getElementById("textContent").contentWindow.close();

            var edit = document.getElementById("textContent").contentWindow;
            edit.focus();

            this.isCreating = !isUpdate;
            this.blogId = blogId || "";
            this.title = title || "";
            var textContent = content || "";

            this.setTextContent(textContent);
            this.setHtmlContent(this.getTextContent());

            //  Checks what is focused every second, work around for focus event listener
            //  not working with iframes.
            setInterval(checkFocus, 1000);
        }

        this.createPost = function () {
            var model = self.createModel();
            var createResponse = postService.createPost(model).
                then(function (resp) {
                    self.message = "Post created successfully";
                    self.isCreating = false;
                }, function (err) {
                    self.message = "There was error creating the post.";
                });
        }

        this.createModel = function () {
            if (this.blogId > 0){
                return new postModel(self.title, self.getHtmlContent(), [], "", this.blogId);
            }

            return new postModel(self.title, self.getHtmlContent(), [], "");
        }

        this.updatePost = function () {
            var model = self.createModel();
            postService.updatePost(model).
                then(function(resp){
                    self.message = "Post Updated";
                },
                function(){
                    self.message = "There was an error updating the post.";
                });
        }

        this.startHtmlToTextContentCopy = function () {
            if (self.textToHtmlContentIntervalId > 0) {
                clearInterval(self.textToHtmlContentIntervalId);
                self.textToHtmlContentIntervalId = -1;
            }

            self.htmlToTextContentIntervalId = setInterval(function () {
                self.setTextContent(self.getHtmlContent());
            }, 1000);

            self.isTextActive = false;
        }

        this.startTextToHtmlContentCopy = function () {
            if (self.htmlToTextContentIntervalId > 0) {
                clearInterval(self.htmlToTextContentIntervalId);
                self.htmlToTextContentIntervalId = -1;
            }

            self.textToHtmlContentIntervalId = setInterval(function () {
                self.setHtmlContent(self.getTextContent);
            }, 1000);

            self.isTextActive = true;
        }

        this.getTextContent = function () {
            return $("#textContent").contents().find("body").html();
        }

        this.getHtmlContent = function() {
            return $("#htmlContent").val();
        }

        this.setTextContent = function (text) {
            $("#textContent").contents().find("body").html(text);
        }

        this.setHtmlContent = function (text) {
            $("#htmlContent").val(text);
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
    }

})();