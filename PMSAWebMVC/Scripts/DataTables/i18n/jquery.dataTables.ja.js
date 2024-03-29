﻿$.extend(true, $.fn.dataTable.defaults, {
    responsive: true,
    fixedHeader: true,
    ordering: false,
    "errMode": 'throw',
    "language": {
        "emptyTable": "テーブルにデータがありません",
        "info": " _TOTAL_ 件中 _START_ から _END_ まで表示",
        "infoEmpty": " 0 件中 0 から 0 まで表示",
        "infoFiltered": "（全 _MAX_ 件より抽出）",
        "infoPostFix": "",
        "infoThousands": ",",
        "lengthMenu": "_MENU_ 件表示",
        "loadingRecords": "読み込み中...",
        "processing": "処理中...",
        "search": "検索:",
        "zeroRecords": "一致するレコードがありません",
        "paginate": {
            "first": "先頭",
            "last": "最終",
            "next": "次",
            "previous": "前"
        },
        "aria": {
            "sortAscending": ": 列を昇順に並べ替えるにはアクティブにする",
            "sortDescending": ": 列を降順に並べ替えるにはアクティブにする"
        }
    }
});
function resizeDatatable() {
    $($.fn.dataTable.tables(true)).DataTable().columns.adjust().responsive.recalc().draw();
}