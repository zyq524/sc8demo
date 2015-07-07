using System;

namespace SC8Demo.Web
{
    using SC8Demo.EXM;

    public partial class ClearSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }
    }
}