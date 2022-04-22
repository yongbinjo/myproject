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
    public partial class DataRegist : System.Web.UI.Page
    {
        TDefineClass def;
        TableClass tbc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["interviewid"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            def = new TDefineClass();
            tbc = new TableClass();
            string sqltext;

            string code = Request.Params["code"].ToString();
            string q1 = Request.Params["Q1"].ToString();
            string q2 = Request.Params["Q2"].ToString();
            string q3 = Request.Params["Q3"].ToString();
            string q4 = Request.Params["Q4"].ToString();

            string mtellnum = Request.Params["mtellnum"].ToString();
            string musername = Request.Params["musername"].ToString();
            string content = Request.Params["content"].ToString();
            string state = Request.Params["state"].ToString();
            string total = Request.Params["htotal"].ToString();
            string usercode = Session["interviewid"].ToString();
            string username = Session["interviewname"].ToString();
            string startdate = Session["startdate"].ToString();

            if (state == "0")
            {

                sqltext = "insert into " + tbc.dataTable + "(code,startdate,enddate,Q1,Q2,Q3,Q4,total,interviewid,interviewname) values('" + code + "','" + startdate + "','" + DateTime.Now.ToString() + "','" + q1 + "','" + q2 + "','" + q3 + "','" + q4 + "','" + total + "','" + usercode + "','" + username + "')";

                sqltext = sqltext + " update " + tbc.MoniteringTable + " set  mtellnum='" + mtellnum + "', musername='" + musername + "', content='" + content + "' where usercode='" + code + "'";
                def.dbcls.CallInsert(sqltext);
            }
            else
            {
                sqltext = " update " + tbc.dataTable + " set enddate='" + DateTime.Now.ToString() + "', Q1='" + q1 + "',Q2=" + q2 + ",Q3=" + q3 + ",Q4=" + q4 + ", total='" + total + "', interviewid='" + usercode + "', interviewname='" + username + "' where code='" + code + "'";
                sqltext = sqltext + " update " + tbc.MoniteringTable + " set mtellnum='" + mtellnum + "', musername='" + musername + "', content='" + content + "' where usercode='" + code + "'";

                def.dbcls.CallInsert(sqltext);
            }

            def.dbcls.CloseDB();
            def = null;
            tbc = null;

            Response.Redirect("MoniteringList.aspx");
        }
    }
}