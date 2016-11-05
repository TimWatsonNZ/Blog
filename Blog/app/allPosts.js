function allPostsController($) {
    var self = this;

    //this.postContainer = $("#postContainer");
    this.postService = new postService($);
    this.mainContent = $("#mainContent");

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

    function getLatestPost() {
        var post = self.postService.getLatestPost();

        post.done(function (post) {
            var content = "<div class='post'>" +
                                        "<div>" +
                                            "<div class='postInfo'>" +
                                                "<div>" +
                                                    "{Title}" +
                                                "</div>" +

                                                "<div>" +
                                                    "{Date}" +
                                                "</div>" +

                                                "<div>" +
                                                    "{Tags}" +
                                                "</div>" +
                                            "</div>" +

                                            "<div class='postContent'>" +
                                                "{Content}" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>";
            content = content.replace(/{Title}/g, post.title)
                             .replace(/{Date}/g, post.created)
                             .replace(/{Tags}/g, post.tags)
                             .replace(/{Content}/g, post.content)
            self.mainContent.append(content);

        });
    }

    function loadPageOfPosts() {
        var call = self.postService.loadPageOfPosts();

        call.done(function (posts) {
            posts.forEach(function (post) {
                var content = "<div class='post'>" +
                                            "<div>" +
                                                "<div class='postInfo'>" +
                                                    "<div>" +
                                                        "<b>{Title}</b>" +
                                                    "</div>" +

                                                    "<div>" +
                                                        "{Date}" +
                                                    "</div>" +

                                                    "<div>" +
                                                        "{Tags}" +
                                                    "</div>" +
                                                "</div>" +
                                                "<br />" + 
                                                "<div class='postContent'>" +
                                                    "{Content}" +
                                                "</div>" +
                                            "</div>" +
                                        "</div>" +
                                        "<hr>";
                content = content.replace(/{Title}/g, post.title)
                                 .replace(/{Date}/g, moment(post.created).format("MMMM Do YY"))
                                 .replace(/{Tags}/g, post.tags || "No tags")
                                 .replace(/{Content}/g, post.content)
                self.mainContent.append(content);
            });
        });
    }

    loadPageOfPosts();
}

var allPosts = allPostsController($);