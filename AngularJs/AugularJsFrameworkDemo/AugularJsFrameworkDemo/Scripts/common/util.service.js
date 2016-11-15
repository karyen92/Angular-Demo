(function (window, angular) {
    'use strict';

    angular.module('demo.common.services')
        .factory('util', [
            '$window', function () {
                return {
                    mergeValidationError: function mergeValidationError(formScope, respData) {
                        if (respData.errors) {
                            for (var i in respData.errors) {
                                for (var ind in formScope) {
                                    if (ind.toLowerCase() == respData.errors[i].propertyName.toLowerCase()) {
                                        formScope[ind].$invalid = true;
                                        formScope[ind].$error.message = respData.errors[i].errorMessage;
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
