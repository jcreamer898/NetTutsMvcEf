/// <reference path="jquery-1.7.2.js" />
(function($) {
    var Review = Backbone.Model.extend();
    var Reviews = Backbone.Collection.extend({
        model: Review,
        url: '/api/reviews'
    });
    var Comment = Backbone.Model.extend({});
    var Comments = Backbone.Collection.extend({
        model: Comment,
        url: '/api/reviews/comments/'
    });
    
    var ListReviews = Backbone.View.extend({
        el: '.reviews',
        initialize: function() {
            this.collection.on('reset', this.render, this);
            this.collection.fetch();
        },
        render: function() {
            this.collection.each(this.renderItem, this);
        },
        renderItem: function(model) {
            var view = new ReviewItem({
                model: model
            });
            this.$el.append(view.el);
        }
    });

    var ReviewItem = Backbone.View.extend({
        events: {
            'click a': 'getComments'
        },
        tagName: 'li',
        initialize: function () {
            
            this.template = _.template($('#reviewsTemplate').html());
            this.collection = new Comments();
            this.collection.on('reset', this.loadComments, this);
            this.render();
        },
        render: function () {
            var html = this.template(this.model.toJSON());
            this.$el.append(html);
        },
        getComments: function () {
            this.collection.fetch({
                data: {
                    Id: this.model.get('Id')
                }
            });
        },
        loadComments: function () {
            var self = this,
                item;
            this.comments = this.$el.find('ul');
            this.collection.each(function (comment) {
                item = new CommentItem({
                    model: comment
                });
                self.comments.append(item.el);
            });
            
            this.$el.find('a').hide();
        }
    });

    var CommentItem = Backbone.View.extend({
        tagName: 'li',
        initialize: function () {
            this.template = _.template($('#commentsTemplate').html());
            this.render();
        },
        render: function () {
            var html = this.template(this.model.toJSON());
            this.$el.html(html);
        }
        
    });

    $(function () {
        window.reviews = new Reviews();
        window.reviewList = new ListReviews({
            collection: reviews
        });
        
    });
}(jQuery));