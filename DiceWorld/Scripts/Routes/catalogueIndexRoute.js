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
        includeTags: { refreshModel: true }
    },
    model: function (params) {
        return this.store.find('boardGame', params);
    },
    setupController: function(controller, model) {
        controller.set('inputPage', controller.get('page'));
        controller.set('inputKeyword', controller.get('keyword'));
        controller.set('inputPublishedFrom', controller.get('publishedFrom'));
        controller.set('inputPublishedTo', controller.get('publishedTo'));
        controller.set('inputExactRange', controller.get('exactRange'));
        controller.set('inputPlayerCountMin', controller.get('minPlayers'));
        controller.set('inputPlayerCountMax', controller.get('maxPlayers'));
        controller.set('model', model);
        controller.set('tagDefinitions', this.store.find('tagDefinition'));
    }
});