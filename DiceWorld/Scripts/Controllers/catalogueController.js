App.CatalogueController = Ember.ArrayController.extend({

    queryParams: ['page', 'itemsPerPage', 'keyword', 'publishedFrom', 'publishedTo', 'exactRange', 'minPlayers', 'maxPlayers'],
    page: 1,
    itemsPerPage: 24,
    keyword: "",
    publishedFrom: "",
    publishedTo: "",
    exactRange: false,
    minPlayers: "",
    maxPlayers: "",

    inputPage: 1,
    inputKeyword: "",
    inputPublishedFrom: "",
    inputPublishedTo: "",
    inputExactRange: false,
    inputPlayerCountMin: "",
    inputPlayerCountMax: "",
    inputTags: [],

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
        },
        addTag: function (datum) {
            this.get('inputTags').pushObject(datum);
        },
        search: function () {
            this.setProperties({
                keyword: this.get('inputKeyword'),
                publishedFrom: this.get('inputPublishedFrom'),
                publishedTo: this.get('inputPublishedTo'),
                exactRange: this.get('inputExactRange'),
                minPlayers: this.get('inputPlayerCountMin'),
                maxPlayers: this.get('inputPlayerCountMax')
            });
        },
    }
    
});