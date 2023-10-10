using System.Transactions;

class Conta
{
    // letra inicial maiúscula em propriedade pública
    public int Numero { get; private set; } 
    public string Titular { get; private set; }
    public double Saldo { get; private set; }
    public double? Limite { get; set; }

    public Conta(int numero, string titular, double saldo, double limite)
    {
        Numero = numero;
        Titular = titular;
        Saldo = saldo;
        Limite = limite;
    }

    public void Info()
    {
        string saldoFormatado = string.Format("{0:N2}", Saldo);
        string limiteFormatado = string.Format("{0:N2}", Limite);

        string output = "Nº da conta: " + Numero + "\n" +
                        "Titular da conta: " + Titular + "\n" +
                        "Saldo disponível: R$" + saldoFormatado + "\n" +
                        "Limite da conta: R$" + limiteFormatado + "\n";

        Console.WriteLine(output);
    }

    public void Extrato()
    {
        Console.WriteLine($"Saldo disponível do titular {Titular}: R${Saldo:N2}");
    }

    public void Deposita(double valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
        }
        else
        {
            Console.WriteLine("O valor do depósito deve ser maior que R$0,00.");
        }
    }

    private bool Pode_sacar(double valor_saque)
    {
        double vd = (double)(Saldo + Limite);
        return valor_saque <= vd;
    }

    public void Saca(double valor)
    {
        if (Pode_sacar(valor))
        {
            Saldo -= valor;
        }
        else
        {
            Console.WriteLine($"O valor {valor:N2} passou o limite de saque.\n");
        }
    }

    public void Envia(double valor, Conta destinatario)
    {
        if (Saldo >= valor && valor > 0)
        {
            Saca(valor);
            destinatario.Deposita(valor);
        }
        else
        {
            Console.WriteLine($"O envio de {valor:N2} para {destinatario.Titular} não foi possível de ser efetuado.\n");
        }
    }

}
