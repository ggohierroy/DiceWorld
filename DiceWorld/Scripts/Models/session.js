App.Session = Ember.Object.extend({

    key: 'DiceWorldSession',

    init: function () {

        this.get('token');
        
        var session = sessionStorage[this.get('key')];

        if (session) {
            session = JSON.parse(session);
            this.set('token', session.token);
            this.set('userId', session.userId);
            this.set('username', session.username);
        }
    },

    token: null,
    username: null,
    userId: null,
    user: null,

    signOut: function() {
        this.set('token', null);
        this.set('userId', null);
        this.set('user', null);
        this.set('username', null);
    },

    tokenOrUserChanged: function () {
        debugger;
        Ember.run.once(this, 'saveSession');
    }.observes('token'),

    userChanged: function () {
        debugger;
        var user = this.get('user');
        this.setProperties({ userId: user.id, username: user.get('name') });
        this.saveSession();
    }.observes('user'),

    saveSession: function () {
        var userId = this.get('user.id');
        var token = this.get('token');
        var username = this.get('user.name');

        var key = this.get('key');

        if (token) {
            sessionStorage[key] = JSON.stringify({ token: token, username: username, userId: userId });
        } else {
            sessionStorage.removeItem(key);
        }
    }
})