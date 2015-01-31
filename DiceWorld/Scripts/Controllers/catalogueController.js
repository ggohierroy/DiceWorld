App.CatalogueController = Ember.ArrayController.extend({
    queryParams: [
        'page',
        'itemsPerPage',
        'keyword',
        'publishedFrom',
        'publishedTo',
        'exactRange',
        'minPlayers',
        'maxPlayers',
        'includeTags',
        'minPrice',
        'maxPrice',
        'minPlayingTime',
        'maxPlayingTime',
        'minWeight',
        'maxWeight',
        'minRating',
        'maxRating'
    ],

    itemsPerPage: 24,
    page: 1,
    keyword: "",
    publishedFrom: "",
    publishedTo: "",
    exactRange: false,
    minPlayers: "",
    maxPlayers: "",
    minPrice: "",
    maxPrice: "",
    minPlayingTime: "",
    maxPlayingTime: "",
    minWeight: "",
    maxWeight: "",
    minRating: "",
    maxRating: "",
    includeTags: [], // array of ids

    // Contains all the tag defnitions loaded from the server
    // This is a DS.PromiseArray that fulfills to a DS.RecordArray
    tagDefinitions: null,

    // Inputs for the search form
    inputPage: 1,
    inputKeyword: "",
    inputPublishedFrom: "",
    inputPublishedTo: "",
    inputExactRange: false,
    inputPlayerCountMin: "",
    inputPlayerCountMax: "",
    inputPlayingTimeMin: "",
    inputPlayingTimeMax: "",
    inputWeightMin: "",
    inputWeightMax: "",
    inputRatingMin: "",
    inputRatingMax: "",
    inputPriceMin: "",
    inputPriceMax: "",
    inputTags: [], // array of tag definition object

    totalPages: function() {
        var totalItems = this.get('model.meta.total');
        return Math.floor(totalItems / this.get('itemsPerPage')) + 1;
    }.property('model.meta.total'),

    // Observing when the tag definitions get loaded from the server
    setInputTags: function () {
        var includeTags = this.get('includeTags');
        var tagDefinitions = this.get('tagDefinitions').filter(function(item) {
            return includeTags.contains(item.id);
        });

        tagDefinitions.forEach(function (item) { this.addTag(item); }, this);
    },

    addTag: function(tagDefinition) {
        if (!this.get('inputTags').contains(tagDefinition))
            this.get('inputTags').pushObject(tagDefinition);
    },

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
        tagSelected: function (tagDefinition) {
            this.addTag(tagDefinition);
        },
        search: function () {
            this.setProperties({
                keyword: this.get('inputKeyword'),
                publishedFrom: this.get('inputPublishedFrom'),
                publishedTo: this.get('inputPublishedTo'),
                exactRange: this.get('inputExactRange'),
                minPlayers: this.get('inputPlayerCountMin'),
                maxPlayers: this.get('inputPlayerCountMax'),
                minPrice: this.get('inputPriceMin'),
                maxPrice: this.get('inputPriceMax'),
                minPlayingTime: this.get('inputPlayingTimeMin'),
                maxPlayingTime: this.get('inputPlayingTimeMax'),
                minWeight: this.get('inputWeightMin'),
                maxWeight: this.get('inputWeightMax'),
                minRating: this.get('inputRatingMin'),
                maxRating: this.get('inputRatingMax'),
                includeTags: this.get('inputTags').mapBy('id')
            });
        },
        clear: function() {
            this.setProperties({
                inputKeyword: "",
                inputPublishedFrom: "",
                inputPublishedTo: "",
                inputExactRange: false,
                inputPlayerCountMin: "",
                inputPlayerCountMax: "",
                inputPlayingTimeMin: "",
                inputPlayingTimeMax: "",
                inputWeightMin: "",
                inputWeightMax: "",
                inputRatingMin: "",
                inputRatingMax: "",
                inputPriceMin: "",
                inputPriceMax: "",
                inputTags: []
            });
        },
        removeTag: function(tagDefinition) {
            this.get('inputTags').removeObject(tagDefinition);
        }
    }
    
});