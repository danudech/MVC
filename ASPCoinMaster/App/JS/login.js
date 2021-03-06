AppMaster.controller('LoginMaste',
    function indexMaste($scope, $http,$window) {
        $scope.signup = false;
        $scope.login = true;

        $scope.login = function (user, pass) {
            console.log(user);
            console.log(pass);
        }

        $scope.init = function (refer) {
            console.log(refer.length);
            if (refer.length > 0) {
                $scope.link('ToCreate',refer);
            }
            $http({
                method: "POST",
                url: '/Master/Getdatalogin',
                dataType: "json"
            }).then(function (response) {
                $scope.process = response.data.titlelogin;
                //$scope.varModules = response.data.Modules;
            });
        }

        $scope.link = function (link, refer) {
            console.log(link);
            if (link == 'ToCreate') {
                $scope.show = true;
                $scope.login = false;
                $scope.refer = refer;
                //$window.location.href = '/Master/Signup'
            } else {
                $scope.login = true;
                $scope.show = false;
            }
            
        }

        $scope.signup = function (SignUser, SignPass, SignEmail, refer) {
            $scope.show = false;
            $scope.loading = true;
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
                if (response.data.val == "User is Avalible") {
                    $scope.loading = false;
                    $scope.login = true;
                    $scope.sentmail(SignEmail);
                } else {
                    $scope.loading = false;
                    $scope.show = true;
                }
            });
        }

        //$scope.submitForm = function () {
        //    if (event.keyCode == 13) {
        //        console.log("OK Guy!!");
        //        window.event.keyCode = 9;
        //    }
            //alert('The form has been submitted !');
        //};
        $scope.checkmail = function (SignEmail) {
            $scope.chkmail = true;
            if (SignEmail != null) {
                $scope.chkmail = false;
            }
        }

        $scope.sentmail = function (SignEmail) {
            $http({
                method: "POST",
                url: "/Master/SendEmail",
                data: {
                    to: SignEmail,
                    body: "Test Sent Form MVC By AngularJS",
                    subject: "Test Sent Form MVC"
                },
                dataType: "Json"
            }).then(function (respons) {
                console.log(respons.data);
            });
        }
            
    });