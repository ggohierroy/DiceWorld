App.BoardGame = DS.Model.extend({
    bggId: DS.attr('number'),
    name: DS.attr('string'),
    description: DS.attr('string'),
    yearPublished: DS.attr('number'),
    minPlayers: DS.attr('number'),
    maxPlayers: DS.attr('number'),
    playingTime: DS.attr('number'),
    minAge: DS.attr('number'),
    tags: DS.hasMany('tag'),
    boardGameStats: DS.belongsTo('boardGameStat'),
    imageId: DS.attr('number'),
    price: DS.attr('number'),
    imageUrl: function() {
        return '/Content/Images/Processed/pic' + this.get('imageId') + '.jpg';
    }.property('imageId')
});