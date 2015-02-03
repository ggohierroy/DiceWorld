App.HomeUpcomingRoute = Ember.Route.extend({
    beforeModel: function () {
        // Update the active page
        this.controllerFor('home').updateActiveLink('home.upcoming');
    },
    model: function () {
        var tagDefinitions = this.store.all('tagDefinition');
        var newTag = tagDefinitions.findBy('name', 'Upcoming');
        return this.store.find('boardGame', { includeTags: [newTag.id] });
    },
    renderTemplate: function () {
        this.render('boardGameList');
    }
});