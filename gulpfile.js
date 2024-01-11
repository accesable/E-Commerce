var gulp = require("gulp");
var uglify = require("gulp-uglify");

// Task for Bootstrap CSS
gulp.task("copy-bootstrap-css", function () {
  return gulp
    .src("node_modules/bootstrap/dist/css/bootstrap.min.css")
    .pipe(gulp.dest("wwwroot/css/"));
});

// Task for Bootstrap JS
gulp.task("copy-bootstrap-js", function () {
  return gulp
    .src("node_modules/bootstrap/dist/js/bootstrap.min.js")
    .pipe(gulp.dest("wwwroot/js/"));
});

// Task for jQuery
gulp.task("copy-jquery", function () {
  return gulp
    .src("node_modules/jquery/dist/jquery.min.js")
    .pipe(gulp.dest("wwwroot/js/"));
});

// Task for Popper.js
gulp.task("copy-popper", function () {
  var popperStream = gulp.src("node_modules/popper.js/dist/popper.min.js");

  // Check if minification is enabled
  if (false) {
    // Set to true if you want to enable minification
    popperStream = popperStream.pipe(uglify());
  }

  return popperStream.pipe(gulp.dest("wwwroot/js/"));
});

// Default task to run all tasks
gulp.task(
  "default",
  gulp.parallel(
    "copy-bootstrap-css",
    "copy-bootstrap-js",
    "copy-jquery",
    "copy-popper"
  )
);
