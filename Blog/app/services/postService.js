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

        return $.post(self.base + "post", postModel).promise();
    }

    function updatePost(postModel) {
        if (postModel == null || !postModel.isValid()) {
            return new returnWrapper(null, true, ErrorTypes.InvalidParameters);
        }

        $.post(
            self.base + "post",
            postModel,
        function (data) {
            return new returnWrapper(data);
        })
        .fail(function (response) {
            console.log("Error on createPost");
            return new returnWrapper(null, true, ErrorTypes.HttpError, response);
        });
    }

    function getPosts() {
        return $.get(self.base + "GetPosts").promise();
    }

    return {
        createPost: createPost,
        getLatestPost: getLatestPost,
        getPosts: getPosts
    };
};