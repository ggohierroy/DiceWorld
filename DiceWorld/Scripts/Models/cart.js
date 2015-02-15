App.Cart = DS.Model.extend({
    cartItems: DS.hasMany('cartItem', { async: true }),
    user: DS.belongsTo('user'),

    total: function () {
        return this.get('cartItems').reduce(function(previousValue, item) {
            return (previousValue || 0) + item.get('quantity') * item.get('boardGame.price');
        });
    }.property('cartItems.@each.quantity')
});