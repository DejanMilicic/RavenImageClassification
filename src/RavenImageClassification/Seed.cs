using RavenImageClassification.Models;

namespace RavenImageClassification;

public static class Seed
{
    public static void Do()
    {
        using var session = DocumentStoreHolder.Store.OpenSession();

        var scan1 = new Scan();
        session.Store(scan1);
        using FileStream file1 = File.Open("./images/test1.jpeg", FileMode.Open);
        session.Advanced.Attachments.Store(scan1.Id, "test1.jpeg", file1, "image/jpeg");
        
        session.SaveChanges();
    }
}

