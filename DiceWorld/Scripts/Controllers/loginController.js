App.LoginController = Ember.Controller.extend({

    //needs: ['application'],

    queryParams: ['userId', 'token'],

    confirmationSuccessful: function() {
        return this.get('registrationStatus') === "success";
    }.property('registrationStatus'),

    confirmationFail: function() {
        return this.get('registrationStatus') === "fail";
    }.property('registrationStatus'),

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

    actions: {
        login: function() {

            this.set('result', "");

            var loginData = {
                grant_type: 'password',
                username: this.get('loginEmail'),
                password: this.get('loginPassword')
            };

            var tokenKey = this.get('tokenKey');

            var self = this;
            Ember.$.ajax({
                type: 'POST',
                url: '/Token',
                data: loginData
            }).done(function (data) {
                self.set('user', data.userName);
                // Cache the access token in session storage.
                sessionStorage.setItem(tokenKey, data.access_token);
                //this.get('controllers.application').set('user', data.userName);
                self.transitionToRoute('account');
            }).fail(function(data) {
                self.showError(data);
            });
        }
    }
});