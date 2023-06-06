using Raven.Client.Documents.Indexes;
using RavenImageClassification.Models;

namespace RavenImageClassification.Indexes;

public class Scans_ByObject : AbstractIndexCreationTask<Scan, Scans_ByObject.Entry>
{
    public class Entry
    {
        public string[] Term { get; set; }
    }

    public Scans_ByObject()
    {
        Map = employees => from employee in employees

            let attachmentNames = AttachmentsFor(employee)

            select new Entry
            {
                Term = attachmentNames.Select(x => x.Name).ToArray()
            };
    }
}

