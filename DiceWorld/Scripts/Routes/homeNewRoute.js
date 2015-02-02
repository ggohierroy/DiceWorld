App.HomeNewRoute = Ember.Route.extend({
    beforeModel: function() {
        // Update the active page
        this.controllerFor('home').updateActiveLink('home.new');
    },
    model: function () {
        var tagDefinitions = this.store.all('tagDefinition');
        var newTag = tagDefinitions.findBy('name', 'New');
        return this.store.find('boardGame', {includeTags: [newTag.id]});
    }
});