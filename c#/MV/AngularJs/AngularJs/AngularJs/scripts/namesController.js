(function () {
    var app = angular.module('myApp', []);


    app.controller('namesCtrl', function ($scope) {
        $scope.names = [
            { name: 'Jani', country: 'Norway' },
            { name: 'Hege', country: 'Sweden' },
            { name: 'Kai', country: 'Denmark' }
        ];
    });

    app.controller('personCtrl', function ($scope) {
        $scope.firstName = "John";
        $scope.lastName = "Doe";
        $scope.fullName = function () {
            return $scope.firstName + $scope.lastName;
        }
        $scope.alertmsg = function () {
            var firstName = $scope.firstName;
            //alert("fistName:" + firstName);
        }
        $scope.person = {
            firstName: "ge la",
            lastName: "jack"
        };
        $scope.myVar = true;
        $scope.toggle = function () {
            $scope.myVar = !$scope.myVar;
        };
    });

    app.controller('costCtrl', function ($scope) {
        $scope.quantity = 1;
        $scope.price = 9.99;
    });

    //有个 $location 服务，它可以返回当前页面的 URL 地址。
    app.controller('customersCtrl', function ($scope, $location) {
        $scope.myUrl = $location.absUrl();
    });

    app.controller('httpServiceCtrl', function ($scope, $http) {
        $http.get("6_filter.html").then(function (response) {
            $scope.myWelcome = response.data;
        });
    });

    app.controller("timeoutServiceCtrl", function ($scope, $timeout) {
        $scope.myHeader = "hello world";
        $timeout(function () {
            $scope.myHeader = "How are you today?";
        }, 2000);
    });

    //创建自定义服务
    app.service('$hexafy', function () {
        this.myFunc = function (x) {
            return x.toString(16);
        }
    });

    app.controller("selfServiceCtrl", function ($scope, $hexafy) {
        $scope.hex = $hexafy.myFunc(255);
    });

    //过滤器中，使用自定义服务
    app.filter('myFormat', ['$hexafy', function ($hexafy) {
        return function (x) {
            return $hexafy.myFunc(x);
        };
    }]);
    app.controller('numCtrl', function ($scope) {
        $scope.counts = [255, 251, 200];
    });

    //http服务
    app.controller('httpCtrl', function ($scope, $http) {
        $http.get("jsonData.js")
        .success(function (response) { $scope.names = response.sites; });
    });

    //
    app.controller('ddlCtrl', function ($scope) {
        $scope.names = ["Google", "Runoob", "Taobao"];
    });

    //validate controller
    app.controller('validateCtrl', function ($scope) {
        $scope.user = 'John Doe';
        $scope.email = 'john.doe@gmail.com';
    });

    //AngularJS 全局 API
    app.controller('APICtrl', function ($scope) {
        $scope.x1 = "JOHN";
        $scope.x2 = angular.lowercase($scope.x1);
        $scope.x3 = angular.uppercase($scope.x1);
        $scope.x4 = angular.isString($scope.x1);
        $scope.x5 = angular.isNumber($scope.x1);
    });

    app.controller('userCtrl', function ($scope) {
        $scope.fName = '';
        $scope.lName = '';
        $scope.passw1 = '';
        $scope.passw2 = '';
        $scope.users = [
       { id: 1, fName: 'Hege', lName: "Pege" },
        { id: 2, fName: 'Kim', lName: "Pim" },
       { id: 3, fName: 'Sal', lName: "Smith" },
        { id: 4, fName: 'Jack', lName: "Jones" },
       { id: 5, fName: 'John', lName: "Doe" },
       { id: 6, fName: 'Peter', lName: "Pan" }
        ];
        $scope.edit = true;
        $scope.error = false;
        $scope.incomplete = false;

        $scope.editUser = function (id) {
            if (id == 'new') {
                $scope.edit = true;
                $scope.incomplete = true;
                $scope.fName = '';
                $scope.lName = '';
            } else {
                $scope.edit = false;
                $scope.fName = $scope.users[id - 1].fName;
                $scope.lName = $scope.users[id - 1].lName;
            }
        };

        $scope.$watch('passw1', function () { $scope.test(); });
        $scope.$watch('passw2', function () { $scope.test(); });
        $scope.$watch('fName', function () { $scope.test(); });
        $scope.$watch('lName', function () { $scope.test(); });

        $scope.test = function () {
            if ($scope.passw1 !== $scope.passw2) {
                $scope.error = true;
            } else {
                $scope.error = false;
            }
            $scope.incomplete = false;
            if ($scope.edit && (!$scope.fName.length ||
            !$scope.lName.length ||
            !$scope.passw1.length || !$scope.passw2.length)) {
                $scope.incomplete = true;
            }
        }
    });
    //factory 是一个函数用于返回值。在 service 和 controller 需要时创建。
    //通常我们使用 factory 函数来计算或返回值。

    app.factory('MathService', function() {
        var factory = {};
   
        factory.multiply = function(a, b) {
            return a * b
        }
        return factory;
    });

    // 在 service 中注入 factory "MathService"
    app.service('CalcService', function (MathService) {
        this.square = function (a) {
            return MathService.multiply(a, a);
        }
    });
    
    app.value("defaultInput", 5);

    app.controller('CalcController', function ($scope, CalcService, defaultInput) {
        $scope.number = defaultInput;
        $scope.result = CalcService.square($scope.number);

        $scope.square = function () {
            $scope.result = CalcService.square($scope.number);
        }
    });


}());