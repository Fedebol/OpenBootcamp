
Cliente cliente = new Cliente();
cliente.edad = 25;
cliente.telefono = 321654;
cliente.nombre = "Marta";
cliente.credito = 10000;

Console.WriteLine(cliente.nombre);
Console.WriteLine(cliente.edad);
Console.WriteLine(cliente.telefono);
Console.WriteLine(cliente.credito);

Trabajador trabajador = new Trabajador();

trabajador.telefono = 65465;
trabajador.edad = 45;
trabajador.nombre = "susana";
trabajador.salario = 120000;

Console.WriteLine(trabajador.nombre);
Console.WriteLine(trabajador.edad);
Console.WriteLine(trabajador.telefono);
Console.WriteLine(trabajador.salario);






class Persona
{
   public int edad { get; set; }
   public int telefono { get; set; }
   public string nombre { get; set; }
}

class Cliente: Persona
{
    public float credito { get; set; }
}

class Trabajador: Persona
{
    public float salario { get; set; }
}