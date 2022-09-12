using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task.Models
{
    public class LoginModel
    {
        [Required]
        public string Name { set; get; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        public bool isSelected { set; get; }
    }
}
