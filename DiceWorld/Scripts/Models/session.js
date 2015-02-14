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

    token: null,
    user: null,
    userId: null,

    tokenOrUserChanged: function() {
        Ember.run.once(this, 'saveSession');
    }.observes('token', 'user'),

    saveSession: function () {
        var user = this.get('user');
        var token = this.get('token');

        var userKey = this.get('userKey');
        var tokenKey = this.get('tokenKey');

        if (user && token) {
            sessionStorage[userKey] = user;
            sessionStorage[tokenKey] = token;
        } else {
            sessionStorage.removeItem(tokenKey);
            sessionStorage.removeItem(userKey);
        }
    }
})