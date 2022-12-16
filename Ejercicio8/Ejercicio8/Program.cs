Persona persona1 = new Persona();
persona1.Nombre = "Federico";
persona1.Edad = 34;
persona1.Telefono = 088840052;

Console.WriteLine(persona1.Nombre);
Console.WriteLine(persona1.Telefono);
Console.WriteLine(persona1.Edad);
class Persona
  {
   public string Nombre { get; set; }
   public int Telefono { get; set; }
   public int Edad { get; set; }

  }


