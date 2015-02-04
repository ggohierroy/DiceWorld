App.RegisterIndexController = Ember.Controller.extend({

    isRegistering: false,

    email: "",
    password: "",
    confirmPassword: "",

    errors: [],

    handleSuccess: function(response) {
        this.transitionToRoute('register.confirm');
    },

    handleError: function (response) {
        var errors = this.get('errors');
        errors.clear();
        var modelState = response.responseJSON.modelState;
        for (var key in modelState) {
            for (var i = 0; i < modelState[key].length; i++) {
                errors.pushObject(modelState[key][i]);
            }
        }
    },

    actions: {
        register: function () {
            var self = this;
            var registerData = { email: this.get("email"), password: this.get("password"), confirmPassword: this.get("confirmPassword") }
            this.set('isRegistering', true);
            Ember.$.ajax({
                type: "POST",
                url: "/api/Account/Register",
                dataType: 'json',
                contentType: "application/json",
                data: JSON.stringify(registerData),
                error: $.proxy(this.handleError, this),
            }).done(function(data) {
                self.handleSuccess(data);
            }).fail(function(data) {
                self.handleError(data);
            }).always(function() {
                self.set('isRegistering', false);
            });
        }
    }
});