using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LojaDeEsporte.Presentation.WebApp.Models;

namespace LojaDeEsporte.Presentation.WebApp.Helpers
{
    public static class PaginacaoHelper
    {
        public static MvcHtmlString PaginasLinks(this HtmlHelper htmlHelper, InformacaoDePaginacao informacaoDePaginacao,
                                              Func<int, string> url)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= informacaoDePaginacao.TotalDePaginas; i++)
            {
                TagBuilder tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", url(i));
                tagBuilder.InnerHtml = i.ToString();

                if (i == informacaoDePaginacao.PaginaAtual)
                    tagBuilder.AddCssClass("selected");
                builder.Append(tagBuilder.ToString());
            }

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}