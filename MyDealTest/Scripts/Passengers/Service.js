(function () {
    'use strict';

    angular.module('MyDealApp').
        factory('PassengersService', ['$resource', '$cacheFactory', function ($resource, $cacheFactory) {
            return {
                ProcessPassengers: $resource('/api/passengers/Process:RawPassengerList', '@RawPassengerList', { 'Process': { method: 'POST', isArray: true } }),

            }
        }])
})();