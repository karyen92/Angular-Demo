(function (window, angular, undefined) {
    'use strict';

    angular.module('form.core.resources').factory('normalFormResourceService', ['$resource',
	    function ($resource) {

	        var exports = $resource("/AngularDemo/api/normalForm/:formId/:verb", {
	            formId: "@id"
	        }, {
	            update: {
	                method: 'PUT'
	            }
	        }); 

	        return exports;
	    }]);

})(window, window.angular);