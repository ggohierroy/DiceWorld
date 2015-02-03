App.HomeHotnessRoute = Ember.Route.extend({
    beforeModel: function () {
        // Update the active page
        this.controllerFor('home').updateActiveLink('home.hotness');
    },
    model: function () {
        return this.store.find('boardGame', { sortBy: "hotness" });
    },
    renderTemplate: function() {
        this.render('boardGameList');
    }
});