App.HomeNewController = Ember.ArrayController.extend({

    actions: {
        addToCart: function(boardGame) {
            this.transitionToRoute('cart.add', boardGame);
        }
    }
});