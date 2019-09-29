using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using User.Core.UseCases;
using User.Infrastructure.Database;
using User.Infrastructure.InMemory;

namespace User.Tests
{
    [TestFixture]
    public class CreateUserTest
    {
        [Test]
        public async Task TestDatabaseCreate()
        {
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase("Users")
                .Options;

            await using var context = new UserContext(options);
            var userRepository = new UserDatabaseRepository(context);

            var createUser = new CreateUser(userRepository);

            var user = new Core.Entities.User
            {
                UserName = "admin",
                Password = "test1234",
                FirstName = "administrator",
                LastName = "administrator"
            };

            await createUser.CreateAsync(user);

            Assert.AreEqual(1, user.Id);
        }
        
        [Test]
        public async Task TestInMemoryCreate()
        {
            var userRepository = new UserMemoryRepository();
            var createUser = new CreateUser(userRepository);

            var user = new Core.Entities.User
            {
                UserName = "admin",
                Password = "test1234",
                FirstName = "administrator",
                LastName = "administrator"
            };

            await createUser.CreateAsync(user);

            Assert.AreEqual(1, user.Id);
        }
    }
}