using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAtlantico.ViewModels
{
    public class UsuarioCreateViewModel
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Senha é um campo obrigatório!")]
        [Display(Name = "Nome")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Idade é um campo obrigatório!")]
        [Display(Name = "Idade")]
        public string Idade { get; set; }


    }
}
