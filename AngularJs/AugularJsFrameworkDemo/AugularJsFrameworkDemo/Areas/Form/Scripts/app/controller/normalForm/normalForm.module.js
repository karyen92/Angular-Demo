(function (window, angular, undefined) {
    'use strict';

    angular.module('normalForm.module', [
        'ngRoute',
        'ui.router',
        'form.core',
        'normalForm.controllers'
    ]).config(['$stateProvider',
        function ($stateProvider) {

            $stateProvider
                .state('normalForm', {
                    url: '/',
                    templateUrl: 'tpl.normalForm',
                    controller: 'normalFormController'
                });
        }]);

    angular.module('normalForm.controllers', ['form.core.resources']);
})(window, window.angular);