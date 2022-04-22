  // open window modal
function f_OpenWindow(twinname, topenstr, tparamx) {
    if (tparamx == "undefined") tparamx = "clientwindow"
    var twstr;
    switch (twinname) {
        case 0:case 10: //
            if (tparamx.left != "undefind" && tparamx.top != "undefined" && tparamx.width != "undefined" && tparamx.height != "undefined") {
                twstr = "dialogTop:" + tparamx.top + "px;dialogLeft:" + tparamx.left + "px;dialogWidth:" + tparamx.width + "px;dialogHeight:"
                twstr += tparamx.height + "px;resizable: no; help: no; status: no; scroll:yes;toolbars:no;";
                //document.write(twstr + "<br>");
                //document.write(fs_ReString2(topenstr, tparamx.actionurl) + "<br>");
                return showModalDialog(fs_ReString2(topenstr, tparamx.actionurl)+"&w__="+tparamx.width+"&h__="+tparamx.height, tparamx, twstr);
            }
            else {
                twstr = "dialogTop:100;dialogLeft:400;dialogWidth:440px;dialogHeight: 400px;";
                twstr += "resizable: no; help: no; status: no; scroll: yes;"
                return showModalDialog(fs_ReString2(topenstr, tparamx.actionurl) + "&w__=" + tparamx.width + "&h__=" + tparamx.height, tparamx, twstr);
            }
            break;
        case 1:
            if (tparamx.left != "undefind" && tparamx.top != "undefined" && tparamx.width != "undefined" && tparamx.height != "undefined") {
                twstr = "dialogTop:" + tparamx.top + "px;dialogLeft:" + tparamx.left + "px;dialogWidth:" + tparamx.width + "px;dialogHeight:"
                twstr += tparamx.height + "px;resizable: no; help: no; status: no; scroll:yes;toolbars:no;";
                return showModalDialog(fs_ReString3(topenstr, tparamx.actionurl) + "&w__=" + tparamx.width + "&h__=" + tparamx.height, tparamx, twstr);
            }
            else {
                twstr = "dialogTop:100;dialogLeft:400;dialogWidth:440px;dialogHeight: 400px;";
                twstr += "resizable: no; help: no; status: no; scroll: yes;"
                return showModalDialog(fs_ReString3(topenstr, tparamx.actionurl) + "&w__=" + tparamx.width + "&h__=" + tparamx.height, tparamx, twstr);
            }
            break;

        case 2:

            if (tparamx.left != "undefind" && tparamx.top != "undefined" && tparamx.width != "undefined" && tparamx.height != "undefined") {
                twstr = "dialogTop:" + tparamx.top + "px;dialogLeft:" + tparamx.left + "px;dialogWidth:" + tparamx.width + "px;dialogHeight:"
                twstr += tparamx.height + "px;resizable: no; help: no; status: no; scroll:yes;toolbars:no;";
                return showModalDialog(fs_ReString4(topenstr, tparamx.actionurl) + "&w__=" + tparamx.width + "&h__=" + tparamx.height, tparamx, twstr);
            }
            else {
                twstr = "dialogTop:100;dialogLeft:400;dialogWidth:440px;dialogHeight: 400px;";
                twstr += "resizable: no; help: no; status: no; scroll: yes;"
                return showModalDialog(fs_ReString4(topenstr, tparamx.actionurl) + "&w__=" + tparamx.width + "&h__=" + tparamx.height, tparamx, twstr);
            }
            break;
    }
}

function fs_ReString2(tm_str, tm_str2) {
    var temp;
    var tstr = tm_str.split("?");
//    temp = "../common/window_frame.aspx?"
    temp = "/aspxcommon/window_frame.aspx?"
    if (tstr.length < 2) {
//        temp += "tactionurl=../" + tm_str2 + "/" + tm_str;
        temp += "tactionurl=" + tm_str2 + "/" + tm_str;
    }
    else {
        temp += tstr[1];
//        temp += "&tactionurl=../" + tm_str2 + "/" + tstr[0];
        temp += "&tactionurl=" + tm_str2 + "/" + tstr[0];
    }
    return temp;
}

function fs_ReString3(tm_str, tm_str2) {
    var temp;
    var tstr = tm_str.split("?");
    temp = "/axpxcommon/intrnet_frame.asp?"
    if (tstr.length < 2) {
        temp += "tactionurl=" + tm_str2 + "/" + tm_str;
    }
    else {
        temp += tstr[1];
        temp += "&tactionurl=" + tm_str2 + "/" + tstr[0];
    }
    return temp;
}

function fs_ReString4(tm_str, tm_str2) {
    var temp;
    var tstr = tm_str.split("?");
    temp = "/aspxcommon/window_frame.aspx?"
    if (tstr.length < 2) {
        temp += "tactionurl="+tm_str;
    }
    else {
        temp += tstr[1];
        temp += "&tactionurl="+ tstr[0];
    }
    return temp;
} 
