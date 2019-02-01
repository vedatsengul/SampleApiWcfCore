using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RebTel.WCF.Models;

namespace RebTel.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISubscriptionService
    {
        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        bool CreateUser(User newUser);

        [OperationContract]
        bool AddSubscriptionToUser(UserSubscription userSubscription);

        [OperationContract]
        bool DeleteUser(int userId);

        [OperationContract]
        List<Subscription> GetSubscriptions();

        [OperationContract]
        Subscription GetSubscription(string id);

        [OperationContract]
        bool CreateSubscription(Subscription newSubscription);

        [OperationContract]
        bool DeleteSubscription(string subscriptionId);
        [OperationContract]
        bool UpdateSubscription(Subscription subscription);
    }
}
