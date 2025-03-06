ContaBancaria conta = new ContaBancaria("12345", "João Silva", 1000.00);
Console.WriteLine("Bem-vindo ao Banco Simulação!");
Console.WriteLine($"Conta: {conta.NumeroConta}, Titular: {conta.Titular}, Saldo Inicial: {conta.Saldo:C}");
while (true)
{
    Console.WriteLine("\nEscolha uma operação:");
    Console.WriteLine("1. Depositar");
    Console.WriteLine("2. Sacar");
    Console.WriteLine("3. Consultar Saldo");
    Console.WriteLine("4. Consultar Histórico de Transações");
    Console.WriteLine("5. Sair");
    Console.Write("Opção: ");
    string? opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
            Console.Write("Digite o valor para depósito: ");
            double valorDeposito = Convert.ToDouble(Console.ReadLine());
            conta.Depositar(valorDeposito);
            break;
        case "2":
            Console.Write("Digite o valor para saque: ");
            double valorSaque = Convert.ToDouble(Console.ReadLine());
            conta.Sacar(valorSaque);
            break;
        case "3":
            Console.WriteLine($"Saldo atual: {conta.Saldo:C}");
            break;
        case "4":
            conta.ExibirHistoricoTransacoes();
            break;
        case "5":
            Console.WriteLine("Obrigado por usar o Banco Simulação. Até logo!");
            return;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}
class ContaBancaria
{
public string NumeroConta { get; private set; }
public string Titular { get; private set; }
public double Saldo { get; private set; }
private List<string> HistoricoTransacoes;
public ContaBancaria(string numeroConta, string titular, double saldoInicial)
{
NumeroConta = numeroConta;
Titular = titular;
Saldo = saldoInicial;
HistoricoTransacoes = new List<string>
{
    $"Conta criada com saldo inicial de {saldoInicial:C}"
};
}
public void Depositar(double valor)
{
if (valor > 0)
{
    Saldo += valor;
    HistoricoTransacoes.Add($"Depósito de {valor:C} realizado. Saldo atual: {Saldo:C}");
    Console.WriteLine($"Depósito de {valor:C} realizado com sucesso.");
}
else
{
    Console.WriteLine("Valor de depósito inválido.");
}
}
public void Sacar(double valor)
{
if (valor > 0 && valor <= Saldo)
{
    Saldo -= valor;
    HistoricoTransacoes.Add($"Saque de {valor:C} realizado. Saldo atual: {Saldo:C}");
    Console.WriteLine($"Saque de {valor:C} realizado com sucesso.");
}
else
{
    Console.WriteLine("Valor de saque inválido ou saldo insuficiente.");
}
}
public void ExibirHistoricoTransacoes()
{
Console.WriteLine("Histórico de Transações:");
foreach (var transacao in HistoricoTransacoes)
{
    Console.WriteLine(transacao);
}
}
}