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

    public void Sacar(double valor)
    {
        if (Saldo < valor || valor < 0)
        {
            return;
        }
        Saldo -= valor;
    }

    public void Depositar(double valor)
    {
        Saldo += valor;
    }

    public bool Transferir(double valor, ContaCorrente destino)
    {
        if (Saldo < valor || valor < 0)
        {
            return false;
        }

        Saldo -= valor;
        destino.Saldo += valor;

        return true;
    }
}