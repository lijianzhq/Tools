

$(function () {
    if ("" != "true") {

        CFW.oWin.fnAlert("申报信息自动读取上次未提交审批内容，请检查所有信息无误后提交审批。");
        gtForm.edit.value = "true";

        ldlzy_init();
        document.getElementById("backBtn").style.display = "none";
    } else {
        gtForm.AAB080.value = "2018-05-02";
        gtForm.BBD131.value = "2018";
        //ldlzy_getzsxx();
        //ldlzy_changeBHE034_edit();
    }
    if (gtForm.readOnly.value != "true" && !CFW.oValid.fnIsNull(gtForm.BCC859.value))
        ldlzy_changeBHE034_edit();

    $("input[name='BCC903']").poshytip({
        className: 'tip-yellowsimple',
        showOn: 'focus',
        alignTo: 'target',
        alignX: 'right',
        alignY: 'center',
        offsetX: 5,
        hideTimeout: 5,
        content: '请填写补贴资金拨至的银行账户'
    });

    //提示窗口
    $('#indiApplicationWindow').fwwindow({
        title: '',
        width: 800,
        modal: true,
        closed: true,
        height: 100
    });
    //申诉窗口
    $('#shensuWindow').fwwindow({
        title: '',
        width: 800,
        modal: true,
        closed: true,
        height: 200
    });
    //验证码窗口
    $('#codeWindow').fwwindow({
        title: '',
        width: 800,
        modal: true,
        closed: true,
        height: 200
    });
    if (gtForm.SYZBS.value == "0" || gtForm.SYZBS.value == "" || gtForm.SYZBS.value == undefined) {
        $("#submitBtn").attr("disabled", "disabled");
    } else {
        $("#submitBtn").attr("disabled", false);
    }
    if (gtForm.BDCZ56.value == 1 && gtForm.BDCZ59.value == "01") {
        $("#submitBtn").attr("disabled", false);
    }
    var BCC859 = "1898841";
    if (BCC859 != "") {
        document.getElementById("codediv").style.display = "block";
    }
});


function ldlzy_back() {
    backform.action = "/gdweb/ggfw/web/wsyw/app/ldlzy/gryw/grbtsb/btxx!toQ.do";
    backform.submit();
}

function ldlzy_init() {
    var BCC859 = "1898841";
    if (BCC859 == "") {
        $("#submitBtn").attr("disabled", "disabled");
        $("#saveBtn").attr("disabled", "disabled");
    }
    if (gtForm.readOnly.value == "true") {
        $("#btn_cen").hide();
    }
    gtForm.BBD131.value = "2018";
    gtForm.AAB080.value = "2018-05-02";
}



function ldlzy_changeBHE034() {

    CFW.oGt.fnSetCombVal(gtForm.CCE029, '');
    var BHE034 = gtForm.BHE034.value;
    if (BHE034 == '01' || BHE034 == '02') {
        var arr = ['11', '12', '13', 'D'];
        CFW.oGt.fnFilter('gtForm.CCE029', arr, 1);
        CFW.oGt.fnReReadOnly(gtForm, ['CCE029']);
    } else if (BHE034 == '03') {
        var arr1 = ['11', '12', '13', '1', '2', '3', '4', '5'];
        CFW.oGt.fnFilter('gtForm.CCE029', arr1, 1);
        CFW.oGt.fnReReadOnly(gtForm, ['CCE029']);
    } else if (BHE034 == '04') {
        var arr2 = ['D', '1', '2', '3', '4', '5'];
        CFW.oGt.fnFilter('gtForm.CCE029', arr2, 1);
        CFW.oGt.fnReReadOnly(gtForm, ['CCE029']);
    }
    ldlzy_getzsxx();
}

function ldlzy_changeBHE034_edit() {
    var temp = document.gtForm.CCE029.value;


    CFW.oGt.fnSetCombVal(gtForm.CCE029, '');
    var BHE034 = gtForm.BHE034.value;
    if (BHE034 == '01' || BHE034 == '02') {
        var arr = ['11', '12', '13', 'D'];
        CFW.oGt.fnFilter('gtForm.CCE029', arr, 1);
        CFW.oGt.fnReReadOnly(gtForm, ['CCE029']);
    } else if (BHE034 == '03') {
        var arr1 = ['11', '12', '13', '1', '2', '3', '4', '5'];
        CFW.oGt.fnFilter('gtForm.CCE029', arr1, 1);
        CFW.oGt.fnReReadOnly(gtForm, ['CCE029']);
    } else if (BHE034 == '04') {
        var arr2 = ['D', '1', '2', '3', '4', '5'];
        CFW.oGt.fnFilter('gtForm.CCE029', arr2, 1);
        CFW.oGt.fnReReadOnly(gtForm, ['CCE029']);
    }
    CFW.oGt.fnSetCombVal(gtForm.CCE029, temp);
}


