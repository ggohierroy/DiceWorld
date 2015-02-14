App.ApplicationRoute = Ember.Route.extend({

    beforeModel: function() {
        var userId = this.session.get('userId');

        // If we have a userId saved up, we can try to load it from the server
        // to get the cart and orders data
        if (userId) {
            var self = this;
            return this.store.find('user', userId).then(function(user) {
                // success
                self.session.set('user', user);
            }, function() {
                // fail (most probably because token expired)
                self.session.createAnonymousUser(self.store);
            });
        }

        this.session.createAnonymousUser(this.store);
    },

    model: function () {
        return Ember.RSVP.hash({
            tagDefinitions: this.store.find('tagDefinition')
        });
    },

    actions: {
        addToCart: function (boardGame) {
            this.controllerFor('cart').addToCart(boardGame);
        }
    }
});