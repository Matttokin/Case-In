var my_masage_styl = "my_msg";
var bot_msg_styl = "bot_msg";
var bot_msg_button_styl = "bot_msg_button";
var bot_masg_link_styl = "bot_masg_link";
var bot_masg_image_styl = "bot_masg_image";

var document = window.document;
var text = document.getElementById("text_message");


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

function showButtons(dataCommand, nameCommand, paramCommand) {
    let trss = document.createElement('tr');
    let input = document.createElement('input');
    input.className = "bot_msg_button";
    input.type = "submit";
    input.id = dataCommand;
    input.value = nameCommand;
    if (paramCommand !== null)
        input.name = paramCommand;
    trss.append(input);
    document.getElementById("spisochk").append(trss);
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
        showButtons(entry.dataCommand, entry.nameCommand, entry.paramCommand);
    });
}

function showMessg(msgsses, class_name) {
    let trss = document.createElement('tr');
    let div = document.createElement('td');
    div.className = class_name;
    div.innerHTML = msgsses;
    trss.append(div);
    document.getElementById("spisochk").append(trss);

    var curPos = $(document).scrollTop();
    var height = $("body").height();
    var scrollTime = (height - curPos) / 1.73;
    $("body,html").animate({ "scrollTop": height }, scrollTime);
}

function textProcces(text) {
    var msg;
    switch (text.type) {
        case 'img':
            msg = '<a class="fancybox" rel="group" href="' + text.data + '"><img src="' + text.data  + '" alt="" /></a>';
            break;
        case 'link':
            msg = '<a href="' + text.data + '"><b>' + text.alias + '</b></a>';
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

function sendRequest(dataCommand, paramCommand) {
    if (document.getElementById("listCommnds") !== null) document.getElementById("listCommnds").remove();
    var req = '{ "mainCommand": "' + dataCommand + '",' + '"param": "' + paramCommand + '"}';
    var json;
    $.ajax({
        url: 'http://c1997e2b1dd1.ngrok.io/api/Main?json=' + req,
        type: 'post',
        dataType: 'html',
        async: false,
        success: function (msg) {
            json = msg;
            document.getElementById("button_message").onclick = function () {
                showMessg(text.value, my_masage_styl);
                sendReq(text.value);
            }
        }
    });

    var obj = $.parseJSON(json);
    var text = "";
    if (obj.errorMes !== null) {
        showMessg(obj.errorMes, bot_msg_styl);
        showButtons("listCommnds", "Вызвать список команд?", null);
        document.getElementById("listCommnds").onclick = function () {
            resetButtons();
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
            let trss = document.createElement('tr');
            let input = document.createElement('input');
            input.className = "bot_msg_button";
            input.type = "submit";
            input.id = data.dataCommand + data.paramCommand;
            input.value = data.nameCommand;
            if (data.paramCommand !== null)
                input.name = data.paramCommand;
            trss.append(input);
            document.getElementById("spisochk").append(trss);
            document.getElementById(data.dataCommand + data.paramCommand).onclick = function () {
                sendRequest(data.dataCommand, data.paramCommand);
                document.getElementById(data.dataCommand + data.paramCommand).remove();
            }
        });

    }
}

function sendReq(msg) {
    if (document.getElementById("listCommnds") !== null) document.getElementById("listCommnds").remove();
    var req = msg;
    var json;
    $.ajax({
        url: 'http://c1997e2b1dd1.ngrok.io/api/Text?text=' + req,
        type: 'post',
        dataType: 'html',
        async: false,
        success: function (msg) {
            json = msg;
        }
    });

    $.f

    var obj = $.parseJSON(json);
    var text = "";
    if (obj.errorMes !== null) {
        showMessg(obj.errorMes, bot_msg_styl);
        showButtons("listCommnds", "Вызвать список команд?", null);
        document.getElementById("listCommnds").onclick = function () {
            resetButtons();
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
            let trss = document.createElement('tr');
            let input = document.createElement('input');
            input.className = "bot_msg_button";
            input.id = data.dataCommand + data.paramCommand;
            input.value = data.nameCommand;
            if (data.paramCommand !== null)
                input.name = data.paramCommand;
            trss.append(input);
            document.getElementById("spisochk").append(trss);
            document.getElementById(data.dataCommand + data.paramCommand).onclick = function () {
                sendRequest(data.dataCommand, data.paramCommand);
                document.getElementById(data.dataCommand + data.paramCommand).remove();
            }
        });

    }
}

document.getElementById("button_message").onclick = function () {
    showMessg(text.value, my_masage_styl);
    sendReq(text.value);
}

getListCommand();

var RegulationsDocs = document.getElementById("RegulationsDocs");
var CompanyOffices = document.getElementById("CompanyOffices");
var CompanyOfficesPlan = document.getElementById("CompanyOfficesPlan");
var CompanyOfficesInfo = document.getElementById("CompanyOfficesInfo");
var CultureInfo = document.getElementById("CultureInfo");
var UserInfo = document.getElementById("UserInfo");


RegulationsDocs.onclick = function () { sendRequest(RegulationsDocs.id, null); };
CompanyOffices.onclick = function () { sendRequest(CompanyOffices.id, null); };
CultureInfo.onclick = function () { sendRequest(CultureInfo.id, CultureInfo.name); };
CompanyOfficesPlan.onclick = function () {
    showMessg("Введите " + CompanyOfficesPlan.name.toLowerCase(), bot_msg_styl);
    document.getElementById("button_message").onclick = function () {
        showMessg(text.value, my_masage_styl);
        sendRequest(CompanyOfficesPlan.id, text.value);
    }
};
CompanyOfficesInfo.onclick = function () {
    showMessg("Введите " + CompanyOfficesInfo.name.toLowerCase(), bot_msg_styl);
    document.getElementById("button_message").onclick = function () {
        showMessg(text.value, my_masage_styl);
        sendRequest(CompanyOfficesInfo.id, text.value);
    }
};
UserInfo.onclick = function () {
    showMessg("Введите " + UserInfo.name.toLowerCase(), bot_msg_styl);
    document.getElementById("button_message").onclick = function () {
        showMessg(text.value, my_masage_styl);
        sendRequest(UserInfo.id, text.value);
    }
};