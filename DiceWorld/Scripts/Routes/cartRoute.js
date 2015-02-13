App.CartRoute = Ember.Route.extend({
    model: function () {
        return this.store.find('cart');
    },

    setupController: function (controller, model) {
        controller.set('model', model.get('firstObject'));
    }
});