class Program
{
    public static void Main()
    {
        var numeroIf = -1;
        var numeroWhile = 0;
        var estacion = "invierno";

        Console.WriteLine("ejercicio if");
        if (numeroIf==0)
        {
            Console.WriteLine("es igual a cero");
        }else if(numeroIf < 0)
        {
            Console.WriteLine("es negativo");
        }
        else
        {
            Console.WriteLine("es positivo");
        }

        Console.WriteLine("ejercicio while");

        while (numeroWhile < 3)
        {
            Console.WriteLine(numeroWhile.ToString());
            numeroWhile++;
        }

        Console.WriteLine("ejercicio do while");

        do {
            Console.WriteLine(numeroWhile.ToString());
            numeroWhile++;
        } while (numeroWhile < 3);

        Console.WriteLine("ejercicio for");

        for (int numeroFor = 0; numeroFor<=3; numeroFor++)
        {
            Console.WriteLine(numeroFor.ToString());
        }

        Console.WriteLine("ejercicio switch");

        switch (estacion)
        {
            case "invierno":
                Console.WriteLine("la estacion es invierno");
                break;
            case "otoño":
                Console.WriteLine("la estacion es otoño");
                break ;
            case "primavera":
                Console.WriteLine("la estacion es primavera");
                break;
            case "verano":
                Console.WriteLine("la estacion es verano");
                break;   
            default:
                Console.WriteLine("eso no es una estacion");
                break;
        }
    }
}