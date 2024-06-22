using Moq;
using PetCareSystem.Data.Repositories.Users;
using PetCareSystem.Data.Entites;
using PetCareSystem.Services;

namespace UnitTest1
{
    [TestFixture]
    public class AuthServiceTests
    {
        private AuthService _authService;
        private Mock<IUserRepository> _mockUserRepository;

        [SetUp]
        public void SetUp()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _authService = new AuthService(_mockUserRepository.Object);
        }

        [Test]
        public async Task TestLoginAsync_ValidCredentials_ReturnsToken()
        {
            string username = "chi";
            string password = "123456";
            string hashedPassword = "$2a$11$EijoRs/Ry3qFe6I38LJoWOwxnw53KuTWGTFmZFIHjrV09X7.PLv8y"; 
            var user = new User { Username = username, Password = hashedPassword };

            _mockUserRepository.Setup(r => r.GetUserByUsernameAsync(username)).ReturnsAsync(user);

            
            var result = await _authService.LoginAsync(username, password);

            
            Assert.IsTrue(result.Success, "Login should succeed with valid credentials.");
            Assert.IsNotNull(result.Token, "Token should not be null on successful login.");
            Console.WriteLine(result.Token);
        }

        [Test]
        public async Task TestLoginAsync_InvalidPassword_ReturnsInvalidCredentials()
        {
            
            string username = "chi";
            string password = "1234";
            string hashedPassword = "$2a$11$EijoRs/Ry3qFe6I38LJoWOwxnw53KuTWGTFmZFIHjrV09X7.PLv8y";

            
            var mockUser = new User { Username = username, Password = hashedPassword };
            _mockUserRepository.Setup(r => r.GetUserByUsernameAsync(username)).ReturnsAsync(mockUser);

            
            var result = await _authService.LoginAsync(username, password);

            
            if (!result.Success)
            {
                Console.WriteLine(result.Message);
            }
            Assert.IsFalse(result.Success, "Login should fail with invalid password.");
            Assert.AreEqual("Invalid credentials", result.Message, "Expected 'Invalid credentials' message on failure.");
        }
    }
}