(function () {
    var moduleId = "service";
    var serviceId = "postService";

    var app = angular.module(moduleId, []);
    app.factory(serviceId, ["$http", service]);

    function service($http) {
        var self = this;

        self.baseUrl = "/api";

        function test() {
            alert("test");
        }

        function getSummaries() {
            var requestUrl = "{base}/posts/Summaries".replace(/{base}/, self.baseUrl);
            
            var posts = $http({
                method: "GET",
                url: requestUrl
            });

            return posts;
        }

        //function getLatestPost() {
        //    return $.get(self.base + "getLatest").promise();
        //}

        //function createPost(postModel) {
        //    if (postModel == null || !postModel.isValid()) {
        //        return new returnWrapper(null, true, ErrorTypes.InvalidParameters);
        //    }
        //    var deferred = $.Deferred();

        //    var postViewModel = { Title: "Test Title, please work" };

        //    return deferred;
        //}

        //function loadPageOfPosts() {
        //    return $.get(self.base + "getPageOfPosts").promise();
        //}

        //function updatePost(postModel) {
        //    if (postModel == null || !postModel.isValid()) {
        //        return new returnWrapper(null, true, ErrorTypes.InvalidParameters);
        //    }

        //    var deferred = $.Deferred();

        //    $.put(self.base + "put", postModel, function () {
        //        deferred.resolve();
        //    });

        //    return deferred;
        //}

        //function getPosts() {
        //    return $.get(self.base + "GetPosts").promise();
        //}

        //$.put = function (url, data, callback, type) {

        //    if ($.isFunction(data)) {
        //        type = type || callback,
        //        callback = data,
        //        data = {}
        //    }

        //    return $.ajax({
        //        url: url,
        //        type: 'PUT',
        //        success: callback,
        //        data: data,
        //        contentType: type
        //    });
        //}

        return {
            //createPost: createPost,
            //getLatestPost: getLatestPost,
            //getPosts: getPosts,
            //loadPageOfPosts: loadPageOfPosts,
            //updatePost: updatePost
            getSummaries: getSummaries,
            test: test
        };
    }
})();