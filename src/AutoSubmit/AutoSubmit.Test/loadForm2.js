

$(function () {
    ywmenuBind();
});
function ywmenuBind() {
    $(".accordion-toggle").click(function () {
        var ele = $($(this).attr("ref"));
        if (ele.length > 0) {
            ele.toggle();
            if (ele.is(":hidden")) {
                $(this).find("i").attr("class", "icon-plus");
            } else {
                $(this).find("i").attr("class", "icon-minus");
            }
        }
    });
}

/**
* 刷新左边菜单
* menuId 菜单ID
* menuLx 菜单显示类型， 值为1：第一次显示的菜单；值为2：第二次显示的菜单，即点“审核”等按钮后才显示的菜单 
* data 要传递的数据，刷新菜单时，同时传递所需要的数据
*/
function refreshMenu(menuId, menuLx, data) {
    var subsys = "LDL";
    ggfw_refreshMenus(menuId, subsys, menuLx, data);
}



