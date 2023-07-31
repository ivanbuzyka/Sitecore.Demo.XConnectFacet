using System.IO;

namespace ModelSerializer
{
  internal class Program
  {
    static void Main(string[] args)
    {
      System.Console.WriteLine("Generating your model ...");
      var model = Demo.XConnectFacet.Domain.XConnect.SalesRepresentativeModel.Model;
      string filePath = "C:\\temp\\" + model.FullName + ".json";
      var serializedModel = Sitecore.XConnect.Serialization.XdbModelWriter.Serialize(model);
      File.WriteAllText(filePath, serializedModel);
      System.Console.WriteLine("Your model is here: " + filePath);
      System.Console.WriteLine("Press any key to continue!");
      System.Console.ReadKey();
    }
  }
}
