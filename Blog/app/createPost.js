//  Sits on page, binds page elements to post controller.
function createPostBinder($) {
    var self = this;

    this.postService = new postService($);

    this.title = $("#title");
    this.content = $("#content");
    this.createBtn = $("#createNew");
    this.message = $("#message");

    this.createPost = function(){
        var createResponse = self.postService.createPost(self.createModel());
       // message.text(createResponse);
    }

    this.createModel = function(){
        var model = new postModel(self.title[0].value, self.content[0].value, [], "");
        return model;
    }


    this.createBtn.click(this.createPost);
}

var createPost = new createPostBinder($);