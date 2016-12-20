(function () {
    "use strict";
    var app = angular.module("writePostApp");
    var controllerId = "writePostController";

    app.controller(controllerId, ["postService", controller]);
    
    function controller(postService) {
        var self = this;

        console.log("WritePost");

        this.isCreating = true;
        this.isTextActive = true;

        this.title = "";
        this.textContent = "";
        this.htmlContent = "";

        this.message = "";

        this.textToHtmlContentIntervalId = -1;
        this.htmlToTextContentIntervalId = -1;

        init();

        function init() {
            document.getElementById("textContent").contentWindow.document.designMode = "on";
            document.getElementById("textContent").contentWindow.close();

            var edit = document.getElementById("textContent").contentWindow;
            edit.focus();

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
            return new postModel(self.title, self.htmlContent, [], "");
        }

        this.updatePost = function () {
            console.log("UpdatePost");
        }

        this.startHtmlToTextContentCopy = function () {
            if (self.textToHtmlContentIntervalId > 0) {
                clearInterval(self.textToHtmlContentIntervalId);
                self.textToHtmlContentIntervalId = -1;
            }

            self.htmlToTextContentIntervalId = setInterval(function () {
                $("#textContent").contents().find("body").html($("#htmlContent").val());
            }, 1000);

            self.isTextActive = false;
        }

        this.startTextToHtmlContentCopy = function () {
            if (self.htmlToTextContentIntervalId > 0) {
                clearInterval(self.htmlToTextContentIntervalId);
                self.htmlToTextContentIntervalId = -1;
            }

            self.textToHtmlContentIntervalId = setInterval(function () {
                $("#htmlContent").val($("#textContent").contents().find("body").html());
            }, 1000);

            self.isTextActive = true;
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