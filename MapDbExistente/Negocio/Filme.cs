using MapDbExistente.Extentions;
using System.Collections.Generic;

namespace MapDbExistente.Negocio
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string AnoLancamento { get; set; }
        public short Duracao { get; set; }
        public IList<FilmeAtor> Atores { get; set; }
        public Idioma IdiomaOriginal { get; set; }
        public Idioma IdiomaFalado { get; set; }
        public string Classificacao { get; set; }
        public ClassificacaoIndicativa ClassificacaoIndicativa
        {
            get { return Classificacao.ParaEnum(); }
            set { Classificacao = value.ParaString(); }
        }

        public Filme()
        {
            Atores = new List<FilmeAtor>();
        }
        public override string ToString()
        {
            return $"Filme ({Id}): {Titulo}, {AnoLancamento}, {Duracao}";
        }
    }
}
