var permanotice, tooltip, _alert;
	$(function() {
		new PNotify({
			title : "Hello!",
			type : "dark",
			text : "Have a nice day!",
			nonblock : {
				nonblock : true
			},
			before_close : function(PNotify) {
				// You can access the notice's options with this. It is read only.
				// PNotify.options.text;

				// You can change the notice's options after the timer like this:
				PNotify.update({
					title : PNotify.options.title + " - Enjoy your Stay",
					before_close : null
				});
				PNotify.queueRemove();
				return false;
			}
		});

	});