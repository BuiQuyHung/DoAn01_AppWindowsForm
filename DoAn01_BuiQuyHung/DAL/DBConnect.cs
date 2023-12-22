using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DBConnect
    {
        protected SqlConnection _con = new SqlConnection(@"Data Source=LAPTOP-H7D5M1J0\SQLEXPRESS;Initial Catalog=DoAn01_BuiQuyHung;Integrated Security=True");

    }
}
