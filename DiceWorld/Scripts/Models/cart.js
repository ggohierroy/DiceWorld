App.Cart = DS.Model.extend({
    boardGames: DS.hasMany('boardGame', { async: true }),
});