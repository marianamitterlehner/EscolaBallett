using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Noticia : EntityBase
    {
        public string Titulo { get; set; }
        public string Chamada { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Capa { get; set; }

        public string Texto { get; set; }
    }
}
