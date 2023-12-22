using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NguoiDung
    {
        public string UserID { get; set; }
        public string Pass { get; set; }
        public string Per { get; set; }
        public DTO_NguoiDung()
        {

        }

        public DTO_NguoiDung(string UserID, string Pass, string Per)
        {
            this.UserID = UserID;
            this.Pass = Pass;
            this.Per = Per;
        }
    }
}
