//  Should provide data to front end.
function postService($) {
    var self = this;

    self.base = "/api/blogpost/";

    function getLatestPost() {
        return $.get(self.base + "getLatest").promise();
    }

    function createPost(postModel) {
        if (postModel == null || !postModel.isValid()) {
            return new returnWrapper(null, true, ErrorTypes.InvalidParameters);
        }
        var deferred = $.Deferred();

        $.post(self.base + "post", postModel, function (data) {
            deferred.resolve(data)
        });

        return deferred;
    }
     
    function loadPageOfPosts() {
        return $.get(self.base + "getPageOfPosts").promise();
    }

    function updatePost(postModel) {
        if (postModel == null || !postModel.isValid()) {
            return new returnWrapper(null, true, ErrorTypes.InvalidParameters);
        }

        var deferred = $.Deferred();

        $.put(self.base + "put", postModel, function () {
            deferred.resolve();
        });

        return deferred;
    }

    function getPosts() {
        return $.get(self.base + "GetPosts").promise();
    }

    $.put = function (url, data, callback, type) {

        if ($.isFunction(data)) {
            type = type || callback,
            callback = data,
            data = {}
        }

        return $.ajax({
            url: url,
            type: 'PUT',
            success: callback,
            data: data,
            contentType: type
        });
    }

    return {
        createPost: createPost,
        getLatestPost: getLatestPost,
        getPosts: getPosts,
        loadPageOfPosts: loadPageOfPosts,
        updatePost: updatePost
    };
};