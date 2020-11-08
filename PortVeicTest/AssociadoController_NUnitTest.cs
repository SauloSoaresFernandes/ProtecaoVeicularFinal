using Api;
using Api.Controllers;
using NUnit.Framework;

namespace PortVeicTest
{
    public class Tests
    {
        [TestFixture]
        public class AssociadoController_NUnitTest
        {
            private AssociadosController associadoController;

            private readonly ProtecaoVeicularContext _context;

            [SetUp]
            public void Setup()
            {
                associadoController = new AssociadosController(_context);
            }

            [TestCase(1)]
            public void GetAssociadoById_Sucesso(int id)
            {
                var resultado = associadoController.GetAssociados(id).GetAwaiter().GetResult();

                var nomeAssociado = resultado.Value.NomeAssociado;

                Assert.IsTrue(nomeAssociado.Length > 0);
            }
        }
        
    }
}