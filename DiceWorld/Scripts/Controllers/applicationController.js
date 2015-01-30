App.ApplicationController = Ember.Controller.extend({
    pages: [
        { name: 'Home', isActive: true, route: 'home' },
        { name: 'Catalogue', isActive: false, route: 'catalogue' }],
})