using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using demo.THR.Infraestrutura.Comuns.Helpers;

namespace demo.THR.Infraestrutura.Comuns.Testes
{
    [TestClass]
    public class ValidationHelperTestes
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ParaNuloOuVazio_ErroQuandoEmBranco() {
            ValidationHelper.ForNullOrEmpty("", "O campo valor é obrigatório.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ParaNuloOuVazio_ErroQuandoNulo()
        {
            ValidationHelper.ForNullOrEmpty(null, "O campo valor é obrigatório.");
        }
    }
}
