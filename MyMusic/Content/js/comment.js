function startComment() {
	var comment = document.getElementById("dataComment").value;
	var url_comment = $('#url_comment').attr("href");
	
	$.ajax({
		type : 'GET',
		data : {},
        url: url_comment + "&contentComment=" + comment,
		success : function() {
            location.reload();
		},
		error : function() {
			location.reload();
		}
	});
}
