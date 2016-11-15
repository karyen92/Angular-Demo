(function(window, angular, undefined) {
    'use strict';

    angular.module('demo.student.controllers').controller('StudentListController',
    [
        '$rootScope', '$scope', '$filter', '$window', 'studentService', 'growl', 'ephemeral', '$state', '$http',
        function($rootScope, $scope, $filter, $window, studentService, growl, ephemeral, $state, $http) {

            $scope.displayCollection = [];

            studentService.get({}, function(data) {
                $scope.displayCollection = data.data;
            });
          
            $scope.remove = function() {
                growl.confirm('Do you sure to remove?', function() {}, function() {});
            }

            $scope.edit = function(student) {
              
            }
        }
    ]);

})(window, window.angular);