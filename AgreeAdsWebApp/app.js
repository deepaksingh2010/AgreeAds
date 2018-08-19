/// <reference path="D:\Dev Deepak\LibAPI\PNSRLibrary\Scripts/angular.js" />
(function () {
    var pnsrlibrary = angular.module("pnsrlibrary", ["ngRoute"]);
    pnsrlibrary.config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/TheMain", {
                templateUrl: "template/TheMain.html",
                controller: "TheMainController"
            }).otherwise({
                templateUrl: "template/TheMain.html",
                controller: "TheMainController"
            });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
        $locationProvider.hashPrefix('');
    });
})();