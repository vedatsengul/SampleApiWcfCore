using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RebTel.WCF.Data;
using RebTel.WCF.Models;

namespace RebTel.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SubscriptionService : ISubscriptionService
    {
        private IAppRepository _repository;

        public SubscriptionService(IAppRepository repository)
        {
            _repository = repository;
        }

        public List<User> GetUsers()
        {
            return _repository.GetUsers();
        }

        public User GetUser(int id)
        {
            return _repository.GetUser(id);
        }

        public bool CreateUser(User newUser)
        {
            return _repository.CreateUser(newUser);
        }

        public bool AddSubscriptionToUser(UserSubscription userSubscription)
        {
            return _repository.AddSubscriptionToUser(userSubscription);
        }

        public bool DeleteUser(int userId)
        {
            return _repository.DeleteUser(userId);
        }
        public List<Subscription> GetSubscriptions()
        {
            return _repository.GetSubscriptions();
        }
        public Subscription GetSubscription(string id)
        {
            return _repository.GetSubscription(id);
        }

        public bool CreateSubscription(Subscription newSubscription)
        {
            return _repository.CreateSubscription(newSubscription);
        }
        
        public bool DeleteSubscription(string subscriptionId)
        {
            return _repository.DeleteSubscription(subscriptionId);
        }

        public bool UpdateSubscription(Subscription subscription)
        {
            return _repository.UpdateSubscription(subscription);
        }
    }
}
