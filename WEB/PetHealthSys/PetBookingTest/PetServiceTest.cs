using NUnit.Framework;
using System;

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
            var pet = new Pet("Owner", "Doctor", "", "male", "Canine", DateTime.Now);
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Pet name - Must not be empty", result);
        }

        [Test]
        public void TestPetNameShort()
        {
            var pet = new Pet("Owner", "Doctor", "B", "male", "Canine", DateTime.Now);
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Pet registered successfully", result);
        }

        [Test]
        public void TestPetNameWithNumber()
        {
            var pet = new Pet("Owner", "Doctor", "Bobby1", "male", "Canine", DateTime.Now);
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Pet name - Must only contain alphabetic characters and spaces", result);
        }

        [Test]
        public void TestGenderBlank()
        {
            var pet = new Pet("Owner", "Doctor", "Bobby", "", "Canine", DateTime.Now);
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Gender - Must not be empty", result);
        }
        [Test]
        public void TestDoctorNameBlank()
        {
            var doctor = new Doctor("", 1, "General");
            var result = _petService.RegisterDoctor(doctor);
            Assert.That(result, Is.EqualTo("Doctor’s name - Doctor’s name can not be blank"));
        }

        [Test]
        public void TestDoctorNameTooLong()
        {
            var doctor = new Doctor("ThisNameIsWayTooLongToBeValid", 1, "General");
            var result = _petService.RegisterDoctor(doctor);
            Assert.That(result, Is.EqualTo("Doctor’s name - The length isn’t more than 20 characters"));
        }

        [Test]
        public void TestDoctorNameWithNumbers()
        {
            var doctor = new Doctor("Doctor123", 1, "General");
            var result = _petService.RegisterDoctor(doctor);
            Assert.That(result, Is.EqualTo("Doctor’s name - Number is not allowed"));
        }

        [Test]
        public void TestDoctorNameWithSpecialCharacters()
        {
            var doctor = new Doctor("Dr. John@Doe", 1, "General");
            var result = _petService.RegisterDoctor(doctor);
            Assert.That(result, Is.EqualTo("Doctor’s name - Special character is not allowed"));
        }

        [Test]
        public void TestValidDoctorRegistration()
        {
            var doctor = new Doctor("John Doe", 1, "General");
            var result = _petService.RegisterDoctor(doctor);
            Assert.That(result, Is.EqualTo("Doctor registered successfully"));
        }
        [Test]
        public void TestValidPetRegistration()
        {
            var pet = new Pet("Owner", "Doctor", "Bobby", "male", "Canine", DateTime.Now);
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Pet registered successfully", result);
        }

        [Test]
        public void TestBirthdayInThePast()
        {
            var pastDate = DateTime.Now.AddYears(-1); // One year ago
            var pet = new Pet("Owner", "Doctor", "Bobby", "male", "Canine", pastDate);
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Pet registered successfully", result);
        }

        [Test]
        public void TestBirthdayInTheFuture()
        {
            var futureDate = DateTime.Now.AddYears(1); // One year in the future
            var pet = new Pet("Owner", "Doctor", "Bobby", "male", "Canine", futureDate);
            var result = _petService.RegisterPet(pet);
            Assert.AreEqual("Birthday cannot be in the future", result);
        }
        [Test]
        public void TestServiceBlank()
        {
            var result = _petService.RegisterService("");
            Assert.AreEqual("Service - Must not be blank", result);
        }

        [Test]
        public void TestServiceTooLong()
        {
            var result = _petService.RegisterService("This is a very long service name that exceeds twenty one characters");
            Assert.AreEqual("Service - The length isn’t more than 20 characters", result);
        }

        [Test]
        public void TestServiceValid()
        {
            var result = _petService.RegisterService("Grooming");
            Assert.AreEqual("Service registered successfully", result);
        }

        [Test]
        public void TestServiceStartsWithSpace()
        {
            var result = _petService.RegisterService(" Grooming");
            Assert.AreEqual("Service - First character cannot have space", result);
        }
        [Test]
        public void TestServiceSpecialCharacters()
        {
            var result = _petService.RegisterService("Grooming@");
            Assert.AreEqual("Service - Special character is not allowed", result);
        }
    }
}