function ldlzy_changeCCE029() {
    ldlzy_getzsxx();
}


function ldlzy_JdGzZoom() {
    if (gtForm.BHE034.value == "") {
        CFW.oWin.fnAlert("请选择证书类别");
        return;
    }

    if (gtForm.BHE034.value == "04") {
        CFW.oWin.fnAlert("专业技术资格培训补贴暂未开展，请选择其他证书类别");
        return;
    }
    if (gtForm.BHE034.value != '04') {
        CYW.oAppComm.fnOpenJdGzFdj({ formName: 'gtForm', codeField: 'BCC867', nameField: 'BCC867NAME', codeField3: 'BHB321', codeField4: 'BHB322', isSubsidyOnly: 'true' });
        if (CFW.oValid.fnIsNull(gtForm.BCC867NAME.value))
            gtForm.BHB322.value = "";
    } else {
        CYW.oAppComm.fnOpenZygzFdj({ formName: 'gtForm', codeField: 'BCC867', nameField: 'BCC867NAME' });
    }
    ldlzy_getzsxx();
}


function ldlzy_getzsxx() {
    $("#submitBtn").attr("disabled", "disabled");
    $("#saveBtn").attr("disabled", "disabled");
    var BHE034 = gtForm.BHE034.value;//证书类别
    var CCE029 = gtForm.CCE029.value;//证书级别
    var BCC867 = gtForm.BCC867.value;//工种流水号
    var AAB080 = "2018-05-02";//申报日期
    var AAC058 = gtForm.AAC058.value;//身份证件类型
    var AAC147 = gtForm.AAC147.value;//身份证件号码
    var AAC003 = gtForm.AAC003.value;//姓名
    var BOE531 = gtForm.BOE531.value;//户口类别
    var BCC870 = gtForm.BCC870.value;//是否贫困家庭学员
    var BOD215 = gtForm.BOD215.value;//现居住地（行政区划）
    var BCC864 = gtForm.BCC864.value;//申请鉴定地
    var BCC859 = gtForm.BCC859.value;//个人补贴申请流水号
    var BHB321 = gtForm.BHB321.value;//工种别名信息维护表流水号
    var edit = gtForm.edit.value;//编辑标志


    if (CFW.oValid.fnIsNull(BCC864) || CFW.oValid.fnIsNull(BHE034) || CFW.oValid.fnIsNull(CCE029) || CFW.oValid.fnIsNull(BCC867) || CFW.oValid.fnIsNull(AAB080) || CFW.oValid.fnIsNull(AAC058) || CFW.oValid.fnIsNull(AAC147) || CFW.oValid.fnIsNull(AAC003)) {
        gtForm.BCC290.value = "";
        gtForm.BCC868.value = "";
        gtForm.BCA060.value = "0";
        gtForm.ZSBAE001.value = "";
        gtForm.BCC856.value = "";
        gtForm.SYZBS.value = "0";
        gtForm.isLackOfIndicators.value = "";
        gtForm.BCC229.value = "0";
        $("#submitBtn").attr("disabled", "disabled");
        ldlzy_jsZj();
        return;
    }

    var mparams = { 'BHE034': BHE034, 'CCE029': CCE029, 'BCC867': BCC867, 'AAB080': AAB080, 'AAC058': AAC058, 'AAC147': AAC147, 'AAC003': AAC003, 'BCC864': BCC864, 'BCC859': BCC859, 'BOE531': BOE531, 'BCC870': BCC870, 'edit': edit, 'BOD215': BOD215, 'BHB321': BHB321 };
    new Service({
        serviceId: 'btxxService',
        method: 'getZsxx',
        parameters: mparams
    }).sentAjax('', function (data) {
        $("#saveBtn").attr("disabled", false);
        $("#submitBtn").attr("disabled", false);
        gtForm.BCC290.value = data[0].BCC290;
        gtForm.BCC868.value = data[0].BCC868;
        gtForm.BCA060.value = data[0].BCC869;
        gtForm.ZSBAE001.value = data[0].ZSBAE001;
        gtForm.ACC560.value = data[0].ZSBAE001;

        gtForm.BCC229.value = data[0].BCC229;

        gtForm.BCC856.value = data[0].BCC856;
        gtForm.SYZBS.value = data[0].SY2;
        gtForm.BCEA6Z.value = data[0].BCEA6Z;
        gtForm.isLackOfIndicators.value = data[0].isLackOfIndicators;
        if (gtForm.SYZBS.value == "0" || gtForm.isLackOfIndicators.value == "true" || gtForm.isLackOfIndicators.value == "") {
            $("#submitBtn").attr("disabled", "disabled");
            if (gtForm.BDCZ56.value == 1 && gtForm.BDCZ59.value == "01") {
                $("#submitBtn").attr("disabled", false);
            }
        } else {
            $("#submitBtn").attr("disabled", false);
        }
        ldlzy_jsZj();
    }, function (Msg) {
        CFW.oWin.fnAlert(Msg);
        gtForm.BCC290.value = "";
        gtForm.BCC868.value = "";
        gtForm.BCA060.value = "0";
        gtForm.ZSBAE001.value = "";
        gtForm.BCC856.value = "";
        gtForm.SYZBS.value = "0";
        gtForm.isLackOfIndicators.value = "";
        gtForm.BCC229.value = "0";
        $("#submitBtn").attr("disabled", "disabled");
        $("#saveBtn").attr("disabled", "disabled");
        if (gtForm.BDCZ56.value == 1 && gtForm.BDCZ59.value == "01") {
            $("#submitBtn").attr("disabled", false);
        }
        ldlzy_jsZj();
    });
}


