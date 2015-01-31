App.HomeRoute = Ember.Route.extend({
    setupController: function () {
        this.controllerFor('application').updateActiveLink('home');
    }
});