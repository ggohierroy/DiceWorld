App.LoginController = Ember.Controller.extend({
    queryParams: ['userId', 'token'],

    userId: "",
    token: "",

    loginEmail: "",
    loginPassword: "",

    user: "",

    tokenKey: 'accessToken',
    result: "",

    showError: function(response) {
        this.set('result', response.status + ': ' + response.statusText);
    },

    login: function () {
        
        this.set('result', "");

        var loginData = {
            grant_type: 'password',
            username: this.get('loginEmail'),
            password: this.get('loginPassword')
        };

        var self = this;
        $.ajax({
            type: 'POST',
            url: '/Token',
            data: loginData
        }).done(function (data) {
            self.set('user', data.userName);
            // Cache the access token in session storage.
            sessionStorage.setItem(tokenKey, data.access_token);
        }).fail(function(data) {
            self.showError(data);
        });
    }
});