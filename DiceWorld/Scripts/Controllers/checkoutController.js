App.CheckoutController = Ember.Controller.extend({

    actions: {
        submit: function () {
            var $form = $("#payment-form");

            // Disable the submit button to prevent repeated clicks
            // TODO

            Stripe.card.createToken($form, this.stripeResponseHandler);
        }
    },

    stripeResponseHandler: function(status, response) {
        if (response.error) {
            // Show the errors on the form
            // TODO
        } else {
            // response contains id and card, which contains additional card details
            var token = response.id;

            // Create charge
            // TODO

            // Post charge
            // TODO
        }
    }
});