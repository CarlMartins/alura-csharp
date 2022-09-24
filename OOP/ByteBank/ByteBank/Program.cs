using ByteBank;

Console.WriteLine("Boas vindas ao seu banco, ByteBank!");

var conta1 = new ContaCorrente("Carlos Martins", "10123-X", 23, "Agência Central", 100.00, true);
var conta2 = new ContaCorrente("Carlos Martins", "10123-X", 23, "Agência Central", 100.00, true);

Console.WriteLine(
    $"Titular: {conta1.Titular} - " +
    $"Conta: {conta1.Conta} - " +
    $"Numero Agência: {conta1.NumeroAgencia} - " +
    $"Nome Agência: {conta1.NomeAgencia} - " +
    $"Saldo: {conta1.Saldo}");

Console.WriteLine(
    $"Titular: {conta2.Titular} - " +
    $"Conta: {conta2.Conta} - " +
    $"Numero Agência: {conta2.NumeroAgencia} - " +
    $"Nome Agência: {conta2.NomeAgencia} - " +
    $"Saldo: {conta2.Saldo}");


Console.WriteLine(Equals(conta1, conta2));

Console.ReadKey();