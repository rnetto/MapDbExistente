using MapDbExistente.Negocio;
using System.Collections.Generic;
using System.Linq;

namespace MapDbExistente.Extentions
{
    public static class ClassificacaoIndicativaExtensions
    {
        private static Dictionary<string, ClassificacaoIndicativa> dicionario = new Dictionary<string, ClassificacaoIndicativa>
        {
            {"G", ClassificacaoIndicativa.Livre },
            {"PG", ClassificacaoIndicativa.MaioresQue10 },
            {"PG-13", ClassificacaoIndicativa.MaioresQue13 },
            {"R", ClassificacaoIndicativa.MaioresQue14 },
            {"NC-17", ClassificacaoIndicativa.MaioresQue18 }
        };
        public static string ParaString(this ClassificacaoIndicativa classificacao)
        {
            return dicionario.First(d => d.Value == classificacao).Key; 
        }
        public static ClassificacaoIndicativa ParaEnum(this string paraEnum)
        {
            return dicionario.First(d => d.Key == paraEnum).Value;
        }
    }
}
