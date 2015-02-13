App.CartItem = DS.Model.extend({
    cart: DS.belongsTo('cart'),
    boardGame: DS.belongsTo('boardGame'),
    quantity: DS.attr('number')
});