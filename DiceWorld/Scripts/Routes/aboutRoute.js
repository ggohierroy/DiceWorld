App.AboutRoute = Ember.Route.extend({
    setupController: function() {
        this.controllerFor('application').updateActiveLink('about');
    }
});