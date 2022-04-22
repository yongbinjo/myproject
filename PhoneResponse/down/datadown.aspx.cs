using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using ybcDatabaseClass;
using DefineClass;
using System.Text;

namespace PhoneResponse.down
{
    public partial class datadown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TDefineClass def = new TDefineClass();
            TableClass tbc = new TableClass();
            StringBuilder strb = new StringBuilder();

            strb.Append("<table style=\"border:1px solid black;\">");
            strb.Append("<tr>");
            strb.Append("<td>usercode</td>");
            strb.Append("<td>username</td>");
            strb.Append("<td>musername</td>");
            strb.Append("<td>tellnum</td>");
            strb.Append("<td>mtellnum</td>");
            strb.Append("<td>code1</td>");
            strb.Append("<td>code2</td>");
            strb.Append("<td>content</td>");
            strb.Append("<td>startdate</td>");
            strb.Append("<td>enddate</td>");
            strb.Append("<td>Q1</td>");
            strb.Append("<td>Q2</td>");
            strb.Append("<td>Q3</td>");
            strb.Append("<td>Q4</td>");
            strb.Append("<td>total</td>");
            strb.Append("<td>interviewid</td>");
            strb.Append("<td>interviewname</td>");
            strb.Append("</tr>");

            string sqltext = "select a.usercode, a.username, a.musername, a.tellnum,a.mtellnum, a.code1,  a.code2, a.content, b.startdate, b.enddate, b.Q1, b.Q2, b.Q3, b.Q4, b.total, b.interviewid, b.interviewname from " + tbc.MoniteringTable + " a left join " + tbc.dataTable + " b on a.usercode = b.code";
            SqlDataReader sd = def.dbcls.CallSelect(sqltext);
            while (sd.Read())
            {
                strb.Append("<tr>");
                strb.Append("<td>" + sd["usercode"] + "</td><td>" + sd["username"] + "</td><td>" + sd["musername"] + "</td><td>" + sd["tellnum"] + "</td><td>" + sd["mtellnum"] + "</td><td>" + sd["code1"] + "</td><td>" + sd["code2"] + "</td><td>" + sd["content"] + "</td><td>" + sd["startdate"] + "</td><td>" + sd["enddate"] + "</td><td>" + sd["Q1"] + "</td><td>" + sd["Q2"] + "</td><td>" + sd["Q3"] + "</td><td>" + sd["Q4"] + "</td><td>" + sd["total"] + "</td><td>" + sd["interviewid"] + "</td><td>" + sd["interviewname"] + "</td>");
                strb.Append("</tr>");
            }

            strb.Append("</table>");
            ltlexcel.Text = strb.ToString();

            Response.AddHeader("content-disposition", "attachment;filename=down.xls");
            Response.ContentType = "application/vnd.ms-excel";

            System.IO.StringWriter stringwriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new HtmlTextWriter(stringwriter);
            exceldata.RenderControl(htmlwriter);
            Response.Write(stringwriter.ToString());
            Response.End();
        }
    }
}