(function(angular, alertify) {

    function alertifyFactory($q) {

        if (typeof alertify === 'undefined') {
            throw new Error('Missing alertify object');
        }

        var alertifyProxy = Object.create(alertify);

        function anyToString(x) {
            if (typeof x === 'string') {
                return x;
            }
            if (x instanceof Error) {
                return x.message;
            }
            return JSON.stringify(x, null, 2);
        }

        function newlineToBreak(x) {
            return typeof x === 'string' ? x.replace(/\n/g, '<br>') : x;
        }

        // make sure the newlines are formatted in the output html
        var messageMethods = ['log', 'error', 'success', 'alert'];

        // overwrite .log(), .error(), and other simple popups
        messageMethods.forEach(function(name) {
            alertifyProxy[name] = function() {
                var args = Array.prototype.slice.call(arguments, 0);
                var strings = args.map(anyToString).map(newlineToBreak);
                return alertify[name].call(alertify, strings.join(' '));
            };
        });

        alertifyProxy.json = function alertifyJson(title, object) {
            if (typeof title === 'object') {
                object = title;
                title = 'JSON output';
            }
            if (typeof title !== 'string') {
                throw new Error('Expected title to be a string');
            }
            // pop an "alert" style dialog
            var str = JSON.stringify(object);
            alertify.prompt(title, undefined, str);
        };

        // transform .confirm(message) into promise-returning method
        alertifyProxy.confirm = function alertifyConfirm(message, cssClass) {
            var defer = $q.defer();
            alertify.confirm(message, function(answer) {
                if (answer) {
                    defer.resolve(answer);
                } else {
                    defer.reject(answer);
                }
            }, cssClass);
            return defer.promise;
        };

        // transform .prompt(message) into promise-returning method
        alertifyProxy.prompt = function alertifyPrompt(message, defaultValue, cssClass) {
            var defer = $q.defer();
            alertify.prompt(message, function(yes, answer) {
                if (yes) {
                    defer.resolve(answer);
                } else {
                    defer.reject();
                }
            }, defaultValue, cssClass);
            return defer.promise;
        };

        return alertifyProxy;
    }
    angular.module('Alertify', [])
    // need name that does not clash with other libraries / modules
    .constant('meta', {
        name: 'ng-alertify',
        description: 'AngularJS wrapper around alertify popup library',
        version: '1.0.2',
        author: 'Gleb Bahmutov <gleb@kensho.com>'
    })
    .factory('Alertify', ['$q', alertifyFactory]);

}(window.angular, window.alertify));

(function(window, angular, alertify, undefined) {
    'use strict';

    angular.module('demo.common', [
        'demo.common.services'
    ]);

    angular.module('demo.common.services', ['Alertify']);

})(window, window.angular)
