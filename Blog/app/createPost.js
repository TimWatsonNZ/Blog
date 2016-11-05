//  Sits on page, binds page elements to post controller.
function createPostBinder($) {
    var self = this;

    this.postService = new postService($);
    this.hasCreated = false;
    this.postId = -1;
    this.htmlContent = "";

    this.title = $("#title");
    this.content = $("#content");
    this.createBtn = $("#createNew");
    this.message = $("#message");

    this.createPost = function(){
        var createResponse = self.postService.createPost(self.createModel());

        createResponse.then(function (data) {
            self.message.text("Post created!");
            self.postId = data;
            self.hasCreated = true;

            self.changeToUpdate();
        });
    }

    this.updatePost = function () {
        var updateResponse = self.postService.updatePost(self.createModel());

        updateResponse.then(function (data) {
            self.message.text("Post updated!");
        });
    }

    this.createModel = function () {
        if (self.postId > 0) {
            return new postModel(self.title[0].value, self.content[0].value, [], "", self.postId);
        }
        
        return new postModel(self.title[0].value, self.content[0].value, [], "");
    }

    this.changeToUpdate = function () {
        self.createBtn.text("Update");

        self.createBtn.unbind('click');
        self.createBtn.click(this.updatePost);
    }

    this.init = function(){
        this.createBtn.click(this.createPost);
    }

    self.init();
}

var createPost = new createPostBinder($);