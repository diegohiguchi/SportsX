using System.Collections.Generic;
using SportsX.Domain.Enums;

namespace SportsX.Domain.Entities
{
    public class PessoaFisica : Pessoa
    {
        public string Cpf { get; private set; }
        public PessoaFisica()
        { }

        public PessoaFisica(
            string cpf,
            string nome,
            string email,
            string cep,
            ClassificacaoEnum classificacao)
        {
            Cpf = cpf;
            Nome = nome;
            Email = email;
            Cep = cep;
            Classificacao = classificacao;
            Telefones = new List<Telefone>();
        }

        public void AdicionarTelefone(Telefone telefone)
        {
            Telefones.Add(telefone);
        }

        public void AlterarCpf(string cpf)
        {
            Cpf = cpf;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarEmail(string email)
        {
            Email = email;
        }

        public void AlterarCep(string cep)
        {
            Cep = cep;
        }

        public void AlterarClassificacao(ClassificacaoEnum classificacao)
        {
            Classificacao = classificacao;
        }

        public void AtualizarTelefone(IList<Telefone> telefones)
        {
            Telefones = telefones;
        }
    }
}