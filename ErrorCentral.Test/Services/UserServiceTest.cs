using AutoMapper;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Application.Services;
using ErrorCentral.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ErrorCentral.Test.Services
{
    public class UserServiceTest
    {
        private readonly Mock<IOptions<TokenDTO>> mockToken;
        private readonly Mock<IMapper> mockMapper;

        public UserServiceTest()
        {
            mockToken = new Mock<IOptions<TokenDTO>>();
            mockToken.Setup(x => x.Value)
                .Returns(new TokenDTO()
                {
                    Secret = "InsertYourTokenSecretHere",
                    ExpirationHours = 1,
                    Issuer = "ConradoAlexsander",
                    ValidAt = "http://localhost:53290"
                });

            mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async void AddUser()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(x => x.Add("Johny Doe", "johnydoe@test", "123"))
                .Returns(Task.FromResult(true));

            var usuarioAplicacao = new UserService(mockRepo.Object, mockMapper.Object, mockToken.Object);
            var feedback = await usuarioAplicacao.Add(new UserDTO()
            {
                UserName = "Johny Doe",
                Email = "johnydoe@test",
                Password = "123"
            });

            Assert.True(feedback);
        }

        [Fact]
        public void CheckIfTokenWasGenerated()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(x => x.Login("johnydoe@testjohnydoe@test", "123"))
                .Returns(Task.FromResult(new IdentityUser()));

            var usuarioAplicacao = new UserService(mockRepo.Object, mockMapper.Object, mockToken.Object);
            var retorno = usuarioAplicacao.Login(new LoginDTO()
            {
                Email = "thamy@gmail.com",
                Password = "1234"
            });

            Assert.NotNull(retorno);
        }
    }
}