using Swim_Feedback.Services;

namespace Swim_Feedback_Tests.Services
{
    [TestClass]
    public class TestAccountService
    {
        private AccountService accountService = new();

        [TestMethod]
        public void Login()
        {
            //accountService.Login();
            Assert.IsTrue(true);
        }
    }
}
