const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const postcssPresetEnv = require("postcss-preset-env");
const CopyPlugin = require("copy-webpack-plugin");

const devMode = process.env.NODE_ENV !== "production";

module.exports = {
  mode: devMode ? "development" : "production",

  entry: {
    site: "./resources/scss/site.scss", // Path to your main SCSS file
    // Additional entries can be added here
  },

  output: {
    filename: "js/app.min.js", // Bundled JavaScript output
    path: path.resolve(__dirname, "wwwroot"), // Output directory
  },

  module: {
    rules: [
      {
        // SCSS to CSS conversion
        test: /\.(sa|sc)ss$/,
        use: [
          MiniCssExtractPlugin.loader,
          {
            loader: "css-loader",
            options: { importLoaders: 2 },
          },
          {
            loader: "postcss-loader",
            options: {
              postcssOptions: {
                plugins: devMode
                  ? () => []
                  : () => [
                      postcssPresetEnv({ browsers: [">1%"] }),
                      require("cssnano")(),
                    ],
              },
            },
          },
          "sass-loader",
        ],
      },
      {
        // Image handling for CSS
        test: /\.(png|jpe?g|gif)$/,
        use: [
          {
            loader: "file-loader",
            options: {
              name: "[name].[ext]",
              publicPath: "../images",
              emitFile: false, // Set to true if you want Webpack to emit the file
            },
          },
        ],
      },
    ],
  },

  plugins: [
    new MiniCssExtractPlugin({
      filename: devMode ? "css/[name].css" : "css/[name].min.css",
    }),
    new CopyPlugin({
      patterns: [
        {
          from: "node_modules/jquery/dist/jquery.min.js",
          to: "js/jquery.min.js",
        },
        {
          from: "node_modules/bootstrap/dist/js/bootstrap.min.js",
          to: "js/bootstrap.min.js",
        },
        {
          from: "node_modules/popper.js/dist/popper.min.js",
          to: "js/popper.min.js",
        },
        {
          from: "node_modules/bootstrap/dist/css/bootstrap.min.css",
          to: "css/bootstrap.min.css",
        },
      ],
    }),
  ],
};
