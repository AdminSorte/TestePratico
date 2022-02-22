
$('#agendamentoId').click(function () {
    $('#dialogAgendamento').showModal();
});


var showModal = function (idAgendamento) {
    $("#codigoAgend").val(idAgendamento);
    $('#dialogAgendamento').showModal();
};
