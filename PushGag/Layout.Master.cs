﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace PushGag
{
    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString;
    public partial class Layout : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
    }
}