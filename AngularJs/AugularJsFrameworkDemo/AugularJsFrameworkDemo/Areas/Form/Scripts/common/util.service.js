(function (window, angular) {
    'use strict';

    angular.module('form.common.services')
        .factory('util', [
            '$window', function () {
                return {
                    mergeValidationError: function mergeValidationError(form, data) {
                        console.log(form);
                        console.log(data)
                        if (data.errors) {
                            for (var i in data.errors) {
                                for (var ind in form) {
                                    if (ind.toLowerCase() == data.errors[i].propertyName.toLowerCase()) {
                                        form[ind].$invalid = true;
                                        form[ind].$error.message = data.errors[i].errorMessage;
                                        debugger;
                                    }
                                }
                            }
                        }
                        return form;
                    }
                }
            }
        ]);
})(window, window.angular);
