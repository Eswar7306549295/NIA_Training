//
$.fn.validateForm = function (op) {
    var op = $.extend({
        novalidate: "",
        validate: "event", // event, execute
        error_align: "top",
        beforeValidate: {}
    }, op);
    var error = { valid: true };
    this.each(function () {
        var validationRx = {
            alfanumeric: /^[a-zA-z0-9 ]+$/,
            contact_person: /^[a-zA-z0-9\. ]+$/,
            nia_name_of_org: /^[a-zA-z0-9\.\s\,\-\/\:\()\&]+$/,
            nia_training_id: /^[a-zA-z0-9\s\.\-]+$/,
            name: /^[a-zA-z\. ]+$/,
            string: /^[a-zA-z\s0-9\'\"\?\&\%\#\@\!\^\(\)\-\_\;\:\.\,\/]+$/,
            number: /^\d+$/,
            mobile: /^\d{10}$/,
            phone: /^\d{6,13}$/,
            multiMobile: /^[\s0-9\-\(\)\+\.\,\/]+$/,
            pincode: /^\d{6}$/,
            amount: /^\d+(\.\d{0,2})?$/,
            //	url : /^(https|http):\/\/[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$/,
            url: /^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/|www\.)[A-Za-z0-9]+([\-\.]{1}[A-Za-z0-9]+)*\.[A-Za-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/,
            email: /[\w-]+@([\w-]+\.)+[\w-]+/,
            PAN: /[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}/,
            date: /^\d{2}\/\d{2}\/\d{4}$/
        }

        var fm = $(this);
        var inputFields = fm.find("input,select,textarea").not(op.novalidate); // getting all form field except hidden fields and novalidate fields
        //var inputFields = fm.find("input").not(op.novalidate); // getting all form field except hidden fields and novalidate fields

        var txt_sel = inputFields.filter(function () {
            if ($(this).is("[type=text],[type=email],[type=password],[type=number],[type=radio],select,textarea")) return true;
                /*if($(this).is("[type=radio]"))return true;*/
            else return false;
        });
        if (op.validate == "event") {
            txt_sel.blur(function () {
                var bv = $(this).data("beforevalidate");
                //console.log("Before Validate ["+$(this).val()+"]["+bv+"]["+op.beforeValidate[bv]+"]");
                if (op.beforeValidate[bv]) {
                    op.beforeValidate[bv]($(this));
                }
                checkvalid($(this));
            });
        } else if (op.validate == "refresh") { //Reset validateForm method for new dynamically added rows
            txt_sel.unbind('blur').blur(function () {
                var bv = $(this).data("beforevalidate");
                //console.log("Before Validate ["+$(this).val()+"]["+bv+"]["+op.beforeValidate[bv]+"]");
                if (op.beforeValidate[bv]) {
                    op.beforeValidate[bv]($(this));
                }
                checkvalid($(this));
            });
        } else if (op.validate == "verify") {
            txt_sel.each(function () {
                if (!checkvalid($(this))) {
                    //var fid = $(this).closest(".forms").data("form");
                    //$(".anav[data-form="+fid+"]").trigger("click");
                    return false;
                }
            });
            if (op.postValidate && error.valid) {
                //console.log("validating post validate");
                error.valid = op.postValidate($(this));
                //console.log("returning ["+error.valid+"]");
                //if (error.valid == undefined)error.valid = true;
            }
        } else if (op.validate == "execute") {
            $(".err").remove();
            txt_sel.each(function () {
                var e1 = $(this);
                if (e1.data("validatefor") == "radio") {
                    if (!getRadioVal(fm, e1[0].getAttribute("name"))) {
                        //alert("Error");
                        error.field = e1[0];
                        e1.prev(".err").remove();
                        if (error.field) { // if invalidate
                            //console.log("Error field is present!-["+el.prev(".err").length+"]");
                            error.errText = e1.data("errtext") ? e1.data("errtext") : "Invalid Field!";
                            if (e1.prev(".err").length == 0) {
                                $(error.field).before("<span class='err'>" + error.errText + "</span>");
                                //$(error.field).focus();
                                //console.log("Appended error ["+$(error.field).parent().html()+"]["+error.errText+"]");
                                //return false;
                            }
                            //error={};errreturn false;or.valid = false;
                            return false;
                        }
                    }
                }
                else if (!checkvalid(e1)) {
                    var fid = $(this).closest(".forms").data("form");
                    //console.log("Error valid before click ["+error.valid+"]["+fid+"]");
                    if (fid != 0)
                        $(".anav[data-form=" + fid + "]").trigger("click");
                    //console.log("Error valid before return["+error.valid+"]");
                    return false;
                }
            });

            //console.log("Error valid ["+error.valid+"]");
            if (op.postValidate && error.valid) {
                //console.log("Validating again?");
                error.valid = op.postValidate($(this));
                if (error.valid == undefined) error.valid = true;
            }
        }

        function checkvalid(e) {
            var el = e;
            if (el.val() == "" && el.data("mandatory") == "1") {
                //console.log("Failed ["+el.val()+"]");
                error.field = el[0];
            } else if (el.val() != "" && el.val() != undefined) {
                var validatefor = el.data("validatefor");
                //console.log("Validating ["+el.val()+"] with ["+validationRx[validatefor]+"]");
                if (!el.val().match(validationRx[validatefor])) {
                    error.field = el[0];
                }
                el.prev(".err").remove();
            } else if (el.val() == "") {
                //console.log("Nothing Failed ["+el.val()+"]");
                el.prev(".err").remove();
            }

            if (error.field) { // if invalidate
                //console.log("Error field is present!-["+el.prev(".err").length+"]");
                error.errText = el.data("errtext") ? el.data("errtext") : "Invalid Field!";
                if (el.prev(".err").length == 0) {
                    if (op.error_align == "bottom") {
                        $(error.field).after("<span class='err'>" + error.errText + "</span>");
                    } else {
                        $(error.field).before("<span class='err'>" + error.errText + "</span>");
                    }
                    $(error.field).focus();
                    //console.log("Appended error ["+$(error.field).parent().html()+"]["+error.errText+"]");
                }
                error = {}; error.valid = false;
                return false;
            } else {
                return true;
            }
        }
    });
    if (op.validate == "event") return this;
    else if (op.validate == "refresh") return this;
    else if (op.validate == "verify") return error.valid;
    else if (op.validate == "execute") return error.valid;


    function getRadioVal(form, name) {
        var val;
        // get list of radio buttons with specified name
        var inputFields = form.find("input").not(op.novalidate); // getting all form field except hidden fields and novalidate fields

        var radios = inputFields.filter(function () {
            //if($(this).is("[type=text],[type=email],[type=password],[type=number],select,textarea"))return true;
            if ($(this).is("[type=radio]")) return true;
            else return false;
        });

        var sel = false;
        // loop through list of radio buttons
        for (var i = 0, len = radios.length; i < len; i++) {
            if (radios[i].checked) { // radio checked?
                sel = true; // if so, hold its value in val
                break; // and break out of for loop
            }
        }
        //alert(sel);
        return sel; // return value of checked radio or undefined if none checked
    }
}