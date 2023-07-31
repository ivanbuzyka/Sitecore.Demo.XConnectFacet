using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using System;
using System.Web.Mvc;

namespace Demo.XConnectFacet.Controllers
{
  public class SetFacetController : Controller
  {
    // GET: API to set facet for the controller using GET "/api/sitecore/SetFacet?contactId=CONTACT_ID" request
    public ActionResult Index(string contactId)
    {
      using (Sitecore.XConnect.Client.XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
      {
        var reference = new Sitecore.XConnect.ContactReference(Guid.Parse(contactId));
        var contact = client.Get(reference, new Sitecore.XConnect.ContactExecutionOptions(new Sitecore.XConnect.ContactExpandOptions(Demo.XConnectFacet.Domain.XConnect.SalesRepresentativeInfo.DefaultFacetKey)));

        if (contact != null)
        {
          var salesRepresentativeInfoFacet = contact.GetFacet<Demo.XConnectFacet.Domain.XConnect.SalesRepresentativeInfo>(Demo.XConnectFacet.Domain.XConnect.SalesRepresentativeInfo.DefaultFacetKey);
          if (salesRepresentativeInfoFacet != null)
          {
            salesRepresentativeInfoFacet.SRFirstName = "John";
            salesRepresentativeInfoFacet.SRLastName = "Doe";
            salesRepresentativeInfoFacet.SREmail = "johnDoe@test.com";
          }
          else
          {
            salesRepresentativeInfoFacet = new Demo.XConnectFacet.Domain.XConnect.SalesRepresentativeInfo()
            {
              SRFirstName = "John",
              SRLastName = "Doe",
              SREmail = "johnDoe@test.com"
            };
            client.SetFacet<Domain.XConnect.SalesRepresentativeInfo>(contact, Demo.XConnectFacet.Domain.XConnect.SalesRepresentativeInfo.DefaultFacetKey, salesRepresentativeInfoFacet);
          }

          client.Submit();
        }

        // return anonymous json object here
        return Json(new { contactId = contactId }, JsonRequestBehavior.AllowGet);
      }
    }
  }
}