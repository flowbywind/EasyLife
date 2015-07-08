;(function($){
	//窗口高度全屏
	$.fn.useStrTemplet = function(options){
		var $this=$(this);
		var opts = $.extend({
			str:""
		},options);
	
		var strArr = opts.str.split(","),
			newStrArr = [];
		for(var i = 0,len = strArr.length;i < len; i++){
			if(!$("#" + strArr[i]).length){
				newStrArr.push(strArr[i]);
			}
		}
		
		
		
		var templet =  {  
						/*****************图片上传开始**********************/
						"cut-textarea": '<textarea id="cut-textarea" style="display: none;">'+
											'<form id="cut-form" class="cut-box" method="POST"    action="">'+
												'<input name="uploadId" type="hidden" value="@Guid.NewGuid()"/>'+
												'<input type="hidden" class="cut-uploadflag" name="cut-uploadflag" value=""/>' +//属于哪一个地方上传，上传背景：bg-01 引导图：guide-01,02,03
												'<input type="hidden" name="cut-url" id="cut-url" value="/sys/image/imagecut"/>'+//上传url地址
												'<input type="hidden" name="cut-cutType" id="cut-cutType" value="bg"/>'+//上传类型，上传背景：bg-1 引导图：guide
												'<input type="hidden"  name="cut-base64" id="cut-base64" value="" />'+//上传base64值
												//'<div style="display:none" name="cut-base64" id="cut-base64"></div>'+
												'<input type="hidden" id="cut-position" name="cut-position" value=""/>'+//上传位置：1 引导图：1,2,3
												'<input type="hidden" id="cut-img-offset" name="cut-img-offset" type="hidden" value=""/>' +//回传坐标值 xx|xx
												'<input type="hidden" id="cut-range" name="cut-range" type="hidden" value=""/>' +//回传宽和高 xx|xx/
												'<input type="hidden" id="old-hash-code" name="old-hash-code" type="hidden" value=""/>' +//回传哈希 /
												'<input type="hidden" id="new-hash-code" name="new-hash-code" type="hidden" value=""/>' +//回传新哈希 /
												'<input type="hidden" id="old-source-img" name="old-source-img" type="hidden" value=""/>' +//回传原图地址 /
												'<p class="cut-top">'+
													'<span class="upload-btn"></span>'+
													'<input class="upload-input" type="file" name="up" id="up"   value="" accept="image/jpeg,image/gif,image/png" />'+
													'<a class="cut-message-bar" href="javascript:void(0)" style="display:none;"></a>'+
												'</p>'+
												'<div class="preview-box">'+
													'<div class="cut-process-bar" style="display:none;"></div>'+
													'<div class="preview-area">'+
														'<img id="preview-img" style="display:none;"/>'+
													'</div>'+
												'</div>'+
											'</form>'+
											'<ul class="pop-footer clearfix">'+
												'<a class="pop-ok pop-cut-ok mr-20" href="javascript:void(0)" continue="1">确认</a>'+
												'<a class="pop-cancel pop-cut-cancel" data="close" href="javascript:void(0)">取消</a>'+
											'</ul>'+
										'</textarea>',
										
						/*****************弹窗开始*************************/
						
						"comfirm-textarea":	'<textarea id="comfirm-textarea" style="display: none;">'+
												'<div class="content comfirm-info">这里是信息</div>'+
												'<ul class="pop-footer clearfix">'+
													'<a class="pop-ok  mr-20" href="javascript:void(0)">确认</a>'+
													'<a class="pop-cancel" data="close" href="javascript:void(0)">取消</a>'+
												'</ul>'+
											'</textarea>',
											
						"alert-textarea":	'<textarea id="alert-textarea" style="display: none;">'+
												'<div class="content alert-info"></div>'+
												'<ul class="pop-footer clearfix">'+
													'<a class="pop-ok  alert-btn mr-20" href="javascript:void(0)">确认</a>'+
												'</ul>'+
											'</textarea>'
							
						}
		
		//templet.cutArea
		
		for(var i = 0,len = newStrArr.length; i < len; i++){	
			var k=newStrArr[i];
			$("body").append($(templet[k]));
		}
		
	
	}
})(jQuery)