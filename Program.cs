using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using AulaClasses;

namespace Clientes;

class Program 
{
    static PessoaRepository _pessoaRepositorio  = new PessoaRepository();

    static void Main(string[] args)
    {
        var cultura = new CultureInfo("pt-BR");
        Thread.CurrentThread.CurrentCulture = cultura;
        Thread.CurrentThread.CurrentUICulture = cultura;

        _pessoaRepositorio.LerDadosClientes();

        while(true)
        {
            Menu();

            Console.ReadKey();
        }
    }

    static void Menu()
    {
       // Console.Clear();

        Console.WriteLine("Cadastro de Clientes");
        Console.WriteLine("--------------------");
        Console.WriteLine("1 - Cadastrar Cliente");
        Console.WriteLine("2 - Exibir Clientes");
        Console.WriteLine("3 - Editar Cliente");
        Console.WriteLine("4 - Excluir Cliente");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("--------------------");

        EscolherOpcao();
        Console.Write(Environment.NewLine);
    }

    
    static void EscolherOpcao()
    {
        Console.Write("Escolha uma opção: ");

        var opcao = Console.ReadLine();

        switch (int.Parse(opcao))
        {
            case 1:
                {
                    _pessoaRepositorio.CadastrarPessoa();
                    _pessoaRepositorio.GravarDadosPessoa();
                    Menu();
                    break;
                }
            case 2:
                {
                    _pessoaRepositorio.ExibirPessoas();
                    Menu();
                    break;
                }
            case 3:
                {
                    _pessoaRepositorio.EditarPessoa();
                    Menu();
                    break;
                }
            case 4:
                {
                    _pessoaRepositorio.ExcluirPessoa();
                    Menu();
                    break;
                }
            case 5:
                {
                    _pessoaRepositorio.GravarDadosPessoa();
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.Clear();
                    Console.WriteLine("Opção Inválida!"); 
                    break;
                }
        }
    }
}