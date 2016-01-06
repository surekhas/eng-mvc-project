'use strict';

var contls = angular.module('Eng_Part.controllers', []);

angular.module("Eng_Part",
                ['ngRoute',
                 'Eng_Part.controllers'
                ])
                .config(['$routeProvider', function ($routeProvider) {
                    debugger;
                    $routeProvider.
                        when('/Angular', {
                            templateUrl: 'View/Angular/PartList.html',
                            controller: 'partlist'
                        })
                    .otherwise({ redirectTo: '/Angular' });


                }])
                .run(['$route', function ($route) {
                    $route.reload();
                }]);
              