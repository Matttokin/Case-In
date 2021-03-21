var my_masage_styl = "my_msg";
var bot_msg_styl = "bot_msg";
var bot_msg_button_styl = "bot_msg_button";
var bot_masg_link_styl = "bot_masg_link";
var bot_masg_image_styl = "bot_masg_image";

var document = window.document;
var text = document.getElementById("text_message");

var login_password = "";

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
    var listMenuButtons = document.getElementsByClassName("menuclass");
    var count = [];
    for (var i = 0; i < listMenuButtons.length; i++) {
        count.push(listMenuButtons[i].id);
    }
    for (var i = 0; i < count.length; i++) {
        document.getElementById(count[i]).remove();
    }
    getListCommand();
}

function showButtons(dataCommand, nameCommand, paramCommand, canusetwithoutchat = true, needreemove = false, scroll = true, menu = false) {
    let trss = document.createElement('tr');
    let input = document.createElement('input');
    input.className = "bot_msg_button";
    if (menu) input.className += " menuclass" 
    input.type = "submit";
    input.id = dataCommand;
    input.value = nameCommand;
    if (paramCommand !== null)
        input.name = paramCommand;
    if (dataCommand == "UserInfo") {
        input.onclick = function () {
            sendRequest(dataCommand, login_password);
        }
    }
    else
    if (dataCommand == "Authorization") {
        input.onclick = function () {
            showMessg('Введите логин и пароль в следующем формате: "log pass"', bot_msg_styl);
            document.getElementById("button_message").onclick = function () {
                login_password = text.value;
                sendRequest(dataCommand, login_password);
                text.value = "";
            };
        }
    }
    else
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
        url: 'http://c1997e2b1dd1.ngrok.io/api/GetCommandList?isAuth=' + (login_password !== ""),
        type: 'GET',
        dataType: 'html',
        async: false,
        success: function (msg) {
            json = msg;
        }
    });
    var obj = $.parseJSON(json);
    obj.forEach(function (entry) {
        showButtons(entry.dataCommand, entry.nameCommand, entry.paramCommand, entry.canUseWithoutChat, false, false, true);
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

function proccessDataFromServer(json, dataCommand = "huawehoau") {
    if (document.getElementById("listCommnds") !== null) document.getElementById("listCommnds").remove();
    var obj = $.parseJSON(json);
    var text = "";
    if (obj.errorMes !== null) {
        if (dataCommand == "Authorization") login_password = "";
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
    var res = false;
    $.ajax({
        url: 'http://c1997e2b1dd1.ngrok.io/api/Main?json=' + req,
        type: 'post',
        dataType: 'html',
        async: false,
        success: function (msg) {
            bseClickProccesSend();
            proccessDataFromServer(msg, dataCommand);
        }
    });
    return res;
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
