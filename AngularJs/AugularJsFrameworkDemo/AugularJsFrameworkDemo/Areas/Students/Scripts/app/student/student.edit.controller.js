(function (window, angular, undefined) {
    'use strict';

    angular.module('demo.student.controllers').controller('StudentEditController',

    ['$rootScope', '$scope', '$filter', '$window', 'studentService', 'util', 'ephemeral', '$state', '$http',
        function ($rootScope, $scope, $filter, $window, studentService, util, ephemeral, $state, $http) {
            $scope.title = "Edit Student";

            studentService.get({ id: $state.params.id }, function (data) {
                $scope.model = data.model;
                $scope.empty = data.model;
            }, function () {
                //error do nothing
            });

            $scope.init = function () {
                debugger;
                if ($state.params.method) {
                    $scope[$state.params.method]();
                }
            }

            $scope.edit = function() {
                alert('hi');
            }

            $scope.reset = function (form) {
                if (form) {
                    form.$setPristine();
                    form.$setUntouched();
                }
                $scope.model = angular.copy($scope.empty);
            };

            $scope.save = function () {
                studentService.update({
                    id: $scope.model.id,
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

            $scope.back = function () {
                $state.go("student");
            }

            $scope.init();
        }]);

})(window, window.angular);
