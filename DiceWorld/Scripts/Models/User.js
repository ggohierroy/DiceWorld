App.User = DS.Model.extend({
    cart: DS.belongsTo('cart', { async: true }),
    name: DS.attr('string')
});