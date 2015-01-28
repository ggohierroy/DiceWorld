App.AutoCompleteComponent = Ember.TextField.extend({

    attributeBindings: ['resource-name'],


    didInsertElement: function () {

        var resourceName = this.get('resource-name');

        var engine = new Bloodhound({
            prefetch: "/Content/" + resourceName + ".json",
            remote: "api/" + resourceName + "ForAutocomplete?keyword=%QUERY",
            datumTokenizer: function (d) {
                return Bloodhound.tokenizers.whitespace(d.name);
            },
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            dupDetector: function(remoteMatch, localMatch) {
                return remoteMatch.name === localMatch.name;
            }
        });

        engine.clearPrefetchCache();

        var promise = engine.initialize();
        promise
        .done(function () { console.log('Bloodhound initialized successfully!'); })
        .fail(function () { console.log('Error initializing Bloodhound!'); });

        
        var typeahead = $(this.get('element')).typeahead(null, {
            displayKey: 'name',
            source: engine.ttAdapter()
        });

        //var myView = this;
        //typeahead.on('typeahead:selected', function (event, datum) {
        //    myView.sendAction('displayPlayer', datum.PlayerId);
        //});
        //typeahead.on('typeahead:autocompleted', function (event, datum) {
        //    myView.sendAction('displayPlayer', datum.PlayerId);
        //});
    }
});