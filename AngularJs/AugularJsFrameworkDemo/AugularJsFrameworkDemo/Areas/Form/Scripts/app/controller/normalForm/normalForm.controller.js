(function (window, angular, undefined) {
    'use strict';

    angular.module('normalForm.controllers').controller('normalFormController',

    ['$rootScope', '$scope', '$filter', '$window', 'normalFormResourceService', 'util', 'ephemeral', '$state', '$http',
        function ($rootScope, $scope, $filter, $window, normalFormResourceService, util, ephemeral, $state, $http) {

            normalFormResourceService.get({}, function (data) {
                $scope.model = data.model;
                $scope.empty = data.model;
            }, function () {
                //error do nothing
            });

            $scope.reset = function (form) {
                if (form) {
                    form.$setPristine();
                    form.$setUntouched();
                }
                $scope.model = angular.copy($scope.empty);
            };

            $scope.validate = function () {
                normalFormResourceService.save({
                    userName: $scope.userName,
                    email: $scope.email,
                    contactNo: $scope.contactNo
                }, function (resp) {
                    alert('Validate Success');
                }, function (err) {
                    util.mergeValidationError($scope.form, err.data);
                    $scope.form.submitted = true;
                });
            }
        }]);

})(window, window.angular);
