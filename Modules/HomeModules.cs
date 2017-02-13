using Nancy;
using Addresses.Objects;
using System;
using System.Collections.Generic;
using Contacts.Objects;

namespace Contacts
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };

    // shows the contact add form
      Get["/contact/new"] = _ => {
        return View["contact_add.cshtml"];
      };
    // posts the new address from the form onto the list
      Post["/contact/created"] = _ => {
        var newContact = new Contact(Request.Form["contact-name"]);
        return View["created.cshtml", newContact];
      };

      Get["/contact/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        var contactAddress = selectedContact.GetAddress();
        model.Add("contact", selectedContact);
        model.Add("address", contactAddress);
        return View["details.cshtml", model];
      };
      Get["/contact/{id}/address/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<Address> allAddress = selectedContact.GetAddress();
        model.Add("contact", selectedContact);
        model.Add("address", allAddress);
        return View["address_add.cshtml", model];
      };
      Post["/address/add"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(Request.Form["consoleName-id"]);
        List<Address> contactAddress = selectedContact.GetAddress();
        string addressStreet = Request.Form["new-street"];
        string addressCity = Request.Form["new-city"];
        string addressState = Request.Form["new-state"];
        Address newAddress = new Address(addressStreet, addressCity, addressState);
        contactAddress.Add(newAddress);
        model.Add("address", contactAddress);
        model.Add("contact", selectedContact);
        return View["contact.cshtml", model];
      };
    }
  }
}
