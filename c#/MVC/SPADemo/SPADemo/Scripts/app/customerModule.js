(function (app) {

    var config = function ($routeProvider) {
        $routeProvider
            .when("/list", { templateUrl: "/client/views/list.html" })
          //  .when("/edit", { templateUrl: "/client/views/edit.html" })
            .when("/details/:id", { templateUrl: "/client/views/details.html" })
            .otherwise({ redirectTo: "/list" });
    };
    config.$inject = ["$routeProvider"];

    app.config(config);
    app.constant("ServiceApiUrl", "api/CustomersAPI/");

}(angular.module("myapp", ["ngRoute"])));