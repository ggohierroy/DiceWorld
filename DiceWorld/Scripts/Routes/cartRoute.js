App.CartRoute = Ember.Route.extend({
    model: function () {
        return this.session.get('user.cart');
    }
});