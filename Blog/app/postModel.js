
function postModel(title, content, tags, category) {
    var self = this;

    this.Title = title;
    this.Content = content;
    this.Tags = tags;
    this.Category = category;

    self.isValid = function () {
        return this.Title && this.Content;
    }
}
