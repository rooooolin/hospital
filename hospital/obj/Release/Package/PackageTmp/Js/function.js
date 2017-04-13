
function checkAll(chkobj){
	if($(chkobj).text()=="全选")
	{
		$(chkobj).text("取消");
		$(".checkall input").attr("checked", true);
	}else{
		$(chkobj).text("全选");
		$(".checkall input").attr("checked", false);
	}
}