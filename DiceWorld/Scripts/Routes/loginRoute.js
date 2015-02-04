App.LoginRoute = Ember.Route.extend({
    beforeModel: function (transition) {
        debugger;
        if (!transition.queryParams)
            return Ember.RSVP.resolve();

        if (transition.queryParams.userId && transition.queryParams.token) {
            var registerData = { userId: transition.queryParams.userId, token: transition.queryParams.token }
            return Ember.$.ajax({
                type: "POST",
                url: "/api/Account/ConfirmEmail",
                dataType: 'json',
                contentType: "application/json",
                data: JSON.stringify(registerData)
            });
        }
        return Ember.RSVP.resolve();
    },

    actions: {
        error: function (reason) {
            debugger;
            alert(reason); // "FAIL"

            // Can transition to another route here, e.g.
            // this.transitionTo('index');

            // Uncomment the line below to bubble this error event:
            // return true;
        }
    }
});