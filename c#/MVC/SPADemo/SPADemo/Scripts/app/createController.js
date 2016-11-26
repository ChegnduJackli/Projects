(function (app) {

    var CreateController = function ($scope, customerService) {

        var createCustomer = function (newcustomer) {
            $scope.loading = true;
            var frien = newcustomer;
            customerService.create(frien).success(function (data) {
                alert("Added Successfully!!");
                $scope.customers.push(data);
                $scope.newcustomer = null;
                toggleAddbtn();
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Adding Customer! ";
            });
        }

        //create new customer
        $scope.save = function (newcustomer) {
            if (!$scope.addCustomerForm.$valid) {
                $scope.error = "An Error has occured while creating Customer! ";
                return false;
            }
            createCustomer(newcustomer);
        };
        
        $scope.cancel = function () {
            toggleAddbtn();
        }
    };
    CreateController.$inject = ["$scope", "customerService"];

    app.controller("CreateController", CreateController);

}(angular.module("myapp")));