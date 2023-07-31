using Sitecore.XConnect;
using Sitecore.XConnect.Schema;

namespace Demo.XConnectFacet.Domain.XConnect
{
  public class SalesRepresentativeModel
  {
    public static XdbModel Model { get; } = BuildModel();

    private static XdbModel BuildModel()
    {
      var builder = new XdbModelBuilder("SalesRepresentativeModel", new XdbModelVersion(1, 0));

      builder.DefineFacet<Contact, SalesRepresentativeInfo>(SalesRepresentativeInfo.DefaultFacetKey);

      return builder.BuildModel();
    }
  }
}