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

        engine.initialize();
        
        var typeahead = $(this.get('element')).typeahead(null, {
            displayKey: 'name',
            source: engine.ttAdapter()
        });

        var that = this;
        typeahead.on('typeahead:selected', function (event, datum) {
            that.sendAction('selected', datum);
        });
        typeahead.on('typeahead:autocompleted', function (event, datum) {
            that.sendAction('autocompleted', datum);
        });
    }
});