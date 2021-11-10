using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ITEC_116

{

    class DBConnect
    {
        private string con;


        public string MyConnection()
        {
            con = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AF_Database;Integrated Security=True";
            return con;
        }
    }
}
