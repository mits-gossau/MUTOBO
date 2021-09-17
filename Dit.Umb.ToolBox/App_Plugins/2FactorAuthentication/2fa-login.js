angular.module("umbraco").controller("2FactorAuthentication.LoginController",
    function ($scope, $cookies, localizationService, userService, externalLoginInfo, resetPasswordCodeInfo, $timeout, authResource, editorService, twoFactorService) {

        $scope.code = "";
        $scope.provider = "";
        $scope.providers = [];
        $scope.step = "send";
        
       /* not working twoFactorService.get2FAProviders()
            .then(function (data) {
                console.log(data);
                $scope.providers = data;
            });*/
        $scope.providers = "GoogleAuthenticator";//temp netser
        $scope.step = "code";

        //$scope.send = function (provider) {
        //    $scope.provider = provider;
        //    $scope.step = "code";
        //};

        $scope.validate = function (provider, code) {
            provider = "GoogleAuthenticator"; //temp netser
            $scope.error2FA = "";
            $scope.code = code;
            authResource.verify2FACode(provider, code)
                .then(function (data) {
                    userService.setAuthenticationSuccessful(data);
                    window.location.href = '/umbraco';
                    //$scope.submit(true);
                }, function () { $scope.error2FA = "Invalid code entered." });
        };
    });