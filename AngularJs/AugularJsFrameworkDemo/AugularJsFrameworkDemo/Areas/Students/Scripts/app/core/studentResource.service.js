(function (window, angular, undefined) {
    'use strict';

    angular.module('demo.core.resources').factory('studentService', ['$resource',
	    function ($resource) {
	        var exports = $resource("/AngularDemo/api/students/:formId/:verb", {
	            formId: "@id"
	        }, {
	            update: {
	                method: 'PUT'
	            }
	        }); 

	        return exports;
	    }]);

})(window, window.angular);