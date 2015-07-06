; (function ($) {
    //多图上传回调
    $.fn.mutipulUpload = function (options) {
        var opts = $.extend({
            s: ""
        }, options)

        var $this = $(this);
        if (!$this.length) return false;
        //添加事件      s--》 src地址
        var addCallback = function (s) {
            //  1.往容器里 添加元素
            //  2.重新查找容器里的 个数，个数大于  最大上传值， 上传按钮隐藏
            var $str = "",
				$divList = $this.parent(".mutipul-img-list"),			//list容器
				multipul = parseInt($divList.attr("multipul")),
				$newDiv = "",
				divLen = 0,
				concatStr = "",
				jsonData = [];
            if (s.length > 0) {
                jsonData = eval('(' + s + ')');
                $.each(jsonData, function (i, item) {
                    concatStr += i + "='" + item + "' ";
                });
            }

            if ($this.parent().parent().attr("id") == "outer-goods-detail") {
                $str = $("<div class='mutipul-img-container'><img " + concatStr + "/><b></b><span class='set-min-img'>设置成缩略图</span></div>");
            } else {
                $str = $("<div class='mutipul-img-container'><img " + concatStr + "/><b></b></div>");
            }
            $str.insertBefore($this);									//执行步骤1	
            $newDiv = $divList.find(".mutipul-img-container");     		//重新获取元素
            divLen = $newDiv.length;
            if (divLen >= multipul) {									//判断是否大于容纳数
                $this.hide();
            } else {
                $this.show();
            }
        }//添加结束
        addCallback(opts.s);
    }

    //监听图片删除
    $.fn.imgLisenEvent = function (options) {
        var opts = $.extend({
            mainDom: ".mutipul-img-list",
            subDom: ".mutipul-img-container",
            imgDom: ".set-min-img",						//设置略缩图用到的元素
            transfer: "#form-transfer-img",				//异步表单
            successDom: "#outer-goods-list",				//更改图片放置的外层DOM
            url: "",
            operate: ""
        }, options)

        $(opts.mainDom).delegate("b", "click", function () {			//删除
            var $this = $(this),
                str = "",
                $div = $this.parent(),
                $divList = $div.parent(),
                $uploadArea = $divList.children(".upload-area");

            $div.remove();
            $uploadArea.show();
        });

        $(opts.mainDom).delegate(opts.subDom, "mouseover", function () {
            var $this = $(this);
            $this.find(opts.imgDom).show()
        });
        $(opts.mainDom).delegate(opts.subDom, "mouseout", function () {
            var $this = $(this);
            $this.find(opts.imgDom).hide()
        });
        $(opts.mainDom).delegate(opts.imgDom, "click", function () {
            var $this = $(this),
				img = $this.siblings("img").get(0),					//img Dom
				imgSrc = img.src;

            if ($this.attr("checkFlag") == "1") {		//防止多次点击
                return false;
            } else {
                $.ajax({
                    type: "GET",
                    url: opts.url,
                    data: { operate: opts.operate, src: imgSrc },
                    cache: false,
                    success: function (data) {
                        
                        var s = data.src,
							$str = "",
							concatStr = "",
							$transferDom = $(opts.successDom).find(opts.subDom);

						if (s.length > 0) {
                        jsonData=eval('('+s+')');
                        $.each(jsonData,function(i,item){
                        	concatStr += i + "='" + item + "' ";
                        	});
						}
                        $str = $("<div class='mutipul-img-container'><img " + concatStr + "/><b></b></div>");
                        if ($transferDom.length != 0) {
                            $transferDom.find("img").parent().remove();
                        }
                        var $d = $(opts.successDom).find("#cutgoodslist");
                        $str.insertBefore($d);
                        $d.hide();
                        $this.attr("checkFlag", "1");
                        $this.parents(opts.subDom).siblings(opts.subDom).find(".set-min-img").attr("checkFlag", "0");
                    }
                })
            }
        });
    }

    //用于上传按钮的显示和隐藏，图片的拖拽排序
    $.fn.imgListenInit = function (options) {
        var opts = $.extend({
            divDom: ".mutipul-img-container",				//容器里面元素
            btn: ".upload-area"
        }, options)

        var $this = $(this);
        if (!$this.length) return false;

        var multipul = parseInt($this.attr("multipul"));	//能上传的个数
        if (multipul == 1) return false;						//是否只能上传单个元素  单个 false
        var $divDom = $this.find(opts.divDom),				//容器内元素
			len = $divDom.length,
			$uploadArea = $this.children(opts.btn);			//上传按钮		
        if (len == multipul) {
            $uploadArea.hide();
        } else {
            $uploadArea.show();
        }

        //拖拽排序
        $this.sortable({
            items: '.mutipul-img-container'
        });
    }

})(jQuery);