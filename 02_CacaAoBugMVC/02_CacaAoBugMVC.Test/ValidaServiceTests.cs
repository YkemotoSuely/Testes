using Microsoft.VisualStudio.TestTools.UnitTesting;
using _02_CacaAoBugMVC.Model;

namespace _02_CacaAobugMVC.Test

{

    [TestClass]

    public class ValidaServiceTests

    {

        [TestMethod]

        public void ValidarNome_DeveRetornarTrue_QuandoNomeValido()

        {

            // Arrange

            var service = new ValidaService();

            string mensagemErro;

            // Act

            var resultado = service.ValidarNome("Diego", out mensagemErro);//precisa dos 2 parâmetros para funcionar

            // Assert

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensagemErro, "");

        }

        [TestMethod]

        public void ValidarNome_QuandoVazio_DeveRetornarFalse()

        {

            // Arrange

            var service = new ValidaService();

            string mensagemErro;

            // Act

            var resultado = service.ValidarNome("Diego", out mensagemErro);

            // Assert

            Assert.IsFalse(resultado);
            Assert.AreNotEqual(mensagemErro, "");

        }

        [TestMethod]

        public void ValidarNome_QuandoMenos3Caracteres_DeveRetornarFalse()
        {
            //Arrange
            var service = new ValidaService();
            string mensagemErro;

            //Act
            var resultado = service.ValidarNome("Di", out mensagemErro);

            //Assert
            Assert.IsFalse(resultado);
            Assert.AreNotEqual(mensagemErro, "");
        }

        [TestMethod]

        public void ValidarNome_Quando3LetrasIguaisConsecutivas_DeveRetornarFalse()
        {
            //Arrange
            var service = new ValidaService();
            string mensagemErro;

            //Act
            var resultado = service.ValidarNome("", out mensagemErro);

            //Assert
            Assert.IsFalse(resultado);
            Assert.AreNotEqual(mensagemErro, "");
        }

        [TestMethod]

        public void ValidarNome_QuandoEspaçoDuplo_DeveRetornarFalse()
        {
            //Arrange
            var service = new ValidaService();
            string mensagemErro;

            //Act
            var resultado = service.ValidarNome("D  iego", out mensagemErro);

            //Assert
            Assert.IsFalse(resultado);
            Assert.AreNotEqual(mensagemErro, "");
        }
        [TestMethod]

        public void ValidarNome_QuandoCaractereInvalido_DeveRetornarFalse()
        {
            //Arrange
            var service = new ValidaService();
            string mensagemErro;

            //Act
            var resultado = service.ValidarNome("Di3go", out mensagemErro);

            //Assert
            Assert.IsFalse(resultado);
            Assert.AreNotEqual(mensagemErro, "");

        }
        [TestMethod]
        public void TentarConverterNota_NotaValida_DeveRetornarTrue()
        {
            var service = new ValidaService();
            double nota;

            var resultado = service.ConverterNota("7.5", out nota);

            Assert.IsTrue(resultado);
            Assert.AreEqual(7.5, nota);
        }

        [TestMethod]
        public void TentarConverterNota_NotaComVirgula_DeveRetornarTrue()
        {
            var service = new ValidaService();
            double nota;

            var resultado = service.ConverterNota("7,5", out nota);

            Assert.IsTrue(resultado);
            Assert.AreEqual(7.5, nota);
        }

        [TestMethod]
        public void TentarConverterNota_NotaComPonto_DeveRetornarTrue()
        {
            var service = new ValidaService();
            double nota;

            var resultado = service.ConverterNota("8.3", out nota);

            Assert.IsTrue(resultado);
            Assert.AreEqual(8.3, nota);
        }

        [TestMethod]
        public void TentarConverterNota_NotaForaDoIntervalo_DeveRetornarFalse()
        {
            var service = new ValidaService();
            double nota;

            var resultado = service.ConverterNota("12", out nota);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TentarConverterNota_TextoInvalido_DeveRetornarFalse()
        {
            var service = new ValidaService();
            double nota;

            var resultado = service.ConverterNota("abc", out nota);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TentarConverterNota_CampoVazio_DeveRetornarFalse()
        {
            var service = new ValidaService();
            double nota;

            var resultado = service.ConverterNota("", out nota);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TentarConverterNota_FormatoNumericoIncorreto_DeveRetornarFalse()
        {
            var service = new ValidaService();
            double nota;

            var resultado = service.ConverterNota("7,5,2", out nota);

            Assert.IsFalse(resultado);
        }
    }

}



