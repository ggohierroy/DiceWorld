App.RegisterController = Ember.Controller.extend({
    email: "",
    password: "",
    confirmPassword: "",

    errors: [],

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
            var registerData = { email: this.get("email"), password: this.get("password"), confirmPassword: this.get("confirmPassword") }
            Ember.$.ajax({
                type: "POST",
                url: "/api/Account/Register",
                dataType: 'json',
                contentType: "application/json",
                data: JSON.stringify(registerData),
                error: $.proxy(this.handleError, this)
            });
        }
    }
});