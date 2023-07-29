// <reference path="jquery-1.4.2-vsdoc.js" />

/*==================This is blocked an declared later, this function work same as showInfo
function showInformation(msg) {
//alert('---' + msg);
var emsg = msg;
$('#actAlert').html(emsg);
$('#errorMsg').show();
setTimeout($('#errorMsg').fadeOut(10000), 10000);
}
*/


/*
paste these 2 line in aspx page: 
  
<div class="infoShowDiv"></div>
<div class="errorShowDiv"></div>

and call info/error showing function from cs page:

String myScript = "showInfo('Saved/Updated Successfully')";
ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript, true);
myScript = "";
*/


function showInformation(msg) {
    //alert('---' + msg);
    createInformationShowingDIV();
    var emsg = msg;
    $('#actInfo').html(emsg);
    $('#infoMsg').show();
    setTimeout('$(\'#infoMsg\').fadeOut(1000)', 3000);
    //$('#infoMsg').fadeOut(10000);
}


function showInfo(msg){
	var emsg = msg;
	$.gritter.add({
		title: 'Message!',
		text: emsg,
		sticky: false,
		position: 'top-right', // defaults to 'top-right' but can be 'bottom-left', 'bottom-right', 'top-left', 'top-right' (added in 1.7.1)
		fade_in_speed: 'medium', // how fast notifications fade in (string or int)
		fade_out_speed: 2000, // how fast the notices fade out
		time: 3000, // hang on the screen for...
		class_name: 'gritter-item-wrapper gritter-success'
	});
	
	return false;
}

function showInfo_OLD(msg) {
    //alert('---' + msg);
    createInformationShowingDIV();
    var emsg = msg;
    $('#actInfo').html(emsg);
    $('#infoMsg').show();
    setTimeout('$(\'#infoMsg\').fadeOut(1000)', 3000);
    //$('#infoMsg').fadeOut(10000);
}

function showInfoModal(msg) {
    //alert('---' + msg);
    createInformationShowingModalDIV();
    var emsg = msg;
    $('#actInfo').html(emsg);
    $('#infoMsgModal').show();
    setTimeout('$(\'#infoMsg\').fadeOut(1000)', 3000);
    //$('#infoMsgModal').fadeOut(10000);
}



function showError(msg){
	var emsg = msg;
	$.gritter.add({
		title: 'Error!',
		text: emsg,
		sticky: false,
		position: 'top-canter', // defaults to 'top-right' but can be 'bottom-left', 'bottom-right', 'top-left', 'top-right' (added in 1.7.1)
		fade_in_speed: 'medium', // how fast notifications fade in (string or int)
		fade_out_speed: 2000, // how fast the notices fade out
		time: 3000, // hang on the screen for...
		class_name: 'gritter-item-wrapper gritter-error'
	});
	
	return false;
}

//this is original message changed at Nov 26, 2014 - above 
function showError_OLD(msg) {
    //alert('---' + msg);
    createErrorShowingDIV();
    var emsg = msg;
    $('#errorMsg').show();
    $('#actAlert').html(emsg);
    setTimeout('$(\'#errorMsg\').fadeOut(1000)', 3000);
    //$('#errorMsg').fadeOut(10000);
}



function createInformationShowingDIV() {
    //alert(' info called');
    var infoDivContent = '<div id="infoMsg" class="alert alert-block alert-success">';
    infoDivContent += '<button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>';
    infoDivContent += '<i class="icon-ok"></i> <span id="actInfo"></span></p></div>';
    $('.infoShowDiv').append(infoDivContent);
}


function createInformationShowingModalDIV() {
    //alert(' info called');
    var infoDivContent = '<div id="infoMsgModal" class="ui-state-highlight ui-corner-all" style="margin-top: 0px; padding: 0 .7em;"> ';
    infoDivContent += '<p><span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>';
    infoDivContent += '<strong><span id="actInfo"></span></strong></p></div>';
    $('.infoShowDiv').append(infoDivContent);
}



function createErrorShowingDIV() {
    var infoDivContent = '<div id="errorMsg" class="alert alert-danger">';
    infoDivContent += '<button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>';
    infoDivContent += '<i class="icon-remove"></i> <span id="actAlert"></span></p></div>';
    $('.errorShowDiv').append(infoDivContent);
}


