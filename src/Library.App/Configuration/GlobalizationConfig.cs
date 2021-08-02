using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace Library.App.Configuration
{
    public static class GlobalizationConfig
    {
        public static IApplicationBuilder UseGlobalizationConfiguration(this IApplicationBuilder app)
        {
            /*
            * Organizando a aplica��o
             * Definindo uma cultura default que servir� de auxiliar para o corrigir o padr�o de Moeda(decimal)
            */
            var defaultCulture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> {defaultCulture},
                SupportedUICultures = new List<CultureInfo> {defaultCulture}
            };
            app.UseRequestLocalization(localizationOptions);
            return app;
        }
    }
}