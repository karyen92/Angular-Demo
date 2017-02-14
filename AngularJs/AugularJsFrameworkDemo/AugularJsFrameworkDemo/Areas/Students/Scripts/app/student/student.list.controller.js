(function (window, angular, undefined) {
    'use strict';

    angular.module('demo.student.controllers').controller('StudentController',
    [
        '$rootScope', '$scope', '$filter', '$window', 'studentService','util', 'growl', 'ephemeral', '$state',
        function ($rootScope, $scope, $filter, $window, StudentService, util, growl, ephemeral, $state) {
            
            $scope.title = '';

            var service = new StudentService({});
            $scope.model = service;
            $scope.displayCollection = [];
            $scope.init = function () {
                if ($state.params.method)
                    $scope[$state.params.method]();
            };

            $scope.list = function() {
                service.$get({}, function (data) {
                    $scope.displayCollection = data.collection;
                });
            }

            $scope.add = function() {
                $scope.title = 'Add Student';
            }

            $scope.edit = function () {
                service.get({ id: $state.params.id }, function(data) {
                    $scope.model = data;
                });
                $scope.title = 'Edit Student';
            }

            $scope.remove = function (id) {
                //growl.confirm('Remove this record?', function () {
                //    //studentService.remove({ id }, function(data) {
                //    //    $state.go("student");
                //    //});
                //}, function() {
                //});
                service.delete({ id: id }, function (data) {
                    alert('Successfully Deleted!');
                });
            }

            $scope.create = function () {
                service.$save({
                }, function () {
                    $state.go("student");
                }, function (data) {
                    util.mergeValidationError($scope.form, data.data.errors);
                     $scope.form.submitted = true;
                });
            }

            $scope.update = function() {
                service.update({
                }, function (resp) {
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
                $state.go('student');
            }
            $scope.init();
        }
    ]);

})(window, window.angular);