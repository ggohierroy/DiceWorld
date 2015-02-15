App.Cart = DS.Model.extend({

    itemsKey: 'DiceWorldCartItems',

    cartItems: DS.hasMany('cartItem', { async: true }),
    user: DS.belongsTo('user'),

    total: function () {
        return this.get('cartItems').reduce(function(previousValue, item) {
            return (previousValue || 0) + item.get('quantity') * item.get('boardGame.price');
        });
    }.property('cartItems.@each.quantity'),

    cartItemAdded: function () {
        var items = this.get('cartItems').map(function(item) {
            return { quantity: item.get('quantity'), boardGame: item.get('boardGame.id') };
        });
        sessionStorage[this.get('itemsKey')] = JSON.stringify(items);
    }.observes('cartItems.@each.quantity')
});