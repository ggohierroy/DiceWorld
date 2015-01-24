App.AutoCompleteComponent = Ember.TextField.extend({
    didInsertElement: function () {
        var engine = new Bloodhound({
            prefetch: "/Content/boardGames.json",
            remote: 'api/boardgamesForAutocomplete?keyword=%QUERY',
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