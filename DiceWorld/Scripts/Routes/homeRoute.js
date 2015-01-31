App.HomeRoute = Ember.Route.extend({
    beforeModel: function () {
        this.controllerFor('application').updateActiveLink('home');
    }
});