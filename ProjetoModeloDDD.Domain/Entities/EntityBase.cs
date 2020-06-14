using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Liberado { get; set; }
        public bool Excluido { get; private set; }

        public void Excluir()
        {
            Excluido = true;
            Liberado = false;
        }

        public void Liberar()
        {
            Excluido = false;
            Liberado = true;
        }

        public void Bloquear()
        {
            Excluido = false;
            Liberado = false;
        }
    }
}
