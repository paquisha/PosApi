using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Dtos.Persona.Request;
using POS.Application.Interfaces;
using POS.Utilities.Static;

namespace POS.Test.Persona
{
    [TestClass]
    public class PersonaApplicationTest
    {
        private static WebApplicationFactory<Program> _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        [ClassInitialize]
        public static void Inicialize(TestContext _testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task RegisterPersona_whenSendingNullValuesOrEmpty_ValidationErrors()
        {
            using var scope = _scopeFactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<IPersonaApplication>();

            var firstName = "";
            var lastName = "";
            var email = "";
            //var status = (int)StateTypes.Active;
            var expected = ReplyMessage.MESSAGE_VALIDATE;
            var result = await context!.RegisterPersona(new PersonaRequestDto()
            {
                FirtsName = firstName,
                LastName = lastName,
                Email = email
                //Status = status
            });
            var cerrent = result.Message;

            Assert.AreEqual(expected, cerrent);
        }

        [TestMethod]
        public async Task RegisterPersona_WhenSendingCorrectValues_RegisteredSuccessfully()
        {
            using var scope = _scopeFactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<IPersonaApplication>();

            var firstName = "";
            var lastName = "";
            var email = "";
            //var status = (int)StateTypes.Active;
            var expected = ReplyMessage.MESSAGE_SAVE;
            var result = await context!.RegisterPersona(new PersonaRequestDto()
            {
                FirtsName = firstName,
                LastName = lastName,
                Email = email
                //Status = status
            });
            var cerrent = result.Message;

            Assert.AreEqual(expected, cerrent);
        }
    }
}
