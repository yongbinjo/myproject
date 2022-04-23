using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using ybcDatabaseClass;
using DefineClass;

namespace PhoneResponse
{
    public partial class Login : System.Web.UI.Page
    {
        TDefineClass def;
        TableClass tbc;
        SqlDataReader sd;

        protected void Page_Load(object sender, EventArgs e)
        {
            string tinterviwerid = (Request.Params["tinterviwerid"] == null ? "" : Request.Params["tinterviwerid"].ToString());
            string tinterviwername = (Request.Params["tinterviwername"] == null ? "" : Request.Params["tinterviwername"].ToString());


            def = new TDefineClass();
            tbc = new TableClass();

            Response.Write(tbc.InterviewerTable);
            Response.End();
            sd = def.dbcls.CallSelect("select * from " + tbc.InterviewerTable + " where userid='" + tinterviwerid + "' and username='" + tinterviwername + "'");
            if (sd.HasRows)
            {
                sd.Read();
                Session["interviewid"] = tinterviwerid;
                Session["interviewname"] = tinterviwername;
                Session["used"] = sd["used"].ToString();
                Response.Redirect("MoniteringList.aspx");

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            def.dbcls.CloseDB();
            def = null;
            tbc = null;
            sd = null;
        }
    }
}