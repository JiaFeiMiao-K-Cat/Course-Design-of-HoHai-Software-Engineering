function BlazorSetLocalStorage(key, value) {
    localStorage.setItem(key, value);
}

function BlazorGetLocalStorage(key) {
    return localStorage.getItem(key);
}

function BlazorRegisterStorageEvent(component) {
    window.addEventListener("storage", async e => {
        await component.invokeMethodAsync("OnStorageUpdated", e.key);
    });
}
function ChangeDisplay(ID, ColumnNumber, style) {
    var needChange = document.getElementById(ID).rows;
    for (var i = 0, len = needChange.length; i < len; i++) {
        var cell = needChange[i].cells[ColumnNumber];
        cell.style.display = style;
    }
}
function HideDiv(ID) {
    var needHide = document.getElementById(ID);
    needHide.display = "none";
}
function ShowDiv(ID) {
    var needShow = document.getElementById(ID);
    needShow.display = "";
}
function PrintDiv(ID) {
    var needPrint = document.getElementById(ID);
    var win = window.open("");
    win.document.write(
        '<html><head><link href="css/bootstrap/bootstrap.min.css" rel="stylesheet" />'
        + '<link href="css/app.css" rel="stylesheet" />'
        + '<link href="_content/AntDesign/css/ant-design-blazor.css" rel="stylesheet" />'
        + '<link href="PWA.styles.css" rel="stylesheet" /></head><body>'
        + needPrint.outerHTML + '</body>'
        + "</html>");
    win.document.close();
    //Chrome
    if (navigator.userAgent.indexOf("Chrome") != -1) {
        win.onload = function () {
            win.document.execCommand('print');
            win.close();
        }
    }
    //Firefox
    else {
        win.print();
        win.close();
    }
}
function ShowMessage(text) {
    alert(text);
}
function Save(text, fileName) {
    var element = document.createElement('a');
    element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));
    element.setAttribute('download', fileName);
    element.style.display = 'none';
    element.click();
}