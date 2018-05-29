(function () {
	console.log("hello api");

	var HttpClient = function () {
		this.get = function (aUrl, aCallback) {
			var anHttpRequest = new XMLHttpRequest();
			anHttpRequest.onreadystatechange = function () {
				if (anHttpRequest.readyState == 4 && anHttpRequest.status == 200)
					aCallback(anHttpRequest.responseText);
			}

			anHttpRequest.open("GET", aUrl, true);
			anHttpRequest.send(null);
		}
	}

	var client = new HttpClient();
	client.get("https://localhost:44328/api/Cars", function (response) {
		console.log(response);

		document.getElementById("api-result").innerHTML = response;
	});

})();