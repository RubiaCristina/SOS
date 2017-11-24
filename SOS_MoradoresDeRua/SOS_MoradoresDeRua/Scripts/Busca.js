$("#botaoPesquisar").click(function () { BuscaMorador() });
function BuscaMorador()
{
    var Pesquisa = encodeURI($("#BuscarMorador").val());
    $("#NomeMorador").load("/Master/PesquisaMorador?s=" + Pesquisa)
}

$("#botaoPesquisar").click(function () { BuscaUsuario() });
function BuscaUsuario() {
    var Pesquisa = encodeURI($("#BuscarUsuario").val());
    $("#NomeUsuario").load("/Master/PesquisaUsuario?s=" + Pesquisa)
}

$("#botaoPesquisar").click(function () { BuscaDesaparecido() });
function BuscaDesaparecido() {
    var Pesquisa = encodeURI($("#BuscarDesaparecido").val());
    $("#NomeDesaparecido").load("/Master/PesquisaDesaparecido?s=" + Pesquisa)
}