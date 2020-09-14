using System;
using System.Collections.Generic;
using System.Text;

namespace SportsX.Domain.Entities
{
    public class Telefone : Entity
    {
        public string Numero { get; set; }
        public Guid? PessoaFisicaId { get; set; }
        public Guid? PessoaJuridicaId { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }
    }
}
