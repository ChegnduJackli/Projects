(function (app) {

    var ListController = function ($scope, customerService) {

        $scope.loading = true;
        $scope.addMode = false;

        customerService.getAll().success(function (data) {
            $scope.customers = data;
            $scope.loading = false;
        }).error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });


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

        var toggleAddbtn = function () {
            $scope.addMode = !$scope.addMode;
            if ($scope.addMode) {
                //add default value
                $scope.newcustomer = { name: "zhangsan", address: "tianfu", city: "chengdu", country: "China", age: 18 };
            }
            $scope.error = null;
        }
        $scope.toggleAdd = function () {
            toggleAddbtn();
        };

        //Delete Customer
        $scope.delete = function () {
            if (!confirm('Are you sure to delete this record?')) {
                return false;
            }
            var Id = this.customer.id;
            customerService.delete(this.customer).success(function (data) {
                alert("Deleted Successfully!!");
                $.each($scope.customers, function (i) {
                    if ($scope.customers[i].id === Id) {
                        $scope.customers.splice(i, 1);
                        return false;
                    }
                });
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving Customer! " + data;
           
            });
        };
    };
    ListController.$inject = ["$scope", "customerService"];

    app.controller("ListController", ListController);
     // app.controller('custController', ['$scope', '$http', custController]);

}(angular.module("myapp")));