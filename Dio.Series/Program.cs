using System;

namespace Dio.Series
{
    class Program : ConsoleMessages
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries(repositorio);
						break;
					case "2":
						InserirSerie(repositorio);
						break;
					case "3":
						AtualizarSerie(repositorio);
						break;
					case "4":
						ExcluirSerie(repositorio);
						break;
					case "5":
						VisualizarSerie(repositorio);
						break;
					case "C":
						Console.Clear();
						break;

					default:
						try {
                            throw new ArgumentOutOfRangeException();
                        }catch(ArgumentOutOfRangeException){
                            ErrorMessage();
                        }
                        break;
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			FimPrograma();
        }

        
    }
}