function ldlzy_jsZj() {
    var BCC229 = isNaN(gtForm.BCC229.value) ? 0 : parseInt(gtForm.BCC229.value);
    var BCA060 = isNaN(gtForm.BCA060.value) ? 0 : parseInt(gtForm.BCA060.value);
    gtForm.ZJ.value = BCC229 + BCA060;
}


function ldlzy_save() {
    //CYW.oAppComm.fnShowLoadingWindow();
    if (CFW.oGt.fnValidateForm(gtForm) == false) {
        //CYW.oAppComm.fnHideLoadingWindow();
        return;
    }
    //ldlzy_changeBCC905('01');
    //ldlzy_changeBCC905('01');
    if (gtForm.BCC865.value == "01") {
        if (gtForm.BCC901.value == "") {
            CFW.oWin.fnAlert("学习方式选择“参加培训”，培训机构必须录入");
            //CYW.oAppComm.fnHideLoadingWindow();
            return;
        }
    }
    /*if(gtForm.ZSBAE001.value.length != 2){
        if(gtForm.ZSBAE001.value != gtForm.BCC864.value){
            CFW.oWin.fnAlert("“申请补贴地”所属市跟鉴定库证书发放市必须一致");
            return ;
        }
    }*/
    if (gtForm.BDCZ56.value == 1 && gtForm.BDCZ59.value == "01") {
        $("#submitBtn").attr("disabled", false);
    }
    document.gtForm.BCC869.value = document.gtForm.BCA060.value;
    document.gtForm.BCC871.value = document.gtForm.BCC229.value;
    gtForm.AAB080.value = "2018-05-02";
    var params = CFW.oGt.fnGetForm(document.gtForm);
    /*if(!window.confirm("请确认申请信息录入正确，提交后申请信息不能修改！")){
        return;
    }*/
    $("#submitBtn").attr("disabled", "disabled");
    $("#saveBtn").attr("disabled", "disabled");
    new Service({
        serviceId: 'btxxService',
        method: 'saveTempBtxx',
        parameters: params
    }).sentAjax('', function (data) {
        $("#submitBtn").attr("disabled", false);
        $("#saveBtn").attr("disabled", false);
        CFW.oWin.fnAlert("申报信息暂存成功，核对无误后请点击“提交”按钮将申报信息提交主管部门审核！");
        document.gtForm.BCC859.value = data[0].YWLSH;
        //document.gtForm.readOnly.value = "true" ;
        document.gtForm.action = "/gdweb/ggfw/web/wsyw/app/ldlzy/gryw/grbtsb/btxx!toIu.do";
        document.gtForm.submit();
        //return;
    }, function (Msg) {
        CFW.oWin.fnAlert(Msg);
        //CYW.oAppComm.fnHideLoadingWindow();
        $("#submitBtn").attr("disabled", false);
        $("#saveBtn").attr("disabled", false);
        if (gtForm.SYZBS.value == '0' || gtForm.SYZBS.value == '' || gtForm.SYZBS.value == undefined) {
            $("#submitBtn").attr("disabled", "disabled");
        }

    }, false);
}


