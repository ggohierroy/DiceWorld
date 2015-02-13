App.Session = Ember.Object.extend({

    userKey: 'DiceWorldUser',
    tokenKey: 'DiceWorldToken',

    init: function () {
        var token = sessionStorage[this.get('tokenKey')];
        var user = sessionStorage[this.get('userKey')];

        if (token && user) {
            this.set('token', token);
            this.set('user', user);
        }
    },

    token: "",
    user: "",

    tokenOrUserChanged: function() {
        Ember.run.once(this, 'saveSession');
    }.observes('token', 'user'),

    saveSession: function() {
        sessionStorage[this.get('userKey')] = this.get('user');
        sessionStorage[this.get('tokenKey')] = this.get('token');
    }
})