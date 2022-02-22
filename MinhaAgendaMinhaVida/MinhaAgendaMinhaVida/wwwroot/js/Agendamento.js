var fecharModal = function () {
    var modal = document.getElementById('dialogAgendamento');
    modal.close();
};

var salvar = function () {
    var id = $('#AgendamentoId').val();
    var usuarioId = $('#UsuarioId').val();
    var data = $('#Data').val();
    var descricao = $('#Descricao').val();

    var parametros = {
        id,
        usuarioId,
        data,
        descricao
    };

    if (id > 0)
    {
        var url = '/Agenda/Atualizar/';

        $.ajax({
            url: url,
            type: 'PUT',
            data: parametros
        })
        .fail((ex) => {
            alert(ex.responseText);
        })
        .done(() => {
            fecharModal();
            location.reload();
        });
    }
    else
    {
        var url = '/Agenda/Salvar/';
        var post = $.post(url, parametros);

        post
            .fail((ex) => {
                alert(ex.responseText);
            })
            .done(() => {
                fecharModal();
                location.reload();
            });
    }
};

$(document).ready(function () {
    $("#dataAgendamento").datepicker({ dateFormat: 'dd/MM/yyyy' });
});