using NUnit.Framework;
using Moq;
using PetCareSystem.Services.Services.Pets;
using PetCareSystem.Services.Models.Pet;
using PetCareSystem.Data.Repositories.Pets;
using System.Threading.Tasks;
using System;
using PetCareSystem.Data.Entites;

namespace PetCareSystem.Tests
{
    [TestFixture]
    public class PetServiceTests
    {
        private IPetService _petService;
        private Mock<IPetRepository> _mockPetRepository;
        private Pet _pet;

        [SetUp]
        public void Setup()
        {
            _mockPetRepository = new Mock<IPetRepository>();
            _petService = new PetService(_mockPetRepository.Object, null); 

            _pet = new Pet
            {
                Id = 1,
                PetName = "Destiny",
                KindOfPet = "Cat",
                Gender = true,
                Birthday = DateTime.Now.AddYears(-5),
                Species = "ALN",
            };
            _mockPetRepository.Setup(repo => repo.GetPetByIdAsync(_pet.Id)).ReturnsAsync(_pet);
        }

        [Test]
        public async Task UpdatePetAsync_ValidId_ReturnsTrue()
        {
            // Arrange
            int petId = _pet.Id; 
            var updatePetRequest = new PetRequest
            {
                PetName = "Destiny", 
                KindOfPet = "Cat", 
                Gender = false, 
                Birthday = DateTime.Now.AddYears(-2), 
                Species = "ALN",
            };
            _mockPetRepository.Setup(repo => repo.UpdatePet(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<bool>(),
                It.IsAny<DateTime>(),
                It.IsAny<string>()
            )).ReturnsAsync(true);
            var result = await _petService.UpdatePetAsync(petId, updatePetRequest);
            Console.WriteLine(result);
            if (result)
            {
                var updatedPet = await _mockPetRepository.Object.GetPetByIdAsync(petId);
                Console.WriteLine(updatedPet);
            }
            Assert.IsTrue(result);
            
        }
        
        [Test]
        public async Task UpdatePetAsync_InvalidId_ReturnsFalse()
        {
            int invalidPetId = 1; 
            var updatePetRequest = new PetRequest
            {
                PetName = null,
                KindOfPet = "Cat",
                Gender = false,
                Birthday = DateTime.Now.AddYears(-2),
                Species = "ALN",
            };
            _mockPetRepository.Setup(repo => repo.GetPetByIdAsync(invalidPetId)).ReturnsAsync((Pet)null);
            _mockPetRepository.Setup(repo => repo.UpdatePet(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<bool>(),
                It.IsAny<DateTime>(),
                It.IsAny<string>()
            )).ReturnsAsync(false);
            var result = await _petService.UpdatePetAsync(invalidPetId, updatePetRequest);
            Assert.IsFalse(result);
        }
    }
}
