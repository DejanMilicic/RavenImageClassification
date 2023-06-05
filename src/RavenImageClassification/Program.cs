using RestSharp;

Console.WriteLine("Hello, World!");

var client = new RestClient(new RestClientOptions("http://localhost/"));

var request = new RestRequest("api/predict", Method.Post);
request.AddFile(
        "image", 
        @"C:\GitHub\imagercg-waiter\backend\test2.jpeg",
        "image/jpeg");

var response = client.Execute(request);

var x= 1;