using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using MakeTableClass;
using DefineClass;

namespace PhoneResponse
{
    public partial class MoniteringList : System.Web.UI.Page
    {
        TDefineClass def;
        MakeTable make;
        SqlDataReader sd;
        TableClass tbc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["interviewid"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (state.Value.ToString() == "1")
            {
                Session["interviewid"] = null;
                Session["interviewname"] = null;
                Session["used"] = null;
                Response.Redirect("Default.aspx");
            }
            string searchcode = Request.Params["search"] == null ? "" : Request.Params["search"].ToString();

            def = new TDefineClass();
            tbc = new TableClass();

            ltllog.Text = "접속자 : " + Session["interviewname"].ToString() + "님";

            if (Session["used"].ToString() == "2")
            {
                sd = def.dbcls.CallSelect("select count(*) as cnt from dbo.tb_responsedata");
                sd.Read();
                ltladmin.Text = "<td style=\"font-size:13px; font-family:맑은 고딕;\">완료 : " + sd["cnt"].ToString() + " &nbsp;&nbsp; <input type=\"button\" style=\"background-color:Black; color:White;\" value=\"excel down\" onclick=\"f_excel();\"></td>";
                sd.Close();
            }

            if (searchcode == "")
            {
                //sd = def.dbcls.CallSelect("select * from " + tbc.MoniteringTable);
                //sd = def.dbcls.CallSelect("select a.usercode,a.username, a.code1, a.code2, a.tellnum, b.startdate from "+tbc.MoniteringTable+" a left join "+tbc.dataTable+" b on a.usercode = b.code");
                sd = def.dbcls.CallSelect("select a.usercode,a.username, a.code1, a.code2, a.tellnum, case when b.enddate is null then '미완료' else '완료' end as datastate, b.interviewname  from " + tbc.MoniteringTable + " a left join " + tbc.dataTable + " b on a.usercode = b.code");
            }
            else
            {
                sd = def.dbcls.CallSelect("select a.usercode,a.username, a.code1, a.code2, a.tellnum, case when b.enddate is null then '미완료' else '완료' end as datastate, b.interviewname from " + tbc.MoniteringTable + " a left join " + tbc.dataTable + " b on a.usercode = b.code where a.usercode like '%" + searchcode + "%' or a.username like '%" + searchcode + "%' or a.tellnum like '%" + searchcode + "%' or a.code1 like '%" + searchcode + "%' or a.code2 like '%" + searchcode + "%' or interviewname like '%" + searchcode + "%'");
            }
            make = new MakeTable();
            make.TableWidth = "900px";

            make.TableOutLineHeight = "1000px";
            make.TableOutLineWidth = "1200px";
            make.TableScroll = true;
            make.MouseOverState = true;
            make.TdOnclick = "f_codeclick,usercode";
            make.ContentOnClickFunction = "f_codeclick";
            make.SetTableHead = "코드,이름,필드1,필드2,전화번호,상태, 등록자";
            make.headFieldAlign = "center,center,center,center,center,center,center";
            make.HeadFieldWidth = "15%,15%,15%,15%,20%,10%,10%";
            make.HeadBackColor = "#2E75B6";
            make.HeadHeight = "30px";
            make.HeadFontColor = "white";
            make.HeadFontSize = "13px";
            make.BodyFontSize = "12px";
            make.BodyHeight = "25px";
            make.BodyFieldAlign = "center,center,center,center,center,center,center";
            make.DBField = "usercode,username,code1,code2,tellnum,datastate,interviewname";
            ltllist.Text = make.CreateTable(sd);

            sd.Close();
            sd = null;
            make = null;
            def.dbcls.CloseDB();
            def = null;
            tbc = null;

        }
    }
}