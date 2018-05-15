

var isEncrypty = "1";
var subsys = "ldl";
$(function () {


    //处理placeholder
    $(".text-box").each(function () {
        if ($(this).val() != "") {
            $(this).parent().find(".placeholder").hide();
        }
    });
    /*placeholder*/
    $("input").focus(function () {
        $(this).parent().find(".placeholder").hide();
    });
    $(".placeholder").click(function () {
        $(this).parent().find("input").focus();
        $(this).hide();
    });
    $("input").blur(function () {
        if (!$(this).val()) {
            $(this).parent().find(".placeholder").show();
        }
    });
    //处理导航条上的个人信息栏
    if (false) {
        changeHeaderLoginInfo();
    } else {
        $("#header_login", window.parent.document).html("");
        $("#header_login", window.parent.document).hide();
    }

    //验证码点击
    $("#validate_code").click(function () {
        $(this).attr("src", contextPath + "/ImageCheck.jpg?d=" + new Date());
    });
    //假如子系统是专业技术人才管理系统zyjs，那么隐藏CA登陆
    if ("zyjs" == subsys) {
        $(".checkbox").hide();
        $("#xzyjsz").show();
    }

    //登录按钮点击，=====登录开始======
    $("#loginBtn").click(function () {
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
                    //if( false  ){//劳动力转移个人用户第一次登陆 时跳转到“办事指南”
                    if (loginform.subsys.value == "ldl" && (results.params.LASTLOGINTIME == null || results.params.LASTLOGINTIME == undefined || results.params.LASTLOGINTIME.substring(0, 10) != results.params.CURRENTLOGINTIME.substring(0, 10)) && "01" == results.params.OperType) {//劳动力转移个人用户每天第一次登陆 时跳转到“办事指南”
                        $(".navbar", parent.document).find("tbody td#bszn").click();
                    } else {
                        refresh();
                    }

                }
            }, beforeSend: function (XMLHttpRequest) {
                XMLHttpRequest.setRequestHeader('Token', token);
                logining = layer.load("正在登录...", 0);
            }, complete: function () {
                token = $.cookie("Token"); //更新token


                layer.close(logining);
            }
        });
        return false;
    });
    //登录结束

});

//刷新页面
function refresh() {
    setTimeout(function () {
        //window.location.reload();
        parent.window.refresh();
    }, 1000);
}

//退出系统
$("#logout_href").click(function () {
    var logining;
    GGFW.confirm("确定退出系统吗？", function () {
        $.ajax({
            url: contextPath + "/ajaxlogin!logout.do",
            type: "post",
            data: "sessionid=7mMf5HElLWSBFP8qNCpQ9tVWnqfGW_c08Uzi7a7_Iz-JP_Go_oGY!1853443157!1525248454949",
            dataType: "json",
            success: function (results) {
                if (results.flag == "-1") {
                    GGFW.alert(results.message);
                } else {
                    layer.msg(results.message, 2, 1);
                    refresh();

                }
            }, beforeSend: function (XMLHttpRequest) {
                XMLHttpRequest.setRequestHeader('Token', token);
                logining = layer.load("正在注销...", 0);
            }, complete: function () {
                token = $.cookie("Token"); //更新token
                layer.close(logining);
            }
        });
    });



});


/*CA登录校验 */
function checkCA() {
    if (!$.browser.msie) {
        $("#isCa").attr("checked", false);
        GGFW.alert("非IE浏览器不能正常加载CA证书驱动，请使用IE浏览器");
    }
    if ($("#isCa").attr("checked")) {
        try {
            if (!isPKIInstalled()) {
                GGFW.alert("请先安装网证通CA证书登录控件");
                $("#isCa").attr("checked", false);
                return false;
            }
            var hasCert = isHasCert(3);
            if (hasCert == false) {
                $("#isCa").attr("checked", false);
                GGFW.alert("请插入网证通CA证书");
                return false;
            }
            /*
            var password = document.loginform.password.value;
            if(password == "" || password == undefined) {
                $("#isCa").attr("checked",false);
                GGFW.alert("请输入证书密码");
                document.loginform.password.focus();
                return false;
            }
            loginform.signature.value = signPKCS7ByPwd(loginform.ticket.value,false,document.loginform.password.value);//带密码的PKCS7签名
            if(loginform.signature.value=="null"||loginform.signature.value==""||loginform.signature.value==null){
                $("#isCa").attr("checked",false);
                return false;
            }*/
            return true;
        }
        catch (e) {
            return false;
        }
    }
    return true;
}

//改变导航条的用户信息
function changeHeaderLoginInfo() {
    if ($("#header_login #user", window.parent.document).length > 0) { //已经有个人栏信息了
        return;
    }
    var blsxCount = 0;
    var messageCount = 0;
    var html = "<span id='user'>" +
        "欢迎您，<a href='javascript:void(0)' class='un'><strong></strong>&nbsp;<i class='icon-down'></i></a>" +
        "<div id='userMenu' class='userMenu' style='display: none;'>";

    html += "<ul><li><a href='javascript:showSchedule('ldl');'>办理事项跟踪</a></li>";
    if (messageCount > 0)
        html += "<li class='nl'><a href='javascript:showMessage();'>消息</a></li>";
    html += "<li class='nl'><a href='javascript:showPwChange();'>密码修改</a></li></ul>" +
        "</div></span>|<a id='nav_href_logout' href='javascript:logout()'>退出系统</a>";
    var header_login = $("#header_login", window.parent.document);
    header_login.html(html);
    //给个人信息栏注册事件处理
    $("#user", window.parent.document).mouseover(function () {
        $("#userMenu", window.parent.document).show();
    });
    $("#user", window.parent.document).mouseout(function () {
        $("#userMenu", window.parent.document).hide();
    });
    header_login.show();

}

/**
 * 展示单位信息
 */
function dwxxwh(subsys) {
    $.layer({
        type: 2,
        shade: [0.5, '#000', true],
        shadeClose: true,
        fix: true,
        title: ["单位信息维护", true],
        iframe: { src: contextPath + "/ggfw/web/wsyw/app/zyjsrcgl/dwxxwh/dwxxwh.do" },
        area: ['800px', '90%'],
        offset: ['50px', ''],
        success: function () { layer.shift('top', 400) }
    });
}