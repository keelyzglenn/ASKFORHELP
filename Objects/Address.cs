using System.Collections.Generic;
using Contacts.Objects;

namespace Addresses.Objects
{
  public class Address
  {
    private static List<Address> _instances = new List<Address> {};
    private string _street;
    private string _city;
    private string _state;
    private int _id;

    public Address(string addressStreet, string addressCity, string addressState)
    {
      _street = addressStreet;
      _city = addressCity;
      _state = addressState;
      _instances.Add(this);
      _id = _instances.Count;
    }
// street
      public string GetStreet()
      {
        return _street;
      }
      public void SetStreet(string addressStreet)
      {
        _street = addressStreet;
      }
// city
      public string GetCity()
      {
        return _city;
      }
      public void SetCity(string addressCity)
      {
        _city = addressCity;
      }
// state
      public string GetState()
      {
        return _state;
      }
      public void SetState(string addressState)
      {
        _state = addressState;
      }
// id
      public int GetId()
      {
        return _id;
      }
// instance
      public static List<Address> GetAll()
      {
        return _instances;
      }
      public static void ClearAll()
      {
        _instances.Clear();
      }
      public static Address Find(int searchId)
      {
        return _instances[searchId-1];
      }
  }
}
