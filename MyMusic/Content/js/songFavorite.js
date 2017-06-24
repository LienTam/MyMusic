function addFavorite() {
	var url_addFavorite = $('#url_addFavorite').attr("href");
	$.ajax({
		type : 'GET',
		url : url_addFavorite

	});
}
function removeFavorite() {
	var url_removeFavorite = $('#url_removeFavorite').attr("href");
	$.ajax({
		type : 'GET',
		url : url_removeFavorite

	});
}
