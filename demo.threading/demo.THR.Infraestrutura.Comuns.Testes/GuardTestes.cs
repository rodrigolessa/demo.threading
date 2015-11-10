using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace demo.THR.Infraestrutura.Comuns.Testes
{
    [TestClass]
    public class GuardTestes
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ParaNuloOuVazio_ErroQuandoEmBranco() {
            Guard.ParaNuloOuVazio("", "O campo valor é obrigatório.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ParaNuloOuVazio_ErroQuandoNulo()
        {
            Guard.ParaNuloOuVazio(null, "O campo valor é obrigatório.");
        }
    }
}
