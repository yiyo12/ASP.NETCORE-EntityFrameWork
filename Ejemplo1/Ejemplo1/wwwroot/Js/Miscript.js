function confirmarBorrar(id,seHizoClick)
{
    var confirmBorrar = 'BorrarSpan_' + id
    var confirmBorrarSpan = 'confirmBorrarSpan_' + id

    if (seHizoClick) {
        $('#' + confirmBorrar).hide();
        $('#' + confirmBorrarSpan).show();
    } else {
        $('#' + confirmBorrar).show();
        $('#' + confirmBorrarSpan).hide();
    }
}