using MongoDB.Driver.Builders;

namespace passstore
{
    public class TestUser : UserBase
    {
        public override UserBase GetUser(string username)
        {
            return new TestUsers().Collection.FindOneAs<TestUser>(Query<TestUser>.EQ(u => u.Username, username));
        }
    }
}
