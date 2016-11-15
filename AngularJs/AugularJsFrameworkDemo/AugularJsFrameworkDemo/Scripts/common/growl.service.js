
(function (window, angular, alertify, undefined) {
    'use strict';

    angular.module('demo.common.services')
        .factory('growl', [
            '$window', function (window) {

                alertify.set('notifier', 'position', 'top-right');
                alertify.set('notifier', 'delay', 10);

                var exports = {};

                exports.alert = function (msg) {
                    debugger;
                    var title = 'Demo';

                    alertify.alert(msg)
                     .set('title', title);
                };
                
                exports.confirm = function (msg, onOk, onKo) {
                    debugger;
                    var title = 'Demo';

                    alertify.confirm(msg)
                        .set('title', title)
                        .set('onok', onOk)
                        .set('oncancel', onKo);
                };

                exports.prompt = function (msg, handler, defaultValue) {
                    alertify.prompt(msg, handler, defaultValue);
                };

                exports.log = function (msg) {
                    alertify.log(msg, "", 0);
                };

                exports.success = function (msg) {
                    alertify.success(msg);
                };

                exports.error = function (msg) {
                    alertify.error(msg);
                };

                return exports;
            }
        ]);

})(window, window.angular, window.alertify);
