App.TagDefinition = DS.Model.extend({
    name: DS.attr('string'),
    description: DS.attr('string'),
    occurences: DS.attr('number'),
    tagTypeId: DS.attr('number'),
    isImportant: DS.attr('boolean')
});