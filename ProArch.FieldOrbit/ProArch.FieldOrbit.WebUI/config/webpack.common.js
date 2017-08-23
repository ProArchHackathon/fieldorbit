const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
//const ExtractTextPlugin = require('extract-text-webpack-plugin');
const helpers = require('./helpers');

module.exports = {
  entry: {
    'polyfills': './app/polyfills.ts',
    'vendor': './app/vendor.ts',
    'app': './app/main.ts'
  },

  resolve: {
    extensions: ['.ts', '.js', '.css']
  },

  module: {
    rules: [{
      test: /\.ts$/,
      use: [
        // Support for .ts files.
        {
          loader: 'awesome-typescript-loader',
          options: {
            configFileName: helpers.root('.', 'tsconfig.json')
          }
        }, 'angular2-template-loader'
      ]
    },
    // Support for *.json files.
    {
      test: /\.json$/,
      use: ['json-loader']
    },

    // support for .html 
    {
      test: /\.html$/,
      use: ['html-loader']
    },
    {
      test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
      use: ['file-loader?name=images/[name].[hash].[ext]']
    },
    {
        test: /\.css$/,
        use: ['to-string-loader', 'css-loader'],
        exclude: [helpers.root('Content', 'app')]
    },
    // {
    //   test: /\.css$/,
    //   exclude: helpers.root('Content'),
    //   use: ExtractTextPlugin.extract({
    //     fallback: 'style-loader',
    //     use: 'css-loader?sourceMap'
    //   })
    // },
    // {
    //   test: /\.css$/,
    //   include: helpers.root('Content'),
    //   use: 'raw-loader'
    // }
    ]
  },

  plugins: [
    // Workaround for angular/angular#11580
    new webpack.ContextReplacementPlugin(
      // The (\\|\/) piece accounts for path separators in *nix and Windows
      /angular(\\|\/)core(\\|\/)@angular/,
      helpers.root('./app'), // location of your src
      {} // a map of your routes
    ),

    new webpack.optimize.CommonsChunkPlugin({
      name: ['app', 'vendor', 'polyfills'],
      minChunks: Infinity
    }),

    new HtmlWebpackPlugin({
      inject: false,
        template: 'Views/Home/IndexDetails.cshtml',
        filename: '../Views/Home/Index.cshtml'
    })
  ]
};