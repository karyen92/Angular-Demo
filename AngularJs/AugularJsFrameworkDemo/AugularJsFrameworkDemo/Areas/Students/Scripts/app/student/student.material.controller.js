(function (window, angular, undefined) {
    'use strict';

    angular.module('demo.student.controllers').controller('MaterialController',
    [
        '$rootScope', '$scope', '$filter', '$window', '$state', 'MaterialResource',
        function ($rootScope, $scope, $filter, $window, $state, MaterialResource) {
            $scope.myDate = new Date();
            $scope.dropdowns = [];
            $scope.materials = [];

            var resource = new MaterialResource({});
            $scope.model = resource;

            MaterialResource.dropdown({}, function (data) {
                $scope.dropdowns = data.collection;
            });


            MaterialResource.get({}, function (data) {
                $scope.materials = data.collection;
            });

            $scope.create = function () {
                resource.$save({}, function (resp) {
                    console.log('save successfully');
                }, function (resp) {
                    console.log('fail');
                });
            }
        }
    ]);

})(window, window.angular);