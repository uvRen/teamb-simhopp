using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Simhopp;
using 

namespace Simhopp_WebApplication
{
    public partial class FormContests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Simhopp.FormMainFunctions.FillListViewWithEvent();
            MySqlConnection _connection = Database.ConnectToDatabase();
         
            

        }
    }
}