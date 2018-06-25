﻿/// <binding BeforeBuild='less' />
var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less");

gulp.task("less", function () {
    return gulp.src('Styles/main.less')
        .pipe(less())
        .pipe(gulp.dest('Content/css'));
});