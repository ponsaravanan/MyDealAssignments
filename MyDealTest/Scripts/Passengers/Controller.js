(function () {
    'use strict';

    angular
        .module('MyDealApp')
            .controller('PassengersController', ['$scope', 'PassengersService', '$http', '$filter',
                function ($scope, PassengersService, $http, $filter) {

                    $scope.RawPassengersInput = $("#RawPassengerText").val();//reflect from jquery updates
                    $scope.SearchInput = "";

                    $scope.ProcessThis = function () {
                        if ($scope.RawPassengersInput == '') {
                            alert("Input PNL can not be empty!");
                            return;
                        }

                        var RawText = {
                            SearchInput: '"' + $scope.SearchInput + '"',
                            RawPassengerList: '"' + $scope.RawPassengersInput + '"'
                        };

                        console.log('RawText', RawText);
                        $scope.AllPassengers = PassengersService.ProcessPassengers.Process(RawText, function (result) {
                            $scope.AllPassengers = result;
                            return $scope.AllPassengers;
                        });
                    };

                }]);
})();
