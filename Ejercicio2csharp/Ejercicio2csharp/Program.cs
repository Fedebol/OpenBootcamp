
//ejercicio 1
Console.WriteLine("ingrese su nombre: ");
var nombre = Console.ReadLine();
Console.WriteLine("ingrese su apellido: ");
var apellido = Console.ReadLine();
Console.WriteLine("ingrese su edad: ");
var edad = Console.ReadLine();
Console.WriteLine("sabe programar?: ");
var sabeProgramar = Console.ReadLine();
Console.WriteLine("su nombre es: " + nombre);
Console.WriteLine("su apellido es: " + apellido);
Console.WriteLine("su edad es: " + edad);
Console.WriteLine("sabe programar?: " + sabeProgramar);

Console.WriteLine();
//ejercicio 2
Console.WriteLine();

Coche coche = new Coche();

Console.WriteLine("ingrese numero de puertas: ");
coche.puerta= Convert.ToInt32(Console.ReadLine());
Console.WriteLine("ingrese cantidad de ruedas: ");
coche.ruedas = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("ingrese la marca: ");
coche.marca = Console.ReadLine();
Console.WriteLine("ITV vigente?: ");
coche.ITVvigente = Console.ReadLine();
Console.WriteLine("el coche tiene: " + coche.puerta + " puertas");
Console.WriteLine("el coche tiene: " + coche.ruedas + " ruedas");
Console.WriteLine("la marca del coche es: " + coche.marca);
Console.WriteLine("ITV esta vigente?: " + coche.ITVvigente);

Console.WriteLine();
Console.WriteLine();

Mesa mesa = new Mesa();


Console.WriteLine("ingrese el peso: ");
mesa.peso = float.Parse(Console.ReadLine());
Console.WriteLine("ingrese el largo de la mesa: ");
mesa.largo = float.Parse(Console.ReadLine());
Console.WriteLine("ingrese el material: ");
mesa.material = Console.ReadLine();
Console.WriteLine("ingrese el color de la mesa: ");
mesa.material = Console.ReadLine();
Console.WriteLine("la mesa pesa: " + mesa.peso + " Kg.");
Console.WriteLine("la mesa mide: " + mesa.largo + " de largo");
Console.WriteLine("la mesa es de: " + mesa.material);
Console.WriteLine("la mesa es de : " + mesa.color);

//ejercicio 3

Console.WriteLine("ingrese un numero: ");
var numero = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("ingrese una letra: ");
var letra = Convert.ToChar(Console.ReadLine());

Console.WriteLine("el numero es mayor igual a 18: " + (numero >= 18));
Console.WriteLine("la letra ingresa es 'a': " + letra.Equals('a'));
Console.WriteLine($"cumple las dos condiciones? {(numero >= 18) && (letra == 'a')}");
Console.WriteLine($"cumple alguna condicion? {(numero >= 18) || (letra == 'a')}");




class Coche
{
    public int puerta { get; set; }
    public int ruedas { get; set; }
    public string marca { get; set; }
    public string ITVvigente { get; set; }
}

class Mesa
{
    public float peso { get; set; }
    public float largo { get; set; }
    public string material { get; set; }
    public string color { get; set; }
}