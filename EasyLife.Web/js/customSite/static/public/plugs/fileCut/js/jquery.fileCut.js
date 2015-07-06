; (function ($) {
    $.fn.wdtWindowPop = function (options) {
        var $this = $(this), _this = this;
        var opts = $.extend({
            popId: "wdtWindowOne",
            closeBtn: "close",
            tempurl: "",
            content: "这里是内容",
            title: "弹窗标题",
            isTitleTag: false,		//有标题样式?
            showTime: 500,
            width: 500,
            height: 300,
            isCloseBtn: true,		//带关闭按钮？
            isTitle: true,
            isReady: true,
            isLayer: true,			//带遮罩层？
            isAjax: false,			//ajax提交？
            ajaxUrl: "",
            closeFlag: "",
            draggle: "",
            insertIframe: "",
            showCallback: function () { },
            hideCallback: function () { }
        }, options);
        if ($this.size() == 0) return false;

        var aliasId = "#" + opts.popId;
        var title = opts.isTitle ? opts.title : "";
        var data_Class = opts.isTitleTag ? "tcnewcle tcnewcleno" : "tcnewcle";
        var closehtml = opts.isCloseBtn ? "<a href=\"javascript:\" class=\"" + data_Class + "\" data=\"" + opts.closeBtn + "\">X</a>" : "";
        var bodyheight = $(window).height() + "px";
        var divLayer = $("<div></div>").attr("id", "wdtDivLayer").css({ "background": "#000", "opacity": 0.4, "width": "100%", "height": "2000px" }).hide();
        var iframeLayer = $("<iframe></iframe").css({ "width": "100%", "height": "100%", "opacity": 0, "background": "#fff", "border": 0 });
        var boxWrap = $("<div></div>").attr("id", opts.popId).addClass("tcnewbox").hide();

        divLayer.append(iframeLayer);
        if (opts.isTitleTag) {
            boxWrap.html("<div class=\"tcnewtop tcnewtop_no\">" + closehtml + "</div><div class=\"tcnewbd\"></div>");
        } else {
            boxWrap.html("<div class=\"tcnewtop\">" + closehtml + "<h2 class=\"tcnewtit\"></h2></div><div class=\"tcnewbd\"></div>");
        }
        if (opts.isReady && $(aliasId).length == 0) $("body").append(boxWrap);
        if (opts.isLayer && $("#wdtDivLayer").length == 0) $("body").append(divLayer);

        var $body = $(aliasId + " .tcnewbd"), $titleLabel = $(aliasId + " .tcnewtit");

        $titleLabel.html(title);

        var hasWdtSalesFrame = 0;
        if (opts.insertIframe != "") {
            var windowStr = window.parent,
				$iframeParent = $(windowStr),							//父级
				$iframeParentDocument = $(window.parent.document),		//父级
				windowHeight = $(window.parent).height(),				//父级可视高度				***
				$iframe = $iframeParent.find("#iframeId"),				//获取iframe.
				$parentTop = $iframeParentDocument.find(".top"),		//top 高度						***
				parentTopH = $parentTop.height(),
				iframeViewH = windowHeight - parentTopH - 36;			//36 是margin值 由于某些原因 不能写	object	

            if (hasWdtSalesFrame == 0) {
                var iframeH = $(window).height() + 60;
                $iframeParentDocument.find("#frameBox").height(iframeH);
            }
            hasWdtSalesFrame = 1;										//网店通的标识
        }

        var initLocationEvent = function () {
            var $aliasId = $(aliasId);
            $aliasId.css({ "width": opts.width, "height": opts.height, "z-index": 9999, "position": "fixed" });

            if (hasWdtSalesFrame == 1) {
                $aliasId.css({ "position": "absolute" });
                //var _scroll_top = parent.document.documentElement.scrollTop || parent.document.body.scrollTop;
                $aliasId.find("form").css({ "padding": "5px 20px", "position": "relative" });		//适配选取错乱
                var _scroll_top = $(parent).scrollTop();
                var top = (iframeViewH - $(aliasId).outerHeight()) / 2 + _scroll_top;			//
                var left = ($(window).outerWidth() - $(aliasId).outerWidth()) / 2;
                $aliasId.css({ "top": top + "px", "left": left + "px" });
                $("#wdtDivLayer").css({ "top": "0px", "position": "fixed" });
            } else {
                var top = ($(window).outerHeight() - $(aliasId).outerHeight()) / 2;
                var left = ($(window).outerWidth() - $(aliasId).outerWidth()) / 2;
                $aliasId.css({ "top": top + "px", "left": left + "px" });
                $("#wdtDivLayer").css({ "top": "0px", "position": "fixed" });

            }
        }

        var showLayerEvent = function () {
            initLocationEvent();
            $(aliasId).fadeIn(opts.showTime);
            $("#wdtDivLayer").show();
            return false;
        }

        var closeLayerEvent = function () {
            //最后一个层才隐藏遮罩
            if ($(".tcnewbox").length == 1) {
                $(aliasId).fadeOut(opts.showTime);
                $("#wdtDivLayer").hide();
            } else {
                $(aliasId).fadeOut(opts.showTime).remove();
                $(".tcnewbox").last().show();
            }

            if ($(".cut-laywer").length) {
                $(".cut-laywer").remove();
            }

            setTimeout(function () { opts.hideCallback($body) }, opts.showTime);
            return false;
        }
        var hideLayerEvent = function () {
            closeLayerEvent();
            opts.hideCallback($body);
            return false;
        }
        var sendAjaxEvent = function () {
            //不是ajax提交 刷新页面
            if (!opts.isAjax) {
                window.location.href = opts.ajaxUrl;
                return false;
            }
            $.ajax({
                url: opts.ajaxUrl,
                type: "GET",
                dataType: "json",
                beforeSend: function () {
                    $(aliasId + ".tcnewbd").html('<table width="100%" height="150"><tr><td align="center"><img src="http://s0.55tuanimg.com/themes/default/images/static/img/55pic/newfivethree/css/img/loading.gif" title="处理中"/><br/>处理中.....</td></tr></table>');
                },
                success: function (msg) {
                    if (msg.flag) hideLayerEvent();
                    return false;
                },
                error: function (msg) {
                    return false;
                }
            });
        }
        if (opts.tempurl) {
            $body.load(opts.tempurl, function () {
                opts.showCallback($body);
                if (opts.isAjax) $("#okbtn").bind("click", sendAjaxEvent);
            });
        } else {
            $body.html(opts.content);
            opts.showCallback($body);
            //加入拖拽排序
            if (opts.draggle) {
                $(opts.draggle).sortable({
                    cursor: "move",
                    revert: false,
                    forceHelperSize: true,
                    placeholder: 'ui-sortable-placeholder',
                    forcePlaceholderSize: true,
                    tolerance: 'pointer',
                    containment: '.edit-mode-list',
                    scroll: true,
                    stop: function (event, ui) {
                        var index = ui.item.attr("id");
                        index = $("#wdtWindowOne .edit-mode-list li").index($("#" + index));
                        var count = $("#wdtWindowOne .edit-mode-list li").length;
                        var poplistli = $("#wdtWindowOne .edit-mode-list li");
                        if (index == 0) {
                            poplistli.eq(0).find(".sort-up").attr("style", "display:none;");
                            poplistli.eq(0).find(".sort-down").removeAttr("style");
                            poplistli.eq(1).find(".sort-up,.sort_down").removeAttr("style");
                        } else {
                            if (index == (count - 1)) {
                                poplistli.eq(count - 1).find(".sort-down").attr("style", "display:none;");
                                poplistli.eq(count - 1).find(".sort-up").removeAttr("style");
                                poplistli.eq(count - 2).find(".sort-down,.sort-up").removeAttr("style");
                            } else {
                                poplistli.eq(index).find(".sort-down").removeAttr("style");
                                poplistli.eq(index).find(".sort-up").removeAttr("style");
                                poplistli.eq(0).find(".sort-up").attr("style", "display:none;");
                                poplistli.eq(0).find(".sort-down").removeAttr("style");
                                poplistli.eq(count - 1).find(".sort-down").attr("style", "display:none;");
                                poplistli.eq(count - 1).find(".sort-up").removeAttr("style");
                            }
                        }

                    }
                });
            }
            $("#okbtn").bind("click", sendAjaxEvent);
        }

        showLayerEvent();
        $(window).bind("resize", initLocationEvent);
        $(aliasId + "[data='" + opts.closeBtn + "']").bind("click", closeLayerEvent);
        $(aliasId + " [data='" + opts.closeBtn + "']").bind("click", closeLayerEvent);
    };

    //预览插件
    $.fn.uploadPreview = function (opts) {
        var _self = this,
			_this = $(this);
        opts = $.extend({
            cutType: "",				//类型标识： bg =  背景图     guide = 引导图    ico = 图标
            cutPosition: "0",			//放置的位置 默认为0；
            cutSize: "",
            cutRange: "",
            popId: "",
            ImgType: ["gif", "jpeg", "jpg", "bmp", "png"],
            maxArea: "",
            alertFlag: "0",
            callBack: function () { }
        }, opts || {}
		);
        var $popId = $("#" + opts.popId),								//主要用途识别弹层
			$up = $popId.find("#up"),
			$previewBox = $popId.find(".preview-box"),
			$previewImg = $popId.find("#preview-img"),
			$previewArea = $popId.find(".preview-area"),
			$processBar = $previewBox.find(".cut-process-bar"),			//进度提示
			$messageBar = $popId.find(".cut-message-bar"),					//信息提示
			maxArea = opts.maxArea,									//最大尺寸限制
			imgTypeStr = [],												//上传图片类型
			bgStr = "url(http://r0.55.com/wdtres/wdtF2E/customSite/static/pagemanager/cut-box-bg.jpg)";//图片背景

        //修正可上传的图片类型
        for (var i = 0, len = opts.ImgType.length; i < len; i++) {
            var tempStr = opts.ImgType[i].toLowerCase();
            if (tempStr.indexOf("jpg") != -1 || tempStr.indexOf("jpeg") != -1) {
                imgTypeStr.push("image/jpeg");
            }
            if (tempStr.indexOf("png") != -1) {
                imgTypeStr.push("image/png");
            }
            if (tempStr.indexOf("gif") != -1) {
                imgTypeStr.push("image/gif");
            }
        }
        //写入类型
        if (imgTypeStr.length != 0) {
            imgTypeStr.join(",");
            $up.attr("accept", imgTypeStr);
        }


        _this.change(function (e) {
            var __this = this,
				img_preview = "";
            if (this.value) {
                var $cutLawyer = $(".cut-laywer"),
					cutLen = $cutLawyer.length;
                //判断图片类型：
                if (!RegExp("\.(" + opts.ImgType.join("|") + ")$", "i").test(this.value.toLowerCase())) {
                    //图片格式错误，请上传png格式图片
                    $messageBar.html("图片格式错误，请上传 " + opts.ImgType.join(",") + " 格式图片").show();
                    $previewBox.css({ "background": bgStr });
                    this.value = "";
                    if (cutLen) { $cutLawyer.hide() };
                    return false;
                }
                if (window.FileReader) {  		//HTML5支持
                    var maxSize = parseInt(opts.cutSize) * 1024,		//上传最大值：K
						rangeArr = opts.cutRange.split("|");
                    maxRangeW = parseInt(rangeArr[0]),						//上传最大宽 ，高
                    maxRangeH = parseInt(rangeArr[1]),
                interVal = "";
                    if (maxSize < __this.files[0].size) {
                        maxSize = parseInt(maxSize / 1024 / 1024);
                        //请上传小于10M的png图片
                        $messageBar.html("请上传小于" + maxSize + "M 的 " + opts.ImgType.join(",") + " 图片").show();
                        $previewBox.css({ "background": bgStr });
                        if (cutLen) { $cutLawyer.hide() };
                        return false;
                    }

                    if ($previewImg.length) {
                        $previewImg.remove();
                        var str = "<img id='preview-img' style='display:none;'/>";
                        $previewArea.html(str);
                    }

                    //哈希计算
                    var hashCaculator = function () {
                        var hashFileReader = new FileReader(),
							$newHash = $popId.find("#new-hash-code"),
							blobSlice = File.prototype.mozSlice || File.prototype.webkitSlice || File.prototype.slice,
							file = __this.files[0], chunkSize = 2097152,
							// read in chunks of 2MB
							chunks = Math.ceil(file.size / chunkSize),
							currentChunk = 0,
							spark = new SparkMD5();

                        hashFileReader.onload = function (e) {
                            //console.log("read chunk nr", currentChunk + 1, "of", chunks);
                            spark.appendBinary(e.target.result);
                            // append binary string
                            currentChunk++;

                            if (currentChunk < chunks) {
                                loadNext();
                            } else {
                                var yy = new Date().getTime();
                                //console.log("finished loading");
                                $newHash.val(spark.end())
                                //console.info("computed hash", spark.end());
                                // 哈希计算结束
                            }
                        };

                        function loadNext() {
                            var start = currentChunk * chunkSize, end = start + chunkSize >= file.size ? file.size : start + chunkSize;

                            hashFileReader.readAsText(blobSlice.call(file, start, end));
                        }
                        loadNext();
                    }
                    var afterRander = function () {
                        if (img_preview.src.indexOf("undefined") == -1) {
                            //console.log(img_preview.naturalHeight)
                            clearInterval(interVal);
                            $previewBox.css("background", "#fff");
                            var imgWidth = parseInt(img_preview.naturalWidth),		//读取原始图片的宽度，高度
								imgHeight = parseInt(img_preview.naturalHeight),
								imgFlag = "11";								//图片尺寸是否满足标识：11 宽高都满足 10 宽满足 00 都不满足
                            //判断宽高是否符合

                            if (opts.alertFlag == "1") {
                                if (maxRangeW > imgWidth || maxRangeH > imgHeight) { 		//宽高都不足的情况



                                    //上传图片尺寸不足，请上传大于1080*1920px图片，目前图片尺寸为512*512px
                                    $messageBar.html("上传图片尺寸不足。请上传大于 " + maxRangeW + "*" + maxRangeH
                                                       + " 的图片，目前尺寸为：" + imgWidth + "*" + imgHeight + "px").show();
                                    $previewBox.css({ "background": bgStr });
                                    if (cutLen) { $cutLawyer.hide() };
                                    return false;
                                } else {
                                    $messageBar.html("").hide();
                                }
                            } else {
                                $messageBar.html("").hide();
                            }

                            if (maxRangeW > imgWidth && maxRangeH > imgHeight) { 		//宽高都不足的情况
                                if (imgWidth >= $previewBox.width() || imgHeight >= $previewBox.height()) {	//大于展示区?
                                    imgFlag = "center";
                                } else {
                                    imgFlag = "00";
                                }

                            } else if (maxRangeW > imgWidth) {							//宽不足的情况
                                imgFlag = "01";
                            } else if (maxRangeH > imgHeight) {							//高不足的情况
                                imgFlag = "10";
                            } else {
                                imgFlag = "11";
                            }
                            if (maxRangeW == 50) {									//针对icon 做优化
                                imgFlag = "50";
                            }
                            if (maxRangeW == 50 && maxRangeW == imgWidth && maxRangeH == imgHeight) {	//icon 特殊优化
                                imgFlag = "00";
                            }
                            //准备图片所需要的信息
                            var cutScale = 0, rateStr = "", rate = 0, viewW = 0, viewH = 0, rangeW = 0, rangeH = 0;
                            switch (imgFlag) {
                                case "00":
                                    cutScale = 1;
                                    rateStr = "1:1";
                                    viewW = imgWidth;								//preview-area，img图片 的宽高
                                    viewH = imgHeight;
                                    rangeW = imgWidth;								//切割区域的宽高
                                    rangeH = imgHeight;
                                    break;
                                case "01":		//宽不满足

                                    cutScale = imgWidth / 600 > imgHeight / 345 ? imgWidth / 600 : imgHeight / 345;  	//获取比例值
                                    rateStr = rangeArr[0] + ":" + rangeArr[1];
                                    rate = maxRangeW - maxRangeH > 0 ? parseInt(maxRangeW / maxRangeH) : maxRangeH / maxRangeW;
                                    viewW = parseInt(imgWidth / cutScale);
                                    viewH = parseInt(imgHeight / cutScale);
                                    rangeW = viewW;
                                    rangeH = parseInt(viewH / rate);
                                    break;
                                case "10":		//高不满足
                                    cutScale = imgWidth / 600 > imgHeight / 345 ? imgWidth / 600 : imgHeight / 345;  	//获取比例值
                                    rateStr = rangeArr[0] + ":" + rangeArr[1];
                                    rate = maxRangeH / maxRangeW;
                                    viewW = parseInt(imgWidth / cutScale);
                                    viewH = parseInt(imgHeight / cutScale);
                                    rangeW = parseInt(viewW / rate);
                                    rangeH = viewH;
                                    break;
                                case "11":
                                    cutScale = imgWidth / 600 > imgHeight / 345 ? imgWidth / 600 : imgHeight / 345;  	//获取比例值
                                    rateStr = rangeArr[0] + ":" + rangeArr[1];
                                    viewW = parseInt(imgWidth / cutScale);
                                    viewH = parseInt(imgHeight / cutScale);
                                    rangeW = parseInt(maxRangeW / cutScale);										//显示在图上的切割区
                                    rangeH = parseInt(maxRangeH / cutScale);
                                    break;
                                case "50":
                                    cutScale = imgWidth / 600 > imgHeight / 345 ? imgWidth / 600 : imgHeight / 345;  	//获取比例值
                                    rateStr = "1:1";
                                    viewW = parseInt(imgWidth / cutScale);
                                    viewH = parseInt(imgHeight / cutScale);
                                    rangeW = 50;										//显示在图上的切割区
                                    rangeH = 50;
                                    break;
                                case "center":
                                    cutScale = imgWidth / 600 > imgHeight / 345 ? imgWidth / 600 : imgHeight / 345;  	//获取比例值
                                    heightRate = parseInt(maxRangeH / imgHeight);
                                    rateStr = "1:1";
                                    viewW = parseInt(imgWidth / cutScale);
                                    viewH = parseInt(imgHeight / cutScale);
                                    rangeW = viewW;										//显示在图上的切割区
                                    rangeH = viewH / heightRate;
                                    break;
                            }

                            $cutImgOffset = $popId.find("#cut-img-offset");							//偏移坐标DOM
                            $cutRange = $popId.find("#cut-range");									//上传宽*高DOM
                            $previewArea.css({ "width": viewW + "px", "height": viewH + "px" })		//展示层动态变化
                            $previewBox.css("background", "#fff");						//背景空白
                            $(img_preview).css({ "width": viewW + "px", "height": viewH + "px" }).show();

                            var getData = function (img, selection) {
                                var selectionX = selection.x1,							//裁剪坐标x1，y1
									selectionY = selection.y1,
									totalTempX = selectionX + selection.width,				//预览图区域总长度
									totalTempY = selectionY + selection.height,
									destX = totalTempX - imgWidth,						//与图片长度的差值
									destY = totalTempY - imgHeight,
									realX = 0, realY = 0;								//真实坐标

                                if (destX > 0) {
                                    realX = selectionX - destX;
                                } else {
                                    realX = selectionX;
                                }
                                if (destY > 0) {
                                    realY = selectionY - destY;
                                } else {
                                    realY = selectionY;
                                }
                                $cutImgOffset.val(realX + "|" + realY);								//偏移坐标
                                $cutRange.val(selection.width + "|" + selection.height);			//上传宽*高	

                            }

                            $(img_preview).imgAreaSelect({
                                selectionOpacity: 0.2,
                                imageWidth: imgWidth,
                                imageHeight: imgHeight,
                                aspectRatio: rateStr,		//宽高比
                                resizable: true,		//固定
                                minWidth: rangeW,		//最小裁剪值
                                minHeight: rangeH,
                                parent: "#cut-form",	//相对父路径
                                x1: 0,
                                y1: 0,
                                x2: rangeW * cutScale,
                                y2: rangeH * cutScale,
                                show: true,
                                handles: true,
                                onInit: function (img, selection) {
                                    getData(img, selection);
                                },
                                onSelectEnd: function (img, selection) {
                                    getData(img, selection);
                                }
                            });
                            /*************哈希计算***************/
                            hashCaculator();
                        }
                    }


                    $previewBox.css("background", "url(http://s1.55tuanimg.com/55F2E/static/public/img/loading.gif) center center no-repeat");
                    img_preview = $popId.find("#preview-img").get(0);		//获取展示区域	
                    var reader = new FileReader();
                    img_preview.src = "";
                    reader.onload = function (evt) {
                        img_preview.src = evt.target.result;
                    }

                    img_preview.src = reader.readAsDataURL(__this.files[0]);

                    interVal = setInterval(function () {
                        afterRander();
                    }, 1000)

                    return false;

                } else {							//不支持
                    $messageBar.html("本功能暂不支持ie10以下浏览器,请使用其他高级浏览器操作").show();
                    $previewBox.css({ "background": bgStr });
                    return false;
                }
            }
        })
    }

    $.fn.cutEvent = function (options) {				//触发按钮
        var $this = $(this);
        if (!$this.length) return false;
        var opts = $.extend({
            cutTextarea: "#cut-textarea",				//模板区域
            insertIframe: "",
            callBack: function () { }						//回调函数（主要用于图标）
        }, options);
        var cutType = $this.attr("cutType"),			//元素类型       背景 cut-bg   引导图 cut-guide   图标cut-ico 
			cutTitle = $this.attr("cutTitle"),
			cutPosition = parseInt($this.attr("cutPosition")),	//元素的位置
			cutSize = $this.attr("cutMaxSize"),			//元素的大小
			sendUrl = $this.attr("sendUrl"),
			popId = cutType == "icon" ? "wdtWindowIco" : "wdtWindowOne",
			ImgType = typeof $this.attr("imgType") != "undefined" ? $this.attr("imgType").split("|") : ["jpg", "png", "gif", "jpeg"],
			oldHashCode = typeof $this.attr("oldHashCode") != "undefined" ? $this.attr("oldHashCode") : "",			//原图片哈希
			oldSourceImg = typeof $this.attr("oldSourceImg") != "undefined" ? $this.attr("oldSourceImg") : "",		//原图片地址
			alertFlag = $this.attr("alertFlag") == "1" ? "1" : "0",	//是否限制尺寸	
			bgStr = "url(http://r0.55.com/wdtres/wdtF2E/customSite/static/pagemanager/cut-box-bg.jpg)";			//背景图地址
        $this.bind("click", function () {
            if ($this.parents(".tcnewbox").length != 0) {
                $this.parents(".tcnewbox").hide();
            }
            $(window).wdtWindowPop({
                width: 650,
                height: "auto",
                title: cutTitle,
                popId: popId,
                content: $(opts.cutTextarea).val(),		//弹窗模板
                insertIframe: opts.insertIframe,
                showCallback: function () {	//弹窗
                    var $popId = $("#" + popId),
						$previewBox = $popId.find(".preview-box"),
						$previewArea = $popId.find(".preview-area"),
						$processBar = $previewBox.find(".cut-process-bar"),
						$messageBar = $popId.find(".cut-message-bar"),
						cutRange = $this.attr("cutRange");		//元素的切割区

                    $("#" + popId).find(".upload-input").uploadPreview({
                        cutType: cutType,
                        cutPosition: cutPosition,
                        cutSize: cutSize,
                        cutRange: cutRange,
                        popId: popId,
                        alertFlag: alertFlag,
                        ImgType: ImgType,
                        callBack: opts.callBack
                    });

                    $("#" + popId).find(".pop-cut-ok").bind("click", function () {
                        var $previewImg = $("#preview-img");
                        if (!$previewImg.attr("src")) {
                            $messageBar.html("还没有上传图片哦").show();
                            $previewBox.css({ "background": bgStr });
                            return false;
                        }
                        if (!$(".cut-laywer:visible").length) {
                            if ($(this).attr("continue") == "0") {
                                $messageBar.html("上传中 请稍后").show();
                            } else {
                                if ($previewImg.is(":hidden")) {
                                    $messageBar.html("还没有上传图片哦").show();
                                    $previewBox.css({ "background": bgStr });
                                } else {
                                    $messageBar.html("还没有选取区域哦").show();
                                    $previewBox.css({ "background": "#fff" });
                                }
                            }
                            return false;
                        }


                        //关闭窗口		
                        var closeCutWindow = function () {
                            var $tcnewbox = $(".tcnewbox"),
								boxlen = $tcnewbox.length;
                            if (boxlen == 1) {
                                $popId.hide();
                                $("#wdtDivLayer").hide();
                            } else {
                                $tcnewbox.eq(boxlen - 2).show();
                                $popId.remove();
                            }
                            $(".cut-laywer").remove();
                            $(".imgareaselect-outer").remove();
                        }

                        var comfirmCallback = function (data) {
                            var s = data.src,
								f = data.cutType,
								p = data.cutPosition;
                            closeCutWindow();
                            var str = { "background": "url(" + s + ")  no-repeat", "background-size": "cover" },
								p_fix = parseInt(p) - 1;

                            switch (f) {
                                case "AppIcon":
                                    var sJson = JSON.parse(s);
                                    $("#app_icon").attr("src", sJson.ios);
                                    $("#app_ios_icon").attr("value", sJson.ios);
                                    $("#app_android_icon").attr("value", sJson.android);
                                    var $imgbox = $(".theme-style-list.app-name-list li .imgbox");
                                    $imgbox.attr("oldHashCode", data.ImgList.HashCode);
                                    $imgbox.attr("oldSourceImg", data.ImgList.SourceImg);
                                    break;
                                default:
                                    break;
                            }
                            opts.callBack(s, f, p);
                        }


                        var DOM = document,
							previewImg = DOM.getElementById("preview-img"),							//图片dom
							cutImgOffsetArr = DOM.getElementById("cut-img-offset").value.split("|"),		//起始坐标数组
							cutRangeArr = DOM.getElementById("cut-range").value.split("|"),			//宽高数组
							inputObj = DOM.getElementById("up").value,								//上传的文件名
							cutImgOffsetX = parseInt(cutImgOffsetArr[0]),
							cutImgOffsetY = parseInt(cutImgOffsetArr[1]),
							cutRangeW = parseInt(cutRangeArr[0]),
							cutRangeH = parseInt(cutRangeArr[1]),
							origeCutRangeArr = cutRange.split("|"),							//绘制尺寸
							origeCutRangeX = parseInt(origeCutRangeArr[0]),
							origeCutRangeY = parseInt(origeCutRangeArr[1]);
                        imgTypeArr = inputObj.split("."),								//获取后缀
                        imgArrNum = imgTypeArr.length - 1,
                        imgEndName = imgTypeArr[imgArrNum],
                        imgStr = "",
                        $okBtn = $popId.find(".pop-ok"),							//成功按钮
						canvas = $("<canvas width='" + origeCutRangeX + "px' height='" + origeCutRangeY + "px'></canvas>")[0],
						tempSrc = "",
                        ctx = canvas.getContext('2d');
                        imgEndName = imgEndName.toLowerCase();

                        switch (imgEndName) {
                            case "jpg":
                                imgStr = "image/jpeg";
                                break;
                            case "jpeg":
                                imgStr = "image/jpeg";
                                break;
                            default:
                                imgStr = "image/png";
                        }
                        ctx.drawImage(previewImg, cutImgOffsetX, cutImgOffsetY, cutRangeW, cutRangeH, 0, 0, origeCutRangeX, origeCutRangeY);
                        src = canvas.toDataURL(imgStr);
                        canvas = null;
                        ctx = null;

                        $popId.find("#cut-cutType").val(cutType);
                        $popId.find("#cut-position").val(cutPosition);
                        $popId.find("#cut-base64").val(src);
                        $popId.find("#old-hash-code").val(oldHashCode);					//原图片哈希
                        $popId.find("#old-source-img").val(oldSourceImg);					//原图片地址
                        //防止鼠标连续点击提交
                        if ($okBtn.attr("continue") == "0") {
                            return false;
                        } else {
                            $okBtn.attr("continue", "0");
                            $processBar.show().html("");
                            $popId.find("#cut-form").attr("action", sendUrl).ajaxSubmit({
                                cache: false,
                                beforeSubmit: function () {
                                    $popId.find(".preview-area").hide();
                                    $popId.find(".preview-box").css("background", "url(http://s1.55tuanimg.com/55F2E/static/public/img/loading.gif) center center no-repeat");
                                    $(".cut-laywer").eq(0).hide();
                                    $(".imgareaselect-outer").hide();
                                },
                                uploadProgress: function (event, position, total, percentComplete) {		//防止后台输出进度有误
                                    if (percentComplete == 100) {
                                        $processBar.html("目前图片上传进度为: 99 %, 服务器正在努力处理图片,请耐心等候哦");
                                    } else {
                                        $processBar.html("目前图片上传进度为: " + percentComplete + " %, 请耐心等候哦");
                                    }

                                },
                                success: function (data) {
                                    $okBtn.attr("continue", "1");
                                    if (data.success == "1") {
                                        comfirmCallback(data);
                                    } else {
                                        $previewArea.show();
                                        $previewBox.css("background", "#fff");
                                        $(".cut-laywer").eq(0).hide();
                                        $(".imgareaselect-outer").hide();
                                        $messageBar.html(data.info).show();
                                    }
                                    $processBar.hide().html("");
                                    return false;
                                },
                                error: function (XmlHttpRequest, textStatus, errorThrown, data) {
                                    console.log("XmlHttpRequest:" + XmlHttpRequest);
                                    console.log("textStatus:" + textStatus);
                                    console.log("errorThrown:" + errorThrown);
                                    console.log("data:" + data);
                                }
                            })
                        }
                    })
                }
            })
        })

        $(window).bind("keyup", function (e) {
            var $cut_dom = $(".cut-laywer");
            if ($cut_dom.length) {
                switch (e.keyCode) {
                    case 27:
                        $(".cut-laywer").eq(0).hide();
                        $(".imgareaselect-outer").hide();
                        $(".imgareaselect-selection").hide();
                        break;
                    default:
                        break;
                }
            }
        })
    };

})(jQuery);