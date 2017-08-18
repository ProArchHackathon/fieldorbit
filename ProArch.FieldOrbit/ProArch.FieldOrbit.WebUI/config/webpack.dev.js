const helpers = require('./helpers');
const webpack = require('webpack');
//const ExtractTextPlugin = require('extract-text-webpack-plugin');
const webpackMerge = require('webpack-merge');
const OptimizeJsPlugin = require('optimize-js-plugin');
const commonConfig = require('./webpack.common.js');

module.exports = webpackMerge(commonConfig, {
  devtool: 'cheap-module-eval-source-map',

  output: {
    path: helpers.root('dist'),
    filename: 'js/[name].js',
    chunkFilename: '[id].chunk.js',
    sourceMapFilename: '[file].map'
  },
  plugins: [
    //new ExtractTextPlugin('css/[name].css'),
    new OptimizeJsPlugin({
      sourceMap: true
    }),
    new webpack.DefinePlugin({
      'process.env.NODE_ENV': '"development"',
    }),
  ],
  watch: true,
  // devServer: {
  //   historyApiFallback: true,
  //   stats: 'minimal',
  //   contentBase: path.join(__dirname, '..', "public"),
  //   compress: true,
  //   port: 9000
  // },
  watchOptions: {
    aggregateTimeout: 300,
    poll: 1000
  }
});