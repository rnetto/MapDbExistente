using Alura.Filmes.App.Extensions;
using MapDbExistente.Dados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MapDbExistente
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraContext())
            {
                Console.WriteLine("Operações? (s/n)");
                string check = Console.ReadLine();
                string h = null;

                while (check == "s" || check == "S")
                {
                    Console.WriteLine("Habilitar log SQL no Console?(s/n)");
                    h = Console.ReadLine();
                    if (h == "s" || h == "S")
                    {
                        contexto.LogSQLToConsole();
                    }

                    Console.WriteLine("<<< SELECT Simples para tabela de ATORES >>> (a)");
                    Console.WriteLine("<<< SELECT Simples para tabela de FILMES >>> (f)");
                    Console.WriteLine("<<< SELECT Simples para tabela de FILMES & ATOR (tabela de Relacionamento) >>>  (fa)");
                    Console.WriteLine("<<< SELECT Simples para tabela de FILMES incluindo os Atores do elenco >>> (fe)");
                    Console.WriteLine("<<< SELECT simples para tabela de IDIOMAS >>> (i)");
                    Console.WriteLine("<<< SELECT Tabela de IDIOMAS incluindo os FILMES para cada idioma Falado >>>  (ifala)");
                    Console.WriteLine("<<< SELECT Tabela de IDIOMAS incluindo os FILMES para cada idioma Original >>> (ioriginal)");
                    Console.WriteLine("<<< SELECT Tabela de Clientes >>> (c)");
                    Console.WriteLine("<<< SELECT Tabela de Funcionarios >>> (fc)");

                    Console.WriteLine("\nOpção: ");
                    string x = Console.ReadLine();


                   
                    // <<< SELECT Simples para tabela de ATORES >>> (a)
                    if (x == "a")
                    {
                        foreach (var ator in contexto.Atores)
                        {
                            Console.WriteLine(ator);
                        }
                    }

                    // <<< SELECT Simples para tabela de FILMES >>> (f)
                    if (x == "f")
                    {
                        foreach (var filme in contexto.Filmes)
                        {
                            Console.WriteLine(filme);
                        }
                    }

                    // <<< SELECT Simples para tabela de FILMES & ATOR (tabela de Relacionamento) >>>  (fa)
                    if (x == "fa")
                    {
                        foreach (var item in contexto.Elenco)
                        {
                            var entidade = contexto.Entry(item);
                            var filmid = entidade.Property("film_id").CurrentValue;
                            var actorid = entidade.Property("actor_id").CurrentValue;
                            var lastupd = entidade.Property("last_update").CurrentValue;

                            Console.WriteLine($"filme ({filmid}), ator ({actorid}), ultima modificação ({lastupd})");
                        }
                    }
                    // <<< SELECT Simples para tabela de FILMES incluindo os Atores do elenco >>> (fe)

                    if (x == "fe")
                    {
                        var filme = contexto.Filmes
                            .Include(f => f.Atores)
                            .ThenInclude(fa => fa.Ator)
                            .FirstOrDefault();

                        Console.WriteLine(filme);
                        Console.WriteLine("Elenco:");

                        foreach (var ator in filme.Atores)
                        {
                            Console.WriteLine(ator.Ator);
                        }
                    }

                    // <<< SELECT simples para tabela de IDIOMAS >>> (i)
                    if (x == "i")
                    {
                        foreach (var idioma in contexto.Idiomas)
                        {
                            Console.WriteLine(idioma);
                        }
                    }

                    //    <<< SELECT Tabela de IDIOMAS incluindo os FILMES para cada idioma Falado >>>  (ifala)
                    if (x == "ifala")
                    {
                        var idiomas = contexto.Idiomas
                           .Include(i => i.FilmesFalados);

                        foreach (var idioma in idiomas)
                        {
                            Console.WriteLine(idioma);

                            foreach (var filme in idioma.FilmesFalados)
                            {
                                Console.WriteLine(filme);
                            }
                            Console.WriteLine();
                        }
                    }

                    // <<< SELECT Tabela de IDIOMAS incluindo os FILMES para cada idioma Original >>> (ioriginal)
                    if (x == "ioriginal")
                    {
                        var idiomas = contexto.Idiomas
                            .Include(i => i.FilmesOriginais);

                        foreach (var idioma in idiomas)
                        {
                            Console.WriteLine(idioma);

                            foreach (var filme in idioma.FilmesOriginais)
                            {
                                Console.WriteLine(filme);
                            }
                            Console.WriteLine();
                        }
                    }

                    // <<< SELECT Tabela de Clientes >>> (c)
                    if (x == "c")
                    {
                        foreach (var cliente in contexto.Clientes)
                        {
                            Console.WriteLine(cliente);
                        }
                    }

                    //// <<< SELECT Tabela de Funcionarios >>> (f)
                    if (x == "fc")
                    {
                        foreach (var funcionario in contexto.Funcionarios)
                        {
                            Console.WriteLine(funcionario);
                        }
                    }

                    check = null;
                    Console.WriteLine("Deseja outra opção? (s/n)");
                    check = Console.ReadLine();
                }

            }
        }
    }
}
