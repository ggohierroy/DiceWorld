App.AutoCompleteComponent = Ember.TextField.extend({
    didInsertElement: function () {
        debugger;
        var engine = new Bloodhound({
            name: 'animals',
            local: [{ val: 'dog' }, { val: 'pig' }, { val: 'moose' }],
            //remote: 'http://example.com/animals?q=%QUERY',
            datumTokenizer: function (d) {
                return Bloodhound.tokenizers.whitespace(d.val);
            },
            queryTokenizer: Bloodhound.tokenizers.whitespace
        });

        var promise = engine.initialize();
        promise
        .done(function () { console.log('Bloodhound initialized successfully!'); })
        .fail(function () { console.log('Error initializing Bloodhound!'); });

        //var myView = this;
        var typeahead = $(this.get('element')).typeahead(null, {
            displayKey: 'val',
            source: engine.ttAdapter()
        });
        //typeahead.on('typeahead:selected', function (event, datum) {
        //    myView.sendAction('displayPlayer', datum.PlayerId);
        //});
        //typeahead.on('typeahead:autocompleted', function (event, datum) {
        //    myView.sendAction('displayPlayer', datum.PlayerId);
        //});
    }
});