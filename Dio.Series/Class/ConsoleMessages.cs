using System;

namespace Dio.Series
{
    public abstract class ConsoleMessages
    {
        private static Serie RetornoSerie(int id){
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			
            //Tratamento de passagem correta de inteiro para Genêro
            int entradaGenero;
            Console.Write("Digite o gênero entre as opções acima: ");
			while (!(int.TryParse(Console.ReadLine(), out entradaGenero) && entradaGenero > 0 && entradaGenero <= 13)){
                Console.WriteLine("Genêro inválido, tente outro:");
            }

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

            //Tratamento de passagem correta de inteiro para Ano
			Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno;
			while (!(int.TryParse(Console.ReadLine(), out entradaAno) && entradaAno > 1900 && entradaAno < 2021)){
                Console.WriteLine("Ano inválido, tente outro:");
            }

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

            return (new Serie(id: id,
                            genero: (Genero)entradaGenero,
                            titulo: entradaTitulo,
                            ano: entradaAno,
                            descricao: entradaDescricao));
        }

        protected static void FimPrograma(){
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }
        protected static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    
        protected static void ListarSeries(SerieRepositorio repositorio)
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();
            
			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}
            
			foreach (var serie in lista)
			{
                var excluido = serie.RetornarExcluido();
				Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornarId(), serie.RetornarTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        protected static void InserirSerie(SerieRepositorio repositorio)
		{
			Console.WriteLine("Inserir nova série");

			repositorio.Insere(RetornoSerie(repositorio.ProximoId()));
		}
    
        protected static void AtualizarSerie(SerieRepositorio repositorio)
		{
            //Verificando se há indices
            if (repositorio.ProximoId() == 0)
            {
                Console.WriteLine("Não há series inseridas!");
                return;
            }

			Console.Write("Digite o id da série: ");
   
            //Tratamento de passagem correta de inteiro para Id
            int indiceSerie;
			while (!(int.TryParse(Console.ReadLine(), out indiceSerie) && indiceSerie > -1 && indiceSerie < repositorio.ProximoId())){
                Console.WriteLine("Id inválido, tente outro:");
            }

			Serie atualizaSerie = RetornoSerie(indiceSerie);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

        protected static void VisualizarSerie(SerieRepositorio repositorio)
		{
            //Verificando se há indices
            if (repositorio.ProximoId() == 0)
            {
                Console.WriteLine("Não há series inseridas!");
                return;
            }

			Console.Write("Digite o id da série: ");
   
            //Tratamento de passagem correta de inteiro para Id
            int indiceSerie;
			while (!(int.TryParse(Console.ReadLine(), out indiceSerie) && indiceSerie > -1 && indiceSerie < repositorio.ProximoId())){
                Console.WriteLine("Id inválido, tente outro:");
            }


			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}
        protected static void ErrorMessage(){
            Console.WriteLine("Opção inváldia, tente outra");
        }
        protected static void ExcluirSerie(SerieRepositorio repositorio)
		{
			//Verificando se há indices
            if (repositorio.ProximoId() == 0)
            {
                Console.WriteLine("Não há series inseridas!");
                return;
            }

			Console.Write("Digite o id da série: ");
   
            //Tratamento de passagem correta de inteiro para Id
            int indiceSerie;
			while (!(int.TryParse(Console.ReadLine(), out indiceSerie) && indiceSerie > -1 && indiceSerie < repositorio.ProximoId())){
                Console.WriteLine("Id inválido, tente outro:");
            }

			repositorio.Exclui(indiceSerie);
		}
    }
}