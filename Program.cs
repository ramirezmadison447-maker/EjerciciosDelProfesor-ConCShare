
/*
 Realice un programa que solicite de dos valores al usuario y luego imprima por pantalla los resultados de las operaciones: 
Suma Resta Multiplicacion Division  Raiz cuadrada de cada valor.
*/

public class Calculadora
{
    
    public int Suma(int num1, int num2)
    {
        return num1 + num2;
    }

    public int Resta(int num1, int num2)
    {
        return num1 - num2;
    }

    public int Multiplicacion(int num1, int num2)
    {
        return num1 * num2;
    }

    public int Division(int num1, int num2)
    {
        return num1 / num2;
    }

    public double RaizCuadrada1(int num1)
    {
        return Math.Sqrt(num1);
    }

    public double RaizCuadrada2(int num2)
    {
        return Math.Sqrt(num2);
    }
}




public class Ejecutable
{
    public static void Main(string[] args)
    {
        
        Console.WriteLine("Ingrese el primer valor: ");
        string numero1 = Console.ReadLine();
        int num1 = Convert.ToInt32(numero1);
        
        Console.WriteLine("Ingrese el segundo valor: ");
        string numero2 = Console.ReadLine();
        int num2 = Convert.ToInt32(numero2);

        Console.WriteLine("Resultados de las operaciones: ");
        
        Calculadora calc = new Calculadora();

        Console.WriteLine($"Suma: {calc.Suma(num1, num2)}");
        Console.WriteLine($"Resta: {calc.Resta(num1, num2)}");
        Console.WriteLine($"Multiplicación: {calc.Multiplicacion(num1, num2)}");
        Console.WriteLine($"División: {calc.Division(num1, num2)}");
        Console.WriteLine($"Raíz cuadrada de {num1}: {calc.RaizCuadrada1(num1)}");
        Console.WriteLine($"Raíz cuadrada de {num2}: {calc.RaizCuadrada2(num2)}");

        Console.ReadKey();
    } 
}