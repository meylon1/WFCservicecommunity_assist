using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "communityService" in code, svc and config file together.
public class communityService : IcommunityService
{
    Community_AssistEntities db = new Community_AssistEntities();

 

    public int Login(string email,string password)
    {
        int key = 0;
        int result = db.usp_Login(email, password);
        if (result != -1)
        {
            var userKey = (from b in db.People
                           where b.PersonEmail.Equals(email)
                           select b.PersonKey).FirstOrDefault();

            key = (int)userKey;
        }
        return key;
    }

    public bool newGrant(GrantRequest GQ)
    {

        db.GrantRequests.Add(GQ);
        db.SaveChanges();
        return true;
         
    }

    public bool RegisterUser(personInfo E)
    {
        bool result = true;
        int person = db.usp_Register(E.lastname, E.firstname, E.email, E.password, E.apartmentNumber, E.street, E.city, E.state, E.zipcode, E.homePhone, E.workPhone);
                     

         return result;

    }

    public List<GrantRequest> ReviewG (int key)
    {
        var req = from b in db.GrantRequests where b.PersonKey == key select b;
        List<GrantRequest> Gran = new List<GrantRequest>();
        foreach ( var r in req)
        { GrantRequest gr = new GrantRequest();
            gr.GrantRequestAmount = r.GrantRequestAmount;
            gr.GrantRequestDate = r.GrantRequestDate;
            gr.GrantRequestExplanation = r.GrantRequestExplanation;
            gr.PersonKey = r.PersonKey;

            Gran.Add(gr);
        }

        return Gran;



    }


}
