

function SHMulSel(ControlClientID, e) {
    var textBoxMain = window.document.getElementById(ControlClientID + '_' + 'tbm');
    var divisionMain = window.document.getElementById(ControlClientID + '_' + 'divMain');

    var displayStatus = divisionMain.style.display;
    if (displayStatus == 'block') {
        divisionMain.style.display = 'none';
        if (window.document.getElementById(ControlClientID + '_' + 'hapb').value == 'True') {
            document.getElementById(ControlClientID + '_' + '__ET1').value = 'MultiSelectDropDown';
            document.getElementById(ControlClientID + '_' + '__EA1').value = textBoxMain.value;
            __doPostBack('MultiSelectDropDown', window.document.getElementById(ControlClientID + '_' + 'tbm').value);
        }
    }
    else {
        divisionMain.style.display = 'block';
    }
    var evt = (window.event == null) ? e : window.event;
    evt.cancelBubble = true;
}

function DisplayTitle(control) {
    control.title = control.value;
}

function SCIT(chkbox, ControlClientID) {
    var labelCollection = window.document.getElementsByTagName('label');
    var hSelectedItemsValueList = document.getElementById(ControlClientID + '_' + 'hsiv');
    var textBoxCurrentValue = new String();
    var textBoxMain = window.document.getElementById(ControlClientID + '_' + 'tbm');
    var selectedLabelValue;

    textBoxCurrentValue = textBoxMain.value;
    var pElement = chkbox.parentElement == null ? chkbox.parentNode : chkbox.parentElement;
    var labelElement = navigator.appName == "Microsoft Internet Explorer" ? pElement.childNodes[2] : pElement.childNodes[3];
    labelValue = labelElement.innerText == null ? labelElement.textContent : labelElement.innerText;

    if (chkbox.checked) {
        textBoxCurrentValue = labelValue + ', ';

        if (textBoxMain.value == 'Select All Employer Ref.' || textBoxMain.value == 'Select')
            textBoxMain.value = textBoxCurrentValue;
        else
            textBoxMain.value += textBoxCurrentValue;

        hSelectedItemsValueList.value = hSelectedItemsValueList.value + chkbox.value + ', ';
    }
    else {
        textBoxCurrentValue = textBoxCurrentValue.replace(labelValue + ', ', "");

        if (textBoxCurrentValue == '')
            textBoxMain.value = 'Select All Employer Ref.';
        else
            textBoxMain.value = textBoxCurrentValue;

        hSelectedItemsValueList.value = hSelectedItemsValueList.value.replace(chkbox.value + ', ', "");
    }
}

function CheckValues(ControlClientID) {
    var control = ControlClientID + '_' + 'hsiv';
    var parentControl = window.document.getElementById(control);
}

function ChangeColor(color, evt) {
    var ele;

    if (window.event != null)
        ele = window.event.srcElement;
    else
        ele = evt.target;

    if (ele.className == 'MultiselectListItemLabel')
        ele = ele.parentElement == null ? ele.parentNode : ele.parentElement;

    if (ele.className == 'MultiselectListItem')
        ele.style.backgroundColor = color;
}

function HideSelectionList(ControlClientID) {
    alert('hello' + ControlClientID);
    var displayStatus = window.document.getElementById(ControlClientID + '_' + 'divMain').style.display;
    if (displayStatus == 'block') {
        window.document.getElementById(ControlClientID + '_' + 'divMain').style.display = 'none';
    }
    else {
        window.document.getElementById(ControlClientID + '_' + 'divMain').style.display = 'block';
    }
}

function HideOnFocusLost(ControlClientID) {
    var divCollection = new Array(ControlClientID + "_ddvs_divMain", ControlClientID + "_ddbu_divMain", ControlClientID + "_dddv_divMain", ControlClientID + "_dddt_divMain", ControlClientID + "_ddsec_divMain", ControlClientID + "_ddcy_divMain", ControlClientID + "_ddcnt_divMain", ControlClientID + "_ddusr_divMain", ControlClientID + "_ddjg_divMain");
    for (index = 0; index < divCollection.length; index++) {
        var divisionMain = document.getElementById(divCollection[index]);
        if (divisionMain != null && divisionMain.style.display == 'block')
            divisionMain.style.display = 'none';
    }
}
