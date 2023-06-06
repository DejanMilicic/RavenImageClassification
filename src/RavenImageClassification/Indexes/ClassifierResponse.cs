namespace RavenImageClassification.Indexes;

public class ClassifierResponse
{
    public bool success { get; set; }

    public Prediction[] predictions { get; set; }
}

public class Prediction
{
    public string label { get; set; }

    public decimal probability { get; set; }
}
