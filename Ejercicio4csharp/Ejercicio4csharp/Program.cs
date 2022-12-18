//while
Console.WriteLine("ingrese un numero: ");
var numero = Convert.ToInt32(Console.ReadLine());
var j = 1;
while(j <= 10)
{
    Console.WriteLine(numero*j);
    j++;
}

//do while
var estado = "n";
do
{

Console.WriteLine("ingrese un numero: ");
var numeroDo = Convert.ToInt32(Console.ReadLine());
    if (numeroDo == 0)
    {
        Console.WriteLine("el numero es cero");
    }
    else if(numeroDo > 0)
    {
        Console.WriteLine("el numero es positivo");
    }
    else
    {
        Console.WriteLine("el numero es negativo");
    }
    Console.WriteLine("desea ingresar otro numero? s/n ");
    estado = Console.ReadLine();
}while(estado == "s");
//for

Console.WriteLine("ingrese un numero para el ancho: ");
var ancho = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("ingrese un numero para el alto: ");
var alto = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("desea que la figura este rellena? s/n: ");
var relleno = Console.ReadLine();
Console.WriteLine("ingrese el numero de veces que desea repetir el proceso: ");
var veces = Convert.ToInt32(Console.ReadLine());

for (var v = 0; v < veces; v++)
{
    for (var i = 0; i < alto; i++)
    {
        Console.WriteLine();
        for (var k = 0; k < ancho; k++)
        {
            if (i == 0)
            {
                Console.Write("*");
            }
            else if (i == alto-1)
            {
                Console.Write('*');
            }
            else
            {
                if (k == 0)
                {
                    Console.Write("*");
                }
                else if (k == ancho - 1)
                {
                    Console.Write('*');
                }
                else
                {

                    if (relleno == "s")
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
        

        }
    }
}

