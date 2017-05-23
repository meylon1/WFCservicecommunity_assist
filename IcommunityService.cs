using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IcommunityService" in both code and config file together.
[ServiceContract]
public interface IcommunityService
{
    [OperationContract]
    int Login(string Email, string password);

    [OperationContract]
    bool RegisterUser(personInfo E );

    [OperationContract]

    List<GrantRequest> ReviewG (int key);


    [OperationContract]
    bool newGrant(GrantRequest GQ);
   
  
}
    [DataContract]
public class personInfo
{

    [DataMember]

  
    public string firstname { get; set; }
    [DataMember]
    public string lastname { get; set; }
    [DataMember]
     public string email { get; set; }
     [DataMember]
    public string  password { get; set; }
    [DataMember]
    public string apartmentNumber { get; set;}
    [DataMember]
    public string street { get; set; }
    [DataMember]
    public string city { get; set; }
    [DataMember]
    public string state { get; set; }
    [DataMember]
    public string zipcode { get; set;}
    [DataMember]
    public string homePhone { get; set; }
    [DataMember]
    public string WorkPhone { get; set; }
   

}
