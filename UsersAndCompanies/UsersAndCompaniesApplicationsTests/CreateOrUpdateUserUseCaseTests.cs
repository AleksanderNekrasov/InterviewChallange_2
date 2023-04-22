using AutoFixture;
using FakeItEasy;
using UsersAndCompaniesApplications;
using UsersAndCompaniesApplications.Dtos;
using UsersAndCompaniesDataAccess.Entities;
using UsersAndCompaniesDataAccess;

namespace UsersAndCompaniesApplicationsTests
{
    public class CreateOrUpdateUserUseCaseTests
    {
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void CreateUser_WhenDtoNotValid_ShouldThrowArgumentException()
        {
            //Assert
            var userDto = _fixture.Build<UserDto>().Without(x => x.Surname).Create();
            var repo = A.Fake<IRepository<UserEntity>>();
            var useCase = new CreateOrUpdateUserUseCase(repo);

            //Act
            Task result() => useCase.CreateUser(userDto);

            Assert.That(result, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdateUser_WhenDtoNotValid_ShouldThrowArgumentException()
        {
            //Assert
            var userDto = _fixture.Build<UserDto>().Without(x => x.Surname).Create();
            var repo = A.Fake<IRepository<UserEntity>>();
            var useCase = new CreateOrUpdateUserUseCase(repo);

            //Act
            Task result() => useCase.UpdateUser(userDto);

            Assert.That(result, Throws.TypeOf<ArgumentException>());
        }
    }
}