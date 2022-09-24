using ByteBank;

Console.WriteLine("Boas vindas ao seu banco, ByteBank!");

var conta1 = new ContaCorrente("Carlos Martins", "10123-X", 23, "Agência Central", 100.00);

Console.WriteLine(
    $"Titular: {conta1.Titular} - " +
    $"Conta: {conta1.Conta} - " +
    $"Numero Agência: {conta1.NumeroAgencia} - " +
    $"Nome Agência: {conta1.NomeAgencia} - " +
    $"Saldo: {conta1.Saldo}");


Console.ReadKey();