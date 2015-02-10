App.CartRoute = Ember.Route.extend({
    model: function () {
        return this.store.find('cart', 1);
        // check if user is logged in otherwise create new cart if doesn't exist
        var cart = this.store.createRecord('cart');
        return cart;
    }
});