namespace ByteBank;

public class ContaCorrente
{
    public string Conta { get; set; }
    public int NumeroAgencia { get; set; }
    public string NomeAgencia { get; set; }
    public double Saldo { get; set; }
    public bool Verificador { get; set; }
    public Cliente Cliente { get; set; }

    public ContaCorrente(string conta, int numeroAgencia, string nomeAgencia, double saldo,
        bool verificador)
    {
        Conta = conta;
        NumeroAgencia = numeroAgencia;
        NomeAgencia = nomeAgencia;
        Saldo = saldo;
        Verificador = verificador;
    }
    
    public ContaCorrente(Cliente cliente, string conta, int numeroAgencia, string nomeAgencia, double saldo,
        bool verificador)
    {
        Cliente = cliente;
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