using System;
using System.Collections.Generic;
using System.Text;
using SportsX.Domain.Enums;

namespace SportsX.Domain.Entities
{
    public abstract class Pessoa : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public ClassificacaoEnum Classificacao { get; set; }
        public IList<Telefone> Telefones { get; set; }
    }
}
