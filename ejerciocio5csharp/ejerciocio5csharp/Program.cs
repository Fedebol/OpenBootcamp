/*//Ejercicio 1 - If

Escribe un programa que:

Pida datos a un cliente: Nombre, email, cupón

Determine si un cliente tiene un cupon descuento

Muestre un precio rebajado en función del descuento

Muestre el precio de un producto sin descuento si no hay cupón

Nota: puedes poner un precio fijo de un producto o uno variable.

Ejercicio 2 - Switch

Haz una lista de lenguajes de programación, por ejemplo: C#, Java, C++. Presenta la lista en consola y pide que el usuario seleccione el lenguaje mediante 1, 2, 3 o a, b, c. Presenta el resultado en consola.

Nota: puedes añadir al resultado el “Hola, mundo” para el caso de C#.
*/
// IF
Console.WriteLine("ingrese el nombre: ");
var nombre = Console.ReadLine();
Console.WriteLine("ingrese su email: ");
var email = Console.ReadLine();
Console.WriteLine("ingrese el numero del cupon: ");
var cuponN = Convert.ToInt32(Console.ReadLine());
var factor = 1.0;
var precio = 999.9;
if (( cuponN == 123 ) || (cuponN == 159) || (cuponN == 234))
{
    factor = 0.70;
}
if (precio == (precio * factor))
{
    Console.WriteLine("numero de cupon no valido");
}
Console.WriteLine($"el precio del producto con descuento es: ${precio * factor}");
Console.WriteLine($"el precio del producto sin descuento es: ${precio}");
Console.WriteLine();
Console.WriteLine();
// switch

Console.WriteLine("seleciones el numero del lenguaje: ");
Console.WriteLine();
Console.WriteLine("1 - JAVA ");
Console.WriteLine("2 - JS ");
Console.WriteLine("3 - C# ");
Console.WriteLine("4 - C++ ");
Console.WriteLine("5 - PHYTON ");
var opcion = Convert.ToInt32(Console.ReadLine());
switch(opcion)
{
    case  1:
        Console.WriteLine("JAVA");
        break;
    case 2:
        Console.WriteLine("JS");
        break;
    case 3:
        Console.WriteLine("Hola, mundo");
        break;
    case 4:
        Console.WriteLine("C++");
        break;
    case 5:
        Console.WriteLine("PHYTON");
        break;
    default:
        Console.WriteLine("opcion incorrecta");
        return;
}
