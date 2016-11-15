(function (window, angular, undefined) {
    'use strict';

    //angular.module(name, [requires], [configFn]);
    angular.module('demo.core', [
        'demo.core.resources'
    ]);

    angular.module('demo.core.resources', ['ngResource']);

})(window, window.angular);