using Domain.Validacoes;
using ExceptionsDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Agenda : Base
    {

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Data { get; private set; }

        protected Agenda() { }

        public Agenda(string titulo, string descricao, DateTime data)
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Data = data;
            this._errors = new List<string>();

            Validar();
        }

        public void MudarTitulo(string titulo)
        {
            Titulo = titulo;
            Validar();

        }

        public void MudarDescricao(string descricao)
        {
            Descricao = descricao;
            Validar();

        }

        public void MudarData(DateTime data)
        {
            Data = data;
            Validar();
        }


        public override bool Validar()
        {
            var validador = new ValidacaoAgenda();
            var validacao = validador.Validate(this);

            if (!validacao.IsValid)
            {
                foreach (var error in validacao.Errors)
                {
                    _errors.Add(error.ErrorMessage);

                    throw new DomainExceptions("Alguns campos estão invalidos por favor corrija-os " , _errors);
                }
            }

           return true;
        }
    }
}
