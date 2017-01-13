(function () {
    "use strict";
    var app = angular.module("mainApp");
    var controllerId = "mainController";

    app.controller(controllerId, ["postService", "utilService", controller]);

    function controller(postService, util) {
        var self = this;

        this.errorMessage = { hasError: false, message: "" };
        this.posts = [];

        init();

        //  On start load posts from api.
        //  Use this data to create dom elements.
        function init() {
            getPosts();
        }

        function getPosts() {
            postService.getSummaries()
                       .then(populatePosts, onGetPostsError);
        }

        function onGetPostsError(response) {
            //  Populate some error div.
            self.errorMessage.hasError = true;
            self.errorMessage.posts = response.data;
        }

        function populatePosts(postData) {
            self.posts = postData.data;
        }

        self.shortDate = function (datetime) {
            return util.printDate(datetime);
        }

        self.gotoPost = function(post){
            //  Navigate to post.
            window.location = "/Post?id=" + post.BlogPostId;
        }

        this.test = function () {
            console.log("mainController");
        }
    }
})();