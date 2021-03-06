﻿(function () {
    'use strict';

    angular.module('GameStoreApp').service('rateService', rateService);

    rateService.$inject = ['$http'];

    function rateService($http) {
        var baseRateUrl = "/api/rate";
        var gameRatesUrl = baseRateUrl.concat("/getgamerates?gameId=");
        var getRecomendedGames = baseRateUrl.concat("/getrecomendedgames?gameId=");
        var addCommentUrl = baseRateUrl.concat("/createfeed");

        this.getRecomendationToGame = function (data) {
            return $http.get(getRecomendedGames + data);
        };

        this.getGameRates = function (data) {
            return $http.get(gameRatesUrl + data);
        };

        this.сreateFeed = function (data) {
            return $http({
                method: 'POST',
                url: addCommentUrl,
                data: data,
                headers: { 'Content-Type': 'application/json' }
            });
        };
    }
})();