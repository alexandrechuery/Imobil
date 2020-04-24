using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImobilidadeFinal.Helpers
{
    public static class HelperImages
    {
        public static MvcHtmlString Carrossel (this HtmlHelper hp)
        {
            string str = "<div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\" style=\"width:80%\">" +
"    <!-- Indicators -->" +
"    <ol class=\"carousel-indicators\">" +
"        <li data-target=\"#myCarousel\" data-slide-to=\"0\" class=\"active\"></li>" +
"        <li data-target=\"#myCarousel\" data-slide-to=\"1\"></li>" +
"        <li data-target=\"#myCarousel\" data-slide-to=\"2\"></li>" +
"        <li data-target=\"#myCarousel\" data-slide-to=\"3\"></li>" +
"    </ol>" +
"" +
"    <!-- Wrapper for slides -->" +
"    <div class=\"carousel-inner\">" +
"" +
"        <div class=\"item active\">" +
"            <div class=\"carousel-caption\">" +
"                <h2>Veja os imóveis disponíveis</h2>" +
"                <p><a class=\"btn btn-default\" href=\"/Imovel/Index/\">Clique aqui para ver os imóveis »</a></p>" +
"            </div>" +
"            <img src=\"/Images/carrossel1.png\" class=\"imgcarrossel\" style=\"width:100%;\">" +
"        </div>" +
"" +
"        <div class=\"item\">" +
"            <div class=\"carousel-caption\">" +
"                <h2>Faça aqui o seu negócio!</h2>" +
"                <p><a class=\"btn btn-default\" href=\"/Negocio/Index\">Clique aqui para fazer o seu negócio »</a></p>" +
"            </div>" +
"            <img src=\"/Images/carrossel2.jpg\" class=\"imgcarrossel\" title=\"Cadastre aqui seu imóvel\" style=\"width:100%;\">" +
"        </div>" +
"" +
"        <div class=\"item\">" +
"            <div class=\"carousel-caption\">" +
"                <h2>Cadastre aqui o seu imóvel!</h2>" +
"                <p> Na IMOBILI, você tem o controle. A apenas um botão, você poderá cadastrar um Tipo de Negócio que atribua as suas demandas.</p>" +
"            </div>" +
"            <a href=\"/TipoNegocio/Index\"><img src=\"/Images/carrossel3.png\" class=\"imgcarrossel\" style=\"width:100%\" ;></a>" +
"        </div>" +
"" +
"        <div class=\"item\">" +
"            <div class=\"carousel-caption\">" +
"                <h2>Proprietário, cadastre-se aqui!</h2>" +
"                <p><a class=\"btn btn-default\" href=\"/Proprietario/Inserir\">Clique aqui para se cadastrar »</a></p>" +
"            </div>" +
"            <img src=\"/Images/carrossel4.jpg\" class=\"imgcarrossel\" style=\"width:100%\";>" +
"        </div>" +
"    </div>" +
"" +
"    <!-- Left and right controls -->" +
"    <a class=\"left carousel-control\" href=\"#myCarousel\" data-slide=\"prev\">" +
"        <span class=\"glyphicon glyphicon-chevron-left\"></span>" +
"        <span class=\"sr-only\">Previous</span>" +
"    </a>" +
"    <a class=\"right carousel-control\" href=\"#myCarousel\" data-slide=\"next\">" +
"        <span class=\"glyphicon glyphicon-chevron-right\"></span>" +
"        <span class=\"sr-only\">Next</span>" +
"    </a>" +
"</div>";

            return new MvcHtmlString(str);
        }
    }
}