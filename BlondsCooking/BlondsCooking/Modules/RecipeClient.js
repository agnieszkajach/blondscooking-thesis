var RecipeModule = angular.module('RecipeModule', []);

RecipeModule.controller('RecipeController', function ($http, $scope) {

    var recipeId = $("#recipeId").val();
    $scope.rates = [0, 1, 2, 3, 4, 5];
    $scope.rateValue = -1;
    $scope.validationError = false;

    $scope.rateRecipe = function (rate) {
        if (rate === -1) {
            $scope.validationError = true;
        } else {
            var req = {
                method: 'POST',
                url: '/Category/Rate',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: { id: recipeId, rateValue: rate }
            }
            $http(req)
                   .success(function (data) {
                   })
               .error(function (error) {
               });
        }
        
    }

});