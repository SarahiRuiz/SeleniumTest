using TestProjectSelenium.Models;

namespace TestProjectSelenium.Data
{
    public class UserLoginDataInstances
    {
        public static UserLoginData InvalidUser = new UserLoginData
        {
            UserName = "Test",
            Password = "Test"
        };
        public static UserLoginData ValidUser = new UserLoginData
        {
            UserName = "test",
            Password = "test"
        };
    }
}
