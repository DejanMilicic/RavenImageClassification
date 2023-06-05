using RavenImageClassification;
using RestSharp;

Console.WriteLine("Hello, World!");

var client = new RestClient(new RestClientOptions("http://localhost/"));

var request = new RestRequest("api/predict", Method.Post);

using FileStream fs = File.OpenRead(@"C:\GitHub\imagercg-waiter\backend\test2.jpeg");

request.AddFile(name: "image", getFile: ()=>fs, "image/jpeg");

var response = client.Post<ClassifierResponse>(request);

var x= 1;