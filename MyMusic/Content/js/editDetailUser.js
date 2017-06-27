function disableAllEditButton() {
		var confirmEidtUserNameButton = document
				.getElementById("confirmEditUserNameButton");
		var confirmEidtEmailButton = document
				.getElementById("confirmEditEmailButton");
		var confirmEidtFullNameButton = document
				.getElementById("confirmEditFullNameButton");
		var confirmEidtPasswrodButton = document
				.getElementById("confirmEditPasswordButton");
		confirmEidtUserNameButton.disabled = true;
		confirmEidtEmailButton.disabled = true;
		confirmEidtFullNameButton.disabled = true;
		confirmEidtPasswrodButton.disabled = true;
		$("#noticePasswordNotTheSame").hide();
		$("#noticeUserNameNotEmpty").hide();
		$("#noticeEmailNotEmpty").hide();
		$("#noticeFullNameNotEmpty").hide();
	}

	function activeConfirmEditUserNameButton() {
		var userNameInput = $("#userNameInput").val();
		var lengthUserName = userNameInput.length;
		if (lengthUserName == 0) {
			document.getElementById('noticeUserNameNotEmpty').innerHTML = "User name not empty";
			$("#noticeUserNameNotEmpty").css('color', 'red');
			$("#noticeUserNameNotEmpty").show();

			var confirmEditUserNameButton = document
					.getElementById("confirmEditUserNameButton");
			confirmEditUserNameButton.disabled = true;
		} else if (lengthUserName < 8) {
			document.getElementById('noticeUserNameNotEmpty').innerHTML = "User name must be than 8 character";
			$("#noticeUserNameNotEmpty").css('color', 'red');
			$("#noticeUserNameNotEmpty").show();
			var confirmEditUserNameButton = document
					.getElementById("confirmEditUserNameButton");
			confirmEditUserNameButton.disabled = true;
		} else {
			$("#noticeUserNameNotEmpty").hide();
			var confirmEditUserNameButton = document
					.getElementById("confirmEditUserNameButton");
			confirmEditUserNameButton.disabled = false;
		}

	}
	function activeConfirmEditEmailButton() {

		var emailInput = $("#emailInput").val();
		var lengthEmail = emailInput.length;
		if (lengthEmail == 0) {
			document.getElementById('noticeEmailNotEmpty').innerHTML = "Email not empty";
			$("#noticeEmailNotEmpty").css('color', 'red');
			$("#noticeEmailNotEmpty").show();
			var confirmEidtEmailButton = document
					.getElementById("confirmEditEmailButton");
			confirmEidtEmailButton.disabled = true;
		} else if (lengthEmail < 8) {
			document.getElementById('noticeEmailNotEmpty').innerHTML = "Email must be correct format";
			$("#noticeEmailNotEmpty").css('color', 'red');
			$("#noticeEmailNotEmpty").show();
			var confirmEidtEmailButton = document
					.getElementById("confirmEditEmailButton");
			confirmEidtEmailButton.disabled = true;
		} else {
			$("#noticeEmailNotEmpty").hide();
			var confirmEidtEmailButton = document
					.getElementById("confirmEditEmailButton");
			confirmEidtEmailButton.disabled = false;
		}

	}
	function activeConfirmEditFullNameButton() {

		var fullNameInput = $("#fullNameInput").val();
		var lengthFullName = fullNameInput.length;
		if (lengthFullName == 0) {
			document.getElementById('noticeFullNameNotEmpty').innerHTML = "Full name not empty";
			$("#noticeFullNameNotEmpty").css('color', 'red');
			$("#noticeFullNameNotEmpty").show();

			var confirmEditUserNameButton = document
					.getElementById("confirmEditFullNameButton");
			confirmEditUserNameButton.disabled = true;
		} else if (lengthFullName < 8) {
			document.getElementById('noticeFullNameNotEmpty').innerHTML = "Full name must be than 8 character and have less than one space";
			$("#noticeFullNameNotEmpty").css('color', 'red');
			$("#noticeFullNameNotEmpty").show();
			var confirmEditUserNameButton = document
					.getElementById("confirmFullNameButton");
			confirmEditUserNameButton.disabled = true;
		} else {
			$("#noticeFullNameNotEmpty").hide();
			var confirmEditUserNameButton = document
					.getElementById("confirmEditFullNameButton");
			confirmEditUserNameButton.disabled = false;
		}
	}

	function checkNewPasswordAndConfirmNewPassword() {
		var newPassword = $("#newPasswordInput").val();
		var confirmPassword = $("#confirmNewPasswordInput").val();
		var n = newPassword.length;

		if (newPassword != "" && confirmPassword != "") {
			if (n > 8) {
				if (newPassword == confirmPassword) {
					$("#noticePasswordNotTheSame").hide();
					var confirmEidtFullNameButton = document
							.getElementById("confirmEditPasswordButton");
					confirmEidtFullNameButton.disabled = false;
				} else {
					var confirmEidtFullNameButton = document
							.getElementById("confirmEditPasswordButton");
					confirmEidtFullNameButton.disabled = true;
					$("#noticePasswordNotTheSame").css('color', 'red');
					document.getElementById('noticePasswordNotTheSame').innerHTML = "New Password and Confirm New Password must be the same";
					$("#noticePasswordNotTheSame").show();
				}
			} else {
				var confirmEidtFullNameButton = document
						.getElementById("confirmEditPasswordButton");
				confirmEidtFullNameButton.disabled = true;
				$("#noticePasswordNotTheSame").css('color', 'red');
				document.getElementById('noticePasswordNotTheSame').innerHTML = "Password must be than 8 character";
				$("#noticePasswordNotTheSame").show();

			}
		}

	}

	function checkUserNameInput() {
		var userNameInput = $("#userNameInput").val();
		var url_editUserName = $('#url_editUserName').attr("href");
		$.ajax({
			type : 'GET',
			data : {},
			url : url_editUserName +"&userName="+ userNameInput,
			success : function() {
				$("#userNameMainHeader").html(userNameInput);
				$("#userNameMainTable").html(userNameInput);
				$("#userNameViewMenu").html(userNameInput);
				setTimeout(function(){$('#myModalUserName').modal({backdrop: false})}, 10);
				setTimeout(function(){$('#myModalUserName').modal('hide')}, 1500);
				
			}
		});

	}
	function checkEmailInput() {
		var emailInput = $('#emailInput').val();
		var url_editEmail = $('#url_editEmail').attr("href");
		
		$.ajax({
			type : 'GET',
			data : {},
			url : url_editEmail +"&email="+ emailInput,
			success : function() {
				$("#mainEmail").html(emailInput);
				setTimeout(function(){$('#myModalEmail').modal({backdrop: false})}, 10);
				setTimeout(function(){$('#myModalEmail').modal('hide')}, 1500);
			}
		});

	}
	function checkFullNameInput() {
		var fullNameInput = $("#fullNameInput").val();
		var url_editFullName = $('#url_editFullName').attr("href");
		$.ajax({
			type : 'GET',
			data : {},
			url : url_editFullName +"&fullName="+ fullNameInput,
			success : function() {
				$("#mainFullName").html(fullNameInput);
				setTimeout(function(){$('#myModalFullName').modal({backdrop: false})}, 10);
				setTimeout(function(){$('#myModalFullName').modal('hide')}, 1500);
			}
		});

	}
	
	function checkPasswordInput() {
		var passwordInput = $('#newPasswordInput').val();

		var url_editPassword = $("#url_editPassword").attr("href");
		$.ajax({
			type : 'GET',
			data : {},
			url : url_editPassword +"&password="+ passwordInput,
			success : 		
				
				
				function() {
				setTimeout(function(){$('#myModalPassword').modal({backdrop: false})}, 10);
				setTimeout(function(){$('#myModalPassword').modal('hide')}, 1500);
				
			}
		});
	}
