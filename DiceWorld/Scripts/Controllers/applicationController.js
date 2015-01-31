App.ApplicationController = Ember.Controller.extend({
    pages: [
        App.Page.create({ name: 'Home', isActive: false, route: 'home', navLink: '#/home' }),
        App.Page.create({ name: 'Catalogue', isActive: false, route: 'catalogue', navLink: '#/catalogue' }),
        App.Page.create({ name: 'About', isActive: false, route: 'about', navLink: '#/about' }),
    ],

    updateActiveLink: function(routeName) {
        this.get('pages').forEach(function (item) { item.set('isActive', false); });
        this.get('pages').findBy('route', routeName).set('isActive', true);
    },
})