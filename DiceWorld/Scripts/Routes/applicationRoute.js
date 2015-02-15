App.ApplicationRoute = Ember.Route.extend({

    beforeModel: function () {
        return this.session.create(this.store);
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