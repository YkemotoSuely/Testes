using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _02_CacaAoBugMVC.Model;

namespace _02_CacaAoBugMVC.Test
{
   [TestClass]
   public class AlunoServiceTests
   {
        private object service;

        [TestMethod]
        public void CalcularMedia_DeveRetornarCorreto() 
        {
            //Arrange (preparar) - 
            var service = new AlunoService();

            // Act (Agir) - instruções para executar o teste
            var resultado = service.CalcularMedia(8.0, 7.5, 6.5);

            // Assert (Afirmar) - realiza o teste e compara com o valor determinado por mim 
            Assert.AreEqual(7.33, resultado);

        }[TestMethod]
        public void CalcularMedia_DeveRetornarErro() 
        {
            //Arrange (preparar) - 
            var service = new AlunoService();

            // Act (Agir) - instruções para executar o teste
            var resultado = service.CalcularMedia(6.0, 5.5, 3.5);

            // Assert (Afirmar) - realiza o teste e compara com o valor determinado por mim 
            Assert.AreEqual(7.33, resultado);

        }
        [TestMethod]
        public void ObterSituacao_DeveRetornarCorreto() 
        {
            //Arrange(preparar)
            var service = new AlunoService();

            //Act (Agir)
            var resultadoAprovado = service.ObterSituacao(8.0);
            var resultadoEmExame = service.ObterSituacao(6.5);
            var resultadoReprovado = service.ObterSituacao(4.9);

            Assert.AreEqual("Aprovado", resultadoAprovado);
            Assert.AreEqual("Em exame final", resultadoEmExame);
            Assert.AreEqual("Reprovado", resultadoReprovado);

        }


   }
   
}
