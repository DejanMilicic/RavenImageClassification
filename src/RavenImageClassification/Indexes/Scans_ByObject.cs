using System.Reflection;
using Raven.Client.Documents.Indexes;
using RavenImageClassification.Models;

namespace RavenImageClassification.Indexes;

public class Scans_ByObject : AbstractIndexCreationTask<Scan, Scans_ByObject.Entry>
{
    public class Entry
    {
        public string[] Terms { get; set; }
    }

    public Scans_ByObject()
    {
        Map = employees => from employee in employees
            
            let terms = AttachmentsFor(employee)
                .SelectMany(att => 
                    ImageClassifier.Classify(
                        LoadAttachment(employee, att.Name).GetContentAsStream(),
                        att.ContentType
                    ).predictions)
                .Where(x => x.probability > 0.5m)
                .Select(x => x.label)
                .ToArray()

            select new Entry
            {
                Terms = terms
            };

            AdditionalSources = new Dictionary<string, string>
            {
                {
                    $"{nameof(ImageClassifier)}", File.ReadAllText(
                        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Indexes", $"{nameof(ImageClassifier)}.cs"))
                }
            };

            AdditionalAssemblies = new HashSet<AdditionalAssembly>()
            {
                AdditionalAssembly.FromNuGet("RestSharp", "110.2.1-alpha.0.3"),
                AdditionalAssembly.FromPath(Assembly.GetExecutingAssembly().Location, new HashSet<string> { "RavenImageClassification.Indexes" })
            };
    }
}

