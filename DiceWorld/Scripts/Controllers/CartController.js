﻿App.CartController = Ember.Controller.extend({
    addToCart: function (boardGame) {
        var cart = this.session.get('user.cart');

        var cartItem = cart.get('cartItems').findBy('boardGame.id', boardGame.id);

        if (cartItem) {
            cartItem.incrementProperty('quantity');
        } else {

            cartItem = this.store.createRecord('cartItem', {
                cart: cart,
                boardGame: boardGame,
                quantity: 1
            });
            
            cart.get('cartItems').pushObject(cartItem);
        }

        if (!this.session.get('user.anonymous')) {
            cartItem.save();
        }

        this.transitionToRoute('cart');
    },

    signOut: function() {
        this.set('model', null);
    },

    actions: {
        quantityClicked: function() {
            
        },
        remove: function(cartItem) {
            this.get('model.cartItems').removeObject(cartItem);
        }
    }
})