// See https://aka.ms/new-console-template for more information

using DIO.Animes;

int idAnime = 0;
    AnimeRepositorio repositorio = new AnimeRepositorio();
    
    string opcaoUsuario = ObterOpcaoUsuario();
    
    while (opcaoUsuario.ToUpper() != "X")
    {
        switch (opcaoUsuario)
        {
            case "1":
                ListarAnimes();
                break; 

            case "2":
                InserirAnime();
                break;
            
            case "3":
                AtualizarAnime();
                break;
            
            case "4":
                ExcluirAnime();
                break;
            
            case "5":
                VisualizarAnime();
                break;
            
            case "C": 
                Console.Clear();
                break;

            default:
                throw new ArgumentOutOfRangeException();
                break;       
        }   

        opcaoUsuario = ObterOpcaoUsuario();
    }

    void ListarAnimes()
    {
        System.Console.WriteLine("Listar animes");

        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            System.Console.WriteLine("Nenhum anime cadastrado");
            return;
        }
        foreach (var anime in lista)
        {
            var excluido = anime.retornaExcluido(); 
            if (!excluido)
            {
                System.Console.WriteLine("#ID {0}: - {1}", anime.retornaId(), anime.retornaTitulo());
            }            
        }
    }

    void InserirAnime()
    {
        System.Console.Clear();
        System.Console.WriteLine("Inserir anime");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }
        
        System.Console.WriteLine("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o título do anime: ");
        string entradaTitulo = System.Console.ReadLine();

        System.Console.WriteLine("Digite o ano de lançamento do anime:");
        int entradaAno = int.Parse(System.Console.ReadLine());

        System.Console.WriteLine("Digite a descrição do anime: ");
        string entradaDescricao = System.Console.ReadLine();

        Anime novoAnime = new Anime(id: idAnime,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
        repositorio.Insere(novoAnime);
        idAnime++;
    }

    void AtualizarAnime()
    {
        System.Console.Clear();
        System.Console.WriteLine("Digite o id do anime que deseja atualizar:");
        int idAnimeAtualizar = int.Parse(System.Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        } 

        System.Console.WriteLine("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o título do anime: ");
        string entradaTitulo = System.Console.ReadLine();

        System.Console.WriteLine("Digite o ano de lançamento do anime:");
        int entradaAno = int.Parse(System.Console.ReadLine());

        System.Console.WriteLine("Digite a descrição do anime: ");
        string entradaDescricao = System.Console.ReadLine(); 

        Anime atualizaAnime = new Anime(id: idAnimeAtualizar,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
        
        repositorio.Atualiza(idAnimeAtualizar, atualizaAnime);
    }    

    void ExcluirAnime()
    {
        System.Console.WriteLine("Digite o id do anime que deseja excluir:");
        int idAnimeExclui = int.Parse(System.Console.ReadLine());

        repositorio.Exclui(idAnimeExclui);    
    }

    void VisualizarAnime()
    {
        System.Console.WriteLine("Digite o id do anime que deseja visualizar:");
        int idAnimeVisualiza = int.Parse(System.Console.ReadLine());

        var anime = repositorio.RetornaPorId(idAnimeVisualiza);

        System.Console.WriteLine(anime);
    }                    

    static string ObterOpcaoUsuario()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("DIO ANIMES");
        System.Console.WriteLine("Informe a opção desejada:");

        System.Console.WriteLine("1 - Listar animes");
        System.Console.WriteLine("2 - Inserir novo anime");
        System.Console.WriteLine("3 - Atualizar anime existente");  
        System.Console.WriteLine("4 - Excluir anime");
        System.Console.WriteLine("5 - Visualizar anime");
        System.Console.WriteLine("C - Limpar Tela");
        System.Console.WriteLine("X - Sair");  

        string opcaoUsuario = Console.ReadLine().ToUpper();
        System.Console.WriteLine();
        return opcaoUsuario;
    } 

