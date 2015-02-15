App.Session = Ember.Object.extend({

    sessionKey: 'DiceWorldSession',
    itemsKey: 'DiceWorldCartItems',

    init: function () {

        // Fetch session
        var session = sessionStorage[this.get('sessionKey')];
        if (session) {
            session = JSON.parse(session);
            this.set('token', session.token);
            this.set('userId', session.userId);
        }
        
        // Fetch cart items
        var cartItems = sessionStorage[this.get('itemsKey')];
        if (cartItems) {
            cartItems = JSON.parse(cartItems);
            this.set('cartItems', cartItems);
        }
    },
    
    create: function(store) {

        var resolve = Ember.RSVP.resolve();

        // If we have a userId saved up, we can try to load it from the server
        // to get the cart and orders data
        var userId = this.get('userId');
        if (userId) {
            var self = this;
            return this.store.find('user', userId).then(function (user) {
                // success
                self.set('user', user);
                return resolve;
            }, function() {
                // fail (most probably because token expired)
                self.createAnonymousUser(store);
                return resolve;
            });
        }

        this.createAnonymousUser(store);
        return resolve;
    },

    cartItems: null,
    token: null,
    userId: null,
    user: null,

    signOut: function() {
        this.setProperties({ token: null, userId: null, user: null, cartItems: null });

        sessionStorage.removeItem(this.get('sessionKey'));
        sessionStorage.removeItem(this.get('itemsKey'));
    },

    createAnonymousUser: function (store) {
        // Create the cart
        var cart = store.createRecord('cart');
        // Create the cart items
        var cartItems = this.get('cartItems');
        if (cartItems) {
            cartItems.forEach(function (item) {
                store.find('boardGame', item.boardGame).then(function (boardGame) {
                    var cartItem = store.createRecord('cartItem', {
                        cart: cart,
                        quantity: item.quantity,
                        boardGame: boardGame
                    });
                    cart.get('cartItems').pushObject(cartItem);
                });
            });
        }
        // Create the user
        this.set('user', store.createRecord('user', {
            anonymous: true,
            name: 'anonymous',
            cart: cart
        }));
    },

    tokenOrUserChanged: function () {
        this.saveSession();
    }.observes('token'),

    userChanged: function () {
        var user = this.get('user');
        if(user)
            this.set('userId', user.id);
        this.saveSession();
    }.observes('user'),

    saveSession: function () {

        var userId = this.get('user.id');
        var token = this.get('token');

        if (token && userId) {
            var key = this.get('sessionKey');
            sessionStorage[key] = JSON.stringify({ token: token, userId: userId });
        }
    }
})