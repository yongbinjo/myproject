function js_Trim(tvalue) {
    var temp;
    if (tvalue == undefined || tvalue == "") return "";
    temp = js_LTrim(tvalue);
    return js_RTrim(temp);
}

function js_LTrim(tvalue) {
    var temp, i;
    if (tvalue == undefined) return "";
    temp = "";
    for (i = 0; i < tvalue.length; i++) {
        if (tvalue.charAt(i) != ' ') break;
    }
    temp = tvalue.substr(i, tvalue.length);
    return temp;
}

function js_RTrim(tvalue) {
    var temp, i;
    if (tvalue == undefined) return "";
    temp = "";
    for (i = tvalue.length - 1; i > 1; i--) {
        if (tvalue.charAt(i) != ' ') break;
    }
    temp = tvalue.substr(0, i + 1);
    return temp;
}

function f_EnterKeyCheck() {
    if (event.keyCode == 13) { event.keyCode = 0; f_submit(document.forms[0]); }
}

function f_Logout(turl) {
    document.forms[0].action =(turl==undefined ? "/Login/Logout.aspx" : turl);
    document.forms[0].submit();
}

function f_WindowMoveCenter(tid) {
    var twin = document.getElementById(tid);
    if (twin == null) return;
    var twidth = twin.style.width.replace("px", ""); var theight = twin.style.height.replace("px", "");
    twin.style.left = (document.documentElement.clientWidth - twidth) / 2 + "px";
    twin.style.top = (document.documentElement.clientHeight - theight) / 2 + "px";
}