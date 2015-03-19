using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simhopp_WebApplication
{
    public partial class FormResults : System.Web.UI.Page
    {
        protected void Timer1_Tick(object sender, EventArgs e)
        {


            GridView2.DataBind();
            GridView1.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView2.DataBind();
            GridView1.DataBind();
        }
        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }
    }
}