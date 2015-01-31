App.CatalogueRoute = Ember.Route.extend({
    queryParams: {
        page: { refreshModel: true },
        itemsPerPage: { refreshModel: true },
        keyword: { refreshModel: true },
        publishedFrom: { refreshModel: true },
        publishedTo: { refreshModel: true },
        exactRange: { refreshModel: true },
        minPlayers: { refreshModel: true },
        maxPlayers: { refreshModel: true },
        includeTags: { refreshModel: true },
        minPrice: { refreshModel: true },
        maxPrice: { refreshModel: true },
        minPlayingTime: { refreshModel: true },
        maxPlayingTime: { refreshModel: true },
        minWeight: { refreshModel: true },
        maxWeight: { refreshModel: true },
        minRating: { refreshModel: true },
        maxRating: { refreshModel: true }
    },
    beforeModel: function() {
        // Update the active page
        this.controllerFor('application').updateActiveLink('catalogue');
    },
    model: function (params) {
        return Ember.RSVP.hash({
            boardGames: this.store.find('boardGame', params),
            tagDefinitions: this.store.find('tagDefinition')
        });
    },
    setupController: function (controller, model) {
        // Set the inputs
        controller.set('inputPage', controller.get('page'));
        controller.set('inputKeyword', controller.get('keyword'));
        controller.set('inputPublishedFrom', controller.get('publishedFrom'));
        controller.set('inputPublishedTo', controller.get('publishedTo'));
        controller.set('inputExactRange', controller.get('exactRange'));
        controller.set('inputPlayerCountMin', controller.get('minPlayers'));
        controller.set('inputPlayerCountMax', controller.get('maxPlayers'));
        controller.set('inputPlayingTimeMin', controller.get('minPlayingTime'));
        controller.set('inputPlayingTimeMax', controller.get('maxPlayingTime'));
        controller.set('inputWeightMin', controller.get('minWeight'));
        controller.set('inputWeightMax', controller.get('maxWeight'));
        controller.set('inputRatingMin', controller.get('minRating'));
        controller.set('inputRatingMax', controller.get('maxRating'));
        controller.set('inputPriceMin', controller.get('minPrice'));
        controller.set('inputPriceMax', controller.get('maxPrice'));

        // Set tag definitions and display already selected tags
        controller.set('tagDefinitions', model.tagDefinitions);
        controller.setInputTags();

        // Set the model
        controller.set('model', model.boardGames);
    }
});