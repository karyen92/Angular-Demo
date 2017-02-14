(function (window, angular) {
    'use strict';

    angular.module('demo.common.services')
        .factory('util', [
            '$window', function () {
                return {
                    mergeValidationError: function mergeValidationError(formScope, errors) {
                        if (errors) {
                            for (var i in errors) {
                                for (var ind in formScope) {
                                    if (ind.toLowerCase() == errors[i].propertyName.toLowerCase()) {
                                        formScope[ind].$invalid = true;
                                        formScope[ind].$error.message = errors[i].errorMessage;
                                    }
                                }
                            }
                        }
                        return formScope;
                    }
                }
            }
        ]);
})(window, window.angular);
