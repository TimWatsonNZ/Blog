(function () {
    "use strict";
    var app = angular.module("postApp");
    var controllerId = "postController";

    app.controller(controllerId, ["postService", controller]);

    function controller(postService) {
        console.log("post controller");
    }
})();