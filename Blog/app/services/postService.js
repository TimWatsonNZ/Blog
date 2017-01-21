(function () {
    var moduleId = "postService";
    var serviceId = "postService";

    var app = angular.module(moduleId, ["utilService"]);
    app.factory(serviceId, ["$http", "utilService", service]);

    function service($http, util) {
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
            var deferred = $.Deferred();

            if (postModel == null || !postModel.isValid()) {
                return deferred.reject(util.InvalidParameters());
            }
            
            var requestUrl = "{base}/posts/Post".replace(/{base}/, self.baseUrl);

            $http({
                method: "POST",
                url: requestUrl,
                data: postModel
            }).then(
               function () {
                deferred.resolve();
            }, function () {
                deferred.reject(util.InvalidParameters());
            });

            return deferred;
        }

        function updatePost(postModel) {
            if (postModel == null || !postModel.isValid()) {
                deferred.reject(util.InvalidParameters());
                return deferred;
            }
            var deferred = $.Deferred();
            var requestUrl = "{base}/Posts/Put".replace(/{base}/, self.baseUrl);

            $http({
                method: "PUT",
                url: requestUrl,
                data: postModel
            }).then(
                function () {
                    deferred.resolve();
            }, 
                function () {
                    deferred.reject();
                });

            return deferred;
        }

        return {
            createPost: createPost,
            updatePost: updatePost,
            getSummaries: getSummaries,
            test: test
        };
    }
})();