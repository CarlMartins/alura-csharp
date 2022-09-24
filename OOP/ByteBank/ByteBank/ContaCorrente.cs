namespace ByteBank;

public class ContaCorrente
{
    public string Conta { get; set; }
    public int NumeroAgencia { get; set; }
    public string NomeAgencia { get; set; }
    private double _saldo;

    public double Saldo
    {
        get { return _saldo; }
        private set
        {
            if (value < 0) return;
            _saldo = value;
        }
    }

    public bool Verificador { get; set; }
    public Cliente Cliente { get; set; }
    public static int TotalDeContasCriadas { get; set; }

    public ContaCorrente(string conta, int numeroAgencia, string nomeAgencia, double saldo,
        bool verificador)
    {
        Conta = conta;
        NumeroAgencia = numeroAgencia;
        NomeAgencia = nomeAgencia;
        Saldo = saldo;
        Verificador = verificador;
        TotalDeContasCriadas++;
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