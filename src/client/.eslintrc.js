module.exports = {
  plugins: ["@typescript-eslint", "eslint-comments", "jest", "promise", "import", "@emotion"],
  extends: [
    "airbnb-typescript",
    "plugin:@typescript-eslint/recommended",
    "plugin:@typescript-eslint/recommended-requiring-type-checking",
    "plugin:eslint-comments/recommended",
    "plugin:jest/recommended",
    "plugin:promise/recommended",
    "plugin:import/recommended",
    "prettier",
  ],
  env: {
    node: true,
    browser: true,
    jest: true,
  },
  parser: "@typescript-eslint/parser",
  parserOptions: {
    project: "./tsconfig.eslint.json",
    extraFileExtensions: [".json"],
  },
  ignorePatterns: ["config-overrides.js"],
  rules: {
    "import/no-unresolved": "error",
    "no-underscore-dangle": "off",
    // Too restrictive, writing ugly code to defend against a very unlikely scenario: https://eslint.org/docs/rules/no-prototype-builtins
    "no-prototype-builtins": "off",
    // https://basarat.gitbooks.io/typescript/docs/tips/defaultIsBad.html
    "import/prefer-default-export": "off",
    "import/no-extraneous-dependencies": "off",
    "import/export": "off",
    "import/no-named-as-default": "off",
    "import/no-cycle": "off",
    // Too restrictive: https://github.com/yannickcr/eslint-plugin-react/blob/master/docs/rules/destructuring-assignment.md
    "react/destructuring-assignment": "off",
    // No jsx extension: https://github.com/facebook/create-react-app/issues/87#issuecomment-234627904
    "react/jsx-filename-extension": "off",
    // Use function hoisting to improve code readability
    "no-use-before-define": "off",
    "@typescript-eslint/ban-ts-comment": "off",
    "@typescript-eslint/no-floating-promises": "off",
    "@typescript-eslint/no-use-before-define": [
      "error",
      { functions: false, classes: true, variables: true, typedefs: true },
    ],
    // Allow most functions to rely on type inference. If the function is exported, then `@typescript-eslint/explicit-module-boundary-types` will ensure it's typed.
    "@typescript-eslint/explicit-function-return-type": "off",
    // Common abbreviations are known and readable
    "unicorn/prevent-abbreviations": "off",
    "unicorn/no-array-for-each": "off",
    "unicorn/prefer-query-selector": "off",
    "unicorn/no-null": "off",
    "unicorn/filename-case": "off",
    "unicorn/no-array-reduce": "off",
    "unicorn/consistent-function-scoping": "off",
    "consistent-return": "off",
    "react/jsx-props-no-spreading": "off",
    "no-plusplus": "off",
    // TODO: resolve prop-types error clear way
    "react/prop-types": "off",
    "no-param-reassign": [
      "error",
      {
        props: true,
        ignorePropertyModificationsFor: ["state"],
      },
    ],
    "jsx-a11y/click-events-have-key-events": "off",
    "jsx-a11y/no-static-element-interactions": "off",
    "unicorn/no-abusive-eslint-disable": "off",
    "eslint-comments/disable-enable-pair": "off",
    "eslint-comments/no-unlimited-disable": "off",
    "@typescript-eslint/ban-types": "off",
    "default-case": "off",
    "no-console": "off",
    "@typescript-eslint/no-misused-promises": "off",
    "import/order":
        [
          1,
          {
            "groups": [
              "external",
              "internal",
              "builtin",
              "parent",
              "sibling",
              "index"
            ],
            "alphabetize": {
              "order": "asc",
              "caseInsensitive": true
            }
          }
        ]
  },
  overrides: [
    {
      files: ["*.js"],
      rules: {
        // Allow `require()`
        "@typescript-eslint/no-var-requires": "off",
      },
    },
    {
      files: ["*.*"],
      rules: {
        "eol-last": 1,
      },
    },
  ],
  settings: {
    "import/parsers": {
      "@typescript-eslint/parser": [".ts", ".tsx"],
    },
    "import/resolver": {
      typescript: {
        alwaysTryTypes: true,
        project: "./tsconfig.json",
      },
    },
  },
};
