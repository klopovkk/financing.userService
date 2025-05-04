using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TokenInfoDTO
    {
        public TokenInfoDTO(Guid Id, string Token)
        {
            id = Id;
            token = Token;
        }

        public Guid id { get; set; }
        public string token { get; set; }
    }
}
