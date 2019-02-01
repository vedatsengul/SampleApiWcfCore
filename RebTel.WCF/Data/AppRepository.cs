using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using RebTel.WCF.Models;

namespace RebTel.WCF.Data
{
    public class AppRepository:IAppRepository
    {
        public AppRepository()
        {
        }

        public List<User> GetUsers()
        {
            using (var context = new DataContext())
            {
                //var users = context.Users.Include(x => x.UserSubscriptions).ThenInclude(y=>y.Subscription).ToList();
                var users = context.Users.ToList();
                return users;
            }
        }

        public User GetUser(int id)
        {
            using (var context = new DataContext())
            {
                //var user = context.Users.Include(x=>x.UserSubscriptions).ThenInclude(y => y.Subscription).FirstOrDefault(u => u.Id==id);
                var user = context.Users.FirstOrDefault(u => u.Id == id);
                return user;
            }
        }

        public bool CreateUser(User newUser)
        {
            using (var context = new DataContext())
            {
                context.Add(newUser);
                return context.SaveChanges() > 0;
            }
        }

        public bool AddSubscriptionToUser(UserSubscription userSubscription)
        {
            using (var context = new DataContext())
            {
                context.Add(userSubscription);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var context = new DataContext())
            {
                var userSubs = context.UserSubscriptions.Where(x => x.UserId == userId).ToList();
                context.RemoveRange(userSubs);
                var user=context.Users.FirstOrDefault(u => u.Id == userId);
                context.Remove(user);
                return context.SaveChanges() > 0;
            }
        }
        public List<Subscription> GetSubscriptions()
        {
            using (var context = new DataContext())
            {
                var subscriptions = context.Subscriptions.ToList();
                return subscriptions;
            }
        }
        public Subscription GetSubscription(string id)
        {
            using (var context = new DataContext())
            {
                var subscription = context.Subscriptions.FirstOrDefault(u => u.Id == id);
                return subscription;
            }
        }

        public bool CreateSubscription(Subscription newSubscription)
        {
            using (var context = new DataContext())
            {
                context.Add(newSubscription);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateSubscription(Subscription newSubscription)
        {
            using (var context = new DataContext())
            {
                var tempSubs=context.Subscriptions.FirstOrDefault(u => u.Id == newSubscription.Id);
                tempSubs.Name = newSubscription.Name;
                tempSubs.Price = newSubscription.Price;
                tempSubs.PriceWithVAT = newSubscription.PriceWithVAT;
                tempSubs.CallMinutes = newSubscription.CallMinutes;
                context.Subscriptions.Update(tempSubs);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteSubscription(string subscriptionId)
        {
            using (var context = new DataContext())
            {
                var userSubs = context.UserSubscriptions.Where(x => x.SubscriptionId == subscriptionId).ToList();
                context.RemoveRange(userSubs);
                var subscription= context.Subscriptions.FirstOrDefault(u => u.Id == subscriptionId);
                context.Remove(subscription);
                return context.SaveChanges() > 0;
            }
        }

    }
}