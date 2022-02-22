

//(function () {
//    var modal = document.getElementById('dialogAgendamento');
//    var botaoCancelar = document.getElementById('cancelarEdicao');

//    botaoCancelar.addEventListener('click', function () {
//        modal.close();
//    });

//})();

var login = function () {
    var usuario = $("#usuario").val();
    var senha = $("#senha").val();

    var parametros = {
        usuario,
        senha
    };

    var url = '/Login/logar';
    var post = $.post(url, parametros);

    post
        .done(() => {
            window.location.replace("/agenda/");
        })
        .fail((message) => {
            alert(message);
        });
};


//$('#agendamentoId').click(function () {
//    //$('#dialogAgendamento').dialog("open", "width", 560);
//    $('#dialogAgendamento').showModal();
//});

//$('#dialogAgendamento').dialog({
//    width: 600,
//    appendTo: "#agendaView",
//    autoOpen: false,
//    title: 'Agendamento',
//    open: function (event, ui) {
//        $(this).parent().children().children(".ui-dialog-titlebar-close").prop("title", "Fechar");
//        $(".ui-icon-closethick").hide();
//        $(".ui-button-text").hide();
//    }
//});