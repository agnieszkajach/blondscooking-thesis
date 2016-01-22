var BlondsCookingApp = angular.module('BlondsCookingApp', []);


BlondsCookingApp.factory('IngredientService', [
    '$http', function ($http) {
        var IngredientService = {};
        IngredientService.getIngredients = function () {
            return $http.get('/Home/GetIngredients', 1);
        };
        return IngredientService;
    }
]);

//BlondsCookingApp.factory('IngredientPairingService', [
//    '$http', function ($http) {
//        var IngredientPairingService = {};
//        IngredientPairingService.getIngredients = function () {
//            return $http({
//                url: "/Home/GetIngredientsAsd",
//                method: "GET",
//                params: { id: 1 }
//            });
//        };
//        return IngredientPairingService;
//    }
//]);


BlondsCookingApp.controller('IngredientController', function ($http, $scope, $filter, IngredientService) {

   

    $scope.pairings = [];
    $scope.pairingsRequest = [];
    getIngredients();

    function getIngredients() {
        IngredientService.getIngredients().success(function (ingr) {
            $scope.ingredients = ingr;
            console.log($scope.ingredients);
        })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
            });
    }


    $scope.addIngredient = function (id) {
        var selectedIngredient = $filter('filter')($scope.ingredients, { Id: id})[0];
        $scope.pairings.push(selectedIngredient);
        //$scope.pairings.push($scope.ingredients[id - 1]);
        $scope.pairingsRequest.push(id);
        $scope.show = !$scope.show;
        $scope.$apply();
    }

    $scope.showIngredients = function () {
        var req = {
            method: 'POST',
            url: '/Home/GetMatchingIngredients',
            headers: {
                'Content-Type': 'application/json'
            },
            data: $scope.pairingsRequest
        }
        $http(req)
                .success(function (pairedIngredients) {
                    $scope.ingredients = pairedIngredients;
                })
            .error(function (error) {
            });
        $scope.show = !$scope.show;
        $scope.$apply();
    }
});