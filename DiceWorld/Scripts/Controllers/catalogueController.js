App.CatalogueController = Ember.ArrayController.extend({
    queryParams: ['page', 'itemsPerPage', 'keyword', 'publishedFrom', 'publishedTo', 'exactRange', 'minPlayers', 'maxPlayers', 'includeTags'],
    page: 1,
    itemsPerPage: 24,
    keyword: "",
    publishedFrom: "",
    publishedTo: "",
    exactRange: false,
    minPlayers: "",
    maxPlayers: "",
    includeTags: [],

    inputPage: 1,
    inputKeyword: "",
    inputPublishedFrom: "",
    inputPublishedTo: "",
    inputExactRange: false,
    inputPlayerCountMin: "",
    inputPlayerCountMax: "",
    tagDefinitions: null,
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
        addTag: function (tagDefinition) {
            if(!this.get('inputTags').contains(tagDefinition))
                this.get('inputTags').pushObject(tagDefinition);
        },
        search: function () {
            var ids = this.get('inputTags').map(function(item) {
                return parseInt(item.id);
            });
            var includeTags = this.get('includeTags');
            debugger;


            this.setProperties({
                keyword: this.get('inputKeyword'),
                publishedFrom: this.get('inputPublishedFrom'),
                publishedTo: this.get('inputPublishedTo'),
                exactRange: this.get('inputExactRange'),
                minPlayers: this.get('inputPlayerCountMin'),
                maxPlayers: this.get('inputPlayerCountMax'),
                includeTags: this.get('inputTags').mapBy('id')
            });

            includeTags = this.get('includeTags');
            debugger;
        },
        removeTag: function(tagDefinition) {
            this.get('inputTags').removeObject(tagDefinition);
        }
    }
    
});