function ldlzy_subbefor() {
    $('#indiApplicationWindow').fwwindow('close');
    $('#shensuWindow').fwwindow('close');
    $('#codeWindow').fwwindow('open');
}
function ldlzy_submit() {
    if (CFW.oGt.fnValidateForm(gtForm) == false) {
        CYW.oAppComm.fnHideLoadingWindow();
        return;
    }
    //ldlzy_changeBCC905('01');
    if (gtForm.BCC865.value == "01") {
        if (gtForm.BCC901.value == "") {
            CFW.oWin.fnAlert("学习方式选择“参加培训”，培训机构必须录入");
            return;
        }
    }
    if (gtForm.isLackOfIndicators.value == "true") {
        CFW.oWin.fnAlert("选择的【申请补贴地】无指标，请选择【市本级】、【户籍或居住证所在区县】。深圳市申请人，申领补贴地请选择“深圳市市本级”");
    } else if (gtForm.SYZBS.value == "0") {
        CFW.oWin.fnAlert("选择的【申请补贴地】本月剩余补贴指标为0，请联系当地人社部门！联系方式见【办事指南】");
    }
    document.gtForm.BCC869.value = document.gtForm.BCA060.value;
    document.gtForm.BCC871.value = document.gtForm.BCC229.value;
    gtForm.AAB080.value = "2018-05-02";

    var vcode = document.codeform.vcode.value;		 //验证码
    if (vcode == "" || vcode == undefined) {
        alert("请输入验证码！");
        return;
    }
    document.gtForm.vcode.value = vcode;
    var params = CFW.oGt.fnGetForm(document.gtForm);

    if (gtForm.SYZBS.value != "0" && gtForm.isLackOfIndicators.value != "true") {
        if (!window.confirm("请确认申请信息录入正确，提交后申请信息不能修改！")) {
            return;
        }

        $("#submitBtn").attr("disabled", "disabled");
        $("#saveBtn").attr("disabled", "disabled");
        new Service({
            serviceId: 'btxxService',
            method: 'submitBtxx',
            parameters: params
        }).sentAjax('', function (data) {
            if (data[0].flag == "1" || data[0].flag == 1) {
                alert("操作成功");
                return;
            }
            if (data[0].SFSBKJYYC == "true") {
                document.gtForm.BCC859.value = data[0].YWLSH;
                document.gtForm.readOnly.value = "false";//不是成功提交
                $("#sbkspan").html(data[0].SBKERRMSG);
                $('#indiApplicationWindow').fwwindow('open');
                $("#submitBtn").attr("disabled", false);
                $("#saveBtn").attr("disabled", false);
            }
            else {
                //CFW.oWin.fnAlert('申请信息已经提交到'+document.gtForm.BCC864NAME.value+'人力资源和社会保障局，请于5个工作日内携带规定的资料去受理部门书面申请培训补贴！');
                document.gtForm.BCC859.value = data[0].YWLSH;
                document.gtForm.readOnly.value = "true";
                document.gtForm.action = "/gdweb/ggfw/web/wsyw/app/ldlzy/gryw/grbtsb/btxx!toTjS.do";
                document.gtForm.submit();
            }
        }, function (Msg) {
            CFW.oWin.fnAlert(Msg);
            $("#submitBtn").attr("disabled", false);
            $("#saveBtn").attr("disabled", false);
            document.codeform.vcode.value = "";
            document.gtForm.vcode.value = "";
            $('#codeWindow').fwwindow('close');
            $("#validate_code").attr("src", "/gdweb/ImageCheck.jpg?d=" + new Date());//更新验证码
        }, false);
    } else {
        new Service({
            serviceId: 'btxxService',
            method: 'saveTempBtxx',
            parameters: params
        }).sentAjax('', function (data) {
            //alert("操作成功");
            document.gtForm.BCC859.value = data[0].YWLSH;
            //document.gtForm.readOnly.value = "true" ;
            document.gtForm.action = "/gdweb/ggfw/web/wsyw/app/ldlzy/gryw/grbtsb/btxx!toIu.do";
            document.gtForm.submit();
            //return;
        }, function (Msg) {
            CFW.oWin.fnAlert(Msg);
        }, false);
    }
}


