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


BlondsCookingApp.controller('IngredientController', function ($http, $scope, IngredientService) {
    $scope.pairings = [];
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
        $scope.pairings.push($scope.ingredients[id]);
        $scope.show = !$scope.show;
        $scope.$apply();
    }

    $scope.showIngredients = function () {
        var config = {
            params: {
                listOfIngredients: $scope.pairings
            }
        };
        $http.get("/Home/GetMatchingIngredients", config)
                .success(function (data) {
                    alert("good");
                })
            .error(function (error) {
                alert("dupablada");
            });
        $scope.show = !$scope.show;
        $scope.$apply();
    }
});