AppMaster.controller('indexMaste',
    function indexMaste($scope, $http) {
        $scope.home = "/Index/Index";
        $scope.pay = "/Payment/Payment";
        $scope.earn = "#earn";
        $scope.msg = "#msg";
        $scope.refer = "#refer";
        $scope.app = "#app";

        $scope.init = function () {

            $scope.Title = "Index";
            $scope.Subtitle = "This index Page :P";
            $scope.textshow = "Some quick example text to build on the card title and make up the bulk of the card's content. ??";
        };

        $scope.chkwallet = function (wallet) {
            if (wallet != null) {
                if (wallet.length > 20) {
                    console.log(wallet);
                } else {
                    $scope.showalert = true;
                }
            }
        }

        $scope.closealert = function () {
            $scope.showalert = false;
        }
    });