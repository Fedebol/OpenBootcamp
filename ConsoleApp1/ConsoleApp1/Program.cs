class program
{

    public static void Main(string[] args)
    {
        var a = 1;
        var b = 2;
        var c = 3;

        int resultado = suma(a, b, c);
        coche coche = new coche();
        coche.sumarPuerta();
        Console.WriteLine(coche.puertas);

    }

    public static int suma(int a, int b, int c)
    {
        return a + b + c;
    }


    public class coche
    {
        public int puertas = 4;
        public void sumarPuerta()
        {
            this.puertas++;
        }
    }



}