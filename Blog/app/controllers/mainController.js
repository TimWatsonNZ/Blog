(function () {
    var app = angular.module("mainApp")
    var controllerId = "mainController";

    app.controller(controllerId, ["postService", controller]);

    function controller(postService) {
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

        self.gotoPost = function(post){
            alert(post)
        }
    }
})();