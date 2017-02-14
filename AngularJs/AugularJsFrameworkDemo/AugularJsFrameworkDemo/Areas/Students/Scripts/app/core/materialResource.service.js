(function (window, angular, undefined) {
    'use strict';

    angular.module('demo.core.resources').factory('MaterialResource', ['$resource',
	    function ($resource) {
	        var exports = $resource("/AngularDemo/api/material/:id/:verb", {
	            id: "@id"
	        }, {
	            update: {
	                method: 'PUT'
	            },
	            dropdown: {
	                method: 'GET',
	                params: {
	                    verb: 'dropdown'
	                }
	            }
	        });

	        return exports;
	    }]);

})(window, window.angular);