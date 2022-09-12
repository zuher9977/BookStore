using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task.Models
{
    public class CreateAccountModel
    {
        [Required]
        public string Id { set; get; }
        public string Name { set; get; }
        [Required]
        [EmailAddress]
        public string Email { set; get; }
        [Required]
        [Compare("ConfirmPassword")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
