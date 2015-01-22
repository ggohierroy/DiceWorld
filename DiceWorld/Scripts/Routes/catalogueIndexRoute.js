App.CatalogueRoute = Ember.Route.extend({
    queryParams: {
        page: { refreshModel: true },
        itemsPerPage: { refreshModel: true }
    },
    model: function(params) {
        // This gets called upon entering 'articles' route
        // for the first time, and we opt into refiring it upon
        // query param changes by setting `refreshModel:true` above.

        // params has format of { category: "someValueOrJustNull" },
        // which we can just forward to the server.
        return this.store.find('boardGame', params);
    },
    setupController: function(controller, model) {
        controller.set('inputPage', controller.get('page'));
        controller.set('model', model);
    }
});