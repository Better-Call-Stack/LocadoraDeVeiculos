using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    [Serializable]
    public class GrupoDeVeiculos : EntidadeBase<GrupoDeVeiculos>
    {
        public GrupoDeVeiculos()
        {

        }

        public GrupoDeVeiculos(string nome)
        {
            Nome = nome;

        }
        public string Nome { get; set; }

        public List<PlanoDeCobranca> planos = new List<PlanoDeCobranca>();

        public List<PlanoDeCobranca> Planos { get { return planos; }  }

        public override string ToString()
        {
            return $"Nome: {Nome}";
        }

        public GrupoDeVeiculos Clonar()
        {
            return MemberwiseClone() as GrupoDeVeiculos;
        }

        public override void Atualizar(GrupoDeVeiculos registro)
        {
            Nome = registro.Nome;

        }

        public override bool Equals(object obj)
        {
            return obj is GrupoDeVeiculos controladorGrupoVeiculos &&
                   Nome == controladorGrupoVeiculos.Nome;

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Nome);
        }
    }
}
