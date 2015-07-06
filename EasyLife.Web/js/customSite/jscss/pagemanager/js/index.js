var del_singleModule;
var goodspage_num = 1;
var del_moudleconfig = [];
$(function() {
	/*初始加载开始:加入浮动控制框*/
	var mk_append = '<div class="drag_ts"><a title="编辑" class="drag_edit" href="javascript:void(0)">编辑</a><a title="隐藏" class="drag_view" href="javascript:void(0)">隐藏</a><a title="删除" class="drag_del" href="javascript:void(0)">删除</a><a title="拖动" class="drag_handle">手柄</a></div>';
	var mk_two_append = '<div class="drag_ts"><a title="编辑" class="drag_edit" href="javascript:void(0)">编辑</a><a title="拖动" class="drag_handle">手柄</a></div>';
	var mk_three_append = '<div class="drag_ts"><a title="编辑" class="drag_edit" href="javascript:void(0)">编辑</a><a title="隐藏" class="drag_view" href="javascript:void(0)">隐藏</a><a title="拖动" class="drag_handle">手柄</a></div>';
	$("#dragsource").find("li").append(mk_append);
	$("#sortable li").each(function(){
		// if($(this).find(".static-detail").html()=="个人中心" || $(this).find(".static-detail").html()=="关于我们"){
			// $(this).append(mk_two_append);
		// }else{
			// $(this).append(mk_append);
		// }
		var m_m_code = $(this).attr("module_code");
		var f_id = $("#dragsource li[module_code='"+m_m_code+"']").attr("id");
		$(this).attr("f_id",f_id);
		
		if($(this).attr("module_code").trim()=="about" || $(this).attr("module_code").trim()=="usercenter"  ){
			$(this).append(mk_two_append);
		}
		else if($(this).attr("module_code").trim()=="shopspage"){
			$(this).append(mk_three_append);
			}
		else{
		$(this).append(mk_append);
		}
	});
	/*初始加载结束*/	
	var myIndex,sortId,mk_id,osrc;	
	sortId = $("#sortable").children('li').length;
	var tooltipwidth = $("#del_div").width();
	$("#dragsource li").draggable({
		cursor: "move",
		helper: "clone",
		connectToSortable: '.columnlist',
		opacity:0.1,
		snap:"li",
		start: function(event,ui) {			
			myIndex = $(this).index();
			/*索引值结束*/
			var drgClone = $(this).clone(true);
			$(this).find(".basic-sub").attr("style","border-color:#f63");
			mk_id = $(this).attr("id");			
			/*改变图片开始  change guolijuan*/
			/*
			var stylenum = $('#phone').attr('class').split(' ')[0].substr(5);		
			osrc = $(this).find('.dragicon').attr('src');
			var opath=osrc.split('mode-general');
			osrc = opath[0]+"mode-template"+stylenum+opath[1];*/
			/*改变图片结束*/
			osrc = $(this).find('.dragicon').attr('src');
			osrc = osrc.substring(osrc.lastIndexOf("/")+1);
		},
		stop:function(event, ui){			
			$(this).find(".basic-sub").removeAttr("style");
			$(".drag_ts").hide();
			var styleId=$('.theme-style-list li.hover').attr('styleid');
			if(styleId == '6'){
				var popNew='<div style="text-align:center;line-height:80px;">您已经选择<'+$(this).find('.basic-detail').text()+'>模块</div>'+
								'<ul class="pop-footer clearfix">'+
									'<a class="pop-ok pop-cut-ok mr-20" href="#">确认</a>'+
								'</ul>'
				$(window).wdtWindowPop({
					popId:"wdtWindowOne",
					title:"添加模块",
					width:450,
					height:"auto",
					content:popNew,
					showCallback:function() {
						$("#wdtWindowOne .pop-ok").on("click",function(){
							$("#wdtWindowOne").remove();
							$("#wdtDivLayer").hide();
						});
					}
				});
			}
    	}		
	});
	/*初始加入计算可拖拽次数开始*/
	var dragnum_array = new Array();
	var drag_array = new Array();
	$("#sortable li").each(function(){
		drag_array.push($(this).attr("f_id"));		
	});
	var count = 1;  
	var yuansu= new Array();
	var sum = new Array();
	for (var i = 0; i < drag_array.length; i++) {   
		for(var j=i+1;j<drag_array.length;j++)  
		{  
			if (drag_array[i] == drag_array[j]) {  
				count++;
				drag_array.splice(j,1);  
				j--;   
			}  
		}  
		yuansu[i] = drag_array[i];
		sum[i] = count;
		count =1;
	}  
	var str = '';  
	$("#dragsource li").each(function(){
		if($(this).attr("value")<=0){
			$(this).draggable("option", "disabled", true);
		};
	});
	//算出array数组中不同的元素出现的次数  
	for (var i = 0; i < yuansu.length; i++) {		
		$("#dragsource li").each(function(){
			if($(this).attr("id") == yuansu[i]){
				var newvalue = $(this).attr("value")- sum[i];
				$(this).attr("value",newvalue);
				if(newvalue <= 0){	
					$(this).draggable("option", "disabled", true);
				}
			}	
		});
	}
	/*初始加入计算可拖拽次数结束*/	
	$( "#sortable" ).droppable({		
		accept: ":not(.ui-sortable-helper)",
		opacity:0.1,
		activate:function(event, ui){
			$(this).css({"cursor":"move"});
		},
		deactivate:function(event, ui){
			$(this).css("cursor","none");			
		},
		drop: function(event,ui){						 
			$(this).droppable();			
		}
	}).sortable({
		cursor:"move",  
		revert: false,
		forceHelperSize:true,
		placeholder: 'ui-sortable-placeholder',  
        forcePlaceholderSize: true,
        tolerance: 'pointer',
		containment:"#container",
		scroll: true,
		connectWith: '.columnlist',
		handle:'.drag_handle',
		start:function(){
			$("#del_div").css("display","none");
		},		
		update:function(event, ui){
			/*根据索引值改变次数，决定是否可拖拽*/
			var nowValue = $("#dragsource li").eq(myIndex).attr("value");
			if(nowValue>0){
				nowValue = nowValue-1;
			}
			$("#dragsource li").eq(myIndex).attr("value",nowValue);
			/*禁止拖拽开始*/
			if($("#dragsource li").eq(myIndex).attr("value")==0){
				$("#dragsource li").eq(myIndex).draggable("option", "disabled", true); 
			}	
			/*禁止拖拽结束*/
    	},
		stop:function(e, ui){
			var $this = $("#sortable").find(".ui-draggable");
			
			//改变ICON图片	
			
			var iconadress = $(".theme-style-list").find(".hover").attr("iconadress");
			osrc = iconadress + osrc;
			$this.find(".dragicon").attr("src",osrc);
			
			//计算商品可拖拽次数开始
			if($this.attr("module_code")=="goodspage"){
				//goodspage_num = goodspage_num + 1;
				var goodsDetail;
				if(goodspage_num==1){
					goodsDetail = $this.find(".basic-detail").html();
				}else{
					goodsDetail = $this.find(".basic-detail").html()+goodspage_num;
				}
				var compare = function(){
					$("#sortable li:not(.ui-draggable) .basic-detail").each(function(){						
						if($(this).html().trim() == goodsDetail.trim()){
							goodspage_num = goodspage_num + 1;
							goodsDetail = $this.find(".basic-detail").html()+goodspage_num;
							compare();
						}
					});
				};
				compare();
				$this.find(".basic-detail").html(goodsDetail);
				goodspage_num = goodspage_num + 1;
			}
			//计算商品可拖拽次数结束
			$this.attr({"data_index":myIndex,"id":sortId,"f_id":mk_id}).removeAttr("class value style");
			$this.find('img').attr("data_icon","0");
			
			//删除moudleconfig对象里的对应元素
				/*
				$.each(del_moudleconfig,function(n,value) { 
					   console.log(value);
					   if($this.attr("module_code")==value.module_code){
						   delete del_moudleconfig[n]; 
					   }
				});
				*/
			//删除结束			
			$this.find(".dragicon").attr("src",osrc);
			sortId = sortId +1;
			$("#sortable").css("cursor","default");
			//移入移出开始
			$("#sortable").on("mouseenter","li",function(event){				
				$(this).find(".drag_ts").show();
				//event.stopPropagation();
			});
			$("#sortable").on("mouseleave","li",function(event){				
				$(this).find(".drag_ts").hide();
				//event.stopPropagation(); 
			});
			//移入移出结束
			//点击删除按钮				
			$this.find(".drag_del").on("click",function(){
				var left = $(this).parent().parent().offset().left+$(this).parent().parent().width()-tooltipwidth;
				var top = $(this).parent().parent().offset().top-61;
				var del_id = $(this).parent().parent().attr("id");				
				var modulename=$(this).parent().parent().find(".basic-detail").html();
				var currentobj= $("#del_div");
				currentobj.css({"left":left,"top":top,"display":"block"}).attr({"value":del_id});
				currentobj.find(".detail").html('确定要删除'+modulename.trim()+'?');
			});
			//点击隐藏按钮
			$this.find(".drag_view").on("click",function(){
				$(this).parent().parent().addClass("draghidden");
			});
		}
				
	});
	//移入移出
	$("#sortable").on("mouseenter","li",function(event){		
		$(this).find(".drag_ts").show();
		//event.stopPropagation();
	});
	$("#sortable").on("mouseleave","li",function(event){
		$(this).find(".drag_ts").hide();
	});
	//点击删除按钮	
	$("#sortable").on("click",".drag_del",function(e){		
		var left = $(this).parent().parent().offset().left+$(this).parent().parent().width()-tooltipwidth;;
		var top = $(this).parent().parent().offset().top-61;
		var del_id = $(this).parent().parent().attr("id");				
		var currentobj= $("#del_div"),
			currentBg = $("#del_div_bg"),
			oneBgW=$('body').width(),
			oneBgH=$('body').height();
		currentBg.css({"width":oneBgW,"height":oneBgH,"display":"block"}).attr({"value":del_id});
		currentobj.css({"left":left,"top":top,"display":"block"}).attr({"value":del_id});
		var modulename=$(this).parent().parent().find(".basic-detail").html();
		currentobj.find(".detail").html('确定要删除'+modulename.trim()+'?');		
		e.stopPropagation();
	});
	/*
	$(document).click(function(){
		$("#del_div").css('display','none');
	});	*/
	//确认删除按钮
	$("#del_sort_li").on("click",function(){		
		$(this).parent().css("display","none");
		$("#del_div_bg").css("display","none");
		var d_id = $(this).parent().attr("value")+"";		
		var sortable_del_index = $("#"+d_id).attr("data_index");
		//记录删除记录
		var del_module_code = $("#" + d_id).attr("module_code"),
		    merchant_module_id = $("#" + d_id).attr("merchant_module_id"),
		    app_module_id = $("#" + d_id).attr("app_module_id"),
		    module_name = $("#" + d_id).find(".basic-detail").html().trim(),
			icon =  $("#" + d_id).find("img").attr("src"),
			sort=$("#" + d_id).attr("sort"),
			hidden = $("#" + d_id).attr("hidden"),
			cat_id = $("#" + d_id).attr("cat_id"),
			module_id=$("#" + d_id).attr("module_id");
		del_singleModule = { "merchant_module_id": merchant_module_id, "app_module_id": app_module_id,
			    "module_code":del_module_code, "module_name":module_name, "icon":icon, 
             "sort":sort, "hidden":hidden, "cat_id":cat_id, "module_id":module_id,"flag":1};
		del_moudleconfig.push(del_singleModule);
		$("#"+d_id).remove();
		
		var dragsource_value = parseInt($("#dragsource li").eq(sortable_del_index).removeClass("ui-draggable-disabled").attr("value"))+1;
		$("#dragsource li").eq(sortable_del_index).draggable("option", "disabled", false); 		
		$("#dragsource li").eq(sortable_del_index).attr("value",dragsource_value);
	})
	//取消删除
	$("#del_cancel").on("click",function(){
		$(this).parent().css("display","none");
		$("#del_div_bg").css("display","none");
	})
	//点击隐藏按钮
	$("#sortable").on("click",".drag_view",function(){
		$(this).parent().parent().addClass("draghidden").insertAfter($("#sortable").children("li:last-child"));
	});
})