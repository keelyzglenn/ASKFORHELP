using System.Collections.Generic;
using Addresses.Objects;


namespace Contacts.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact>{};
    private string _name;
    private int _id;
    private List<Address> _addressList;

    public Contact(string contactName)
    {
      _name = contactName;
      // _number = contactNumber;
      _instances.Add(this);
      _id = _instances.Count;
      _addressList = new List<Address>{};
    }
// name
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
// address
// these are for adding address into addressList
    public List<Address> GetAddress()
    {
      return _addressList;
    }
    public void AddAddress(Address address)
    {
      _addressList.Add(address);
    }
// number
    // public string GetNumber()
    // {
    //   return _number;
    // }
    // public void SetNumber(string newNumber)
    // {
    //   _number = newNumber;
    // }
// id
    public int GetId()
    {
      return _id;
    }

// instances
    public static List<Contact> GetAll()
    {
     return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
