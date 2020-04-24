$(document).ready(function () {
    $("#status").hide();
    $("#botao-entrar").click(function () {
        $.ajax({
            url: "/Autenticacao/AutenticarUsuario",
            data: { login: $("#txtLogin").val(), senha: $("#txtSenha").val() },
            dataType: "json",
            type: "POST",
            async: true,
            beforeSend: function () {
                $("#status").html("Autenticando usuário...");
                $("#status").show();
            },
            success: function (dados) {
                if (dados.OK) {
                    $("#status").html(dados.Mensagem);
                    setTimeout(function () { window.location.href = "/Home" }, 2000);
                    $("#status").show();
                } else {
                    $("#status").html(dados.Mensagem);
                    $("#status").show();
                }
            },
            error: function (dados) {
                $("#status").html("Erro na autenticação.");
                $("#status").show();
            }
        });
    });

    $("#botao-sair").click(function () {
        $.ajax({
            url: "/Autenticacao/DesautenticarUsuario",
            dataType: "json",
            type: "POST",
            async: true,
            success: function (dados) {
                if (dados.OK)
                    window.location.href = "/Home";
            }
        });
    });

    $.ajax({
        url: "/Autenticacao/VerificarAutenticacao",
        dataType: "json",
        type: "POST",
        async: true,
        success: function (dados) {
            if (dados.OK) 
                $("#botao-sair").show();
                
             else 
                $("#botao-sair").hide();         
               
        }
    });
});