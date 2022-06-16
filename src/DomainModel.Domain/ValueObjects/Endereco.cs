using DomainModel.DomainCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public string Rua { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public string CEP { get; private set; }

        public Endereco() { }

        public Endereco(string rua, string cidade, string estado, string pais, string cep)
        {
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            CEP = cep;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Rua;
            yield return Cidade;
            yield return Estado;
            yield return Pais;
            yield return CEP;
        }
    }
}
