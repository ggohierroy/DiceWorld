module.exports = function (grunt) {
    // Do grunt-related things in here
    // Project configuration.
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        emberhandlebars: {
            compile: {
                options: {
                    templateName: function (sourceFile) {
                        var newSource = sourceFile.replace('Scripts/Templates/', '');
                        newSource = newSource.replace('_', '/');
                        return newSource.replace('.hbs', '');
                    }
                },
                files: [
                  'Scripts/Templates/*.hbs'
                ],
                dest: 'Scripts/Templates/templates.js'
            }
        }
    });

    grunt.loadNpmTasks('grunt-ember-template-compiler');
};