using SportsX.Domain.Enums;
using System.Collections.Generic;

namespace SportsX.Domain.Entities
{
    public class PessoaJuridica : Pessoa
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        
        public PessoaJuridica()
        { }

        public PessoaJuridica(
            string razaoSocial, 
            string cnpj, 
            string nome, 
            string email,
            string cep,
            ClassificacaoEnum classificacao)
        {
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
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

        public void AlterarRazaoSocial(string razaoSocial)
        {
            RazaoSocial = razaoSocial;
        }

        public void AlterarCnpj(string cnpj)
        {
            Cnpj = cnpj;
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