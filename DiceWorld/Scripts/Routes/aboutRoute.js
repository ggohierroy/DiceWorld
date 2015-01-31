App.AboutRoute = Ember.Route.extend({
    beforeModel: function() {
        this.controllerFor('application').updateActiveLink('about');
    }
});