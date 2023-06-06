using RestSharp;

namespace RavenImageClassification.Indexes;

public static class ImageClassifier
{
    public static ClassifierResponse? Classify(Stream stream, string contentType)
    {
        var client = new RestClient(new RestClientOptions("http://localhost/"));

        var request = new RestRequest("api/predict", Method.Post);
        request.AddFile(name: "image", getFile: () => stream, contentType);

        return client.Post<ClassifierResponse>(request);
    }
}

