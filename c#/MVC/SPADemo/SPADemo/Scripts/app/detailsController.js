(function (app) {

    var DetailsController = function ($scope, $routeParams, customerService) {

        customerService.getById($routeParams.id)
                    .success(function (customer) {
                        $scope.customer = customer;
                    }).error(function (response) {
                        $scope.error = "An Error has occured while Saving customer! ";
                    });


        $scope.edit = function () {
            toggleEdit();
        };

        $scope.save = function () {
            if (!$scope.editCustomerForm.$valid) {
                $scope.error = "An Error has occured while Saving customer! ";//+ response;
                return false;
            }

            var frien = $scope.edit.customer;

            customerService.update(frien).success(function (data) {
                alert("Saved Successfully!");
                angular.extend($scope.customer, $scope.edit.customer);
                $scope.customer.editMode = !$scope.customer.editMode;
                $scope.error = null;
            }).error(function (response) {
                $scope.error = "An Error has occured while Saving customer! ";//+ response;
                $scope.errors = parseErrors(response);
            });
        };

        var parseErrors=function(response) {
            var errors = [];
            for (var key in response.ModelState) {
                for (var i = 0; i < response.ModelState[key].length; i++) {
                    errors.push(response.ModelState[key][i]);
                }
            }
            return errors;
        }

        $scope.cancel = function ()
        {
            toggleEdit();
        }

        var toggleEdit = function () {
            $scope.customer.editMode = !$scope.customer.editMode;
            $scope.edit.customer = angular.copy($scope.customer);
            $scope.error = null;
        }

        
        //app.directive('onlyDigits', function () {
        //    return {
        //        restrict: 'A',
        //        require: '?ngModel',
        //        link: function (scope, element, attrs, modelCtrl) {
        //            modelCtrl.$parsers.push(function (inputValue) {
        //                if (inputValue == undefined) return '';
        //                var transformedInput = inputValue.replace(/[^0-9]/g, '');
        //                if (transformedInput !== inputValue) {
        //                    modelCtrl.$setViewValue(transformedInput);
        //                    modelCtrl.$render();
        //                }
        //                return transformedInput;
        //            });
        //        }
        //    };

        //});


    };
    DetailsController.$inject = ["$scope", "$routeParams", "customerService"];

    app.controller("DetailsController", DetailsController);

}(angular.module("myapp")));