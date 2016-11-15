(function (window, angular, undefined) {
    'use strict';

    angular.module('form.core', [
        'form.core.resources'
    ]);

    angular.module('form.core.resources', ['ngResource']);

})(window, window.angular);