function ldlzy_jddZoom() {
    //判断指标是否锁定，锁定应该不允许修改补贴申请地
    if (ldlzy_checkzbsd()) {
        CFW.oWin.fnAlert("个人补贴申请指标已锁定，不能更改补贴申请地！");
        return;
    } else {
        CYW.oAppComm.fnOpenSubCenterFdj({ formName: 'gtForm', codeField: 'BCC864', nameField: 'BCC864NAME', treeWhere: " BAE001 like '44%' and BAE001 <> '44'  and length(BAE001)<7 and BAE001<>'4499' ", isOnlyEndNode: "true", gltWhere: " length(BAE001) not in(2,4) and length(BAE001)<7 " });
        ldlzy_getzsxx();
    }
}

/**
 * 社保卡发卡地触发函数
 */
function ldlzy_changeBCC905(type) {
    //$("#submitBtn").attr("disabled",false);
    //$("#saveBtn").attr("disabled",false);
    var AAC147 = document.gtForm.AAC147.value;
    var AAC003 = document.gtForm.AAC003.value;
    var BCC905 = document.gtForm.BCC905.value;
    var AAC012 = document.gtForm.AAC012.value;
    var BCC857 = "2963899";
    var mparams = { 'AAC147': AAC147, 'AAC003': AAC003, 'BCC905': BCC905, 'AAC012': AAC012 };
    new Service({
        serviceId: 'grxxService',
        method: 'getSbxx',
        parameters: mparams
    }).sentAjax('', function (data) {
        if (type == "02") {
            gtForm.BCC903.value = data[0].BCC903;
            CFW.oGt.fnSetCombVal(gtForm.BCC902, data[0].BCC902);
            CFW.oGt.fnSetCombVal(gtForm.AAC005, data[0].AAC005);
            CFW.oGt.fnSetCombVal(gtForm.AAC009, data[0].AAC009);
            if (BCC857 == "") {
                gtForm.AAC010.value = data[0].AAC010;
            }
        }
        $("#submitBtn").attr("disabled", false);
        $("#saveBtn").attr("disabled", false);
    }, function (Msg) {
        CFW.oWin.fnAlert(Msg);
        $("#submitBtn").attr("disabled", "disabled");
        $("#saveBtn").attr("disabled", "disabled");
        return;
    });
}


/**
 * 提示操作窗口关闭
 */
function ldlzy_close() {
    $('#indiApplicationWindow').fwwindow('close');
}

/**
 * “提交申诉”按钮
 */
function ldlzy_ss_open() {
    $('#indiApplicationWindow').fwwindow('close');
    $('#shensuWindow').fwwindow('open');
    document.ssform.AAC003.value = document.gtForm.AAC003.value;
    document.ssform.AAE005.value = document.gtForm.AAC067.value;
}
/**
 * 提交申诉
 */
function ldlzy_ss_submit() {
    if (CFW.oGt.fnValidateForm(ssform) == false) {
        return;
    }
    document.ssform.BCC859.value = document.gtForm.BCC859.value;
    document.ssform.AAC147.value = document.gtForm.AAC147.value;
    var params = CFW.oGt.fnGetForm(document.ssform);
    new Service({
        serviceId: 'btxxService',
        method: 'saveSsxx',
        parameters: params
    }).sentAjax('', function (data) {
        CFW.oWin.fnAlert("申诉已成功提交！");
        document.gtForm.action = "/gdweb/ggfw/web/wsyw/app/ldlzy/gryw/grbtsb/btxx!toIu.do";
        document.gtForm.submit();
    }, function (Msg) {
        CFW.oWin.fnAlert(Msg);

    }, false);
}
/**
 * 申诉窗口取消按钮
 */
function ldlzy_ss_close() {
    $('#shensuWindow').fwwindow('close');
}
/**
 * 关闭按钮
 */
function ldlzy_code_close() {
    $('#codeWindow').fwwindow('close');
}
/**
 * 指标是否锁定 true为锁定
 */
function ldlzy_checkzbsd() {
    var BCC859 = document.gtForm.BCC859.value;
    var SDFLAG = '0';
    if (!CFW.oValid.fnIsNull(BCC859)) {
        var params = CFW.oGt.fnGetForm(document.gtForm);
        new Service({
            serviceId: 'btxxService',
            method: 'checkzbsd',
            parameters: params
        }).sentAjax('', function (data) {
            SDFLAG = data[0].SDFLAG;
        }, function (Msg) {
            CFW.oWin.fnAlert(Msg);

        }, false);
    }
    if (SDFLAG != '0') {
        return true;
    }
    return false;
}
//更换校验码
function _fnNewImage() {
    $("#validate_code").attr("src", contextPath + "/ImageCheck.jpg?d=" + new Date());
}