(function (window, angular, undefined) {
    'use strict';

    if (!String.prototype.includes) {
        String.prototype.includes = function () {
            'use strict';
            return String.prototype.indexOf.apply(this, arguments) !== -1;
        };
    }

    angular.module('demo', [
        'ngRoute',
        'ui.router',
        'ngMaterial',
        'demo.student',
        'demo.common'
    ]).config(['$httpProvider', '$stateProvider', '$urlRouterProvider',
        function ($httpProvider, $stateProvider, $urlRouterProvider) {
            $httpProvider.interceptors.push([
                '$rootScope', '$q', '$window',
                function ($rootScope, $q, $window) {
                    return {
                        'request': function (config) {
                            $rootScope.$emit('http-call/start');
                            return config || $q.when(config);
                        },
                        'requestError': function (rejection) {
                            $rootScope.$emit('http-call/end');
                            return $q.reject(rejection);
                        },

                        'response': function (response) {
                            if (response.headers("x-isloginpage") === "1") {
                                $window.location.reload(true);
                                return null;
                            }

                            $rootScope.$emit('http-call/end');
                            return response || $q.when(response);
                        },
                        'responseError': function (rejection) {
                            $rootScope.$emit('http-call/end');

                            if (rejection.status === 0) {
                                // The response is empty. Probably cookie expires and require authentication.
                                $window.location.reload(true);
                            }

                            if (rejection.status === 401) {
                                // HTTP 401 Error: 
                                // The request requires user authentication
                                $window.location.reload(true);
                            }

                            if (rejection.status === 403) {
                                // HTTP 403 Error: 
                                // Forbidden access to resource
                                return $q.reject(response);
                            }

                            return $q.reject(rejection);
                        }
                    };
                }
            ]);

            $urlRouterProvider.otherwise('/');

        }])

        .value('ephemeral', window.ephemeral)

        .run(['$rootScope', '$state', '$stateParams', function ($rootScope, $state, $stateParams) {

            // It's very handy to add references to $state and $stateParams to the $rootScope
            // so that you can access them from any scope within your applications.For example,
            // <li ng-class="{ active: $state.includes('contacts.list') }"> will set the <li>
            // to active whenever 'contacts.list' or one of its decendents is active.
            $rootScope.$state = $state;
            $rootScope.$stateParams = $stateParams;

            $rootScope.EPHEMERAL = window.ephemeral;

            $rootScope.previousState = '';
            $rootScope.currentState = '';

            $rootScope.$on('$stateChangeSuccess', function (ev, to, toParams, from, fromParams) {
                $rootScope.previousState = from.name;
                $rootScope.currentState = to.name;
                $rootScope.previousStateParams = fromParams;
                $rootScope.currentStateParams = toParams;
            });

        }]);

    //angular.module('performly.components.directives', ['performly.common.utils']);

})(window, window.angular);