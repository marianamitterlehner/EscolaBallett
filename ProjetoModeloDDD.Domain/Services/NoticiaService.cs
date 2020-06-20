using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class NoticiaService : ServiceBase<Noticia>, INoticiaService
    {
        private readonly INoticiaRepository _noticiaRepository;
        public NoticiaService(INoticiaRepository noticiaRepository)
            : base(noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }

        public IQueryable<Noticia> BuscarPorTitulo(string titulo)
        {
            return _noticiaRepository.BuscarPorTitulo(titulo);
        }
    }
}
