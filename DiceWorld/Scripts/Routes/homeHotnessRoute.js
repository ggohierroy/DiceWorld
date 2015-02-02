App.HomeHotnessRoute = Ember.Route.extend({
    beforeModel: function () {
        // Update the active page
        this.controllerFor('home').updateActiveLink('home.hotness');
    },
});