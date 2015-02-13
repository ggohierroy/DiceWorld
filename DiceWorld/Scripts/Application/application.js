Ember.Application.initializer({
    name: 'session',

    initialize: function (container, application) {
        application.register('session:main', App.Session);
        application.inject('controller', 'session', 'session:main');
        application.inject('adapter', 'session', 'session:main');
    }
});

App = Ember.Application.create({
    LOG_TRANSITIONS: true
});

App.ApplicationAdapter = DS.RESTAdapter.extend({
    namespace: 'api',
    headers: function () {
        return {
            "Authorization": "Bearer " + this.get("session.token")
        };
    }.property("session.token")
});