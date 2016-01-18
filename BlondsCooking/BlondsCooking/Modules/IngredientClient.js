var BlondsCookingApp = angular.module('BlondsCookingApp', []);


BlondsCookingApp.factory('IngredientService', [
    '$http', function ($http) {
        var IngredientService = {};
        IngredientService.getIngredients = function () {
            return $http.get('/Home/GetIngredients');
        };
        return IngredientService;
    }
]);

BlondsCookingApp.controller('IngredientController', function ($scope, IngredientService) {
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
        $scope.$apply();
    }
});