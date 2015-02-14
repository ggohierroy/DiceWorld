App.Cart = DS.Model.extend({
    cartItems: DS.hasMany('cartItem', { async: true }),
    user: DS.belongsTo('user')
});