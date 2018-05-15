function doLogin() {
    var loginid = $.trim(document.loginform.loginid.value); //登录ID
    var password = document.loginform.password.value; //密码
    var vcode = document.loginform.vcode.value;		 //验证码
    var isCa = "false";
    if ($("#isCa").attr("checked")) {
        isCa = document.loginform.isCa.value;		 //是否CA登录
        if (password == "" || password == undefined) {
            $("#isCa").attr("checked", false);
            GGFW.alert("请输入证书密码");
            document.loginform.password.focus();
            return;
        }
        loginform.signature.value = signPKCS7ByPwd(loginform.ticket.value, false, document.loginform.password.value);//带密码的PKCS7签名
        if (loginform.signature.value == "null" || loginform.signature.value == "" || loginform.signature.value == null) {
            $("#isCa").attr("checked", false);
            return;
        }
    }

    if (isEncrypty == '1') { //加密传输
        password = stringToHex(encrypt(document.loginform._1_.value, password));
    }
    var logining;
    var camy = encodeURIComponent(loginform.signature.value);
    //考虑尽量引入JS，这里就不用form插件
    var datas = "LOGINID=" + loginid + "&PASSWORD=" + password + "&IMAGCHECK=" + vcode + "&ISCA=" + isCa + "&CAMY=" + camy + "&ticket=" + loginform.ticket.value + "&des_key=" + loginform.des_key.value;
    datas += "&subsys=" + loginform.subsys.value + "&SUBSYS=" + loginform.SUBSYS.value;
    $.ajax({
        url: contextPath + "/ajaxlogin.do",
        type: "post",
        data: datas,
        dataType: "json",
        success: function (results) {
            if (results.flag == "-1") {
                if (results.message == "NOTBINDCA") {
                    showCABind(0);
                } else {
                    GGFW.alert(results.message);
                    //parent.window.showMsg(results.message);//调用父页面的方法可以将提示信息显示在界面中间，但是会闪一下，因此不用
                    $("#validate_code").attr("src", contextPath + "/ImageCheck.jpg?d=" + new Date());//更新验证码
                }
            }

            else {
                layer.msg(results.message, 2, 1);
                if( false  ){//劳动力转移个人用户第一次登陆 时跳转到“办事指南”
                if (loginform.subsys.value == "ldl" && (results.params.LASTLOGINTIME == null || results.params.LASTLOGINTIME == undefined || results.params.LASTLOGINTIME.substring(0, 10) != results.params.CURRENTLOGINTIME.substring(0, 10)) && "01" == results.params.OperType) {//劳动力转移个人用户每天第一次登陆 时跳转到“办事指南”
                    $(".navbar", parent.document).find("tbody td#bszn").click();
                } else {
                    refresh();
                }
                //window.location.href = "http://210.76.66.109:7006/gdweb/ggfw/web/wsyw/wsyw.do";
            }
        }, beforeSend: function (XMLHttpRequest) {
            XMLHttpRequest.setRequestHeader('Token', token);
            logining = layer.load("正在登录...", 0);
        }, complete: function () {
            token = $.cookie("Token"); //更新token


            layer.close(logining);
        }
    });
}