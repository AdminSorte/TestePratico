using Domain.Validacoes;
using System;
using System.Collections.Generic;

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

                    throw new Exception("Alguns campos estão invalidos por favor corrija-os " + _errors[0]); //Refatorar quando  Implenmentar Exceptions Personalizadas
                }
            }

           return true;
        }
    }
}
