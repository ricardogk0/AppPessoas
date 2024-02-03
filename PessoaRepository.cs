using Microsoft.VisualBasic;

namespace AulaClasses
{
    public class PessoaRepository
    {
        public List<Pessoa> pessoas = new List<Pessoa>();
        public void CadastrarPessoa()
        {
            Console.Write("Nome: ");
            var nome = Console.ReadLine();

            Console.Write("CPF: ");
            var cpf = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            var pessoa = new Pessoa();
            pessoa.Id = pessoas.Count + 1;
            pessoa.Nome = nome;
            pessoa.Cpf = cpf;
            pessoa.Email = email;

            pessoas.Add(pessoa);
        
            Console.WriteLine("Cliente Cadastrado com sucesso! [Enter]");
            Console.WriteLine("--------------------");
            ImprimirPessoa(pessoa);
            Console.ReadKey();
        }

        public void ImprimirPessoa(Pessoa pessoa)
        {
            System.Console.WriteLine("ID:" + pessoa.Id);
            System.Console.WriteLine("Nome:" + pessoa.Nome);
            System.Console.WriteLine("CPF:" + pessoa.Cpf);
            System.Console.WriteLine("Email:" + pessoa.Email);
            Console.WriteLine("------------------------------------");
        }

        public void EditarPessoa()
        {
            System.Console.Write("Id pessoa: ");
            int id = int.Parse(Console.ReadLine());
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);

            if(pessoa == null)
            {
                Console.WriteLine("Cliente não encontrado! [Enter]");
                Console.ReadKey();
                return;
            }

            ImprimirPessoa(pessoa);

            System.Console.WriteLine("Qual dado deseja editar? ");
            string op = Console.ReadLine();

            switch (op)
            {
                case "CPF":
                {
                    Console.Write("Digite o CPF: ");
                    var cpf = Console.ReadLine();
                    pessoa.Cpf = cpf;
                    break;
                }

                case "Nome":
                {
                    Console.Write("Digite o Nome: ");
                    var nome = Console.ReadLine();
                    pessoa.Nome = nome;
                    break;
                }

                case "Email":
                {
                    Console.Write("Digite o Email: ");
                    var email = Console.ReadLine();
                    pessoa.Email = email;
                    break;
                }

                default:
                {
                    Console.Clear();
                    Console.WriteLine("Opção invalida");
                    break;
                }
            }
            
            Console.WriteLine("Cliente Editado com Sucesso!!");
            ImprimirPessoa(pessoa);
            Console.ReadKey();
        }

        public void ExibirPessoas()
        {
            Console.Write(Environment.NewLine);
            foreach(var listaPessoas in pessoas)
            {
                ImprimirPessoa(listaPessoas);
            }

            Console.ReadKey();
        }

        public void ExcluirPessoa()
        {
            System.Console.Write("Id pessoa: ");
            int id = int.Parse(Console.ReadLine());
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);

            if(pessoa == null)
            {
                Console.WriteLine("Cliente não encontrado! [Enter]");
                Console.ReadKey();
                return;
            }

            pessoas.Remove(pessoa);

            Console.WriteLine("Cliente removido com sucesso! [Enter]");

            Console.ReadKey();
        }

        public void GravarDadosPessoa()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(pessoas);
        
            File.WriteAllText("pessoas.txt", json);
        }

        public void LerDadosClientes()
        {
            if(File.Exists("pessoas.txt"))
            {
                var dados = File.ReadAllText("pessoas.txt");
                
                var pessoasArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Pessoa>>(dados);
                
                pessoas.AddRange(pessoasArquivo);
            }
        }
    }
}