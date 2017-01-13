(function () {
    var moduleId = "service";
    var serviceId = "postService";

    var app = angular.module(moduleId, []);
    app.factory(serviceId, ["$http", service]);

    function service($http) {
        var self = this;

        self.baseUrl = "/api";

        function test() {
            return "test";
        }

        function getSummaries() {
            var requestUrl = "{base}/posts/Summaries".replace(/{base}/, self.baseUrl);
            
            var posts = $http({
                method: "GET",
                url: requestUrl
            });

            return posts;
        }

        function createPost(postModel) {
            if (postModel == null || !postModel.isValid()) {
                return new returnWrapper(null, true, ErrorTypes.InvalidParameters);
            }
            var deferred = $.Deferred();
            var requestUrl = "{base}/posts/Post".replace(/{base}/, self.baseUrl);

            $http({
                method: "POST",
                url: requestUrl,
                data: postModel
            });

            return deferred;
        }

        return {
            createPost: createPost,
            getSummaries: getSummaries,
            test: test
        };
    }
})();