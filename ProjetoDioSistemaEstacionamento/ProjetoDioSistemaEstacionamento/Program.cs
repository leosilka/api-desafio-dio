using ProjetoDioSistemaEstacionamento.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");
Console.Write("Digite o preço inicial: R$");

precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.Write("Agora digite o preço por hora: R$");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

//Criar a instancia da classe estacionamento aqui
Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            estacionamento.AdicionarVeiculo();
            break;

        case "2":
            estacionamento.RemoverVeiculo();
            break;

        case "3":
            estacionamento.Listarveiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opcao Invalida!");
            break;
    }
    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa foi encerrado!");