using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Proyect.NetMVC.Models
{


    [Table("Usuario")]
    public  partial class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Escriba el nombre  del usuario")]
        [MinLength(5,ErrorMessage ="El valor del nombre debe ser mayor a 50 caracteres")]
        [MaxLength(50, ErrorMessage = "El valor del nombre debe ser maximo a 50 caracteres")]
        public string Nombre { get; set; }
        public string Sal { get; set; }
        [Required(ErrorMessage = "Escriba el nombre  del usuario")]
        [MinLength(5, ErrorMessage = "El valor del nombre debe ser mayor a 50 caracteres")]
        [MaxLength(50, ErrorMessage = "El valor del nombre debe ser maximo a 50 caracteres")]
        public string Clave { get; set; }







    }
}
