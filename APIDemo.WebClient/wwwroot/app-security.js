$(function () {

	var baseUrl = "https://localhost:44328";
	var accessToken = "";

	var showResponse = function (obj) {
		$("#output").text(JSON.stringify(obj, null, 4));
	};

	var saveAccessToken = function (data) {
		console.log(data);
		accessToken = data.token;
	};

	var login = function () {
		var url = baseUrl + "/token";
		var loginForm = $("#userData").serializeArray();
		var data = {};
		$.each(loginForm, function (i, v) {
			data[v.name] = v.value;
		});

		$.ajax({
			type: 'POST',
			url: url,
			data: JSON.stringify(data),
			contentType: "application/json; charset=utf-8",
			dataType: 'json'
		})
			.done(saveAccessToken)
			.fail(error)
			.always(showResponse);

		return false;
	};

	var getHeaders = function () {
		if (accessToken) {
			return {
				"Authorization": "Bearer " + accessToken
			}
		}
	};

	var getData = function () {
		var url = baseUrl + "/api/Cars";

		$.ajax(url, {
			method: "GET",
			headers: getHeaders()
		})
			.done(success)
			.fail(error)
			.always(showResponse);

		return false;
	};

	var success = function (data) {
		console.log(data);
	};

	var error = function (xhr) {
		console.log(xhr);
	};

	// Eventhandler
	$("#login").click(login);
	$("#getData").click(getData);
});