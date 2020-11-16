$(document).ready(function () {
    $("#consultar").on("click", filtrar);
    $("#fecha").val("");
});

function filtrar() {
    let txt = $("#fecha").val();
    $.ajax({
        type: "GET",
        url: `/Clientes/ordenes_Por_Fecha?fecha=${txt}`,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += `<tr>`;
                html += `<td>` + item.orderid + `</td>`;
                html += `<td>` + fechaFormateada(item.orderdate) + `</td>`;
                html += `<td>` + item.employeeid + `</td>`;
                html += `</tr>`;
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
};

let fechaFormateada = function (fecha) {
    return moment(fecha).format("DD/MM/YYYY")
}