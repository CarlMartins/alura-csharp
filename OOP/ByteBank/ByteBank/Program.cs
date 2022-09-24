using ByteBank;

Console.WriteLine("Boas vindas ao seu banco, ByteBank!");

var conta1 = new ContaCorrente("10123-X", 23, "Agência Central", 100.00, true);
var conta2 = new ContaCorrente("10123-X", 23, "Agência Central", 100.00, true);

Console.WriteLine(
    $"Conta: {conta1.Conta} - " +
    $"Numero Agência: {conta1.NumeroAgencia} - " +
    $"Nome Agência: {conta1.NomeAgencia} - " +
    $"Saldo: {conta1.Saldo}");

Console.WriteLine(
    $"Conta: {conta2.Conta} - " +
    $"Numero Agência: {conta2.NumeroAgencia} - " +
    $"Nome Agência: {conta2.NomeAgencia} - " +
    $"Saldo: {conta2.Saldo}");


Console.WriteLine($"Saldo Carlos pré-saque: {conta1.Saldo}");
conta1.Sacar(0);
Console.WriteLine($"Saldo Carlos pós-saque: {conta1.Saldo}");

Console.WriteLine($"Saldo Carlos pré-deposito: {conta1.Saldo}");
conta1.Depositar(0);
Console.WriteLine($"Saldo Carlos pós-deposito: {conta1.Saldo}");

Console.WriteLine($"Saldo pré-tranferência Carlos: {conta1.Saldo}");
Console.WriteLine($"Saldo pré-tranferência Vanessa: {conta2.Saldo}");

bool transferencia = conta1.Transferir(25, conta2);

Console.WriteLine($"Transferência realizada?: {transferencia}");
Console.WriteLine($"Saldo pós-tranferência Carlos: {conta1.Saldo}");
Console.WriteLine($"Saldo pós-tranferência Vanessa: {conta2.Saldo}");

Cliente cliente = new();
cliente.Nome = "Carlos Martins";
cliente.Cpf = "123.456.789.10";
cliente.Profissao = "Programador";

var conta3 = new ContaCorrente(cliente, "10123-X", 23, "Agência Central", 100.00, true);

Console.WriteLine($"Nome do cliente da conta3: {conta3.Cliente.Nome}");


Console.ReadKey();

