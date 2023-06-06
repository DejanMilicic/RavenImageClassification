using RavenImageClassification.Models;

namespace RavenImageClassification;

public static class Seed
{
    public static void Do()
    {
        using var session = DocumentStoreHolder.Store.OpenSession();

        var scan1 = new Scan { Id = "Scans/1-A" };
        session.Store(scan1);
        using FileStream file1 = File.Open("./images/test1.jpeg", FileMode.Open);
        session.Advanced.Attachments.Store(scan1.Id, "test1.jpeg", file1, "image/jpeg");

        var scan2 = new Scan { Id = "Scans/2-A"};
        session.Store(scan2);
        using FileStream file2 = File.Open("./images/test2.jpeg", FileMode.Open);
        session.Advanced.Attachments.Store(scan2.Id, "test2.jpeg", file2, "image/jpeg");
        
        session.SaveChanges();
    }
}

