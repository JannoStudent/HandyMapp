/// <binding ProjectOpened='watch:tasks' />
/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.initConfig({
        concat:
        {
            all:
            {
                src: ['wwwroot/js/**/*.js', 'wwwroot/lib/**/ *.js'],
                dest: 'wwwroot/CompressedJs/ConcatenatedJsfiles/combined.js'
            }
        },
        uglify:
        {
            js:
            {
                src: ['wwwroot/lib/jquery-ui/*.js', 'wwwroot/js/**/*.js'],
                dest: 'wwwroot/CompressedJs/MinifiedJavascriptfiles/Calculation.js'
            }
        },
        tinyimg:
        {
            minifyimage:
            {
                src: ['wwwroot/img/**/*.{png,jpg,gif,svg}'],
                dest: 'wwwroot/Compressimages/',
                expand: true,
                flatten: true
            }
        },
        watch: {
            files: ["TypeScript/*.js"],
            tasks: ["all"]
        }
    });
    
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks("grunt-tinyimg");
    grunt.loadNpmTasks('grunt-contrib-watch');

    grunt.registerTask('Default', ['concat', 'uglify','tinyimg']);
};