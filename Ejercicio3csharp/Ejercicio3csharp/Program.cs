Cliente cliente = new Cliente();

Console.WriteLine("ingrese el nombre del cliente: ");
cliente.nombre = Console.ReadLine();
Console.WriteLine("ingrese el telefono del cliente: ");
cliente.telefono = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("ingrese el direccion del cliente: ");
cliente.direccion = Console.ReadLine();
Console.WriteLine("ingrese el mail del cliente: ");
cliente.mail = Console.ReadLine();
Console.WriteLine("el cliente es nuevo? si/no: ");
cliente.clientenuevo = Console.ReadLine();

Console.WriteLine(cliente);


public struct Cliente
{
    public string nombre { get; set; }
    public int telefono { get; set; }
    public string direccion { get; set; }
    public string mail { get; set; }
    public string clientenuevo { get; set; }

    public override string ToString() => $"{nombre}, {telefono}, {direccion}, {mail}, {clientenuevo}";
   
}