using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string NomeJogo { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatório!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "A Data de lançamento é obrigatório!")]
        public string DataLancamento { get; set; }
        [Required(ErrorMessage = "O Valor é obrigatório!")]
        public int Valor { get; set; }
    }
}
