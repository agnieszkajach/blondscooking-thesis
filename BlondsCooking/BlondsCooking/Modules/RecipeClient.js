﻿var RecipeModule = angular.module('RecipeModule', []);

RecipeModule.controller('RecipeController', function ($http, $scope) {

    var recipeId = $("#recipeId").val();
    $scope.rates = [0, 1, 2, 3, 4, 5];
    $scope.rateValue = $("#rateValue").val();
    $scope.validationError = false;
    $scope.recipeRated = false;
    if ($scope.rateValue > 0) {
        $scope.recipeRated = true;
    }


    $scope.rateRecipe = function (rate) {
        if (rate === undefined) {
            $scope.validationError = true;
        } else {
            $scope.recipeRated = true;
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