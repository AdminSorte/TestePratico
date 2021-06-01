using API.ViewModels;
using System.Collections.Generic;

namespace API.Utilities
{
    public class Respostas
    {

        public static ResultadoViewModel ErroAplicacao()
        {
            return new ResultadoViewModel
            {
                Mensagem = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
                Sucesso = false,
                Data = null
            };
        }

        public static ResultadoViewModel ErroDominio(string mensagem)
        {
            return new ResultadoViewModel
            {
                Mensagem = mensagem,
                Sucesso = false,
                Data = null
            };

        }

        public static ResultadoViewModel ErroDominio(string mensagem, IReadOnlyCollection<string> erros)
        {
            return new ResultadoViewModel
            {
                Mensagem = mensagem,
                Sucesso = false,
                Data = erros
            };

        }
        public static ResultadoViewModel ErroLogin()
        {
            return new ResultadoViewModel
            {
                Mensagem = "Login e Senha não Conferem!",
                Sucesso = false,
                Data = null
            };
        }


    }
}
