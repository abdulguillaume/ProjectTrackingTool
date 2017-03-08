$(document).ready(function () {

    $("#contact-info-hidden").hide();

    $("input:checkbox").click(function () {
        var group = "input:checkbox[name='" + $(this).attr("name") + "']";
        $(group).prop("checked", false);
        $(this).prop("checked", true);
    });

    $("#add").click(function () {
        $('#contact-info-hidden tbody>tr:last').clone(true).insertAfter('#contact-info tbody>tr:last');
        return false;
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

            //tr.toggle();
 
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

        //tr_pos.parent
        return false;
    });

});


//https://www.codeproject.com/Articles/996400/WebGrid-Inline-Edit-and-Delete-of-data-in-ASP-NET