(function (window, angular, undefined) {
    'use strict';

    angular.module('demo.student.controllers').controller('StudentAddController',

    ['$rootScope', '$scope', '$filter', '$window', 'studentService', 'util', 'ephemeral', '$state', '$http',
        function ($rootScope, $scope, $filter, $window, studentService, util, ephemeral, $state, $http) {

            studentService.get({ id: 0 }, function (data) {
                $scope.model = data.model;
                $scope.empty = data.model;
            }, function ()

            {
                //error do nothing
            });

            $scope.reset = function (form) {
                if (form) {
                    form.$setPristine();
                    form.$setUntouched();
                }
                $scope.model = angular.copy($scope.empty);
            };

            $scope.save = function () {
                studentService.save({
                    studentId: $scope.model.studentId,
                    name: $scope.model.name,
                    registerClass: $scope.model.class,
                    courses: $scope.model.courses
                }, function (resp) {
                    debugger;
                    if (!resp.success) {
                        util.mergeValidationError($scope.form, resp.data);
                        $scope.form.submitted = true;
                    } else {
                        $state.go("student");
                    }

                }, function (err) {
                    console.log(err);
                });
            }

            $scope.back = function() {
                $state.go("student");
            }
        }]);

})(window, window.angular);
