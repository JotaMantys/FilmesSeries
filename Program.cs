using System;
using System.Linq;
using CadastroSeries.Classes;
using CadastroSeries.Enum;


namespace CadastroSeries
{
    class Program
    {

        static serieRepositorio Repo = new serieRepositorio();
        static filmeRepositorio RepoFilme = new filmeRepositorio();
        static void Main(string[] args)
        {
            bool filme = opFilme();
            string opcaoSelecionada = ObterOpcaoUsuario(filme);

            while (opcaoSelecionada != "X")
            {
                 switch (opcaoSelecionada)
                 {
                     case "1":
                        ListarSeries(filme);
                        break;
                    case "2":
                        inserirSerie(filme);
                        break;
                    case "3":
                        atualizarSerie(filme);
                        break;
                    case "4":
                        excluirSerie(filme);
                        break;
                    case "5":
                        VisualizarSerie(filme);
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;



                     default:
                        throw new ArgumentOutOfRangeException("Selecione uma das opções");
                     
                 }
                 filme = opFilme();
                 opcaoSelecionada = ObterOpcaoUsuario(filme);
            }
        }

        private static bool opFilme(){
            Console.WriteLine("Deseja acessar cadastro de filmes ? S / N");
            return Console.ReadLine().ToUpper() == "S" ? true : false;
        }
        private static string ObterOpcaoUsuario (bool filme){
            
            string tipo = filme ? "Filme" : "Serie";
            Console.WriteLine($@"
                                    Cadastro de {tipo}
                                Informe a opção desejada:");

            Console.WriteLine($@"
                                1- Listar {tipo}
                                2- Inserir {tipo}
                                3- Atualizar {tipo}
                                4- Excluir {tipo}
                                5- Visualizar {tipo}
                                C- Limpar Tela
                                X- Sair"); 

            return   Console.ReadLine().ToUpper();
        }

        private static void ListarSeries(bool filme){
            string tipo = filme ? "Filme" : "Serie";
            
            Console.WriteLine($"Lista de {tipo}");

            if (!filme)
            {
                 var lista =  Repo.Lista();

                 var excluidos = from se in lista where (se.retornaExcluido()==true) select se;
                var cadastrados =  from se in lista where (se.retornaExcluido() == false) select se;

                 
                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma Serie Cadastrada");
                    return;
                }
                

                foreach (var serie in cadastrados)
                {
                    Console.WriteLine($"#ID {serie.retornaID()} - {serie.retornaTitulo()}");
                }

                
                if (excluidos.Count()>0)
                {
                    Console.WriteLine("Excluidos");
                    foreach (var serie in excluidos)
                        {
                            Console.WriteLine($"#ID {serie.retornaID()} - {serie.retornaTitulo()}");
                        }
                    
                } 
            }
            else
            {
                var lista = RepoFilme.Lista();

                 var excluidos = from se in lista where (se.retornaExcluido()==true) select se;
                 var cadastrados =  from se in lista where (se.retornaExcluido() == false) select se;

                  
                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma Serie Cadastrada");
                    return;
                }
                

                foreach (var serie in cadastrados)
                {
                    Console.WriteLine($"#ID {serie.retornaId()} - {serie.retornaTitulo()}");
                }

                
                if (excluidos.Count()>0)
                {
                    Console.WriteLine("Excluidos");
                    foreach (var serie in excluidos)
                        {
                            Console.WriteLine($"#ID {serie.retornaId()} - {serie.retornaTitulo()}");
                        }
                    
                } 
            }

            
            

           
            

        }

        private static void inserirSerie(bool filme){

            string tipo = filme ? "Filme" : "Serie";
            Console.WriteLine($"Nov{(filme ? "o" : "a")} {tipo}");

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($" {i} - {System.Enum.GetName(typeof(Genero),i)}");
            }
        
        
            Console.WriteLine("Selecione um dos generos acima");

            int.TryParse(Console.ReadLine(), out int novoGenero );

