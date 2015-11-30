using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using demo.THR.Dominio.Entities;
using demo.THR.Dominio.Entities.ValueObjects;
using demo.THR.Dominio.Entities.Enuns;

namespace demo.THR.Dominio.Testes.Entities
{
    [TestClass]
    public class UsuarioTestes
    {
        private Cpf CPF { get; set; }
        private Email Email { get; set; }
        private Endereco Endereco { get; set; }

        private string Login { get; set; }
        private string Senha { get; set; }
        private string ConfirmacaoDeSenha { get; set; }

        public UsuarioTestes()
        {
            CPF = new Cpf("77723074620");
            Email = new Email("rodrigolsr@gmail.com");
            Endereco = new Endereco("Rua De Teste", "Casa 2", "160", "Centro", "Niterói", Uf.RJ, new Cep("24685020"));
            Login = "rlessa";
            Senha = "123456";
            ConfirmacaoDeSenha = "123456";
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_Novo_CPFObrigatorio()
        {
            new Usuario(Login, Senha, ConfirmacaoDeSenha, null, Email, Endereco);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_Novo_LoginObrigatorio()
        {
            new Usuario("", Senha, ConfirmacaoDeSenha, CPF, Email, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_Novo_EmailObrigatorio()
        {
            new Usuario(Login, Senha, ConfirmacaoDeSenha, CPF, null, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_Novo_SenhaObrigatoria()
        {
            new Usuario(Login, "", ConfirmacaoDeSenha, CPF, Email, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_Novo_ConfirmacaoDeSenhaObrigatoria()
        {
            new Usuario(Login, Senha, "", CPF, Email, Endereco);
        }

        [TestMethod]
        public void Usuario_Novo_CPF()
        {
            var usuario = new Usuario(Login, Senha, ConfirmacaoDeSenha, CPF, Email, Endereco);
            Assert.AreEqual(CPF, usuario.CPF, "CPF digitado é válido");
        }

        [TestMethod]
        public void Usuario_Novo_Email()
        {
            var usuario = new Usuario(Login, Senha, ConfirmacaoDeSenha, CPF, Email, Endereco);
            Assert.AreEqual(Email, usuario.Email, "CPF digitado é válido");
        }

        [TestMethod]
        public void Usuario_Novo_Login()
        {
            var usuario = new Usuario(Login, Senha, ConfirmacaoDeSenha, CPF, Email, Endereco);
            Assert.AreEqual(Login, usuario.Login, "CPF digitado é válido");
        }

        [TestMethod]
        public void Usuario_Novo_Senha()
        {
            var usuario = new Usuario(Login, Senha, ConfirmacaoDeSenha, CPF, Email, Endereco);
            Assert.AreEqual(Senha, usuario.Senha, "CPF digitado é válido");
        }
    }
}
