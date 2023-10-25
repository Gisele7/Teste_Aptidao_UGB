function MensagemOK(mensagem) {
    Swal.fire(
        'Sucesso!',
        mensagem,
        'success'
    )
}

function MensagemErro(mensagemErro) {
    Swal.fire({
        icon: 'error',
        title: 'Erro',
        text: mensagemErro,
    })
}

function ConfiguraDataTable(tabela) {
    $(`#${tabela}`).DataTable({
        fixedHeader: true,
        "scrollY": "600px",
        "scrollCollapse": true,
        "pageLength": 10,
        "bLengthChange": false,
        "bFilter": true,
        "order": [],
        language: {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ Resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
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

}