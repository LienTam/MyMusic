
function disableAllInput() {
    $("#inputTableNameSong").hide();
    $("#buttonConfirmNameSong").hide();
}
function showInputNameSong() {
    $("#nameSongMainTable").hide();
    $("#buttonEditNameSong").hide();
    $("#inputTableNameSong").show();
    $("#buttonConfirmNameSong").show();

}
function confirmEditNameSong() {
    $("#nameSongMainTable").show();
    $("#buttonEditNameSong").show();
    $("#inputTableNameSong").hide();
    $("#buttonConfirmButtonNameSong").hide();

}

