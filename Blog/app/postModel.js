
function postModel(title, content, tags, category, id) {
    var self = this;

    this.Title = title;
    this.Content = content;
    this.Tags = tags;
    this.Category = category;
    this.BlogPostId = id;

    self.isValid = function () {
        return this.Title && this.Content;
    }
}
