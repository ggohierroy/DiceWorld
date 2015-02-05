App.LoginRoute = Ember.Route.extend({
    model: function(params) {
        if (!params)
            return null;

        if (params.userId && params.token) {
            var registerData = { userId: params.userId, token: params.token }

            // The ajax function needs to be wrapped in an ember promise through RSVP.resolve
            // so that the transition completes even when the call fails
            return Ember.RSVP.resolve(Ember.$.ajax({
                type: "POST",
                url: "/api/Account/ConfirmEmail",
                dataType: 'json',
                contentType: "application/json",
                data: JSON.stringify(registerData)
            })).then(function () {
                return { registrationStatus: "success" };
            }, function () {
                return { registrationStatus: "fail" };
            });
        }

        return null;
    },

    setupController: function(controller, model) {
        if (model) {
            // If there is a userId and a token and the transition hasn't failed so far
            // then the registration confirmation was successful
            controller.set('userId', '');
            controller.set('token', '');
            controller.set('registrationStatus', model.registrationStatus);
        }
    },

    actions: {
        error: function (reason) {
            alert(reason); // "FAIL"

            // Can transition to another route here, e.g.
            // this.transitionTo('index');

            // Uncomment the line below to bubble this error event:
            // return true;
        }
    }
});