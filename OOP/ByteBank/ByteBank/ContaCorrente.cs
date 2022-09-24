namespace ByteBank;

public class ContaCorrente
{
    public string Titular { get; set; }
    public string Conta { get; set; }
    public int NumeroAgencia { get; set; }
    public string NomeAgencia { get; set; }
    public double Saldo { get; set; }
    public bool Verificador { get; set; }

    public ContaCorrente(string titular, string conta, int numeroAgencia, string nomeAgencia, double saldo,
        bool verificador)
    {
        Titular = titular;
        Conta = conta;
        NumeroAgencia = numeroAgencia;
        NomeAgencia = nomeAgencia;
        Saldo = saldo;
        Verificador = verificador;
    }
}