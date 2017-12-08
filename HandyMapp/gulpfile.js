/// <binding ProjectOpened='less' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require("gulp");

less = require("gulp-less");

gulp.task("less", function () {
    return gulp.src('wwwroot/Styles/main.less')
        .pipe(less())
        .pipe(gulp.dest('wwwroot/css'));
});



