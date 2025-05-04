using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public record LoginInfoDTO
    {
        public LoginInfoDTO(string email, string password)
        {
            this.email= email;
            this.password = password;
        }
        public string email { get; set; }
        public string password { get; set; }
    }
}
