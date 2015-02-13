App.Cart = DS.Model.extend({
    cartItems: DS.hasMany('cartItem', { async: true }),
    userId: DS.attr('number')
});