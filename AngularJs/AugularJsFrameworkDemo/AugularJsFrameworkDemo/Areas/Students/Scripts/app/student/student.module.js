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
                  .state('material', {
                      url: '/material',
                      templateUrl: 'tpl.student.material',
                      controller: 'MaterialController'
                  })
                .state('student', {
                    url: '/',
                    templateUrl: 'tpl.student.list',
                    controller: 'StudentController',
                    params: {
                        method: 'list'
                    }
                })
                .state('add', {
                    url: '/AddStudent',
                    templateUrl: 'tpl.student.add',
                    controller: 'StudentController',
                    params: {
                        method: 'add'
                    }
                })
                .state('edit', {
                    url: '/EditStudent',
                    templateUrl: 'tpl.student.add',
                    controller: 'StudentController',
                    params: {
                        id: null,
                        method: 'edit'
                    }
                });
        }]);

    angular.module('demo.student.controllers', ['demo.core.resources']);
})(window, window.angular);