internal class Program
{
    private static void Main(string[] args)
    {
        Conta c1 = new(1, "Giovanni", 580, 3000);
        Conta c2 = new(2, "Saweetie", 600, 8000);

        c1.Deposita(300);
        c1.Saca(100);
        c1.Envia(10, c2);
        c1.Limite = 9000;

        c1.Info();
        c2.Info();
    }
}