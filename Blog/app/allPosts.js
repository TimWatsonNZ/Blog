function allPostsController($) {
    var self = this;

    this.postContainer = $("#postContainer");
    this.postService = new postService($);

    function getPosts() {
        var posts = self.postService.getPosts();
        posts.done(function (posts) {
            posts.forEach(function (post) {
                self.postContainer.append("<div>{Title}<div>{Content}</div></div>"
                                         .replace(/{Title}/g, post.title)
                                         .replace(/{Content}/g, post.content)
                                         );
                });
        });
    }
    getPosts();
}

var allPosts = allPostsController($);