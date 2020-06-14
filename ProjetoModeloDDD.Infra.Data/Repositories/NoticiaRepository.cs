using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class NoticiaRepository: RepositoryBase<Noticia>, INoticiaRepository
    {
        public IQueryable<Noticia> BuscarPorTitulo(string titulo)
        {
            return db.Noticias.Where(n => n.Titulo == titulo);
        }
    }
}
