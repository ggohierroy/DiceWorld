App.BoardGameStat = DS.Model.extend({
    numberOfUsers: DS.attr("number"),
    averageRating: DS.attr("number"),
    bayesianRating: DS.attr("number"),
    averageWeight: DS.attr("number"),
    rank: DS.attr("number")
});