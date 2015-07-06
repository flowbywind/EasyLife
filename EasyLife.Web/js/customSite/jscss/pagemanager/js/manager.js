var dataJson = {};
$(function () {
	$(window).useStrTemplet({
		"str" : "cut-textarea"
	});
	//窗口高度调整
	var changeWindow = function () {
		$('.control-list').windowSize({
			bigNodeName : "#phone",
			topNode : ".header",
			addHeightNum : 0,
			scroll : false,
			scrollNum : 0
		});
		$('.basic-scroll').windowSize({
			bigNodeName : "#phone",
			topNode : ".header",
			addHeightNum : -50,
			scroll : false,
			scrollNum : 0
		});
		$('.system-style').windowSize({
			bigNodeName : "#phone",
			topNode : ".header",
			addHeightNum : 0,
			scroll : false,
			scrollNum : 0
		});
		$('.content').windowSize({
			bigNodeName : "#phone",
			topNode : ".header",
			addHeightNum : 0,
			scroll : false,
			scrollNum : 0
		});
	}
	changeWindow();
	//引导页效果
	var guideFunc = function () {
		var guideNode = $('.guide-bg');
		if (guideNode.attr('play') == '0') {
			var w = $('body').width(),
			h = $('body').height(),
			computerH = h - 50;
			$('.guide-bg').css({
				width : w,
				height : h
			});
			var oneW = $('body').width() - 1110,
			leftW = parseInt(oneW / 2) + 295,
			disNo = true;
			$('.guide-two').css({
				left : leftW
			});
			$('.guide-one').css({
				height : computerH
			});
			$('.guide-three').css({
				height : computerH
			});
			$('.guide').each(function () {
				if ($(this).css('display') == 'block') {
					disNo = false;
				}
			});
			if (disNo) {
				$('.guide-bg').css({
					display : 'block'
				});
				$('.guide-one').css({
					display : 'block'
				});
			}
			$('.guide-one a').on('click', function () {
				$('.guide').css('display', 'none');
				$('.guide-two').css('display', 'block');
			});
			$('.guide-two a').on('click', function () {
				$('.guide').css('display', 'none');
				$('.guide-three').css('display', 'block');
			});
			$('.guide-three a').on('click', function () {
				$('.guide').css('display', 'none');
				$('.guide-four').css('display', 'block');
			});
			$('.guide-four a').on('click', function () {
				$('.guide').css('display', 'none');
				$('.guide-bg').css('display', 'none');
				guideNode.attr('play', '1');
			});
		}
	}
	guideFunc();
	$(window).resize(function () {
		changeWindow();
		guideFunc();
	});
	$('.help-play').on('click', function () {
		$('.guide-bg').attr('play', '0');
		guideFunc();
	});
	//首页左右两侧滚动条设置插件
	$('.theme-scroll').jScrollPane({
		showArrows : true, //是否显示上下箭头
		verticalGutter : 5,
		autoReinitialise : true
	});
	$('.basic-scroll').jScrollPane({
		showArrows : true, //是否显示上下箭头
		verticalGutter : 5,
		autoReinitialise : true
	});
	//表单样式
	$('form').jqTransform({
		imgPath : 'formStyle/img/'
	});
	//总编辑按钮位置可视范围
	$(".phone-panel .wap").scroll(function () {
		var topValue = parseInt($('.phone-panel .wap').scrollTop()),
		totleH = parseInt($('.phone-panel .wap-content').height()) - parseInt($('.item-list').height());
		if (topValue > totleH) {
			topValue = topValue - totleH;
		} else {
			topValue = 0;
		}
		$(".item-list .eidt-btn").css('top', topValue);
	});
	$(".menu a").each(function (index) {
		$(this).click(function () {
			$(".menu a").removeClass("hover");
			$(this).addClass("hover");
			if (index != 0) {
				$(".header").find(".operate").hide();
			} else {
				$(".header").find(".operate").show();
			}
		});
	});

	//加载DOM 手机模块
	//切换肤色
	$('.theme-style-list li').bind("click", function (e) {
		changeStyle(this);
	});
	$('.theme-color-list').on("click", 'li', function (e) {
		changeColorStyle(this);
	});
	$(".wap-content").on("mouseenter", ".item-list", function () {
		$(this).find('.eidt-btn').css('display', 'block');
	});
	$(".wap-content").on("mouseleave", ".item-list", function () {
		$(this).find('.eidt-btn').css('display', 'none');
	});
	//system-style tab切换
	$('.system-style').tabselect({
		thisClass : "hover",
		navList : ".tab-ui-head li",
		boxList : ".tab-content>div",
		eTrigger : "click",
		numShow : 0
	});
	//system-style tab切换
	$('.style-content').tabselect({
		thisClass : "hover",
		navList : ".sub-tab-head li",
		boxList : ".sub-tab-content>div",
		eTrigger : "click",
		numShow : 0
	});
	//引导页开始显示隐藏
	var guideNode = $(".guide-offon input[name='onoff']");
	guideNode.bind('click', function () {
		var $this = $(this);
		if ($this.val() == 'on') {
			$('.guide-upload').removeClass('hide');
		} else {
			$('.guide-upload').addClass('hide');
		}
	});
	var shareNode = $(".share .share-content dl").eq(0);
	shareNode.find('input').bind('click', function () {
		var $this = $(this);
		if ($this.val() == 'on') {
			$('.share .share-content dl').eq(1).removeClass('hide');
		} else {
			$('.share .share-content dl').eq(1).addClass('hide');
		}
	});
	//默认加载data-icon='2'加标签
	$('#sortable .dragicon').each(function () {
		if ($(this).attr('data_icon') == '2') {
			$(this).attr('upimg', 'true');
		}
	});
	//弹出层调用开始
	//图标选择弹层（第三层 图标ajax请求更换）
	var icoSelectWindowPop = function () {
		var path = $(".icon-style select option").eq(0).attr("path"), //获取图片路径
		currentIconSrc;
		if ($("#wdtWindowTwo .current-icon img").length) {
			currentIconSrc = $("#wdtWindowTwo .current-icon img").attr("src");
		} else {
			currentIconSrc = $("#wdtWindowOne .current-icon img").attr("src");
		}
		$(".icon-select img").attr("src", currentIconSrc);
		//ajax回调
		var ajaxCallback = function (data) {
			var len = data.length,
			imgStr = "";
			//动态添加img
			for (var i = 0; i < len; i++) {
				imgStr += "<span class='icon-img'><img src='" + data[i].path + "'></span>";
			}
			//console.log(imgStr);
			$(".icon-area").html(imgStr);
			//img默认当前选择
			$(".icon-area img").each(function () {
				var oSrc = $(this).attr('src'),
				currOsrc;
				if (oSrc == currentIconSrc) {
					$(this).parent().addClass('on');
				}
			});
			//点击事件函数
			var selectDone = function () { //选择完毕 确定
				var src = $(".icon-select img").attr("src");
				if ($("#wdtWindowOne .current-icon").length) {
					$("#wdtWindowOne .current-icon").find("img").attr("src", src);
					$("#wdtWindowThree").remove();
				} else {
					$("#wdtWindowTwo .current-icon").find("img").attr("src", src);
					$("#wdtWindowThree").remove();
				}
				if ($("#wdtWindowTwo").length) {
					$("#wdtWindowTwo").show();
				} else {
					$("#wdtWindowOne").show();
				}
				if ($('.icon-img img').attr('upimg') != '') {
					$('.icon-img img').removeAttr('upimg');
				}
			}
			var imgClickEvent = function () {
				var thisSrc = $(this).attr("src");
				$(".icon-area img").parent().removeClass('on');
				$(this).parent().addClass('on');
				$(".icon-select img").attr("src", thisSrc);
			}
			var selectCancel = function () { //取消选择
				$("#wdtWindowThree").remove();
				if ($("#wdtWindowTwo").length) {
					$("#wdtWindowTwo").show();
				} else {
					$("#wdtWindowOne").show();
				}
			}
			//点击事件触发
			$(".icon-area img").unbind().bind("click", imgClickEvent);
			$(".pop-select-ok").unbind().bind("click", selectDone)
			$(".pop-select-cancel").unbind().bind("click", selectCancel)
		}
		var themeid = $('.theme-style-list li.hover').attr('styleid'),
		id = $(".icon-style select option:selected").attr("id"),
		dataobj = {
			"merchantId" : merchantId,
			"themeid" : themeid,
			"IconStyleId" : id
		};
		$.ajax({
			type : "post",
			url : path,
			dataType : "json",
			cache : true,
			data : dataobj,
			success : function (data) {
				ajaxCallback(data);
			}
		})
		//风格切换
		$(".icon-style select").bind("change", function () {
			var path = $(this).find('option:selected').attr("path"), //获取图片路径
			themeid = $('.theme-style-list li.hover').attr('styleid'),
			id = $(".icon-style select option:selected").attr("id"),
			dataobj = {
				"merchantId" : merchantId,
				"themeid" : themeid,
				"IconStyleId" : id
			};
			$.ajax({
				type : "post",
				url : path,
				dataType : "json",
				cache : true,
				data : dataobj,
				success : function (data) {
					ajaxCallback(data);
				}
			})
		})
	}

	//图标信息弹层(第二层，载入信息)
	var loadModuleInfo = function (name, type, imgsrc) {
		var $input = $(".module-name input"), //放置文字
		$b = $(".module-type b"), //放置类型
		$img = $(".current-icon img"); //放置图片
		//放入默认文字和图标
		$input.val(name);
		$b.text(type);
		$img.attr("src", imgsrc);
		//图标选择弹层
		$(".change-ico").bind("click", function () {
			$(window).wdtWindowPop({
				popId : "wdtWindowThree",
				title: "<b>添加图标</b>(上传图片尺寸大于56*56px时可裁剪，支持png格式)",
				width : 700,
				height : "auto",
				content : $("#eidt-mode-window3").val(),
				showCallback : function () {
					//$("#wdtWindowTwo").hide();
					//$("#wdtWindowOne").hide();
					if ($("#wdtWindowTwo").length) {
						$("#wdtWindowTwo").hide();
					} else {
						$("#wdtWindowOne").hide();
					}
					icoSelectWindowPop();
				}
			})
		});
		var changeicon = function (imgSrc) {
			$('.icon-img img').attr({
				'src' : imgSrc,
				'upimg' : true
			});

		}
		$(".add-icon").each(function () {
			$(this).cutEvent({
				callBack : changeicon
			});
		});
	}

	//总编辑按钮触发事件   (第二层)
	var modulePopModifyEvent = function () {
		var $this = $(this),
		popArr = $this.attr("data").split("|");
		$(window).wdtWindowPop({
			popId : "wdtWindowTwo",
			title : "<b>菜单编辑</b>",
			width : 700,
			height : "auto",
			content : $("#eidt-mode-window2").val(),
			showCallback : function () {
				$("#wdtWindowOne").hide();
				loadModuleInfo(popArr[0], popArr[1], popArr[2]); //载入信息
				//$(".module-name input").val(popArr[0]);
				/*****这里是点击确定按钮后的事件*******/
				//模块判断上传ICON显示
				if ($('.basic-sub').css('display') == 'none') {
					$('.tcnewbd .module-icon').css('display', 'none');
					$('.tcnewbd .current-icon').css('display', 'none');
				}
				//显示商品所属分类
				//显示商品所属分类
				var oModuleCode = $this.parents('li').attr('module_code'),
				goodsCate = $this.parents('li').attr('module_goods_cate'),
				cateId = $this.parents('li').attr('cateid');
				if (oModuleCode != "goodspage") {
					$('.tcnewbd .module-store-type').css('display', 'none');
					$('.module-store-type').parents('.tcnewbd').css('overflow', 'hidden');
				} else {
					$('.module-store-type').parents('.tcnewbd').css('overflow', 'visible');
					var TTDiy_select = new window.parent.diy_select({ //参数可选
							TTContainer : 'diy_select', //控件的class
							TTDiy_select_input : 'diy_select_input', //用于提交表单的class
							TTDiy_select_txt : 'diy_select_txt', //diy_select用于显示当前选中内容的容器class
							TTDiy_select_btn : 'diy_select_btn', //diy_select的打开按钮
							TTDiv_select_list : 'diy_select_list', //要显示的下拉框内容列表class
							TTDiy_select_code : 'cateid',
							TTFcous : 'focus' //得到焦点时的class
						});
					$(".diy_select_list li").each(function () {
						var obj1 = $(this);
						if (obj1.attr("cateid") == cateId) {
							$('.tcnewbd .diy_select .diy_select_input').val(obj1.html().trim());
							$('.tcnewbd .diy_select .diy_select_txt').text(obj1.html().trim());
						}
					})
					$('.tcnewbd .diy_select .diy_select_txt').attr('cateid', cateId);
				}
				$("#wdtWindowTwo .pop-module-ok").bind("click", function () {
					var tempName = $(".module-name input").val(),
					tempImg = $(".current-icon img").attr("src"),
					tempStr = tempName + "|" + popArr[1] + "|" + tempImg,
					tempLen = tempName.length,
					atemSrc = tempImg.split('/'),
					$oLi = $this.parent().parent().parent();
					if (tempLen > 4) {
						$(".module-name span").text("不能超过4个字")
					} else if (tempLen == 0) {
						$(".module-name span").text("不能为空")
					} else {
						if (atemSrc[atemSrc.length - 1] != 'default.png') {
							//console.log($(".current-icon img").attr('upimg'));
							if (!$(".current-icon img").attr('upimg')) {
								$oLi.attr('data_icon', "1");
							} else {
								$oLi.attr('data_icon', "2");
							}
						} else {
							$oLi.attr('data_icon', "0");
						}
						$(".module-name span").text("")
						$this.attr("data", tempStr); //回传data字符串
						$this.parent().parent().find('.mode-name').val(tempName);
						if (oModuleCode == "goodspage") {
							var cate = $('#wdtWindowTwo .diy_select .diy_select_input').val(),
							cateID = $('#wdtWindowTwo .diy_select .diy_select_txt').attr('cateid');
							//console.log(cateID)
							$this.parents('li').attr('module_goods_cate', cate);
							$this.parents('li').attr('cateid', cateID);
						}
						$("#wdtWindowTwo").remove();
						$("#wdtWindowOne").show();
					}
				});

				$("#wdtWindowTwo .pop-module-cancel").bind("click", function () { //第2个okbtn
					$("#wdtWindowTwo").remove();
					$("#wdtWindowOne").show();
				})
			}
		});
	};
	//拖动模块单个编辑模块 第一层
	$('.item-list ul').on('click', '.drag_ts .drag_edit', function () {
		var $this = $(this),
		$item = $(this).parent().parent().find('.basic-item'),
		imgsrc = $item.find('img').attr('src'),
		data_icon = $item.find('img').attr('data_icon'),
		itemName = $item.find('.basic-detail').text(),
		itemType = $item.find('.static-detail').text(); //未定义文字类型，需获取
		//$("#iconimg").attr("cutposition",$(this).parent().parent().attr("module_code"));

		if (!imgsrc) {
			imgsrc = 'http://r1.55.com/wdtres/wdtF2E/customSite/static/public/images/pops/default.png';
		} else {
			imgsrc = $item.find("img").attr("src");
		}
		popArr = [];
		popArr.push(itemName.trim(), itemType.trim(), imgsrc);
		//console.log(popArr);
		//popArr = $this.attr("data").split("|");
		$(window).wdtWindowPop({
			popId : "wdtWindowOne",
			title : "<b>菜单编辑</b>",
			width : 700,
			height : "auto",
			content : $("#eidt-mode-window2").val(),
			showCallback : function () {
				$("#wdtWindowOne").find("#addicon").attr("cutposition", $(this).parent().parent().attr("module_code"));
				loadModuleInfo(popArr[0], popArr[1], popArr[2]); //载入信息
				/*****这里是点击确定按钮后的事件*******/
				//$(".module-name input").val(popArr[0]);
				//模块判断上传ICON显示
				if ($('.basic-sub').css('display') == 'none') {
					$('.tcnewbd .module-icon').css('display', 'none');
					$('.tcnewbd .current-icon').css('display', 'none');
				}
				//显示商品所属分类
				var oModuleCode = $this.parents('li').attr('module_code'),
				//goodsCate=$this.parents('li').attr('module_goods_cate'),
				cateId = $this.parents('li').attr('cateid');
				if (oModuleCode != "goodspage") {
					$('.tcnewbd .module-store-type').css('display', 'none');
					$('.module-store-type').parents('.tcnewbd').css('overflow', 'hidden');
				} else {
					$('.module-store-type').parents('.tcnewbd').css('overflow', 'visible');
					var TTDiy_select = new window.parent.diy_select({ //参数可选
							TTContainer : 'diy_select', //控件的class
							TTDiy_select_input : 'diy_select_input', //用于提交表单的class
							TTDiy_select_txt : 'diy_select_txt', //diy_select用于显示当前选中内容的容器class
							TTDiy_select_btn : 'diy_select_btn', //diy_select的打开按钮
							TTDiv_select_list : 'diy_select_list', //要显示的下拉框内容列表class
							TTFcous : 'focus' //得到焦点时的class
						});
					$(".diy_select_list li").each(function () {
						var obj1 = $(this);
						if (obj1.attr("cateid") == cateId) {
							$('.tcnewbd .diy_select .diy_select_input').val(obj1.html().trim());
							$('.tcnewbd .diy_select .diy_select_txt').text(obj1.html().trim());
						}
					});
					$('.tcnewbd .diy_select .diy_select_txt').attr('cateid', cateId);
				}
				$("#wdtWindowOne .pop-module-ok").bind("click", function () {
					var tempName = $(".module-name input").val(),
					tempImg = $(".current-icon img").attr("src"),
					//tempStr = tempName + "|" + popArr[1] + "|" + tempImg,
					tempLen = tempName.length,
					atemSrc = tempImg.split('/'),
					repet = false;
					$this.parents('li').siblings().find(".basic-detail").each(function () {
						//console.log(tempName);
						//console.log($(this).html());
						if (tempName.trim() == $(this).html().trim()) {
							repet = true;
						}
					});
					if (tempLen > 4) {
						$(".module-name span").text("不能超过4个字")
					} else if (tempLen == 0) {
						$(".module-name span").text("不能为空")
					} else if (repet) {
						$(".module-name span").text("模块名称重复");
						$(".module-name input").addClass('error');
					} else {
						$(".module-name span").text("")
						$(".module-name input").removeClass('error')
						//$this.attr("data",tempStr);		//回传data字符串
						var $img = $this.parents('li').find('.basic-sub img');
						//console.log(!parseInt($img.attr('data_icon')));
						if (atemSrc[atemSrc.length - 1] != 'default.png') {
							if (!parseInt($img.attr('data_icon'))) {
								var src = $img.attr('src'); //保存原来的img
								$img.attr('oSrc', src);
							}
							$img.attr('src', tempImg); //新的img
							if ($('.current-icon img').attr('upimg') == 'true') {
								$img.attr('data_icon', "2");
								$img.attr('upimg', 'true');
							} else {
								$img.attr('data_icon', "1");
								$img.removeAttr('upimg');
							}
						}
						if (atemSrc[atemSrc.length - 1] == 'default.png') {
							var osrc = $img.attr('oSrc');
							$img.attr('src', osrc);
							$img.attr('data_icon', "0");
							$img.removeAttr('upimg');
							if ($img.attr('oSrc') != '') {
								$img.removeAttr('oSrc');
							}
						}
						$this.parents('li').find('.basic-detail').text(tempName);
						if (oModuleCode == "goodspage") {
							var cate = $('#wdtWindowOne .diy_select .diy_select_input').val(),
							cateID = $('#wdtWindowOne .diy_select .diy_select_txt').attr('cateid');
							$this.parents('li').attr('module_goods_cate', cate);
							$this.parents('li').attr('cateid', cateID);
						}
						$("#wdtWindowOne").remove();
						$("#wdtDivLayer").hide();
					}
				});
				$("#wdtWindowOne .pop-module-cancel").bind("click", function () { //第2个okbtn
					//$("#wdtWindowTwo").remove();
					if ($('.icon-img img').attr('upimg') != '') {
						var img = $('.icon-img img').attr('src');
						//console.log($("#cut-cancel-url").val());
						//console.log(img);
						$.ajax({
							type : "GET",
							url : $("#cut-cancel-url").val(),
							data : {
								'imgsrc' : img
							},
							success : function (data) {}
						})
					}
					$("#wdtWindowOne").remove();
					$("#wdtDivLayer").hide();
				});
			}
		});
	});
	//总编辑模块 第一层
	function in_array(search, array) {
		for (var i in array) {
			if (array[i] == search) {
				return true;
			}
		}
		return false;
	}
	function ifarray_cf(a) {
		return /(\x0f[^\x0f]+)\x0f[\s\S]*\1/.test("\x0f" + a.join("\x0f\x0f") + "\x0f");
	}
	var del_f_id_array = [];
	$(".eidt-btn").bind("click", function (event) {
		event.preventDefault();
		$(window).wdtWindowPop({
			popId : "wdtWindowOne", //弹层1
			//title:"<b>模块内容</b>(icon添加格式png,尺寸为56*56)",
			title : "<b>菜单模块编辑</b>",
			width : 700,
			height : "auto",
			content : $("#eidt-mode-window").val(),
			draggle : ".edit-mode-list",
			showCallback : function () {
				/*组织弹出列表开始*/
				var id = 0;
				$("#sortable li:not(.draghidden").each(function () {
					var module_goods_cate = $(this).attr("module_goods_cate");
					var cateid = $(this).attr("cateid");
					var id = $(this).attr("id");
					var f_id = $(this).attr("f_id");
					var data_index = $(this).attr("data_index");
					var merchant_module_id = $(this).attr("merchant_module_id") > 0 ? $(this).attr("merchant_module_id") : 0;
					var app_module_id = $(this).attr("app_module_id") > 0 ? $(this).attr("app_module_id") : 0;
					var basic_sub = $(this).find(".basic-detail").html().trim();
					var static_detail = $(this).find(".static-detail").html();
					var imgsrc = $(this).find("img").attr("src");
					var $img = $(this).find(".dragicon"),
					ico_img = $(this).find(".dragicon").attr('src'),
					oSrc,
					data_icon = $(this).find(".dragicon").attr('data_icon');
					if (typeof($img.attr("oSrc")) == 'undefined') {
						oSrc = 'oSrc="' + $(this).find(".dragicon").attr('src') + '" ';
					} else {
						oSrc = 'oSrc="' + $img.attr("oSrc") + '" ';
					}
					if (!imgsrc) {
						ico_img = 'http://r1.55.com/wdtres/wdtF2E/customSite/static/public/images/pops/default.png';
					} else {
						ico_img = imgsrc;
					}
					var module_code = $(this).attr("module_code");
					var module_id = $(this).attr("module_id");
					if ($(this).attr("module_code").trim() == "about" || $(this).attr("module_code").trim() == "usercenter") {
						var poplist = '<li ' + oSrc + 'data_icon="' + data_icon + '" module_goods_cate="' + module_goods_cate + '" cateid="' + cateid + '" merchant_module_id="' + merchant_module_id + '" app_module_id="' + app_module_id + '" module_code="' + module_code + '" module_id="' + module_id + '" id="poplist_' + id + '" did="' + id + '" f_id="' + f_id + '" data_index="' + data_index + '" data_hide="0" data_del="0"><dl><dd class="mode-td-name"><input class="mode-name" type="text" maxlength="4" value="' + basic_sub + '" onkeyup="this.value=this.value.replace(/^ +| +$/g,\'\')" /></dd><dd class="mode-td-type">' + static_detail + '</dd><dd class="mode-td-show"></dd><dd class="mode-td-operate"><a class="edit-submode-btn" data="' + basic_sub + '|' + static_detail + '|' + ico_img + '" href="#" data="a|b|../../wdt_admin/static/public/images/pops/002.jpg"></a><a class="sort-down" href="#"></a><a class="sort-up" href="#"></a></dd></dl></li>';
						$(".edit-mode-list").append(poplist);
					} else if ($(this).attr("module_code").trim() == "shopspage") {
						var poplist = '<li ' + oSrc + 'data_icon="' + data_icon + '" module_goods_cate="' + module_goods_cate + '" cateid="' + cateid + '" merchant_module_id="' + merchant_module_id + '" app_module_id="' + app_module_id + '" module_code="' + module_code + '" module_id="' + module_id + '" id="poplist_' + id + '" did="' + id + '" f_id="' + f_id + '" data_index="' + data_index + '" data_hide="0" data_del="0"><dl><dd class="mode-td-name"><input class="mode-name" type="text" maxlength="4" value="' + basic_sub + '" onkeyup="this.value=this.value.replace(/^ +| +$/g,\'\')" /></dd><dd class="mode-td-type">' + static_detail + '</dd><dd class="mode-td-show"><a class="submode-hide" href="#"></a></dd><dd class="mode-td-operate"><a class="edit-submode-btn" data="' + basic_sub + '|' + static_detail + '|' + ico_img + '" href="#" data="a|b|../../wdt_admin/static/public/images/pops/002.jpg"></a><a class="sort-down" href="#"></a><a class="sort-up" href="#"></a></dd></dl></li>';
						$(".edit-mode-list").append(poplist);
					} else {
						var poplist = '<li ' + oSrc + 'data_icon="' + data_icon + '" module_goods_cate="' + module_goods_cate + '" cateid="' + cateid + '" merchant_module_id="' + merchant_module_id + '" app_module_id="' + app_module_id + '" module_code="' + module_code + '" module_id="' + module_id + '" id="poplist_' + id + '" did="' + id + '" f_id="' + f_id + '" data_index="' + data_index + '" data_hide="0" data_del="0"><dl><dd class="mode-td-name"><input class="mode-name" type="text" maxlength="4" value="' + basic_sub + '" onkeyup="this.value=this.value.replace(/^ +| +$/g,\'\')" /></dd><dd class="mode-td-type">' + static_detail + '</dd><dd class="mode-td-show"><a class="submode-hide" href="#"></a></dd><dd class="mode-td-operate"><a class="edit-submode-btn" data="' + basic_sub + '|' + static_detail + '|' + ico_img + '" href="#" data="a|b|../../wdt_admin/static/public/images/pops/002.jpg"></a><a class="sort-down" href="#"></a><a class="sort-up" href="#"></a><a class="del-submode-btn" href="#"></a></dd></dl></li>';
						$(".edit-mode-list").append(poplist);
					}
				});
				$("#sortable li[class='draghidden']").each(function () {
					var module_goods_cate = $(this).attr("module_goods_cate");
					var cateid = $(this).attr("cateid");
					var id = $(this).attr("id");
					var f_id = $(this).attr("f_id");
					var data_index = $(this).attr("data_index");
					var merchant_module_id = $(this).attr("merchant_module_id") > 0 ? $(this).attr("merchant_module_id") : 0;
					var app_module_id = $(this).attr("app_module_id") > 0 ? $(this).attr("app_module_id") : 0;
					var basic_sub = $(this).find(".basic-detail").html().trim();
					var static_detail = $(this).find(".static-detail").html();
					var imgsrc = $(this).find("img").attr("src");
					var $img = $(this).find(".dragicon"),
					ico_img = $(this).find(".dragicon").attr('src'),
					oSrc,
					data_icon = $(this).find(".dragicon").attr('data_icon');
					if (typeof($img.attr("oSrc")) == 'undefined') {
						oSrc = 'oSrc="' + $(this).find(".dragicon").attr('src') + '" ';
					} else {
						oSrc = 'oSrc="' + $img.attr("oSrc") + '" ';
					}
					if (!imgsrc) {
						ico_img = 'http://r1.55.com/wdtres/wdtF2E/customSite/static/public/images/pops/default.png';
					} else {
						ico_img = imgsrc;
					}
					var module_code = $(this).attr("module_code");
					var module_id = $(this).attr("module_id");
					var poplist = '<li ' + oSrc + 'data_icon="' + data_icon + '" module_goods_cate="' + module_goods_cate + '" cateid="' + cateid + '" merchant_module_id="' + merchant_module_id + '" app_module_id="' + app_module_id + '" module_code="' + module_code + '" module_id="' + module_id + '"id="poplist_' + id + '" did="' + id + '" f_id="' + f_id + '" data_index="' + data_index + '" data_hide="1" data_del="0"><dl><dd class="mode-td-name"><input class="mode-name" type="text" maxlength="4" value="' + basic_sub + '" onkeyup="this.value=this.value.replace(/^ +| +$/g,\'\')" /></dd><dd class="mode-td-type">' + static_detail + '</dd><dd class="mode-td-show"><a class="hide-submode-btn" href="#"></a></dd><dd class="mode-td-operate"><a class="edit-submode-btn" href="#" data="' + basic_sub + '|' + static_detail + '|' + ico_img + '"></a><a class="sort-down" href="#"></a><a class="sort-up" href="#"></a><a class="del-submode-btn" href="#"></a></dd></dl></li>';
					$(".edit-mode-list").append(poplist);
				});
				$("#wdtWindowOne .edit-mode-list li:first-child").find(".sort-up").attr("style", "display:none");
				$("#wdtWindowOne .edit-mode-list li:last-child").find(".sort-down").attr("style", "display:none");
				//点击隐藏或显示按钮
				$(".mode-td-show a").on("click", function () {
					if ($(this).attr("class") == "submode-hide") {
						$(this).attr("class", "hide-submode-btn");
						$(this).parent().parent().parent().attr("data_hide", "1");
					} else {
						$(this).attr("class", "submode-hide");
						$(this).parent().parent().parent().attr("data_hide", "0");
					}
				});
				//点击删除按钮
				$(".del-submode-btn").on("click", function () {
					var This = $(this);
					var del_modulename = This.parent().prev().prev().prev().find("input").val();
					$(window).wdtWindowPop({
						popId : "wdtWindowTwo", //弹层1
						//title:"<b>模块内容</b>(icon添加格式png,尺寸为56*56)",
						title : "<b>模块设置</b>",
						width : 442,
						height : "auto",
						isCloseBtn:false,
						content : $("#del-mode-textarea").val(),
						draggle : ".edit-mode-list",
						showCallback : function () {
							$("#wdtWindowTwo .tcnewtop").css("border-bottom",0);
							$("#delmessage").html('确定删除' + del_modulename + "?");
							$("#wdtWindowOne").hide();
							$("#wdtWindowTwo .pop-ok").on("click", function () {
								var id = This.parent().parent().parent().attr("did");
								var f_id = This.parent().parent().parent().attr("f_id");
								This.parent().parent().parent().addClass("pop_li_del").attr("data_del", "1");
								var li = This.parent().parent().parent();
								var liarrays = $("#wdtWindowOne .edit-mode-list li");
								//var count = liarrays.length;
								var count = $("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").length;
								//var index = liarrays.index(li);

								//console.log(index);
								$("#wdtWindowOne .edit-mode-list li").removeAttr('style');
								$("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").eq(0).find(".sort-up").css('display', 'none');
								$("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").eq(count - 1).find(".sort-down").css('display', 'none');
								//if(index==0){
								//liarrays.eq(index+1).find(".sort-up").attr("style","display:none;");
								//}
								//if(index == (count-1)){
								//liarrays.eq(index-1).find(".sort-down").attr("style","display:none;");
								//}
								//将删除记录存入数组
								var value = parseInt($("#" + f_id).attr("value") + 1);
								var arr = {
									"f_id" : f_id,
									"value" : value
								};
								del_f_id_array.push(arr);

								//记录删除记录
								var $obj = This.parent().parent().parent();
								var del_module_code = $obj.attr("module_code"),
								merchant_module_id = $obj.attr("merchant_module_id"),
								app_module_id = $obj.attr("app_module_id"),
								del_module_code = $obj.attr("module_code"),
								merchant_module_id = $obj.attr("merchant_module_id"),
								app_module_id = $obj.attr("app_module_id"),
								module_name = $obj.find(".mode-td-type").html().trim(),
								icon = $obj.find("img").attr("src"),
								sort = $obj.attr("sort"),
								hidden = $obj.attr("hidden"),
								cat_id = $obj.attr("cat_id"),
								module_id = $obj.attr("module_id");
								del_singleModule = {
									"merchant_module_id" : merchant_module_id,
									"app_module_id" : app_module_id,
									"module_code" : del_module_code,
									"module_name" : module_name,
									"icon" : icon,
									"sort" : sort,
									"hidden" : hidden,
									"cat_id" : cat_id,
									"module_id" : module_id,
									"flag" : 1
								};
								del_moudleconfig.push(del_singleModule);
								$("#wdtWindowTwo").remove();
								$("#wdtWindowOne").show();
							});
						}
					});
				});
				//点击下移按钮
				$(".sort-down").on("click", function () {
					var li = $(this).parent().parent().parent();
					var liarrays = $("#wdtWindowOne .edit-mode-list li");
					//var count1 = liarrays.length;
					var count = $("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").length;
					//console.log('count1:'+count1+'count:'+count);
					var index = liarrays.index(li);
					liarrays.eq(index + 1).after(liarrays.eq(index));
					/*
					if(index == 0){
					liarrays.eq(index).find(".sort-up").removeAttr("style");
					liarrays.eq(index+1).find(".sort-up").attr("style","display:none;");
					}
					if(index == (count-2)){
					liarrays.eq(index).find(".sort-down").attr("style","display:none;");
					liarrays.eq(index+1).find(".sort-down").removeAttr("style");
					}*/
					$("#wdtWindowOne .edit-mode-list li").find(".sort-down").removeAttr('style');
					$("#wdtWindowOne .edit-mode-list li").find(".sort-up").removeAttr('style');
					$("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").eq(0).find(".sort-up").css('display', 'none');
					$("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").eq(count - 1).find(".sort-down").css('display', 'none');
				});
				//点击上移按钮
				$(".sort-up").on("click", function () {
					var li = $(this).parent().parent().parent();
					var liarrays = $("#wdtWindowOne .edit-mode-list li");
					//var count = liarrays.length;
					var count = $("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").length;
					var index = liarrays.index(li);
					liarrays.eq(index - 1).before(liarrays.eq(index));
					/*
					if(index == count-1){
					liarrays.eq(index).find(".sort-down").removeAttr("style");
					liarrays.eq(index-1).find(".sort-down").attr("style","display:none;");
					}
					if(index == 1){
					liarrays.eq(index).find(".sort-up").attr("style","display:none;");
					liarrays.eq(index-1).find(".sort-up").removeAttr("style");
					}*/
					$("#wdtWindowOne .edit-mode-list li").find(".sort-down").removeAttr('style');
					$("#wdtWindowOne .edit-mode-list li").find(".sort-up").removeAttr('style');
					$("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").eq(0).find(".sort-up").css('display', 'none');
					$("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").eq(count - 1).find(".sort-down").css('display', 'none');

				});
				//点击取消按钮
				$(".pop-module-cancel").on("click", function () {
					del_f_id_array = [];
					$("#wdtWindowOne").remove();
					$("#wdtDivLayer").hide();
				});
				//离开焦点时提示模块名称重复
				/*
				$("#wdtWindowOne .mode-name").on("blur",function(){
				alert($(this).index());
				if(in_array($(this).val(),mdname_array)){
				$(this).addClass("error").val("").focus();
				}
				})
				 */
				//点击确认按钮
				$(".pop-module-ok").on("click", function () {
					//console.log(del_f_id_array);
					for (var o in del_f_id_array) {
						$("#" + del_f_id_array[o].f_id).draggable("option", "disabled", false);
						$("#" + del_f_id_array[o].f_id).attr("value", del_f_id_array[o].value);
					}
					del_f_id_array = [];
					//组织数组判断模块名称不能为空或者有重复
					var mdname_array = [];
					$(this).parent().prev().find(".mode-name").each(function () {
						if ($(this).val().length == 0) {
							$(this).addClass("error");
							//alert("模块名称不能为空");
							commonjs.GetAlertHtml("模块名称不能为空");
							return false;
						} else {
							if (in_array($(this).val(), mdname_array)) {
								//alert("模块名称重复");
								commonjs.GetAlertHtml("模块名称重复");
								$(this).addClass("error").val().focus();
								return false;
							} else {
								$(this).removeClass("error");
								mdname_array.push($(this).val());
							}
						}
					});
					//处理输入框
					/*
					$("#wdtWindowOne .mode-name").each(function(){
					if(ifarray_cf(mdname_array)){
					alert("模块名称重复");
					$(this).addClass("error").val().focus();
					//$("#error_tip").html("模块名称不能为空");
					}else{
					$(this).removeClass("error");
					}

					});
					 */

					if ($(".error").length > 0) {
						var container = $('#wdtWindowOne .edit-mode-list'),
						scrollTo = $(".error").eq(0);
						container.scrollTop(
							scrollTo.offset().top - container.offset().top + container.scrollTop() - 10);
					} else {
						//改变手机区模块开始
						var newmks = "",
						newmks_hide = "",
						floatdiv = "";
						$("#wdtWindowOne .edit-mode-list li").each(function () {
							if ($(this).attr("data_del") != 1) {
								var id = $(this).attr("did");
								var f_id = $(this).attr("f_id");
								var data_index = $(this).attr("data_index");
								var module_code = $(this).attr("module_code").trim();
								var module_id = $(this).attr("module_id");
								var module_goods_cate = $(this).attr("module_goods_cate");
								var cateid = $(this).attr("cateid");
								var app_module_id = $(this).attr("app_module_id");

								var three = $(this).find(".edit-submode-btn").attr("data").split("|"),
								img,
								osrc_img = '',
								upImg = '',
								data_icon = $(this).attr('data_icon');
								//console.log(data_icon);
								if (parseInt(data_icon)) {
									osrc_img = 'osrc="' + $(this).attr("osrc") + '"'; //修改了图
									img = three[2];
									if (data_icon == '2') {
										upImg = 'upimg="true"';
									}
								} else {
									img = $(this).attr("osrc");
								}
								var basic_detail = three[0];
								var static_detail = three[1];
								if (module_code == "about" || module_code == "usercenter") {
									floatdiv = '<div class="drag_ts"><a class="drag_edit" title="编辑" href="javascript:void(0)">编辑</a><a title="拖动" class="drag_handle ui-sortable-handle">手柄</a></div>';
								} else if (module_code == "shopspage") {
									floatdiv = '<div class="drag_ts"><a class="drag_edit" title="编辑" href="javascript:void(0)">编辑</a><a title="隐藏" href="javascript:void(0)" class="drag_view">隐藏</a><a title="拖动" class="drag_handle ui-sortable-handle">手柄</a></div>';
								} else {
									floatdiv = '<div class="drag_ts"><a class="drag_edit" title="编辑" href="javascript:void(0)">编辑</a><a title="隐藏" href="javascript:void(0)" class="drag_view">隐藏</a><a title="删除" href="javascript:void(0)" class="drag_del">删除</a><a title="拖动" class="drag_handle ui-sortable-handle">手柄</a></div>';
								}
								if ($(this).attr("data_hide") == 1) {
									var data_hide = 'class="draghidden"';
									newmks_hide = newmks_hide + '<li module_code="' + module_code + '" app_module_id="' + app_module_id + '" cateid="' + cateid + '" module_goods_cate="' + module_goods_cate + '" module_id="' + module_id + '" f_id="' + f_id + '" id="' + id + '" data_index="' + data_index + '" ' + data_hide + '><div class="basic-item"><div class="basic-sub"><img data_icon="' + data_icon + '" ' + upImg + ' src="' + img + '" ' + osrc_img + ' class="dragicon"></div><p class="basic-detail">' + basic_detail + '</p><p class="static-detail">' + static_detail + '</p></div>' + floatdiv + '</li>';

								} else {
									var data_hide = "";
									newmks = newmks + '<li module_code="' + module_code + '" app_module_id="' + app_module_id + '" cateid="' + cateid + '" module_goods_cate="' + module_goods_cate + '" module_id="' + module_id + '" f_id="' + f_id + '" id="' + id + '" data_index="' + data_index + '" ' + data_hide + '><div class="basic-item"><div class="basic-sub"><img data_icon="' + data_icon + '" ' + upImg + ' src="' + img + '" ' + osrc_img + ' class="dragicon"></div><p class="basic-detail">' + basic_detail + '</p><p class="static-detail">' + static_detail + '</p></div>' + floatdiv + '</li>';

								}
							}
						});
						$("#sortable").html(newmks + newmks_hide);

						$("#wdtWindowOne").remove();
						$("#wdtDivLayer").hide();
						//改变手机区模块结束
					}
				});

				/*组织弹出列表内容结束*/
				$(".mode-name").change(function () {
					var odata = $(this).parents('dl').find('.edit-submode-btn'),
					adata = odata.attr('data').split("|"),
					odataStr;
					adata[0] = $(this).val();
					odataStr = adata[0] + '|' + adata[1] + '|' + adata[2];
					odata.attr('data', odataStr);
				});
				$(".edit-submode-btn").each(function () {
					$(this).bind("click", modulePopModifyEvent); //调用第二层
				});

				$(".pop-module-cancel").bind("click", function () { //总编辑第一层取消
					$("#wdtWindowOne").remove();
					$("#wdtDivLayer").hide();
				});
			}
		});
	});
	//弹出层调用结束
	//绑定裁剪图片事件
	$(".cut-area").each(function () {
		$(this).cutEvent();
	});

	// 功能开关
	$(".page-manage-set dl[data='manage-onoff'] input[data-name]").bind("click", function () {
		var $this = $(this),
		dataName = $this.attr("data-name");
		$("#phone ." + dataName).removeClass("on off").addClass($(this).val());
		var $fun = $(".fun"),
		$vLi = $fun.find("li:visible"),
		funWidth = $fun.width() - 11;
		$vLi.width(funWidth / $vLi.length);
		$vLi.removeClass("noborder").eq(-1).addClass("noborder");

	});
	// 选择内容，目前没有后续页面，有内容之后添加事件
	$("#select-con li a").on("click", function () {
		var val = $("[name='viewCount']").find("option:selected").val();
		//console.log(val);
	});

	// 页面配置  设置广告轮播图数量
	$("#view-count li a").on("click", function () {
		var val = parseInt($("[name='viewCount']").find("option:selected").val()),
		$numIcon = $(".num-icon");
		$numIcon.html("");
		for (var i = 0; i < val; i++) {
			var $li = $("<li>");
			if (i == 0) {
				$li.addClass("cur");
			}
			$numIcon.append($li);
		}
	})
	$(".guide-upload a.guide_del").each(function () {
		$(this).click(function () {
			$(this).next().find("img").attr("src", "");
			$(this).next().find("img").attr("oldsourceimg", "");
			$(this).next().find("img").attr("oldhashcode", "");
			$(this).hide();
		})
	})

	// 左侧切换排版 添加border
	$(".page-manage-list ul li").each(function () {
		$(this).bind("click", function () {
			$(this).find(".page-manage-icon").addClass("active");
			$(this).siblings("li").find(".page-manage-icon").removeClass("active");
		});
	})
	//草稿
	$(".del-draft-btn").click(function () {
		var flag = $(this).attr("flag");
		if (flag == 0) { //没有草稿可以删除
			return false;
		}
		$(window).wdtWindowPop({
			popId : "wdtWindowOne", //弹层1
			//title:"<b>模块内容</b>(icon添加格式png,尺寸为56*56)",
			title : "删除草稿",
			isCloseBtn:false,
			width : 442,
			height : "auto",
			content : $("#del-textarea").val(),
			showCallback : function () {
				$("#wdtWindowOne .tcnewtop").css("border-bottom",0);
				//点击取消按钮
				$(".pop-module-cancel").on("click", function () {
					$("#wdtWindowOne").remove();
					$("#wdtDivLayer").hide();
					return;
				});
				$("#btndeleteok").on("click", function () {
					$("#wdtDivLayer").hide();
					$("#wdtWindowOne").remove();
					$.ajax({
						type : "Post",
						url : "/sys/Config/Delete",
						dataType : "json",
						data : {
							"DescMerchantId" : merchantId
						},
						async : false,
						success : function (successdata) {
							//console.log(successdata);
							var successobj = JSON.parse(successdata);
							if (successobj.ret == 0) {
								commonjs.GetBtnOKHtml(successobj.msg,"/sys/config/index?mid=" + merchantId);
							} else if (successobj.ret == -1) {
								commonjs.GetBtnOKHtml(successobj.msg,"/sys/config/index?mid=" + merchantId);
							}
						}
					});
				});
			}
		});
	});
	//发布
	$(".operate .release-btn").on("click", function () {
		//console.log('dddd');
		$(window).wdtWindowPop({
			popId : "wdtWindowOne", //弹层1
			//title:"<b>模块内容</b>(icon添加格式png,尺寸为56*56)",
			title : "消息提示",
			isCloseBtn:false,
			width : 442,
			height : "auto",
			content : $("#pulish-textarea").val(),
			draggle : ".edit-mode-list",
			showCallback : function () {
				$("#wdtWindowOne .tcnewtop").css("border-bottom",0)
				$("#wdtWindowOne .pop-ok").on("click", function () {
					is_draft = "1";
					$("#wdtWindowOne").remove();
					$("#wdtDivLayer").remove();
					publishInfor();
				});
			}
		});
	})
	//草稿
	$(".operate .save-draft-btn").click(function () {
		is_draft = "0";
		publishInfor();
	});
	var publishInfor = function () {
		//模板取值
		var themeconfig,
		themeCode,
		themeBg = "",
		colorcode,
		styleId,
		bg_image_enable,
		color_id,
		background_img_origin = {};
		var $this = $('.theme-style-list li.hover');
		themeCode = $this.attr('themecode');
		themeid = $this.attr('styleid');
		var $colorobj = $('.theme-color-list li.hover');
		colorcode = $colorobj.attr('colorCode');
		color_id = $colorobj.attr("color_id");
		bg_image_enable = $this.attr("bg_image_enable");
		if (bg_image_enable == 1) //主题是否有背景图
		{
			//console.log($(".wap").attr("bgimg"));
			themeBg = $(".wap").attr("bgimg");
		}
		//背景图
		background_img_origin = {
			"HashCode" : $(".wap").attr("oldhashcode"),
			"SourceImg" : $(".wap").attr("oldsourceimg"),
			"TargetImg" : themeBg
		};
		//功能模块取值
		var moudleconfig = [],
		singleModule;
		var code,
		name,
		icon,
		sort,
		flag = 0,
		draft_module_id,
		app_module_id,
		module_id,
		merchant_module_id,
		group_id,
		group_code,
		app_control_code,
		modulecateid; //flag=0;正常,flag=1已隐藏
		//模块
		$("#sortable li").each(function (i) {
			var $this = $(this);
			code = $this.attr('module_code');
			if (code == "ad") {
				app_control_code = "10001";
				group_code = "ad";
				group_id = "1";
			} else {
				if (themeid == 6) {
					switch (code) {
					case "pt":
					case "jx":
					case "cx":
					case "vote":
						app_control_code = "12001";
						group_code = "list";
						group_id = "2";
						break;
					default:
						app_control_code = "11020";
						group_code = "menu";
						group_id = "3";
					}
				} else {
					app_control_code = $(this).parent().attr("app_control_code");
					group_code = $(this).parent().attr("group_code");
					group_id = $(this).parent().attr("group_id");
				}
			}
			name = $this.find('.basic-detail').text();
			icon = $this.find('.dragicon').attr('src');
			merchant_module_id = $this.attr("merchant_module_id");
			app_module_id = $this.attr("app_module_id");
			module_id = $this.attr("module_id");
			modulecateid = $this.attr("cateid");
			if ($this.hasClass("draghidden")) {
				flag = 1;
			} else {
				flag = 0;
			}
			sort = i + 1;
			singleModule = {
				"app_module_id" : app_module_id,
				"module_code" : code.trim(),
				"module_name" : name.trim(),
				"icon" : icon.trim(),
				"sort" : sort,
				"hidden" : flag,
				"cat_id" : modulecateid,
				"module_id" : module_id,
				"merchant_module_id" : merchant_module_id,
				"flag" : "0",
				"group_id" : group_id,
				"group_code" : group_code,
				"app_control_code" : app_control_code
			};
			moudleconfig.push(singleModule);
		});
		//var count = 0;
		var count = iconmodule.length;
		//for(var item in iconmodule){
		//	count=1;
		//console.log('ddd');
		//}
		if (count == 0) {
			var obj = dataJson['theme' + themeCode];
			for (var n = 0; n < obj.modulelist.length; n++) {
				if (obj.modulelist[n].module_code == "ad") {

					singleModule = {
						"app_module_id" : 0,
						"module_code" : obj.modulelist[n].module_code,
						"module_name" : obj.modulelist[n].module_name,
						"icon" : obj.modulelist[n].edit_icon_path,
						"sort" : moudleconfig.length + 1,
						"hidden" : 0,
						"cat_id" : 0,
						"module_id" : obj.modulelist[n].module_id,
						"merchant_module_id" : 0,
						"flag" : "0",
						"group_id" : "1",
						"group_code" : "ad",
						"app_control_code" : "10001"
					};
					moudleconfig.push(singleModule);
				}
			}
		} else {
			for (var i = 0; i < count; i++) {
				singleModule = {
					"app_module_id" : iconmodule[i].app_module_id,
					"module_code" : iconmodule[i].module_code,
					"module_name" : iconmodule[i].module_name,
					"icon" : iconmodule[i].icon,
					"sort" : moudleconfig.length + 1,
					"hidden" : 0,
					"cat_id" : cateId,
					"module_id" : iconmodule[i].module_id,
					"merchant_module_id" : iconmodule[i].merchant_module_id,
					"flag" : "0",
					"group_id" : "1",
					"group_code" : "ad",
					"app_control_code" : "10001"
				};
				//console.log(singleModule);
				moudleconfig.push(singleModule);
			}
		}
		var j = moudleconfig.length;
		for (var i = 0; i < j; i++) {
			var modulename = moudleconfig[i].module_name;
			for (var k = 0; k < j; k++) {
				if (k != i) {
					var name = moudleconfig[k].module_name;
					if (name == modulename) {
						//alert(name + "模块名称重复");
							commonjs.GetBtnOKHtml(name + "模块名称重复","");
						return false;
					}
				}
			}
		}
		//return ;
		//console.log(del_moudleconfig);
		//将删除对象压入moudleconfig
		$.each(del_moudleconfig, function (n, value) {
			if (value.module_code) {
				moudleconfig.push(value);
			}
		});
		//引导页取值
		var bootconfig;

		bootconfig = {},
		status = 0,
		ydimg = [],
		first_boot_origin = []; //默认关闭;0==关闭;1=开启
		onoff = $(".guide-offon input[name='onoff']:checked").val();
		var ydimgcount = 0;
		if (onoff == "on") {
			status = 1;
			$(".guide-upload").find("img").each(function () {
				var src = $(this).attr("src");
				if (src) {
					ydimgcount = ydimgcount + 1;
					ydimg.push(src);
					var first_boot = {
						"HashCode" : $(this).attr("oldhashcode"),
						"SourceImg" : $(this).attr("oldsourceimg"),
						"TargetImg" : src
					};
					first_boot_origin.push(first_boot);
				}
			});
		}
		if (status == 1 && ydimgcount < 1) {
			//alert('请上传启动引导页');
			commonjs.GetBtnOKHtml("请上传启动引导页","");
			return false;
		}
		//for (var i = ydimgcount; i < 3; i++) {
			//ydimg.push("");
		//}
		//系统取值
		var sharestatus = 0,
		share_flag = 0,
		sharearray = [],
		is_onlinetrade = 0,
		is_score = 0,
		is_member = 0,
		is_myorder = 0; //默认不分享;0==不分享;1=分享
		var sharesonoff = $(".share-content input[name='onoff']:checked").val();
		//var is_onlinetrade = $(".share-content input[name='online']:checked").val(); //在线交易
		var is_score = $(".share-content input[name='jifen']:checked").val(); //积分功能
		var is_member = $(".share-content input[name='huiyuan']:checked").val(); //会员卡功能
		var is_myorder = $(".share-content input[name='order']:checked").val(); //会员卡功能
		if (sharesonoff == "on") {
			sharestatus = 1;
			$(".share-content input[name='share-check']:checked").each(function () {
				share_flag = share_flag | $(this).val();
			})
			if (share_flag == 0) {
				//alert('请选择需要分享的信息');
					commonjs.GetBtnOKHtml("请选择需要分享的信息","");
				return false;
			}
		}
		if (merchanttype == 4) {
			is_onlinetrade = 1;
		}
		if (is_score == "on") {
			is_score = 1;
		}
		if (is_member == "on") {
			is_member = 1;
		}
		if (is_myorder == "on") {
			is_myorder = 1;
		}
		//console.log(is_myorder)


		//console.log(merchantId);

		//总发布值
		var publishDatas = {
			"DecsMerchantId" : merchantId,
			"config_id" : config_id,
			"theme_id" : themeid,
			"theme_code" : themeCode,
			"theme_bg" : themeBg,
			"theme_color" : colorcode,
			"module_list" : JSON.stringify(moudleconfig),
			"first_boot" : JSON.stringify(ydimg),
			"is_draft" : is_draft,
			"share_flag" : share_flag,
			"is_share" : sharestatus,
			"is_first_boot" : status,
			"is_onlinetrade" : is_onlinetrade,
			"is_score" : is_score,
			"is_membercard" : is_member,
			"merchant_config_type" : merchant_config_type,
			"bg_image_enable" : bg_image_enable,
			"merchant_config_id" : merchant_config_id,
			"color_id" : color_id,
			"background_img_origin" : JSON.stringify(background_img_origin),
			"first_boot_origin" : JSON.stringify(first_boot_origin),
			"is_myorder" : is_myorder
		};
		//var sydata = JSON.parse(publishDatas);
		//ajax请求
		$.ajax({
			type : "Post",
			url: publishHref + '?is_draft=' + is_draft,
			dataType : "json",
			data : publishDatas,
			async : false,
			success : function (successdata) {
				var successobj = JSON.parse(successdata);
				if (successobj.ret == 0) {
					commonjs.GetBtnOKHtml(successobj.msg,"/sys/config/index?mid=" + merchantId);
				} else if (successobj.ret == -1) {
					commonjs.GetBtnOKHtml(successobj.msg,"/sys/config/index?mid=" + merchantId);
				}
			}
		});
	}
});
function changeStyle(dom) {
	var cssHref = $(dom).attr('styleHref'),
	oLi = $(dom).siblings('li');
	oLi.removeClass('hover');
	$(dom).addClass('hover');
	$('.theme-color-list li').removeClass('hover');

	loadHtml(dom);
	$('#moduleCss').remove();
	var linkHref = '<link id="moduleCss" rel="stylesheet" href="' + cssHref + '">';
	//$($('head')[0]).append(linkHref);
	$('.cut-bg').removeAttr('style');
	$('#colorCss').prepend(linkHref);
	$('#phone').removeAttr('class');
}
function loadHtml(dom) {
	var modelJson = $(dom).attr('modelJson'),
	domHtml = $(dom).attr('domHtml'),
	//MerhantId = $(dom).attr('merhantId'),
	ThemeCode = $(dom).attr('themecode'),
	ThemeId = $(dom).attr('styleid'),
	theme = 'theme' + ThemeCode;
	//console.log(merchantId+'  '+StyleId);
	var datas = {
		"merchantId" : merchantId,
		"cateId" : cateId,
		"ThemeCode" : ThemeCode,
		"ThemeId" : ThemeId
	};
	if (!$(dom).attr('flag')) {
		$.ajax({
			type : "GET",
			url : modelJson,
			dataType : "json",
			data : datas,
			success : function (obj) {
				//obj = JSON.parse((data));
				dataJson[theme] = obj;
				newDom(obj, domHtml, dom);
				$(dom).attr('flag', '1');
			}
		});
	} else {
		obj = dataJson[theme];
		//console.log('begin');
		//console.log(obj);
		//console.log(dataJson);
		newDom(obj, domHtml, dom);
	}
}
function newDom(obj, domHtml, dom) {
	var mks = obj.modulelist;
	var moduleIconPath = mks[0].edit_icon_path;
	var index = moduleIconPath.lastIndexOf("/");
	var iconadress = moduleIconPath.substring(0, index) + "/";
	//console.log(iconadress);
	$(".theme-style-list li.hover").attr("iconadress", iconadress);
	var temhtml,
	adPic;
	$.ajax({
		type : "GET",
		url : domHtml,
		dataType : "text",
		success : function (data) {
			//替换广告
			if ($(".wap-content .ad-list").length) {
				$(".wap-content .ad-list").remove();
			}
			//if(obj.ad_pic){
			//$(".wap-content .title").after("<div class='ad-list'><img src='"+obj.ad_pic+"' /></div>");
			adPic = $(data).find(".ad").html();
			//adPic = adPic.replace("ad_pic",obj.ad_pic);
			$(".wap-content .title").after(adPic);
			//}
			//处理背景图片
			if ($(dom).attr("bg_image_enable") == 1) {
				var url = 'url(' + $(dom).attr("edit_image_path") + ')';
				$(".wap").css({
					'background-image' : url
				});
				$(".wap").attr("bgimg", $(dom).attr("edit_image_path"));
			} else {
				$(".wap").removeAttr('style');
				$(".wap").attr("bgimg", "");
			}
			$("#sortable").attr("app_control_code", $(data).find("ul").attr("app_control_code"));
			$("#sortable").attr("group_code", $(data).find("ul").attr("group_code"));
			$("#sortable").attr("group_id", $(data).find("ul").attr("group_id"));
			temhtml = $(data).find("li").html();
			$("#sortable li").each(function (e) {
				var module_code = $(this).attr("module_code");
				var osrc,
				icon_path,
				user_icon;
				if ($(this).find("img").attr("data_icon") != 0) {
					for (var i in mks) {
						if (module_code == mks[i].module_code) {
							if (mks[i].module_code != "ad") {
								osrc = mks[i].edit_icon_path;
								icon_path = $(this).find("img").attr("src");
								user_icon = $(this).find("img").attr("data_icon");
								temhtml = temhtml.replace("user_icon", user_icon);
								temhtml = temhtml.replace("icon_path", icon_path);
								temhtml = temhtml.replace("module_name", $(this).find(".basic-detail").html());
								temhtml = temhtml.replace("module_type", $(this).find(".static-detail").html());
							}
						}
					}
				} else {
					for (var i in mks) {
						if (module_code == mks[i].module_code) {
							if (mks[i].module_code != "ad") {
								temhtml = temhtml.replace("user_icon", 0);
								temhtml = temhtml.replace("icon_path", mks[i].edit_icon_path);
								temhtml = temhtml.replace("module_name", $(this).find(".basic-detail").html());
								temhtml = temhtml.replace("module_type", $(this).find(".static-detail").html());
							}
						}
					}
				}

				//alert(temhtml);
				$(this).html(temhtml);
				temhtml = $(data).find("li").html();
				if ($(this).find("img").attr("data_icon") != 0) {
					$(this).find("img").attr('osrc', osrc);
					if ($(this).find("img").attr("data_icon") == 2) {
						$(this).find("img").attr('upimg', 'true');
					}
				}
			});
			/*初始加载开始:加入浮动控制框*/
			var mk_append = '<div class="drag_ts"><a title="编辑" class="drag_edit" href="javascript:void(0)">编辑</a><a title="隐藏" class="drag_view" href="javascript:void(0)">隐藏</a><a title="删除" class="drag_del" href="javascript:void(0)">删除</a><a title="拖动" class="drag_handle">手柄</a></div>';
			var mk_two_append = '<div class="drag_ts"><a title="编辑" class="drag_edit" href="javascript:void(0)">编辑</a><a title="拖动" class="drag_handle">手柄</a></div>';
			var mk_three_append = '<div class="drag_ts"><a title="编辑" class="drag_edit" href="javascript:void(0)">编辑</a><a title="隐藏" class="drag_view" href="javascript:void(0)">隐藏</a><a title="拖动" class="drag_handle">手柄</a></div>';
			$("#dragsource").find("li").append(mk_append);
			$("#sortable li").each(function () {
				if ($(this).attr("module_code").trim() == "about" || $(this).attr("module_code").trim() == "usercenter") {
					$(this).append(mk_two_append);
				} else if ($(this).attr("module_code").trim() == "shopspage") {
					$(this).append(mk_three_append);
				} else {
					$(this).append(mk_append);
				}
			});
			/*初始加载结束*/
			//颜色配色变化开始
			var oLi,
			cUL = '';
			//console.log(obj.colorlist);
			for (var i in obj.colorlist) {
				oLi = '<li colorCode="' + obj.colorlist[i].color_code + '" color_id="' + obj.colorlist[i].color_id + '">' +
					'<div class="square ' + obj.colorlist[i].css_class_name + '"></div>' +
					'<img class="current-hover" src="http://r1.55.com/wdtres/wdtF2E/customSite/static/pagemanager/current-color.png"/>' +
					'</li>'
					cUL = cUL + oLi;
			}
			$(".theme-color-list").html('');
			$('.theme-color-list').html(cUL);
			$('.theme-color-list li').first().addClass('hover');
			//颜色配色变化结束
			var changeColor = 'color-' + $('.theme-color-list li.hover').attr('colorcode');
			$('#phone').attr('class', changeColor);
		}
	})
}
function changeColorStyle(dom) {
	var cssName = "color-" + $(dom).attr('colorCode'),
	oLi = $(dom).siblings('li');
	oLi.removeClass('hover');
	$(dom).addClass('hover');
	$('.theme-color-value').attr('value', cssName);
	$('#phone').attr('class', cssName);

}

