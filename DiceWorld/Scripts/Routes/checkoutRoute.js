App.CheckoutRoute = Ember.Route.extend({
    model: function () {
        return this.session.get('user.cart');
    }
});