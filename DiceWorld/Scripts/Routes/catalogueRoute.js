App.CatalogueRoute = Ember.Route.extend({
    beforeModel: function() {
        // Update the active page
        this.controllerFor('application').updateActiveLink('catalogue');
    }
});