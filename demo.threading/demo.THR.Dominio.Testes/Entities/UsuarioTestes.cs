using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using demo.THR.Dominio.Entities;
using demo.THR.Dominio.Entities.ValueObjects;

namespace demo.THR.Dominio.Testes.Entities
{
    [TestClass]
    public class UsuarioTestes
    {
        private Cpf CPF { get; set; }
        private Email Email { get; set; }

        private string Login { get; set; }
        private string Senha { get; set; }
        private string ConfirmacaoDeSenha { get; set; }

        public UsuarioTestes()
        {
            CPF = new Cpf("09073067723");
            Email = new Email("rodrigolsr@gmail.com");
            Login = "rlessa";
            Senha = "123456";
            ConfirmacaoDeSenha = "123456";
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_Novo_CPFObrigatorio()
        {
            new Usuario(Login, Senha, ConfirmacaoDeSenha, null, Email);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_Novo_LoginObrigatorio()
        {
            new Usuario("", Senha, ConfirmacaoDeSenha, CPF, Email);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_Novo_EmailObrigatorio()
        {
            new Usuario(Login, Senha, ConfirmacaoDeSenha, CPF, null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_Novo_SenhaObrigatoria()
        {
            new Usuario(Login, "", ConfirmacaoDeSenha, CPF, Email);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_Novo_ConfirmacaoDeSenhaObrigatoria()
        {
            new Usuario(Login, Senha, "", CPF, Email);
        }

        [TestMethod]
        public void Usuario_Novo_CPF()
        {
            var usuario = new Usuario(Login, Senha, ConfirmacaoDeSenha, CPF, Email);
            Assert.AreEqual(CPF, usuario.CPF, "CPF digitado é válido");
        }

        [TestMethod]
        public void Usuario_Novo_Email()
        {
            var usuario = new Usuario(Login, Senha, ConfirmacaoDeSenha, CPF, Email);
            Assert.AreEqual(Email, usuario.Email, "CPF digitado é válido");
        }

        [TestMethod]
        public void Usuario_Novo_Login()
        {
            var usuario = new Usuario(Login, Senha, ConfirmacaoDeSenha, CPF, Email);
            Assert.AreEqual(Login, usuario.Login, "CPF digitado é válido");
        }

        [TestMethod]
        public void Usuario_Novo_Senha()
        {
            var usuario = new Usuario(Login, Senha, ConfirmacaoDeSenha, CPF, Email);
            Assert.AreEqual(Senha, usuario.Senha, "CPF digitado é válido");
        }
    }
}
