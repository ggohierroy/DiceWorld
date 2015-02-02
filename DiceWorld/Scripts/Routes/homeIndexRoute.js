App.HomeIndexRoute = Ember.Route.extend({
    redirect: function() {
        this.transitionTo('home.new');
    }
});