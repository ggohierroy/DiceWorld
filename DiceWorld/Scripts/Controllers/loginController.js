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

            var self = this;
            Ember.$.ajax({
                type: 'POST',
                url: '/Token',
                data: loginData
            }).done(function (data) {

                self.session.setProperties({
                    token: data.access_token,
                    user: data.userName,
                    userId: data.userId
                });

                self.transitionToRoute('account');
            }).fail(function(data) {
                self.showError(data);
            });
        }
    }
});