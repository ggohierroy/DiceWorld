/// <vs />
module.exports = function (grunt) {
    // Do grunt-related things in here
    // Project configuration.
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
    });

    grunt.registerTask('ember-template-compiler', 'Compiles ember templates', function () {
        var glob = require('glob');
        var fs = require('fs');
        var compiler = require('./bower_components/ember/ember-template-compiler');

        var formatName = function (sourcefile) {
            var newSource = sourcefile.replace('Scripts/Templates/', '');
            newSource = newSource.replace('_', '/');
            return newSource.replace('.hbs', '');
        }
        var pattern = 'Scripts/Templates/*.hbs';

        var output = "";
        glob.sync(pattern).forEach(function (pathMatch) {
            var input = fs.readFileSync(pathMatch, { encoding: 'utf8' });
            var template = compiler.precompile(input, false);
            output += "Ember.TEMPLATES['" + formatName(pathMatch) + "'] = Ember.HTMLBars.template(" + template + ");";
        });

        fs.writeFileSync('./Scripts/Templates/templates.js', output, { encoding: 'utf8' });
    });

    // the default task can be run just by typing "grunt" on the command line
    grunt.registerTask('default', ['ember-template-compiler']);
};