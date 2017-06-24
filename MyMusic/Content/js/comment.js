function startComment() {
	var comment = document.getElementById("dataComment").value;
	var url_comment = $('#url_comment').attr("href");
	var url_postID = $('#stockPost').attr("href");
	$.ajax({
		type : 'GET',
		data : {},
		url : url_comment + url_postID + "/" + comment,
		success : function(result) {
			$("#dataTest").load(result);
		},
		error : function() {
			location.reload();
		}
	});
}
