
var showModal = function (agendamentoId, apenasLeitura = false) {
    $("#dialogAgendamento").load('/Agenda/Edit/' + agendamentoId + '/' + apenasLeitura);
    var modal = document.getElementById('dialogAgendamento');
    modal.showModal();
};


var deleteAgendamento = function (agendamentoId) {
    var url = '/Agenda/Remover/';

    var parametros = {
        agendamentoId
    };

    $.ajax({
        url: url,
        type: 'DELETE',
        data: parametros
    })
    .fail((ex) => {
        alert(ex.responseText);
    })
    .always(() => {
        location.reload();
    });
};

var buscarAgendamentos = function () {
    var texto = $("#textoBusca").val();
    var url = "/Agenda/Pesquisar";

    var parametros = {
        texto
    };

    $.ajax({
        url: url,
        type: 'GET',
        data: parametros
    })
    .done((view, x , y) => {
        $("#listagemAgendamentos").html(view);
    })
    .fail((ex) => {
        alert(ex.responseText);
    });
}