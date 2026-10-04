
public class Ejercicio2
{
    public static void Main(string[] args)
    {
        List<string> filas = new List<string>();
        string respuesta;

        do
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Nota 1: ");
            double n1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nota 2: ");
            double n2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nota 3: ");
            double n3 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nota 4: ");
            double n4 = Convert.ToDouble(Console.ReadLine());

            double promedio = (n1 + n2 + n3 + n4) / 4;

            string literal;
            if (promedio >= 90)
                literal = "A";
            else if (promedio >= 80)
                literal = "B";
            else if (promedio >= 70)
                literal = "C";
            else
                literal = "D";

            filas.Add(nombre + "\t" + apellido + "\t" + n1 + "\t" + n2 + "\t" + n3 + "\t" + n4 + "\t" + promedio + "\t" + literal);

            Console.Write("Desea ingresar otro estudiante? (S/N): ");
            respuesta = Console.ReadLine().ToUpper();
            Console.WriteLine();

        } while (respuesta == "S");

        Console.WriteLine("              Colegio Dios es bueno.");
        Console.WriteLine("          Calificaciones del cuatrimestre\n");
        Console.WriteLine("================================================================");
        Console.WriteLine("Nombre    Apellido   Nota1 Nota2 Nota3 Nota4  Promedio   Literal");
        Console.WriteLine("================================================================");

        foreach (string fila in filas)
            Console.WriteLine(fila);

        Console.ReadKey();

    }
}
