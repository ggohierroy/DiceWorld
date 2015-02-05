﻿App.ApplicationController = Ember.Controller.extend({

    needs: ["login"],

    user: Ember.computed.alias("controllers.login.user"),

    inputKeyword: "",

    pages: [
        App.Page.create({ name: 'Home', isActive: false, route: 'home' }),
        App.Page.create({ name: 'Catalogue', isActive: false, route: 'catalogue' }),
        App.Page.create({ name: 'About', isActive: false, route: 'about' })
    ],

    updateActiveLink: function(routeName) {
        this.get('pages').forEach(function (item) { item.set('isActive', false); });
        this.get('pages').findBy('route', routeName).set('isActive', true);
    },

    actions: {
        navigate: function(page) {
            this.get('pages').forEach(function (item) { item.set('isActive', false); });
            page.set('isActive', true);
            this.transitionToRoute(page.get('route'));
        },
        autoCompleted: function (datum) {
            this.transitionToRoute('boardGame', datum.id);
        },
        search: function () {
            this.transitionToRoute('catalogue', { queryParams: { keyword: this.get('inputKeyword') } });
        }
    }
})