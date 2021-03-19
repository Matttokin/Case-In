var my_masage_styl = "my_msg";
var bot_msg_styl = "bot_msg";
var bot_msg_button_styl = "bot_msg_button";
var bot_masg_link_styl = "bot_masg_link";
var bot_masg_image_styl = "bot_masg_image";

var document = window.document;
var text = document.getElementById("text_message");

function doSendRequests(Comand) {
    if (text.value !== "") {
        showMessg(text.value, my_masage_styl);
        sendRequest(Comand, text.value);
        text.value = "";
    }
}

function scrollBottom() {
    var curPos = $(document).scrollTop();
    var height = $("body").height();
    var scrollTime = (height - curPos) / 1.73;
    $("body,html").animate({ "scrollTop": height }, scrollTime);
}

function bseClickProccesSend() {
    document.getElementById("button_message").onclick = function () {
        if (text.value !== "") {
            showMessg(text.value, my_masage_styl);
            sendReq(text.value);
            text.value = "";
        }
    }
}

function resetButtons() {
    var RegulationsDocs = document.getElementById("RegulationsDocs");
    var CompanyOffices = document.getElementById("CompanyOffices");
    var CompanyOfficesPlan = document.getElementById("CompanyOfficesPlan");
    var CompanyOfficesInfo = document.getElementById("CompanyOfficesInfo");
    var CultureInfo = document.getElementById("CultureInfo");
    var UserInfo = document.getElementById("UserInfo");

    document.getElementById("RegulationsDocs").remove();
    document.getElementById("CompanyOffices").remove();
    document.getElementById("CompanyOfficesPlan").remove();
    document.getElementById("CompanyOfficesInfo").remove();
    document.getElementById("CultureInfo").remove();
    document.getElementById("UserInfo").remove();

    document.getElementById("spisochk").append(RegulationsDocs);
    document.getElementById("spisochk").append(CompanyOffices);
    document.getElementById("spisochk").append(CompanyOfficesPlan);
    document.getElementById("spisochk").append(CompanyOfficesInfo);
    document.getElementById("spisochk").append(CultureInfo);
    document.getElementById("spisochk").append(UserInfo);
}

function showButtons(dataCommand, nameCommand, paramCommand, canusetwithoutchat = true, needreemove = false, scroll = true) {
    let trss = document.createElement('tr');
    let input = document.createElement('input');
    input.className = "bot_msg_button";
    input.type = "submit";
    input.id = dataCommand;
    input.value = nameCommand;
    if (paramCommand !== null)
        input.name = paramCommand;
    if (!canusetwithoutchat) {
        input.onclick = function () {
            showMessg("Введите " + paramCommand.toLowerCase(), bot_msg_styl);
            document.getElementById("button_message").onclick = function () {
                doSendRequests(dataCommand);
            };
        }
    }
    else {
        input.onclick = function () {
            if (needreemove) input.remove();
            sendRequest(dataCommand, paramCommand);
        }
    }
    trss.append(input);
    document.getElementById("spisochk").append(trss);

    if(scroll)
        scrollBottom();
}


function getListCommand() {
    var json;
    $.ajax({
        url: 'http://c1997e2b1dd1.ngrok.io/api/GetCommandList',
        type: 'GET',
        dataType: 'html',
        async: false,
        success: function (msg) {
            json = msg;
        }
    });
    var obj = $.parseJSON(json);
    obj.forEach(function (entry) {
        showButtons(entry.dataCommand, entry.nameCommand, entry.paramCommand, entry.canUseWithoutChat, false, false);
    });
}

function showMessg(msgsses, class_name) {
    let trss = document.createElement('tr');
    let div = document.createElement('td');
    div.className = class_name;
    div.innerHTML = msgsses;
    trss.append(div);
    document.getElementById("spisochk").append(trss);

    scrollBottom();
}

function textProcces(text) {
    var msg;
    switch (text.type) {
        case 'img':
            msg = '<img src="' + text.data  + '" alt="" />';
            break;
        case 'link':
            msg = '<a href="' + text.data + '" target="_blank"><b>' + text.alias + '</b></a>';
            break;
        case 'text':
            var alias = text.alias !== null ? text.alias : " ";
            msg = '<b>' + alias + "&nbsp;" + '</b>' + text.data;
            break;
        default:
            msg = '<b>' + text + '<b>';
            break;
    }
    return msg + '<br><br>';
}

function proccessDataFromServer(json) {
    if (document.getElementById("listCommnds") !== null) document.getElementById("listCommnds").remove();
    var obj = $.parseJSON(json);
    var text = "";
    if (obj.errorMes !== null) {
        showMessg(obj.errorMes, bot_msg_styl);
        showButtons("listCommnds", "Вызвать список команд?", null);
        document.getElementById("listCommnds").onclick = function () {
            resetButtons();
            scrollBottom();
            this.remove();
        }
    }
    if (obj.listData !== null) {
        obj.listData.forEach(function (data) {
            text = text + textProcces(data);
        });
        var texts = '<text>' + text.substr(0, text.length - 8) + '</text>';
        showMessg(texts, bot_msg_styl);
    }
    if (obj.listCommand !== null) {
        obj.listCommand.forEach(function (data) {
            showButtons(data.dataCommand, data.nameCommand, data.paramCommand, data.canUseWithoutChat, true);
        });

    }
}

function sendRequest(dataCommand, paramCommand) {
    var req = '{ "mainCommand": "' + dataCommand + '",' + '"param": "' + paramCommand + '"}';
    $.ajax({
        url: 'http://c1997e2b1dd1.ngrok.io/api/Main?json=' + req,
        type: 'post',
        dataType: 'html',
        async: false,
        success: function (msg) {
            proccessDataFromServer(msg);
            bseClickProccesSend();
        }
    });
}

function sendReq(msg) {
    var req = msg;
    $.ajax({
        url: 'http://c1997e2b1dd1.ngrok.io/api/Text?text=' + req,
        type: 'post',
        dataType: 'html',
        async: false,
        success: function (msg) {
            proccessDataFromServer(msg);
        }
    });
}

bseClickProccesSend();

getListCommand();

