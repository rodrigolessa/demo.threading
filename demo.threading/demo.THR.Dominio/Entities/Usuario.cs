using System;
using System.Linq;
using demo.THR.Dominio.Entities.ValueObjects;
using demo.THR.Infraestrutura.Comuns;
using demo.THR.Infraestrutura.Comuns.Helpers;

namespace demo.THR.Dominio.Entities
{
    public class Usuario : EntityBase
    {
        public Cpf CPF { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }

        public const int LoginMinLength = 6;
        public const int LoginMaxLength = 30;
        public string Login { get; private set; }

        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;
        public byte[] Senha { get; private set; }

        public Guid TokenAlteracaoDeSenha { get; private set; }

        // Para o EntityFramework
        protected Usuario() { }

        public Usuario(string login, string senha, string confirmacaoDeSenha, Cpf cpf, Email email, Endereco endereco)
        {
            SetLogin(login);
            SetCpf(cpf);
            SetEmail(email);
            SetSenha(senha, confirmacaoDeSenha);
            Endereco = endereco;
            DataDeInclusao = DateTime.Now;
        }

        public void SetLogin(string login)
        {
            ValidationHelper.ForNullOrEmptyDefaultMessage(login, "Login");
            ValidationHelper.StringLength("Login", login, LoginMinLength, LoginMaxLength);
            Login = login;
        }

        public void SetCpf(Cpf cpf)
        {
            if (cpf == null)
                throw new Exception("CPF é obrigatório.");
            CPF = cpf;
        }

        public void SetEmail(Email email)
        {
            if (email == null)
                throw new Exception("E-mail é obrigatório.");
            Email = email;
        }

        private void SetSenha(string senha, string senhaConfirmacao)
        {
            ValidationHelper.ForNullOrEmptyDefaultMessage(senha, "Senha");
            ValidationHelper.ForNullOrEmptyDefaultMessage(senhaConfirmacao, "Confirmação de Senha");
            ValidationHelper.StringLength("Senha", senha, SenhaMinLength, SenhaMaxLength);
            ValidationHelper.AreEqual(senha, senhaConfirmacao, "As senhas não conferem!");

            Senha = CryptoHelper.CriptografarSenha(senha);
        }

        public void AlterarSenha(string senhaAtual, string novaSenha, string confirmacaoDeSenha)
        {
            ValidarSenha(senhaAtual);
            SetSenha(novaSenha, confirmacaoDeSenha);
        }

        public void ValidarSenha(string senha)
        {
            ValidationHelper.ForNullOrEmptyDefaultMessage(senha, "Senha");
            var senhaCriptografada = CryptoHelper.CriptografarSenha(senha);
            if (!Senha.SequenceEqual(senhaCriptografada))
                throw new Exception("Senha inválida!");
        }

        public Guid GerarNovoTokenAlterarSenha()
        {
            TokenAlteracaoDeSenha = Guid.NewGuid();
            return TokenAlteracaoDeSenha;
        }

        public void AlterarSenha(Guid token, string novaSenha, string confirmacaoDeSenha)
        {
            if (!TokenAlteracaoDeSenha.Equals(token))
                throw new Exception("token para alteração de senha inválido!");
            SetSenha(novaSenha, confirmacaoDeSenha);
            GerarNovoTokenAlterarSenha();
        }
    }
}