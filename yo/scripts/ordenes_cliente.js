$(document).ready(function () {
    listaClientes();
    $("#consultar").on("click", filtrar);
});  


function listaClientes() {
    $.ajax({
        type: "GET",
        url: "/Clientes/lista_Cliente",
        data: "{}",
        success: function (data) {
            var s = `<option value="-1">Seleccione un cliente</option>`;
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].customerid + '">' + data[i].companyname + '</option>';
            }
            $("#clientes").html(s);
        }
    });
}

function filtrar(codigo) {
    let txt = $("#clientes option:selected").val();
    $.ajax({
        type: "GET",
        url: `/Clientes/ordenes_Por_Cliente?codigo=${txt}`,
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
