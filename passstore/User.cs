using System;
using System.Activities.DurableInstancing;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace passstore
{
    public class User : UserBase
    {
        public override UserBase GetUser(string username)
        {
            return new Users().Collection.FindOneAs<User>(Query<User>.EQ(u => u.Username, username));
        }
    }
}