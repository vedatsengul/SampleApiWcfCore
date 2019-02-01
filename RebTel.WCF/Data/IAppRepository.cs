using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RebTel.WCF.Models;

namespace RebTel.WCF.Data
{
    public interface IAppRepository
    {
        List<User> GetUsers();
        User GetUser(int id);
        bool CreateUser(User newUser);
        bool AddSubscriptionToUser(UserSubscription userSubscription);
        bool DeleteUser(int userId);
        List<Subscription> GetSubscriptions();
        Subscription GetSubscription(string id);
        bool CreateSubscription(Subscription newSubscription);
        bool DeleteSubscription(string subscriptionId);
        bool UpdateSubscription(Subscription newSubscription);
    }
}