(function (app) {

    var EditController = function ($scope, customerService) {

        //var updateCustomer = function () {
        //    customerService.update($scope.edit.customer)
        //        .success(function () {
        //            angular.extend($scope.customer, $scope.edit.customer);
        //            $scope.edit.customer = null;
        //        });
        //};



        var updateCustomer = function () {
            $scope.loading = true;
            //this.customer.editMode = false;
            var frien = $scope.edit.customer;

            customerService.update(frien).success(function (data) {
                alert("Saved Successfully!!");
                angular.extend($scope.customer, $scope.edit.customer);
                $scope.edit.customer = null;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving customer! " + data;
            });
        }

        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.customer;
        };

        $scope.cancel = function () {
            $scope.edit.customer = null;
        };

        $scope.save = function () {
            updateCustomer();
        };
    };
    EditController.$inject = ["$scope", "customerService"];

    app.controller("EditController", EditController);

}(angular.module("myapp")));