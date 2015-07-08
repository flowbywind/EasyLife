$(function () {
    $("#app-tabselect").tabselect({
        thisClass: "on",
        boxList: ".main .list",
        eTrigger: "click",
        numShow: 0
    });

    $(".appcity-con .main").tabselect({
        thisClass: "on",
        navList: ".top li",
        boxList: ".con li",
        eTrigger: "click",
        numShow: 0
    });

    /*去掉橙色边框
	$(".theme-style-list li.list").click(function(){
			$(this).siblings(".list").removeClass("hover");
			$(this).addClass("hover")
	});*/
    $(window).useStrTemplet({ "str": "cut-textarea" });
    $(".theme-style-list.app-name-list li .imgbox").cutEvent({
        callBack: function (s) {
            $(this).find("img").attr({ 'upimg': true });
        }
    });

    $(".hand_upload,.upload_yy_btn").cutEvent({
        callBack: function (s) {
            $('.app-name-list .list .imgbox img').attr({ 'upimg': true });
        }
    });


    $("#preview_link").clickDefultEvent();


    $(".guide-img,.app_phone_bg").cutEvent({
        callBack: function (s) {
            s = $.parseJSON(s);
            $('.guide-img img').attr({ 'src': s.iphone6s, 'upimg': true });
            var $div = $(".bgdiv .imgdiv img");
            $div[0].src = s.iphone4;
            $div[1].src = s.iphone5;
            $div[2].src = s.iphone6;
            $div[3].src = s.iphone6s;
            $div[4].src = s.android;
            if ($("#preview_link").hasClass("greyColor")) {
                $("#preview_link").removeClass("greyColor");
            }
            if ($("#preview_link").hasClass("greyColor")) return false;
            $("#preview_link").click(function () {
                var winwidth = $(window).width(), //浏览器的宽度
					   domEidth = $(".preview_pop").width(),
					   boxLeft = (winwidth - domEidth) / 2;
                $("#preview_textaer").css({ "display": "block", "position": "fixed", "top": "11px", "left": boxLeft });
                $(".preview_pop").tabon({
                    on_class: "on",
                    li_nav: ".edition_ul li",
                    con_nav: ".pre_r .bgdiv"
                });
                $(".preview_pop .close").click(function () {
                    $("#preview_textaer").css("display", "none")
                });


            });
        }
    });




    var e;
    $("body").click(function () {
        $(".appcity-con .main").hide();

    })
    $(".appcity-con .link-btn").click(function (e) {
        $(".appcity-con .main").show();
        e.stopPropagation();
    });
    $(".appcity-con .main").click(function (e) {
        e.stopPropagation();
    });

    $("#select-in").change(function () {
        $("#select-form").ajaxSubmit({
            cache: false,
            success: function (data) {
            }
        })
    })

    $("#select-in2").change(function () {
        $("#select-form2").ajaxSubmit({
            cache: false,
            success: function (data) {
            }
        })
    })

    //$("#downLoad_apprq").click(function () {
    //    var param = { "MerchantId": $(this).attr("mid") };
    //    $.post("/sys/appconfig/DownLoadAppRQ", param, function (data) {
    //        data = JSON.parse(data);
    //        if (data.ret == 1) {
    //            alert(data.msg);
    //        }
    //        else {
    //            if (data != null) {
    //                clearInterval(looper);
    //                window.location.href = "/sys/appconfig/index?mid=" + mid + "&type=" + apptype;
    //            }
    //        }
    //    });
    //});

    //应用打包
    $(".app-packge").each(function () {
        $(this).on("click", function () {
            $(window).wdtWindowPop({
                width: 700,
                height: "auto",
                title: "应用打包",
                content: $("#app-packge-pop").val(),		//弹窗模板
                showCallback: function () {
                    var $contain = $("#wdtWindowOne"),
						$mask = $("#wdtDivLayer"),
						$comfirmPackge = $contain.find(".comfirm-packge"),		//应用打包
						$download = $contain.find(".download");
                    var vinfo = $("#text-versionDesc").val();
                    var version = $("#wdtWindowOne").find("#version-info");
                    var mid = version.attr("mid");
                    var apptype = version.attr("apptype");
                    $("#wdtWindowOne").find(".text-container").html("<textarea maxlength='1000'>" + version.val() + "</textarea>");
                    $comfirmPackge.bind("click", function () {
                        var desc = $("#text-versionDesc").find("textarea").val();
                        if (desc.length > 1000) {
                            commonjs.GetBtnOKHtml("版本信息输入字符不能超过1000个字", "");
                        }
                        var param = { "MerchantId": mid, "Type": apptype, "VersionDesc": $("#text-versionDesc").find("textarea").val() };
                        $.post("/sys/appconfig/SetAppPack", param, function (data) {
                            data = JSON.parse(data);
                            if (data.ret == "-1") {
                                commonjs.GetBtnOKHtml(data.msg, '');
                            }
                            else {
                                window.location.href = "/sys/appconfig/index?type=" + apptype + "&mid=" + mid;
                            }
                        });

                    })
                }
            })
        })
    })

    //客户端更新
    $(".client-update").each(function () {
        $(this).on("click", function () {
            var $data = $(this).parent();
            var $content = $("#app-update-pop");
            var $versionId = $data.attr('versionid');
            var $pushDesc = $data.attr('pushDesc');
            $('#mid', $content).val($versionId);
            $('#pushDesc', $content).html($pushDesc);

            $(window).wdtWindowPop({
                width: 700,
                height: "auto",
                title: "客户端更新",
                content: $content.html(),		//弹窗模板
                showCallback: function () {
                    debugger;
                    var $contain = $("#wdtWindowOne"),
                        $mask = $("#wdtDivLayer"),
                        $comfirmUpdate = $contain.find(".comfirm-update"),		//客户端更新
                        $download = $contain.find(".download");

                    $comfirmUpdate.bind("click", function () {
                        //异步提交表单
                        debugger;
                        $contain.find("form").ajaxSubmit({
                            cache: false,
                            success: function (data) {
                                var obj = JSON.parse(data);
                                if (obj.ret == "0") {
                                    window.location.reload();
                                    //$contain.hide();
                                    //$mask.hide();
                                    return false;
                                } else {
                                    commonjs.GetBtnOKHtml(obj.msg, '');
                                    return false;
                                }

                            }
                        })
                    })
                }
            })
        })

    });
    //查看状态
    $(".view-status").each(function () {
        $(this).on("click", function () {
            var $data = $(this).parent();
            var $download = $data.attr('download');
            $versionId = $data.attr('versionid');
            $packageTime = $data.attr('packageTime');
            $operateMan = $data.attr('operateMan');
            $isPush = $data.attr('isPush');
            $status = $data.attr('status');
            $pushDesc = $data.attr('pushDesc');
            $versionType = $data.attr('versionType');
            var $area = $('#app-view-status-pop');
            $('#mid', $area).val($versionId);
            if ($download == "") {
                $('a.download').hide();
            } else {
                $('a.download').attr('href', $download);
                $('a.download').show();
            }
            if ($versionType == "ipa") {
                var $text = $('#app-view-status-pop');
                $('#version-status').show();
                $('#version-ios').show();
                $('#version-man').html('操作人：' + $operateMan);
                $('#version-Time').html('打包时间：' + $packageTime);
                $('#version-isPush').html(($isPush == 0 ? "推送更新：否" : "推送更新：是"));
                $('#version-desc').html( $pushDesc);
                var $sel = $('#version-status select[name=status] option[value=' + $status + ']');
                $sel.siblings().removeAttr('selected');
                $sel.attr('selected', 'selected');
            } else {
                $('#version-status').hide();
                $('#version-android').show();
                $('#version-man').html('操作人：' + $operateMan);
                $('#version-Time').html('打包时间：' + $packageTime);
                $('#version-isPush').html(($isPush == 0 ? "推送更新：否" : "推送更新：是"));
                $('#version-desc').html( $pushDesc);
            }
            $(window).wdtWindowPop({
                width: 700,
                height: "auto",
                title: "查看状态",
                content: $("#app-view-status-pop").html(),		//弹窗模板
                showCallback: function () {	//弹窗回调
                    var $contain = $("#wdtWindowOne"),
                        $mask = $("#wdtDivLayer"),
                        $notifyUpdate = $contain.find(".notify-update");		//通知更新
                    $notifyUpdate.bind("click", function () {
                        $contain.find("form").ajaxSubmit({
                            cache: false,
                            success: function (data) {
                                var obj = JSON.parse(data);
                                if (obj.ret == "0") {
                                    window.location.reload();
                                } else {
                                    commonjs.GetBtnOKHtml(obj.msg, '');
                                    return false;
                                }
                            }
                        })
                    })
                }
            })
        })
    })


    if ($("#looper_pack_flag").length != 0) {
        var looper = setInterval(function () {
            var pack = $("#looper_pack_flag");
            var mid = pack.attr("mid");
            var apptype = pack.attr("apptype");
            var param = { "MerchantId": mid, "Type": apptype };
            $.post("/sys/appconfig/GetAppPackFlag", param, function (data) {
                data = JSON.parse(data);
                if (data == "0") {
                    clearInterval(looper);
                    window.location.href = "/sys/appconfig/index?mid=" + mid + "&type=" + apptype;
                }
            });
        }, 10000)
    }
});