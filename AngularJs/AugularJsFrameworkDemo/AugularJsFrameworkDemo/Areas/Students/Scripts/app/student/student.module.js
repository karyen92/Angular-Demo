(function (window, angular, undefined) {
    'use strict';

    angular.module('demo.student', [
        'ngRoute',
        'ui.router',
        'demo.core',
        'demo.student.controllers'
    ]).config(['$stateProvider',
        function ($stateProvider) {

            $stateProvider
                .state('student', {
                    url: '/',
                    templateUrl: 'tpl.student.list',
                    controller: 'StudentListController'
                })
            .state('view', {
                url: '/ViewStudent',
                templateUrl: 'tpl.student.view',
                controller: 'StudentViewController'
            })
            .state('add', {
                url: '/AddStudent',
                templateUrl: 'tpl.student.add',
                controller: 'StudentAddController'
            });
        }]);

    angular.module('demo.student.controllers', ['demo.core.resources']);
})(window, window.angular);