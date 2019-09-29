using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using User.Core.UseCases;
using User.Infrastructure.Database;
using User.Infrastructure.InMemory;

namespace User.Tests
{
    [TestFixture]
    public class FindUserTest
    {
        [Test]
        public async Task TestMemoryFindUserById()
        {
            const int id = 1;
            
            var repository = new UserMemoryRepository();

            repository.Create(new Core.Entities.User());
            
            var findUser = new FindUser(repository);

            var user = await findUser.ByIdAsync(id);

            Assert.AreEqual(id, user.Id);
        }

        [Test]
        public async Task TestDatabaseFindUserById()
        {
            const int id = 1;

            var options = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase("Users")
                .Options;

            await using var context = new UserContext(options);
            var repository = new UserDatabaseRepository(context);

            repository.Create(new Core.Entities.User());
            
            var findUser = new FindUser(repository);

            var user = await findUser.ByIdAsync(id);

            Assert.AreEqual(id, user.Id);
        }
    }
}