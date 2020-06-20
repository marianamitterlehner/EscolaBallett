using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class NoticiaAppService : AppServiceBase<Noticia>, INoticiaAppService
    {
        private readonly INoticiaService _noticiaService;

        public NoticiaAppService(INoticiaService noticiaService)
            : base(noticiaService)
        {
            _noticiaService = noticiaService;
        }

    }
}
