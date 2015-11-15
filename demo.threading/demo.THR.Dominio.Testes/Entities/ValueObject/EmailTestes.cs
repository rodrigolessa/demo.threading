using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using demo.THR.Dominio.Entities.ValueObjects;

namespace demo.THR.Dominio.Testes.Entities.ValueObject
{
    [TestClass]
    public class EmailTestes
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_NovoEmail_ErroQuandoVazio() {
            var email = new Email("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_NovoEmail_ErroQuandoNulo()
        {
            var email = new Email(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_NovoEmail_Invalido()
        {
            var email = new Email("qwertyuiop");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_NovoEmail_ErroTamanhoMaximo()
        {
            var endereco = "rodrigolsr@gmail.com";
            while (endereco.Length < Email.EnderecoMaxLength + 1)
            {
                endereco += "rodrigolsr@gmail.com";
            }
            var email = new Email(endereco);
        }

        [TestMethod]
        public void Email_NovoEmail_Valido()
        {
            var endereco = "rodrigolsr@gmail.com";
            var email = new Email(endereco);
            Assert.AreEqual(endereco, email.Endereco);
        }
    }
}
