﻿App.CatalogueController = Ember.ArrayController.extend({

    queryParams: ['page', 'itemsPerPage'],
    page: 1,
    itemsPerPage: 24,

    inputPage: 1,

    totalPages: function() {
        var totalItems = this.get('model.meta.total');
        return Math.floor(totalItems / this.get('itemsPerPage')) + 1;
    }.property('model.meta.total'),

    actions: {
        updatePage: function() {
            this.set('page', this.get('inputPage'));
        },
        next: function() {
            this.set('page', this.get('page') + 1);
        },
        previous: function() {
            this.set('page', this.get('page') - 1);
        },
        fastForward: function() {
            this.set('page', this.get('totalPages'));
        },
        fastBackward: function() {
            this.set('page', 1);
        }
    }
    
});