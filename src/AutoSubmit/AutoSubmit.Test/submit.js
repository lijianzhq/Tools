

$(function () {
    $(".ywmenu-link").click(function () {//三级业务菜单点击处理
        if (true) {
            document.linkform.cmenuid.value = $(this).attr("selfId");
            document.linkform.target = "newBusinessWin";
            document.linkform.submit();
        } else {
            GGFW.alert("您还没有登录系统，请先登录");
        }
    });

    $("#register_href").click(function () {//点击注册处理
        setTimeout(function () {
            window.parent.document.getElementById("main_content_iframe").src = contextPath + "/ggfw/web/pub/ggfw!register.do";
        }, 0);
    });

    $(".help-href").click(function () {//帮助连接点击处理
        if (true) {
            document.linkform.cmenuid.value = $(this).attr("selfId");
            //document.linkform.submit();
            //改为弹出窗
            window.open("/gdweb/ggfw/" + $(this).attr("ymhref") + "?MenuId=" + $(this).attr("selfId"), '', 'top=0, left=0, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no, fullscreen=no');
        } else {
            GGFW.alert("您还没有登录系统，请先登录");
        }
        /*
        var type = $(this).attr("atype");
        if(type == "WJXZ") { 
            document.fileForm.rightId.value = $(this).attr("selfId");
            document.fileForm.cusName.value = $(this).attr("parent");
            document.fileForm.submit();
        } else { 
            document.helpForm.rightId.value = $(this).attr("selfId");
            document.helpForm.submit();
        }*/
    });
});
        