            if (! filme)
            {
            
                Console.WriteLine("Digite o nome da Serie");

                string novoTitulo = Console.ReadLine();


                Console.WriteLine("digite o ano da serie");

                int.TryParse( Console.ReadLine() , out int novoAno);


                Console.WriteLine("digite a descrição da serie");

                string novaDescricao = Console.ReadLine();

            serie novaSerie = new serie(  id: Repo.ProximoId()
                                        , genero: (Genero)novoGenero 
                                        , titulo: novoTitulo
                                        , descricao: novaDescricao
                                        , ano:novoAno  );

            Repo.Insere(novaSerie);
            }
            else
            {
                Console.WriteLine("Digite o nome do Filme");

                string novoTitulo = Console.ReadLine();


                Console.WriteLine("digite o ano do Filme");

                int.TryParse( Console.ReadLine() , out int novoAno);


                Console.WriteLine("digite a descrição do Filme");

                string novaDescricao = Console.ReadLine();

                Console.WriteLine("digite anota do Filme");

                int.TryParse( Console.ReadLine() , out int novaNota);

            Filme novaSerie = new Filme(  id: RepoFilme.ProximoId()
                                        , genero: (Genero)novoGenero 
                                        , titulo: novoTitulo
                                        , descricao: novaDescricao
                                        , ano:novoAno
                                        , nota: novaNota  );

            RepoFilme.Insere(novaSerie);
            }
        }

        private static void atualizarSerie(bool filme){

            string tipo = filme ? "Filme" : "Serie";
            Console.WriteLine($"atualizar {tipo}");

            
            Console.WriteLine($"Digite o id d{(filme ? "o" : "a")} {tipo} para Alterar");

            int.TryParse(Console.ReadLine(), out int idAltera);

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($" {i} - {System.Enum.GetName(typeof(Genero),i)}");
            }
        
        
            Console.WriteLine("Selecione um dos generos acima");

            int.TryParse(Console.ReadLine(), out int alteraGenero );

            if (! filme)
            {
                Console.WriteLine("Digite o nome da Serie");

                string alteraTitulo = Console.ReadLine();


                Console.WriteLine("digite o ano da serie");

                int.TryParse( Console.ReadLine() , out int alteraAno);


                Console.WriteLine("digite a descrição da serie");

                string alteraDescricao = Console.ReadLine();

                serie alterarSerie = new serie(   id: idAltera 
                                                , genero: (Genero)alteraGenero
                                                , titulo: alteraTitulo
                                                , descricao:alteraDescricao
                                                , ano:alteraAno);

                Repo.atualiza(idAltera,alterarSerie);    
            }
            else
            {
                Console.WriteLine("Digite o nome do filme");

                string alteraTitulo = Console.ReadLine();


                Console.WriteLine("digite o ano do filme");

                int.TryParse( Console.ReadLine() , out int alteraAno);


                Console.WriteLine("digite a descrição do filme");

                string alteraDescricao = Console.ReadLine();

                Console.WriteLine("digite anota do Filme");

                int.TryParse( Console.ReadLine() , out int alteraNota);



                Filme alterarSerie = new Filme(   id: idAltera 
                                                , genero: (Genero)alteraGenero
                                                , titulo: alteraTitulo
                                                , descricao:alteraDescricao
                                                , ano:alteraAno
                                                , nota: alteraNota );

                RepoFilme.atualiza(idAltera,alterarSerie);
            }

            

        }

        private static void excluirSerie(bool filme){

            string tipo = filme ? "Filme" : "Serie";

            Console.WriteLine($"Excluir {tipo}");

            Console.WriteLine($"Digite o id d{(filme ? "o" : "a")} {tipo} para Excluir");

            int.TryParse(Console.ReadLine(), out int idExcluir);

            if (! filme)
            {
                Repo.Exclui(idExcluir);    
            }
            else
            {
                RepoFilme.Exclui(idExcluir);
            }

        }

        private  static void VisualizarSerie(bool filme)
        {
            string tipo = filme ? "Filme" : "Serie";

            Console.WriteLine($"Visualizar {tipo}");

            Console.WriteLine($"Digite o id d{(filme ? "o" : "a")} {tipo} para Visualizar");

            int.TryParse(Console.ReadLine(), out int idVisualizar);

            if (! filme)
            {
                serie visualizar  = Repo.RetornaPorId( idVisualizar);
                Console.WriteLine(visualizar.ToString());                
            }
            else
            {
                Filme visualizar = RepoFilme.RetornaPorId(idVisualizar);
                Console.WriteLine(visualizar.ToString());                
            }



        }

    }
}
