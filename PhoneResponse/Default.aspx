<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhoneResponse.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Include/common_style.css" rel="stylesheet" type="text/css" />
    <title>전화 민원 응대 실태 점검</title>
</head>
<script src="Include/ClientDevScript.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function f_submit(x) {
        if (js_Trim(x.tinterviwerid.value) == "" || js_Trim(x.tinterviwername.value) == "") {
            alert("아이디와 비밀번호는 필수 항목입니다.  확인하십시오");
            if (js_Trim(x.tinterviwerid.value) == "") { x.tinterviwerid.value = ""; x.tinterviwerid.focus(); }
            else { x.tinterviwername.value = ""; x.tinterviwername.focus(); }
            return false;
        }
        x.action = "Login.aspx";
        x.submit();
    }
</script>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <br /><br />
        <table>
            <tr>
                <td align="center" style="font-size:20px;"><b>test전화 민원 응대실태 점검 평가</b><br /><br /><br /></td>
            </tr>
            <tr>
                <td>
                    <table style="width:360px;" border="0" cellpadding="3" cellspacing="0">
                        <tr style="height:30px;">
                            <td width="40%" align="center" bgcolor="#CEE3F6" style="font-size:14px;"><b>면접원ID</b></td>
                            <td width="60%" align="left" bgcolor="#F2F2F2"><input type="text" id="tinterviwerid" class="geninput"  style="width:98%;font-size:16px;" maxlength="40" value="" onkeydown="f_EnterKeyCheck();" runat="server"/></td>
                        </tr>
                        <tr style="height:30px;">
                            <td align="center" bgcolor="#CEE3F6" style="font-size:14px;"><b>면접원이름</b></td>
                            <td align="left" bgcolor="#F2F2F2"><input type="text" id="tinterviwername" class="geninput" value=""  style="width:98%;font-size:16px;" maxlength="40" onkeydown="f_EnterKeyCheck();" runat="server"/></td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2"><input type="button" class="button_black" value=" 로 그 인 " onclick="f_submit(this.form);" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
    </div>
    </form>
</body>
</html>

