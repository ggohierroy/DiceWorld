App.HomeController = Ember.Controller.extend({
    pages: [
        App.Page.create({ name: 'New', isActive: false, route: 'home.new' }),
        App.Page.create({ name: 'Hotness', isActive: false, route: 'home.hotness' }),
        App.Page.create({ name: 'Upcoming', isActive: false, route: 'home.upcoming' })
    ],

    updateActiveLink: function (routeName) {
        this.get('pages').forEach(function (item) { item.set('isActive', false); });
        this.get('pages').findBy('route', routeName).set('isActive', true);
    },

    actions: {
        navigate: function (page) {
            this.get('pages').forEach(function (item) { item.set('isActive', false); });
            page.set('isActive', true);
            this.transitionToRoute(page.get('route'));
        },
        addToCart: function(boardGame) {
            alert(boardGame.get('name'));
        }
    }
});