$(document).ready(function () {


    $(".datepicker").datepicker({
        showOtherMonths: true,
        selectOtherMonths: true
    }).attr('readonly', 'readonly');;

    $("#contact-info-hidden").hide();

    $("input:checkbox").click(function () {
        var group = "input:checkbox[name='" + $(this).attr("name") + "']";
        $(group).prop("checked", false);
        $(this).prop("checked", true);
    });

    //$("#add").click(function () {
    //    $('#contact-info-hidden tbody>tr:last').clone(true).insertAfter('#contact-info tbody>tr:last');
    //    return false;
    //});

    $("#add").click(function (e) {
        e.preventDefault();
       // var tmp0 = $("#contact-info > tbody > tr");
        //alert(tmp0.length);
        var index = $("#contact-info tbody>tr:last").index();

        var last = $('#contact-info-hidden tbody>tr:last').clone(true).insertAfter('#contact-info tbody>tr:last');
       
        var selectList = last.find("select");
        selectList.attr("id", "Contact_Info_"+index+"__type.Contact_Type_Id"); 
        selectList.attr("name", "Contact_Info[" + index + "].type.Contact_Type_Id");

        var valSelectField = last.find("span.span_1");
        valSelectField.attr("data-valmsg-for", "Contact_Info[" + index + "].type.Contact_Type_Id"); //ok
        //valSelectField.append("<span for='Contact_Info_" + index + "__.detail' class='span_2'>**</span>")

        //valSelectField.find("span.span_2").hide();

        var inputField = last.find("input");
        //inputField.addClass("abdul-input");
        inputField.attr("id", "Contact_Info_" + index + "__detail");  //id="Contact_Info_0__Contact_Info_Id" name="Contact_Info[0].Contact_Info_Id"
        inputField.attr("name", "Contact_Info[" + index + "].detail");

        var valInputField = last.find("span.span_3");
        valInputField.attr("data-valmsg-for", "Contact_Info[" + index + "].detail");
        //valInputField.append("<span for='Contact_Info_" + index + "__.detail' class='span_4'>Field is required.</span>")

        //$("#Contact_Info_" + index + "__detail").validate();

        $.validator.unobtrusive.parseDynamicContent("#customer_form");

        //$("customer_form").removeData("validator");
        //$("customer_form").removeData("unobtrusiveValidation");
        //$.validator.unobtrusive.parse("customer_form");
        
        //valInputField.find("span.span_4").hide();

        //return false;
    });

    $(".rem").click(function () {
        $(this).closest("tr").remove();
        return false;
    });

    $(".del_customer").click(function () {
        
        var tr = $(this).parents('tr:first');
        var id = $(this).prop('id');
        
        var msg = "Are you sure you want to delete the below customer? \n\nCustomer Name: "
            + tr.find("td:eq(0)").html() + "\nCustomer Type: "
            + tr.find("td:eq(1)").html() + "\nContact Name: "
            + tr.find("td:eq(2)").html() + "\nContact Info: "
            + tr.find("td:eq(3)").text();

        var response = confirm(msg);

        if (response == true)
        {
            $.ajax({
                type: "POST",
                //contentType: "application/json; charset=utf-8",
                url: "/Customer/Delete/",
                data: {"id": id},
                //data: JSON.stringify({ "id": id, "gender": gender, "phone": phone }),
                dataType: "json",
                success: function (data) {
                    tr.toggle();
                },
                error: function (err) {
                    alert("error");
                }
            });
        }


        return false;
    });

});


//https://www.codeproject.com/Articles/996400/WebGrid-Inline-Edit-and-Delete-of-data-in-ASP-NET
// <span class="field-validation-valid text-danger" data-valmsg-for="Contact_Info[1].detail" data-valmsg-replace="true"></span>
