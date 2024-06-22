    using NUnit.Framework;
    using Moq;
    using PetCareSystem.Services.Services.Auth;
    using PetCareSystem.Services.Models.Auth;
    using PetCareSystem.Data.Entites;
    using PetCareSystem.Data.Repositories.Roles;

    namespace PetCareSystem.Tests
    {
        [TestFixture]
        public class RoleServiceTests
        {
            private IAuthService _authService;
            private Mock<IRoleRepository> _mockRoleRepository;
            private Role _role;

            [SetUp]
            public void Setup()
            {
                _mockRoleRepository = new Mock<IRoleRepository>();
                _authService = new AuthService(null, null, _mockRoleRepository.Object, null);

                _role = new Role
                {
                    Id = 1,
                    Title = "AD",
                    Name = "Admin"
                };

                _mockRoleRepository.Setup(repo => repo.GetRoleByTitleAsync(_role.Title)).ReturnsAsync((Role)null);
                _mockRoleRepository.Setup(repo => repo.Create(It.IsAny<Role>())).Callback<Role>(role =>
                {
                    // Simulate the creation process and print the role details
                    Console.WriteLine($"Creating role: {role.Title}, {role.Name}");
                }).Returns(Task.CompletedTask);
                
            }
            
            [Test]
            public async Task CreateRoleAsync_ValidData_PrintsRole()
            {
                // Arrange
                var createRoleRequest = new CreateRoleReq
                {
                    Title = "AD",
                    Name = "Admin"
                };

                // Act
                await _authService.CreateRole(createRoleRequest);

                // Assert
                _mockRoleRepository.Verify(repo => repo.Create(It.Is<Role>(r => r.Title == createRoleRequest.Title && r.Name == createRoleRequest.Name)), Times.Once);
            }

            [Test]
            public async Task CreateRoleAsync_RoleAlreadyExists_ReturnsFalse()
            {
                // Arrange
                var createRoleRequest = new CreateRoleReq
                {
                    Title = "AD",
                    Name = "Admin"
                };

                _mockRoleRepository.Setup(repo => repo.GetRoleByTitleAsync(_role.Title)).ReturnsAsync(_role);

                 await _authService.CreateRole(createRoleRequest);
        
                _mockRoleRepository.Verify(repo => repo.Create(It.IsAny<Role>()), Times.Never);
            }

        }
    }
        

