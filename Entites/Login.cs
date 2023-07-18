using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Login
    {
        
        public int Id { get; set; }

       
        public string LoginName { get; set; }

       
        public string LoginPassworld { get; set; }

        public string Email { get; set; }
    }
}
