(function(app) {

    var customerService = function ($http, ServiceApiUrl) {

        var getAll = function() {
            return $http.get(ServiceApiUrl);
        };

        var getById = function(id) {
            return $http.get(ServiceApiUrl + id);
        };

        var update = function(data) {
            return $http.put(ServiceApiUrl + data.id, data);
        };

        var create = function (data) {
            return $http.post(ServiceApiUrl, data);
        };

        var destroy = function (data) {
            return $http.delete(ServiceApiUrl + data.id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destroy
        };
    };
   
    customerService.$inject = ["$http", "ServiceApiUrl"];

    app.factory("customerService", customerService);


}(angular.module("myapp")))