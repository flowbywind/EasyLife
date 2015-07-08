;(function($){
	//trim
	String.prototype.trim = function () {
		return this .replace(/^\s\s*/, '' ).replace(/\s\s*$/, '' );
	}
	//窗口高度全屏
	$.fn.windowSize = function(options){
		var $this=$(this);
		var opts = $.extend({
			bigNodeName:".big",
			topNode:".header",
			addHeightNum:0,
			scroll:false,
			scrollNum:0
		},options);
		var screenH=$(window).height(),
			topH=$(opts.topNode).height(),
			mainH,bigH;
			mainH=screenH-topH + opts.addHeightNum;
		if($(opts.bigNodeName).length){
			bigH=$(opts.bigNodeName).height()+opts.addHeightNum+parseInt($(opts.bigNodeName).css('margin-top'));
			if(mainH<=bigH){
				mainH=bigH;
			}
		}
		if(opts.scroll){
			$this.css('height',mainH-opts.scrollNum);
		}else{
			$this.css('height',mainH);
		}
	}
	//弹窗插件
	$.fn.wdtWindowPop = function(options){
        var $this = $(this),_this = this;
        var opts = $.extend({
			popId:"wdtWindowOne",
			closeBtn : "close",
            //tempurl : "load.html",
			tempurl : "",
            content : "这里是内容",
			title:"弹窗标题",
			isTitleTag:false,		//有标题样式?
			showTime : 500,
            width : 500,
            height : 300,
			isCloseBtn : true,		//带关闭按钮？
			isTitle : true,
			isReady : true,
			isLayer : true,			//带遮罩层？
			isAjax : false,			//ajax提交？
			ajaxUrl : "",
			closeFlag:"",
			draggle:"",
			showCallback:function(){},
			hideCallback:function(){}
        },options);
		if($this.size()==0) return false;
		
		var aliasId = "#" + opts.popId;
		var title = opts.isTitle?opts.title:"";
		var data_Class = opts.isTitleTag?"tcnewcle tcnewcleno":"tcnewcle";
		var closehtml = opts.isCloseBtn?"<a href=\"javascript:\" class=\""+data_Class+"\" data=\""+opts.closeBtn+"\">X</a>":"";
		var bodyheight = $(window).height()+"px";
		var divLayer = $("<div></div>").attr("id","wdtDivLayer").css({"background":"#000","opacity":0.4,"width":"100%","height":"2000px"}).hide();
		var iframeLayer = $("<iframe></iframe").css({"width":"100%","height":"100%","opacity":0,"background":"#fff","border":0});
		var boxWrap = $("<div></div>").attr("id",opts.popId).addClass("tcnewbox").hide();

		divLayer.append(iframeLayer);
		if(opts.isTitleTag){
			boxWrap.html("<div class=\"tcnewtop tcnewtop_no\">"+closehtml+"</div><div class=\"tcnewbd\"></div>");
		}else{
			boxWrap.html("<div class=\"tcnewtop\">"+closehtml+"<h2 class=\"tcnewtit\"></h2></div><div class=\"tcnewbd\"></div>");
		}
		if(opts.isReady && $(aliasId).length == 0 ) $("body").append(boxWrap);
		if(opts.isLayer && $("#wdtDivLayer").length == 0) $("body").append(divLayer);

		var $body = $(aliasId + " .tcnewbd"),$titleLabel = $(aliasId + " .tcnewtit");

		$titleLabel.html(title);

		var initLocationEvent = function(){
			var $aliasId = $(aliasId);
			$aliasId.css({"width":opts.width,"height":opts.height,"z-index":9999,"position":"fixed"});
			var top = ($(window).outerHeight() - $(aliasId).outerHeight()) / 2;
			var left = ($(window).outerWidth() - $(aliasId).outerWidth()) / 2;
			$aliasId.css({"top":top + "px","left":left + "px"});
			$("#wdtDivLayer").css({"top":"0px","position":"fixed"});
		}

		var showLayerEvent = function(){
			initLocationEvent();
			$(aliasId).fadeIn(opts.showTime);
			$("#wdtDivLayer").show();
			return false;
		}
		
		var  closeLayerEvent = function(){
			//最后一个层才隐藏遮罩
			if($(".tcnewbox").length == 1){
				$(aliasId).fadeOut(opts.showTime);
				$("#wdtDivLayer").hide();
			}else{
				$(aliasId).fadeOut(opts.showTime).remove();
				$(".tcnewbox").last().show();	
			}
			
			if($(".cut-laywer").length){
				$(".cut-laywer").remove();
			}
			
			setTimeout(function(){opts.hideCallback($body)},opts.showTime);
				return false;
		}
		var hideLayerEvent = function(){
			closeLayerEvent();
			opts.hideCallback($body);
			return false;
		}
		var sendAjaxEvent = function(){
			//不是ajax提交 刷新页面
			if(!opts.isAjax) {			
				window.location.href= opts.ajaxUrl;
				return false;
			}
			$.ajax({
				url : opts.ajaxUrl,
				type : "GET",
				dataType : "json",
				beforeSend : function(){
					$(aliasId + ".tcnewbd").html('<table width="100%" height="150"><tr><td align="center"><img src="http://s0.55tuanimg.com/themes/default/images/static/img/55pic/newfivethree/css/img/loading.gif" title="处理中"/><br/>处理中.....</td></tr></table>');
				},
				success : function(msg){
					if(msg.flag) hideLayerEvent();
					return false;
				},
				error : function(msg){
					return false;
				}
			});
		}
		if(opts.tempurl){
			$body.load(opts.tempurl,function(){
				opts.showCallback($body);
				if(opts.isAjax) $("#okbtn").bind("click",sendAjaxEvent);
			});
		}else{
			$body.html(opts.content);
			opts.showCallback($body);
			//加入拖拽排序
			if(opts.draggle){
				$(opts.draggle).sortable({
					cursor:"move",  
					revert: false,
					forceHelperSize:true,
					placeholder: 'ui-sortable-placeholder',  
					forcePlaceholderSize: true,
					tolerance: 'pointer',
					containment: '.edit-mode-list',					
					scroll: true,
					stop:function(event, ui){	
						/*
						var index = ui.item.attr("id");
						index = $("#wdtWindowOne .edit-mode-list li").index($("#"+index));
						var count = $("#wdtWindowOne .edit-mode-list li").length;
						var poplistli = $("#wdtWindowOne .edit-mode-list li");
						if(index==0){
							poplistli.eq(0).find(".sort-up").attr("style","display:none;");
							poplistli.eq(0).find(".sort-down").removeAttr("style");
							poplistli.eq(1).find(".sort-up,.sort_down").removeAttr("style");
						}else{
							if(index == (count-1)){							
								poplistli.eq(count-1).find(".sort-down").attr("style","display:none;");
								poplistli.eq(count-1).find(".sort-up").removeAttr("style");								
								poplistli.eq(count-2).find(".sort-down,.sort-up").removeAttr("style");
							}else{								
								poplistli.eq(index).find(".sort-down").removeAttr("style");
								poplistli.eq(index).find(".sort-up").removeAttr("style");								
								poplistli.eq(0).find(".sort-up").attr("style","display:none;");
								poplistli.eq(0).find(".sort-down").removeAttr("style");															
								poplistli.eq(count-1).find(".sort-down").attr("style","display:none;");
								poplistli.eq(count-1).find(".sort-up").removeAttr("style");
							}
						}
						*/
						var count = $("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").length;
						$("#wdtWindowOne .edit-mode-list li").find(".sort-down").removeAttr('style');
						$("#wdtWindowOne .edit-mode-list li").find(".sort-up").removeAttr('style');
						$("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").eq(0).find(".sort-up").css('display','none');
						$("#wdtWindowOne .edit-mode-list li:not(.pop_li_del)").eq(count-1).find(".sort-down").css('display','none');
					}	
				});	
			}
			$("#okbtn").bind("click",sendAjaxEvent);
		}

		showLayerEvent();
		$(window).bind("resize",initLocationEvent);
		$(aliasId + "[data='"+opts.closeBtn+"']").bind("click",closeLayerEvent);
		$(aliasId + " [data='"+opts.closeBtn+"']").bind("click",closeLayerEvent);
	};
	//tab切换插件
	$.fn.tabselect = function(options){
		var $this = $(this);
		//console.log($this);
		if($this.length == 0) return false;
		var opts = $.extend({
			thisClass:"on",
			navList:".tit li",
			boxList:".bd ul",
			eTrigger:"click",
			numShow:0
		},options);
		$this.find(opts.navList).eq(opts.numShow).addClass(opts.thisClass);
		$this.find(opts.boxList).eq(opts.numShow).show();
		var tabEve = function(){
			//console.log('2');
			var index = $(this).index();
			$this.find(opts.navList).removeClass(opts.thisClass);
			$this.find(opts.boxList).hide();
			$(this).addClass(opts.thisClass);
			$this.find(opts.boxList).eq(index).show();
		}
		$this.find(opts.navList).bind(opts.eTrigger,tabEve);
	};
	
	$.fn.tabon = function(options){
		var $this = $(this),_this=this;					
		var opts = $.extend({		
			on_class:"",
			li_nav:"",
			con_nav:""			
		},options);
		if($this.length==0) return false;
		var liNav = $this.find(opts.li_nav),
			   conNav = $this.find(opts.con_nav),	
			   onClass = opts.on_class;
		var clickEvent = function(){
				var num = $(this).index();
				liNav.removeClass(onClass);
				conNav.hide();	
				liNav.eq(num).addClass(onClass);						
				conNav.eq(num).show();
		};			
		liNav.bind("click",clickEvent);			
	};
	$.fn.clickDefultEvent = function(){		
		if($(this).length==0) return false;
		if($("#preview_link").hasClass("greyColor")) return false;
		var clickEvent = function(){		
			var winwidth = $(window).width(), //浏览器的宽度
				   domEidth = $(".preview_pop").width(),
				   boxLeft = (winwidth-domEidth)/2;	
			//$("#preview_textaer").css("display","block").ieFixed({x:boxLeft,y:10});
			$("#preview_textaer").css({"display":"block","position":"fixed","top":"11px","left":boxLeft});
			$(".preview_pop").tabon({
				on_class:"on",
				li_nav:".edition_ul li",
				con_nav:".pre_r .bgdiv"			
			});
			$(".preview_pop .close").click(function(){
				$("#preview_textaer").css("display","none")	
			});	
		};
		$("#preview_link").bind("click",clickEvent);
	};
})(jQuery);

$(function(){
	//浏览器版本控制
	var browser=function(){
		var b_name = navigator.appName; 
		if (b_name == "Microsoft Internet Explorer") { 
			var b_version = navigator.appVersion,
				version = b_version.split(";"),
				trim_version = version[1].replace(/[ ]/g, ""); 
			if (trim_version == "MSIE9.0" || trim_version == "MSIE8.0"|| trim_version == "MSIE7.0"|| trim_version == "MSIE6.0"){ 
				$('.version-tip').slideDown();
			} 
		}
	}
	browser();
	$(".version-tip .version-but").on("click",function(){
		$('.version-tip').slideUp();
	});	
});