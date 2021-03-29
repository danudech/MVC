AppMaster.controller('LoginMaste',
    function indexMaste($scope, $http,$window) {
        $scope.signup = false;
        $scope.login = true;
        $scope.login = function (user, pass) {
            console.log(user);
            console.log(pass);
        }

        $scope.init = function () {
            $http({
                method: "POST",
                url: '/Master/Getdatalogin',
                dataType: "json"
            }).then(function (response) {
                $scope.process = response.data.titlelogin;
                console.log(response.data.titlelogin);
                //$scope.varModules = response.data.Modules;
            });
        }

        $scope.link = function (link) {
            console.log(link);
            if (link == 'ToCreate') {
                $scope.show = true;
                $scope.login = false;
                //$window.location.href = '/Master/Signup'
            } else {
                $scope.login = true;
                $scope.show = false;
            }
            
        }

        $scope.signup = function (SignUser, SignPass, SignRepass, SignEmail, refer) {
            if (SignPass != SignRepass) {
                console.log("OK Log");
            }
            $http({
                method: "post",
                url: 'master/signup',
                data: {
                    UserName: SignUser,
                    Pass: SignPass,
                    Email: SignEmail,
                    Ref: refer
                },
                dataType: "json",
            }).then(function (response) {
                console.log(response.data.val);
            });;
        }

        $scope.submitForm = function () {
            if (event.keyCode == 13) {
                console.log("OK Guy!!");
                window.event.keyCode = 9;
            }
            //alert('The form has been submitted !');
        };
    });