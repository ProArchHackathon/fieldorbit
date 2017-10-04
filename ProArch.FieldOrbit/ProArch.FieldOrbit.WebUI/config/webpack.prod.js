var webpack = require('webpack');
var webpackMerge = require('webpack-merge');
var commonConfig = require('./webpack.common.js');
var helpers = require('./helpers');

const ENV = process.env.NODE_ENV = process.env.ENV = 'production';

module.exports = webpackMerge(commonConfig, {
  devtool: 'source-map',

  output: {
    path: helpers.root('dist'),
    publicPath: '~/dist/',
    filename: 'js/[name].[hash].js',
    chunkFilename: '[id].[hash].chunk.js',
    sourceMapFilename: '[name].map'
  },

  plugins: [
    new webpack.NoEmitOnErrorsPlugin(),
    new webpack.optimize.UglifyJsPlugin({ 
      mangle: {
        keep_fnames: true
      }
    }),
    new webpack.DefinePlugin({
      'process.env': {
        'ENV': JSON.stringify(ENV)
      }
    }),
    new webpack.LoaderOptionsPlugin({
      htmlLoader: {
        minimize: false 
      }
    })
  ]
});