using System;
using NUnit.Framework;

namespace PetRegistration.Tests
{
    public class PetServiceTests
    {
        private PetService _petService;

        [SetUp]
        public void SetUp()
        {
            _petService = new PetService();
        }

        [Test]
        public void TestPetNameBlank()
        {
            var pet = new Pet("", "Cat", "Female", "Canine", "2024-06-07");
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Pet Name cannot be blank", result);
        }

        [Test]
        public void TestPetNameShort()
        {
            var pet = new Pet("Bo", "Dog", "Male", "Canine", "2024-06-07");
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Pet Name must be more than 2 characters", result);
        }

        [Test]
        public void TestPetNameWithNumber()
        {
            var pet = new Pet("Bobby1", "Dog", "Male", "Canine", "2024-06-07");
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Pet Name cannot contain numbers", result);
        }

        [Test]
        public void TestKindOfPetBlank()
        {
            var pet = new Pet("Bobby", "", "Male", "Canine", "2024-06-07");
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Kind Of Pet cannot be blank", result);
        }

        [Test]
        public void TestGenderBlank()
        {
            var pet = new Pet("Bobby", "Dog", "", "Canine", "2024-07-01");
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Gender cannot be blank", result);
        }

        [Test]
        public void TestSpeciesBlank()
        {
            var pet = new Pet("Bobby", "Dog", "Male", "", "2024-07-01");
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Species cannot be blank", result);
        }

        [Test]
        public void TestSpeciesWithSpecialCharacter()
        {
            var pet = new Pet("Bobby", "Dog", "Male", "C@nine", "2024-07-01");
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Species cannot contain special characters or numbers", result);
        }

        [Test]
        public void TestSpeciesWithNumber()
        {
            var pet = new Pet("Bobby", "Dog", "Male", "Canine123", "2024-07-01");
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Species cannot contain special characters or numbers", result);
        }

        [Test]
        public void TestBirthdayInThePast()
        {
            var pet = new Pet("Bobby", "Dog", "Male", "Canine", "2023-07-01");
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Birthday cannot be in the past", result);
        }

        [Test]
        public void TestValidPetRegistration()
        {
            var pet = new Pet("Bobby", "Dog", "Male", "Canine", "2024-07-01");
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Pet registered successfully", result);
        }
    }
}
