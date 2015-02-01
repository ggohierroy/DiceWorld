App.ApplicationRoute = Ember.Route.extend({
    model: function () {
        return Ember.RSVP.hash({
            tagDefinitions: this.store.find('tagDefinition')
        });
    },
});