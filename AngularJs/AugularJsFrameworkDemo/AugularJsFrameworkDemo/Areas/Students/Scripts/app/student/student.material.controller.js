(function (window, angular, undefined) {
    'use strict';

    angular.module('demo.student.controllers', ['ngFileUpload']).controller('MaterialController',
    [
        '$rootScope', '$scope', '$filter', '$window', '$state', 'MaterialResource', 'Upload', '$timeout',
        function ($rootScope, $scope, $filter, $window, $state, MaterialResource, Upload, $timeout) {
            $scope.myDate = new Date();
            $scope.dropdowns = [];
            $scope.materials = [];

            var resource = new MaterialResource({});
            $scope.model = resource;
            $scope.serverImg = ' http://placehold.it/350x150';

            MaterialResource.dropdown({}, function (data) {
                $scope.dropdowns = data.collection;
            });

            $scope.upload = function (file) {
                file.upload = Upload.upload({
                    url: '/AngularDemo/api/files',
                    data: { file: file }
                });

                file.upload.then(function (response) {
                    $timeout(function () {
                        //debugger;
                        //file.result = response.data;
                        $scope.serverImg = response.data.result.base64String;
                    });
                }, function (err) {
                    console.log(err);
                }, function (evt) {
                    console.log(evt);
                });
            }

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