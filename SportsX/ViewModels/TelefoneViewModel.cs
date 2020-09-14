using System;
using System.ComponentModel.DataAnnotations;

namespace SportsX.ViewModels
{
    public class TelefoneViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Numero { get; set; }
    }
}