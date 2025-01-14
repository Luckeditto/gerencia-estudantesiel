
function exibirMensagemErro(mensagem, campo) {
    const spanErro = document.querySelector(`span[data-valmsg-for="${campo}"]`);
    if (spanErro) {
        spanErro.textContent = mensagem;
        spanErro.classList.remove("field-validation-valid");
        spanErro.classList.add("field-validation-error");
    }
}

function removerMensagemErro(campo) {
    const spanErro = document.querySelector(`span[data-valmsg-for="${campo}"]`);
    if (spanErro) {
        spanErro.textContent = "";
        spanErro.classList.remove("field-validation-error");
        spanErro.classList.add("field-validation-valid");
    }
}

$(document).ready(function () {
 
    $('#CPF').mask('000.000.000-00', { placeholder: "___.___.___-__" });

    $("#CPF").blur(async function () {
        const cpfFormatado = $(this).val().replace(/\D/g, '');
        await verificarCpfExistente(cpfFormatado);
    });

    $('form').submit(async function (event) {
        const cpfFormatado = $("#CPF").val().replace(/\D/g, '');
        const cpfValido = await verificarCpfExistente(cpfFormatado);

        if (!cpfValido) {
            event.preventDefault();
        }
    });

    $.validator.unobtrusive.parse("form");
});

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

let table = new DataTable('#table-estudantes', {

    "ordering": true,

    "paging": true,

    "searching": true,

    "oLanguage": {

        "sEmptyTable": "Nenhum registro encontrado na tabela",

        "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",

        "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",

        "sInfoFiltered": "(Filtrar de _MAX_ total registros)",

        "sInfoPostFix": "",

        "sInfoThousands": ".",

        "sLengthMenu": "Mostrar _MENU_ registros por página",

        "sLoadingRecords": "Carregando...",

        "sProcessing": "Processando...",

        "sZeroRecords": "Nenhum registro encontrado",

        "sSearch": "Pesquisar : ",

        "oPaginate": {

            "sNext": "Proximo",

            "sPrevious": "Anterior",

            "sFirst": "Primeiro",

            "sLast": "Último"

        },

        "oAria": {

            "sSortAscending": ": Ordenar colunas de forma ascendente",

            "sSortDescending": ": Ordenar colunas de forma descendente"

        }

    }



});