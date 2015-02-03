App.CartRoute = Ember.Route.extend({
    model: function () {
        debugger;
        // check if user is logged in otherwise create new cart if doesn't exist
        var cart = this.store.createRecord('cart');
        return cart;
    }
});