function callbtnCheck(gridNameorID) {
    //alert($('#UpdatePanel1 table').attr('id'));
    //var gridID = $('#UpdatePanel1 table').attr('id');

    //alert($("#btnCheck").hasClass('ui-icon-arrowreturn-1-s'));
    var checkStatus = $("#btnCheck").hasClass('ui-icon-arrowreturn-1-s');
    if (checkStatus) {

        $("#" + gridNameorID + " input:checkbox").attr("checked", function () {
            this.checked = true;
        });

        $('#btnCheck').removeClass();
        $('#btnCheck').addClass("ui-icon ui-icon-arrowreturn-1-n");
        $('#btnCheck').attr('title', 'DeSelect All');

    }
    else {

        $("#" + gridNameorID + " input:checkbox").attr("checked", function () {
            this.checked = false;
        });

        $('#btnCheck').removeClass();
        $('#btnCheck').addClass("ui-icon ui-icon-arrowreturn-1-s");
        $('#btnCheck').attr('title', 'Select All');



    }
}

// return false;
//});


function callbtnCheckCon(gridNameorID, btnID) {

    //alert($("#btnCheck").hasClass('ui-icon-arrowreturn-1-s'));
    //alert(gridNameorID);
    var checkStatus = $('#' + btnID + '').hasClass('ui-icon-arrowreturn-1-s');
    //alert(checkStatus);

    if (checkStatus) {

        $("#" + gridNameorID + " input:checkbox").attr("checked", function () {
            this.checked = true;
        });

        $('#' + btnID + '').removeClass();
        $('#' + btnID + '').addClass("ui-icon ui-icon-arrowreturn-1-n");
        $('#' + btnID + '').attr('title', 'DeSelect All');

    }
    else {

        $("#" + gridNameorID + " input:checkbox").attr("checked", function () {
            this.checked = false;
        });

        $('#' + btnID + '').removeClass();
        $('#' + btnID + '').addClass("ui-icon ui-icon-arrowreturn-1-s");
        $('#' + btnID + '').attr('title', 'Select All');



    }
}


$(function () {
    //For Action button
    $('.ui-state-default, .ui-action-button').hover(
             function () { $(this).addClass('ui-state-hover'); },
             function () {
                 $(this).removeClass('ui-state-hover');
             });

    $('.backDateCheck').change(function () {       
        findDateDifference();
    });


});




function makeClear() {
    //alert('make');
    $('.cssTableAddSpecial input[type=text]').val("");
    //$('.cssTableAddSpecial input[type=text]:eq(0)').focus();
    //return false;
}




function findDateDifference() {
    var dateText = $('.backDateCheck').val(); //getting value of txtDate which is Posting Date
    var tDate = $('#ctl00_HidBackDatedPosting').val(); //getting value of txtToDate
    var today = new Date();


    var fDate = dateText.toString();
    var fFullDate = fDate.split("/");
    var startingdate = new Date(fFullDate[2], fFullDate[1] - 1, fFullDate[0]);

    tDate = tDate.toString();
    fFullDate = tDate.split("/");
    var enddate = new Date(fFullDate[2], fFullDate[1], fFullDate[0]);

    var dayinmili = 24 * 60 * 60 * 1000;

    var datediff = Math.ceil(((today.getTime() - startingdate.getTime()) / (dayinmili)));

    if (parseInt(tDate) > 0) {
        var backDatePosting = parseInt(tDate);
        if (backDatePosting < datediff) {
            showError('Maximum ' + tDate + ' days allowed for backdate posting');
            addMarkClass();
        }
        else {
            removeMarkClass();
        }
    }
    else { //when 0

        if (today.toDateString() != startingdate.toDateString()) {
            if (today > startingdate) {
                //alert('Backdated Posting are not allowed');
                showError('Backdated Posting are not allowed');
                addMarkClass();
            }
            else {
                removeMarkClass();
            }
        }
        else {
            removeMarkClass();
        }
    }


    function addMarkClass() {
        $('.backDateCheck').addClass('mark');
        $('#ctl00_ContentPlaceHolder1_btnSave').addClass('ui-button-disabled');
        $('#ctl00_ContentPlaceHolder1_btnSave').addClass('ui-state-disabled');
        $('#ctl00_ContentPlaceHolder1_btnSave').attr('disabled', 'disabled');

    }


    function removeMarkClass() {
        $('.backDateCheck').removeClass('mark');
        $('#ctl00_ContentPlaceHolder1_btnSave').removeClass('ui-button-disabled');
        $('#ctl00_ContentPlaceHolder1_btnSave').removeClass('ui-state-disabled');
        $('#ctl00_ContentPlaceHolder1_btnSave').removeAttr('disabled');

    }


    //alert(datediff);
}



/*function CV_ClientValidatePhone(source, args) {
    alert('my'+source);
    alert(args);
    this.Page_IsValid = false;
    //var isValid = false;
    // your validation logic here
    //args.IsValid = isValid;
}*/
