using Sitecore.XConnect;

namespace Demo.XConnectFacet.Domain.XConnect
{
  [FacetKey(DefaultFacetKey)]
  public class SalesRepresentativeInfo : Facet
  {
    public const string DefaultFacetKey = "SalesRepresentativeInfo";
    public string SRFirstName { get; set; }
    public string SRLastName { get; set; }
    public string SREmail { get; set; }

  }
}