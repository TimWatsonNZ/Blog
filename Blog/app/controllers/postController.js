(function () {
    "use strict";
    var app = angular.module("postApp");
    var controllerId = "postController";

    app.controller(controllerId, ["postService", controller]);

    function controller(postService) {
        var self = this;
        console.log("post");

        self.gotoPost = function (postId) {
            //  Navigate to post.
            window.location = "/Post?id=" + postId;
        }

        this.editPost = function (postId) {
            window.location = "Post/Write?id={postId}&update={isUpdate}"
                                .replace(/{postId}/, postId)
                                .replace(/{isUpdate}/, true);
        }
    }
})();