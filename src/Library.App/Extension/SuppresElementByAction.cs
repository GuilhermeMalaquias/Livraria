﻿using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace Library.App.Extension
{
//Escondendo elemento de acordo com sua rota, evitando assim o usuario tem acesso ao botão de editar a partir da action detalhes.
    [HtmlTargetElement("*", Attributes = "supress-by-action")]
    public class SuppresElementByAction : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SuppresElementByAction(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("supress-by-action")]
        public string ActionName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(output));
           
            var action = _contextAccessor.HttpContext.GetRouteData().Values["action"].ToString();

            if (ActionName.Contains(action)) return;

            output.SuppressOutput();
        }
    }
}
