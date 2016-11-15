(function (window, angular) {
    'use strict';

    angular.module('form.common.services')
        .factory('util', [
            '$window', function () {
                return {
                    mergeValidationError: function mergeValidationError(formScope, respData) {
                        console.log(formScope);
                        console.log(respData)
                        if (respData.errors) {
                            for (var i in respData.errors) {
                                for (var ind in formScope) {
                                    if (ind.toLowerCase() == respData.errors[i].propertyName.toLowerCase()) {
                                        formScope[ind].$invalid = true;
                                        formScope[ind].$error.message = respData.errors[i].errorMessage;
                                        debugger;
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
