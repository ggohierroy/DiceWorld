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
            var contents = fs.readFileSync(pathMatch, { encoding: 'utf8' });
            contents = contents.replace(/\r\n/g, '\n');
            var compiled = compiler.precompile(contents, false);
            output += "Ember.TEMPLATES['" + formatName(pathMatch) + "'] = Ember.Handlebars.template(" + compiled + ");";
        });

        fs.writeFileSync('./Scripts/Templates/templates.js', output, { encoding: 'utf8' });
    });

    // the default task can be run just by typing "grunt" on the command line
    grunt.registerTask('default', ['ember-template-compiler']);
};