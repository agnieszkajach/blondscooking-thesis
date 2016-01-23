var RecipeModule = angular.module('RecipeModule', []);

RecipeModule.controller('RecipeController', function ($http, $scope) {

    var recipeId = $("#recipeId").val();
    $scope.rates = [0, 1, 2, 3, 4, 5];
    $scope.rateValue = 0;

    $scope.rateRecipe = function (rate) {
        alert(recipeId);
        var req = {
            method: 'POST',
            url: '/Category/Rate',
            headers: {
                'Content-Type': 'application/json'
            },
            data: {id : recipeId, rateValue : rate}
        }
        $http(req)
               .success(function (data) {
                alert("good");
            })
           .error(function (error) {
           });
    }

});