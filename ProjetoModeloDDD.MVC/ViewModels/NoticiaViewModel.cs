using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class NoticiaViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Chamada { get; set; }
        [Required]
        public DateTime DataPublicacao { get; set; }
        [Required]
        public string Capa { get; set; }
        [Required]
        public string Texto { get; set; }
    }
}