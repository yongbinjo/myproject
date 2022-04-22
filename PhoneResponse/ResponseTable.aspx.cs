using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data.SqlClient;
using ybcDatabaseClass;
using DefineClass;

namespace PhoneResponse
{
    public partial class ResponseTable : System.Web.UI.Page
    {
        TDefineClass def;
        TableClass tbc;
        StringBuilder strb;
        SqlDataReader sd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["interviewid"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            def = new TDefineClass();
            tbc = new TableClass();
            strb = new StringBuilder();

            string code = Request.Params["tcode"].ToString();
            string usercode = Session["interviewid"].ToString();
            string username = Session["interviewname"].ToString();

            string sqltext = "select * from " + tbc.MoniteringTable + " a left join " + tbc.dataTable + " b on b.code= a.usercode where a.usercode='" + Request.Params["tcode"].ToString() + "'";
            Session["startdate"] = DateTime.Now.ToString();
            
            
            sd = def.dbcls.CallSelect(sqltext);
            sd.Read();
            
            strb.Append("<table style=\"width:100%; border:1px solid black; line-height:20%;\" class=\"DefaultTable\">");
            strb.Append("<tr>");
            strb.Append("<td style=\"background-color:#2E75B6; color:White; width:900px; font-size:20px;\"><strong>전화민원 응대실태 점검 평가표</strong></td>");
            strb.Append("</tr>");
            strb.Append("</table>");
            strb.Append("<br />");
            strb.Append("<br />");
            strb.Append("<table style=\"width:100%; border:1px solid black;\" class=\"DefaultTable\">");
            strb.Append("<tr>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:7%; color:White;\"><b>모니터링 분야</b></td>");
            strb.Append("<td style=\"width:23%\" colspan=\"2\">" + sd["code1"].ToString() + "/" + sd["code2"].ToString() + "</td>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:7%; color:White;\"><b>모니터링 연락처</b></td>");
            strb.Append("<td style=\"width:11%\">" + sd["tellnum"].ToString() + "</td>");
            strb.Append("<td style=\"width:12%\"><input type=\"text\" id=\"mtellnum\" name=\"mtellnum\" style=\"width:150px;\" value=\"" + sd["mtellnum"].ToString() + "\">");
            strb.Append("</tr>");
            strb.Append("<tr>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:7%; color:White;\"><b>평가 대상자</b></td>");
            strb.Append("<td style=\"width:11%\">" + sd["username"].ToString() + "</td>");
            strb.Append("<td><input type=\"text\" id=\"musername\" name=\"musername\" style=\"width:100px;\" value=\"" + sd["musername"].ToString() + "\"></td>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:7%; color:White;\"><b>면접원</b></td>");
            strb.Append("<td colspan=\"2\">" + sd["interviewname"].ToString() + "</td>");
            strb.Append("</tr>");
            strb.Append("<tr>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:7%; color:White;\" ><b>모니터리 내용</b></td>");
            strb.Append("<td colspan=\"2\"><input type=\"text\" id=\"content\" name=\"content\" style=\"width:150px;\" value=\"" + sd["content"].ToString() + "\"></td>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:7%; color:White;\"><b>모니터링 총점</b></td>");
            strb.Append("<td colspan=\"2\"><b><span id=\"spantotal\" runat=\"server\"></span></b></td>");
            strb.Append("</tr>");
            strb.Append("<tr>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:7%; color:White;\"><b>모니터링 일시</b></td>");
            strb.Append("<td colspan=\"5\"><span id=\"spandate\"></span></td>");
            strb.Append("</tr>");
            strb.Append("</table>");
            strb.Append("<div style=\"text-align:left;\"><font color=\"red\"><b>※ 평가 대상자와 연락처가 리스트랑 다를 경우, 직접 입력해주세요.</b></font></div>");

            sd.Close();

            //def.dbcls.CloseDB();
            
            ltlinfo.Text = strb.ToString();
            strb.Clear();

            //정보 그리기
            //sd.Close();

            //table그리기
            
            //sd=def.dbcls.CallSelect(sqltext);

            //string test = "select quesnum,content,value,score from " + tbc.scoreinfoTable;

    
            
            string test = "select quesnum, content, value, score from db_phoneresponse.dbo.tb_scoreinfo";
            sd = def.dbcls.CallSelect(test);
            List<List<string>> list1 = new List<List<string>>();
            List<List<string>> list2 = new List<List<string>>();
            List<List<string>> list3 = new List<List<string>>();
            List<List<string>> list4 = new List<List<string>>();
            int Q1 = 0;
            int Q2 = 0;
            int Q3 = 0;
            int Q4 = 0;
            while (sd.Read())
            {
                if (sd["quesnum"].ToString() == "Q1")
                {
                    list1.Add(new List<string>());
                    list1[Q1].Add(sd["quesnum"].ToString());
                    list1[Q1].Add(sd["content"].ToString());
                    list1[Q1].Add(sd["value"].ToString());
                    list1[Q1].Add(sd["score"].ToString());
                    Q1++;
                }
                else if (sd["quesnum"].ToString() == "Q2")
                {
                    list2.Add(new List<string>());
                    list2[Q2].Add(sd["quesnum"].ToString());
                    list2[Q2].Add(sd["content"].ToString());
                    list2[Q2].Add(sd["value"].ToString());
                    list2[Q2].Add(sd["score"].ToString());
                    Q2++;
                }
                else if (sd["quesnum"].ToString() == "Q3")
                {
                    list3.Add(new List<string>());
                    list3[Q3].Add(sd["quesnum"].ToString());
                    list3[Q3].Add(sd["content"].ToString());
                    list3[Q3].Add(sd["value"].ToString());
                    list3[Q3].Add(sd["score"].ToString());
                    Q3++;
                }
                else if (sd["quesnum"].ToString() == "Q4")
                {
                    list4.Add(new List<string>());
                    list4[Q4].Add(sd["quesnum"].ToString());
                    list4[Q4].Add(sd["content"].ToString());
                    list4[Q4].Add(sd["value"].ToString());
                    list4[Q4].Add(sd["score"].ToString());
                    Q4++;
                }
            }
            sd.Close();
            strb.Append("<table style=\"width:100%; border:1px solid black; line-height:50;\" class=\"DefaultTable\">");
            strb.Append("<tr>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:8%; color:White;\"><b>구분</b></td>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:5%; color:White;\"><b>평가<br />항목</b></td>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:15%; color:White;\"><b>평가내용</b></td>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:5%; color:White;\"><b>배점</b></td>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:44%; color:White;\" colspan=\"2\"><b>평가유형</b></td>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:6%; color:White;\"><b>점수<br />배분</b></td>");
            strb.Append("<td bgColor=\"#2E75B6\" style=\"width:7%; color:White;\"><b>평가<br />점수</b></td>");
            strb.Append("</tr>");
            strb.Append("<tr>");
            strb.Append("<td rowspan=\"2\">수신<br />");
            strb.Append("신속성<br />");
            strb.Append("(30점)</td>");
            strb.Append("<td rowspan=\"2\">신속성</td>");
            strb.Append("<td rowspan=\"2\">전화벨/송출음</td>");
            strb.Append("<td rowspan=\"2\">30</td>");
            strb.Append("<td style=\"text-align:left;\">");
            strb.Append("<input type=\"radio\" id=\"" + list1[0][0].ToString() + "_" + list1[0][2] + "\" name=\"" + list1[0][0].ToString() + "\" onclick=\"f_checkbtn(1," + list1[0][3].ToString() + ");\" value=\"" + list1[0][2].ToString() + "\" />" + list1[0][1].ToString() + "<br />");
            strb.Append("<input type=\"radio\" id=\"" + list1[1][0].ToString() + "_" + list1[1][2] + "\" name=\"" + list1[1][0].ToString() + "\" onclick=\"f_checkbtn(1," + list1[1][3].ToString() + ");\" value=\"" + list1[1][2].ToString() + "\" />" + list1[1][1].ToString() + "<br />");
            strb.Append("<input type=\"radio\" id=\"" + list1[2][0].ToString() + "_" + list1[2][2] + "\" name=\"" + list1[2][0].ToString() + "\" onclick=\"f_checkbtn(1," + list1[2][3].ToString() + ");\" value=\"" + list1[2][2].ToString() + "\" />" + list1[2][1].ToString() + "<br />");
            strb.Append("</td>");
            strb.Append("<td style=\"text-align:left;\">");
            strb.Append("5~7초 수신<br />");
            strb.Append("7~12초 수신<br />");
            strb.Append("12초 이상");
            strb.Append("</td>");
            strb.Append("<td rowspan=\"2\">");
            strb.Append("1)" + list1[0][3].ToString() + "점<br />");
            strb.Append("2)" + list1[1][3].ToString() + "점<br />");
            strb.Append("3)" + list1[2][3].ToString() + "점</td>");
            strb.Append("<td rowspan=\"2\"><font color=\"red\"><b><span id=\"span1\"></span></b></font></td>");
            strb.Append("</tr>");
            strb.Append("<tr>");
            strb.Append("<td colspan=\"2\" style=\"text-align:left;\">※ 늦게 받은 사유를 설명하고 양해인사를 하였을 경우<br /> - 1단계 상향평가</td>");
            strb.Append("</tr>");
            strb.Append("<tr>");
            strb.Append("<td rowspan=\"3\">상담<br />");
            strb.Append("친절성<br />");
            strb.Append("(70점)</td>");
            strb.Append("<td rowspan=\"2\">신뢰성</td>");
            strb.Append("<td>고객맞이<br />");
            strb.Append("인사말</td>");
            strb.Append("<td>20</td>");
            strb.Append("<td colspan=\"2\" style=\"text-align:left;\">");
            strb.Append("<input type=\"radio\" id=\"" + list2[0][0].ToString() + "_" + list2[0][2] + "\" name=\"" + list2[0][0].ToString() + "\" onclick=\"f_checkbtn(2," + list2[0][3].ToString() + ");\" value=\"" + list2[0][2].ToString() + "\" />" + list2[0][1].ToString() + "<br />");
            strb.Append("<input type=\"radio\" id=\"" + list2[1][0].ToString() + "_" + list2[1][2] + "\" name=\"" + list2[1][0].ToString() + "\" onclick=\"f_checkbtn(2," + list2[1][3].ToString() + ");\" value=\"" + list2[1][2].ToString() + "\" />" + list2[1][1].ToString() + "<br />");
            strb.Append("<input type=\"radio\" id=\"" + list2[2][0].ToString() + "_" + list2[2][2] + "\" name=\"" + list2[2][0].ToString() + "\" onclick=\"f_checkbtn(2," + list2[2][3].ToString() + ");\" value=\"" + list2[2][2].ToString() + "\" />" + list2[2][1].ToString() + "<br />");
            strb.Append("<input type=\"radio\" id=\"" + list2[3][0].ToString() + "_" + list2[3][2] + "\" name=\"" + list2[3][0].ToString() + "\" onclick=\"f_checkbtn(2," + list2[3][3].ToString() + ");\" value=\"" + list2[3][2].ToString() + "\" />" + list2[3][1].ToString() + "<br />");
            strb.Append("※ 첫인사말을 '감사합니다.'로 구사해도 첫인사말 구사한것으로 간주<br />");
            strb.Append("예) '감사합니다. 보상과 홍길동입니다.'");
            strb.Append("</td>");
            strb.Append("<td>1)" + list2[0][3].ToString() + "점<br />");
            strb.Append("2)" + list2[1][3].ToString() + "점<br />");
            strb.Append("3)" + list2[2][3].ToString() + "점<br />");
            strb.Append("4)" + list2[3][3].ToString() + "점</td>");
            strb.Append("<td><font color=\"red\"><b><span id=\"span2\"></span></b></font></td>");
            strb.Append("</tr>");
            strb.Append("<tr>");
            strb.Append("<td>종료 인사말</td>");
            strb.Append("<td>20</td>");
            strb.Append("<td colspan=\"2\" style=\"text-align:left;\">");
            strb.Append("<input type=\"radio\" id=\"" + list3[0][0].ToString() + "_" + list3[0][2] + "\" name=\"" + list3[0][0].ToString() + "\" onclick=\"f_checkbtn(3," + list3[0][3].ToString() + ");\" value=\"" + list3[0][2].ToString() + "\" />" + list3[0][1].ToString() + "<br />");
            strb.Append("<input type=\"radio\" id=\"" + list3[1][0].ToString() + "_" + list3[1][2] + "\" name=\"" + list3[1][0].ToString() + "\" onclick=\"f_checkbtn(3," + list3[1][3].ToString() + ");\" value=\"" + list3[1][2].ToString() + "\" />" + list3[1][1].ToString() + "<br />");
            strb.Append("※ 종료인사 구사 시 감사 인사 대신 '수고하세요'로 구사해도 종료인사를 구사한것으로 간주<br />");
            strb.Append("예) '수고하세요' 등");
            strb.Append("</td>");
            strb.Append("<td>1)" + list3[0][3].ToString() + "점<br />");
            strb.Append("2)" + list3[1][3].ToString() + "점</td>");
            strb.Append("<td><font color=\"red\"><b><span id=\"span3\"></span></b></font></td>");
            strb.Append("</tr>");
            strb.Append("<tr>");
            strb.Append("<td>친절성</td>");
            strb.Append("<td>상담 어감 및<br />");
            strb.Append("공감표현 능력</td>");
            strb.Append("<td>30</td>");
            strb.Append("<td colspan=\"2\" style=\"text-align:left;\">");

            strb.Append("<input type=\"radio\" id=\"" + list4[0][0].ToString() + "_" + list4[0][2] + "\" name=\"" + list4[0][0].ToString() + "\" onclick=\"f_checkbtn(4," + list4[0][3].ToString() + ");\" value=\"" + list4[0][2].ToString() + "\" />" + list4[0][1].ToString() + "<br />");
            strb.Append("<input type=\"radio\" id=\"" + list4[1][0].ToString() + "_" + list4[1][2] + "\" name=\"" + list4[1][0].ToString() + "\" onclick=\"f_checkbtn(4," + list4[1][3].ToString() + ");\" value=\"" + list4[1][2].ToString() + "\" />" + list4[1][1].ToString() + "<br />");
            strb.Append("<input type=\"radio\" id=\"" + list4[2][0].ToString() + "_" + list4[2][2] + "\" name=\"" + list4[2][0].ToString() + "\" onclick=\"f_checkbtn(4," + list4[2][3].ToString() + ");\" value=\"" + list4[2][2].ToString() + "\" />" + list4[2][1].ToString() + "<br />");
            strb.Append("<input type=\"radio\" id=\"" + list4[3][0].ToString() + "_" + list4[3][2] + "\" name=\"" + list4[3][0].ToString() + "\" onclick=\"f_checkbtn(4," + list4[3][3].ToString() + ");\" value=\"" + list4[3][2].ToString() + "\" />" + list4[3][1].ToString() + "<br />");
            strb.Append("<input type=\"radio\" id=\"" + list4[4][0].ToString() + "_" + list4[4][2] + "\" name=\"" + list4[4][0].ToString() + "\" onclick=\"f_checkbtn(4," + list4[4][3].ToString() + ");\" value=\"" + list4[4][2].ToString() + "\" />" + list4[4][1].ToString() + "<br />");
            strb.Append("</td>");
            strb.Append("<td>1)" + list4[0][3].ToString() + "점<br />");
            strb.Append("2)" + list4[1][3].ToString() + "점<br />");
            strb.Append("3)" + list4[2][3].ToString() + "점<br />");
            strb.Append("4)" + list4[3][3].ToString() + "점<br />");
            strb.Append("5)" + list4[4][3].ToString() + "점</td>");
            strb.Append("<td><font color=\"red\"><b><span id=\"span4\"></span></b></font></td>");
            strb.Append("</tr>");
            strb.Append("</table>");
            strb.Append("<div style=\"width:100%; text-align:right;\"><br><input type=\"button\" class=\"button_black\" value=\"이  전\" onclick=\"history.go(-1)\" />&nbsp;&nbsp;&nbsp;<input type=\"button\" class=\"button_black\" value=\"등  록\" onclick=\"f_register()\" /></div>");
            strb.Append("<input type=\"hidden\" id=\"code\" name=\"code\" value=\"" + Request.Params["tcode"].ToString() + "\">");

            sqltext = "select * from " + tbc.dataTable + " where code='" + Request.Params["tcode"].ToString() + "'";
            //Response.Write(sqltext);
            sd = def.dbcls.CallSelect(sqltext);

            if (sd.HasRows)
            {
                sd.Read();
                strb.Append("<input type=\"hidden\" id=\"htotal\" name=\"htotal\" value=\"0\">");
                strb.Append("<input type=\"hidden\" id=\"state\" name=\"state\" value=\"1\">");
                strb.Append("<script type=\"text/javascript\">");
                strb.Append("document.getElementsByName(\"Q1\")[" + (Convert.ToInt32(sd["Q1"]) - 1).ToString() + "].checked=true; ");
                strb.Append("document.getElementsByName(\"Q2\")[" + (Convert.ToInt32(sd["Q2"]) - 1).ToString() + "].checked=true; ");
                strb.Append("document.getElementsByName(\"Q3\")[" + (Convert.ToInt32(sd["Q3"]) - 1).ToString() + "].checked=true; ");
                strb.Append("document.getElementsByName(\"Q4\")[" + (Convert.ToInt32(sd["Q4"]) - 1).ToString() + "].checked=true; ");
                if (sd["Q1"].ToString() != "0")
                {
                    strb.Append("f_checkbtn(1," + list1[Convert.ToInt32(sd["Q1"]) - 1][3] + ");");
                    strb.Append("f_checkbtn(2," + list2[Convert.ToInt32(sd["Q2"]) - 1][3] + ");");
                    strb.Append("f_checkbtn(3," + list3[Convert.ToInt32(sd["Q3"]) - 1][3] + ");");
                    strb.Append("f_checkbtn(4," + list4[Convert.ToInt32(sd["Q4"]) - 1][3] + ");");

                    strb.Append("f_checktotal(" + sd["total"].ToString() + ");");
                    strb.Append("f_checkdate('" + sd["startdate"].ToString() + " / " + sd["enddate"].ToString() + "');");
                }
                strb.Append("</script>");
            }
            else
            {
                strb.Append("<input type=\"hidden\" id=\"htotal\" name=\"htotal\" value=\"0\">");
                strb.Append("<input type=\"hidden\" id=\"state\" name=\"state\" value=\"0\">");
            }

            ltltable.Text = strb.ToString();
            sd.Close();
            strb = null;

            def.dbcls.CloseDB();
            def = null;
            list1 = null;
            list2 = null;
            list3 = null;
            list4 = null;
            sd = null;
            tbc = null;
        }
    }
}