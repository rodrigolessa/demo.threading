﻿using System;
using demo.THR.Infraestrutura.Comuns;
using demo.THR.Infraestrutura.Comuns.Helpers;
using demo.THR.Dominio.Entities.Enuns;

namespace demo.THR.Dominio.Entities.ValueObjects
{
    public class Endereco
    {
        public const int LogradouroMaxLength = 150;
        public virtual string Logradouro { get; private set; }

        public const int ComplementoMaxLength = 150;
        public virtual string Complemento { get; private set; }

        public const int NumeroMaxLength = 50;
        public virtual string Numero { get; private set; }

        public const int BairroMaxLength = 150;
        public virtual string Bairro { get; private set; }

        public const int CidadeMaxLength = 150;
        public virtual string Cidade { get; private set; }

        public virtual Uf? Uf { get; private set; }

        public virtual Cep Cep { get; private set; }

        protected Endereco() { }

        public Endereco(string logradouro, string complemento, string numero, string bairro, string cidade, Uf? uf, Cep cep)
        {
            SetCep(cep);
            SetBairro(bairro);
            SetCidade(cidade);
            SetComplemento(complemento);
            SetLogradouro(logradouro);
            SetNumero(numero);
            SetUf(uf);
        }

        public void SetCep(Cep cep)
        {
            if (cep.Vazio())
                throw new Exception("CEP é obrigatório!");
            Cep = cep;
        }

        public void SetComplemento(string complemento)
        {
            if (string.IsNullOrEmpty(complemento))
                complemento = "";
            Complemento = TextHelper.ToTitleCase(complemento);
        }

        public void SetLogradouro(string logradouro)
        {
            ValidationHelper.ForNullOrEmptyDefaultMessage(logradouro, "Endereço");
            Logradouro = TextHelper.ToTitleCase(logradouro);
        }

        public void SetNumero(string numero)
        {
            ValidationHelper.ForNullOrEmptyDefaultMessage(numero, "Número");
            Numero = numero;
        }

        public void SetBairro(string bairro)
        {
            ValidationHelper.ForNullOrEmptyDefaultMessage(bairro, "Bairro");
            Bairro = TextHelper.ToTitleCase(bairro);
        }

        public void SetCidade(string cidade)
        {
            ValidationHelper.ForNullOrEmptyDefaultMessage(cidade, "Cidade");
            Cidade = TextHelper.ToTitleCase(cidade);
        }

        public void SetUf(Uf? uf)
        {
            if (!uf.HasValue)
                throw new Exception("Estado é obrigatório");
            Uf = uf;
        }

        public override string ToString()
        {
            return Logradouro + ", " + Numero + " - " + Complemento + " <br /> " + Bairro + " - " + Cidade + "/" + Uf;
        }
    }
}
