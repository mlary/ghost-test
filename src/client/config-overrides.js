const path = require("path");
const { removeModuleScopePlugin } = require("customize-cra");
const TsconfigPathsWebpackPlugin = require('tsconfig-paths-webpack-plugin');

module.exports = function override(config, env) {
  if (!config.plugins) {
    config.plugins = [];
  }
  removeModuleScopePlugin()(config);
  config.resolve.plugins = [new TsconfigPathsWebpackPlugin()];

  config.resolve.alias = {
    ...config.resolve.alias,
    react: path.resolve("./node_modules/react"),
    "react-router-dom": path.resolve("./node_modules/react-router-dom"),
    "react-router": path.resolve("./node_modules/react-router"),
    "react-redux": path.resolve("./node_modules/react-redux"),
    '@emotion/react': path.resolve('./node_modules/@emotion/react'),
    '@emotion/styled': path.resolve('./node_modules/@emotion/styled'),
    '@mui/material': path.resolve('./node_modules/@mui/material'),
  };
  return config;
};
