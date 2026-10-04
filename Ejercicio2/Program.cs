public class Ejercicio2
{
    public static void Main(string[] args)
    {
        List<string> filas = new List<string>();
        string respuesta = "";

        do
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            double n1;
            do
            {
                Console.Write("Nota 1: ");
                n1 = Convert.ToDouble(Console.ReadLine());
                if (n1 < 0 || n1 > 100)
                    Console.WriteLine("Error: la nota debe estar entre 0 y 100.");
            } while (n1 < 0 || n1 > 100);

            double n2;
            do
            {
                Console.Write("Nota 2: ");
                n2 = Convert.ToDouble(Console.ReadLine());
                if (n2 < 0 || n2 > 100)
                    Console.WriteLine("Error: la nota debe estar entre 0 y 100.");
            } while (n2 < 0 || n2 > 100);

            double n3;
            do
            {
                Console.Write("Nota 3: ");
                n3 = Convert.ToDouble(Console.ReadLine());
                if (n3 < 0 || n3 > 100)
                    Console.WriteLine("Error: la nota debe estar entre 0 y 100.");
            } while (n3 < 0 || n3 > 100);

            double n4;
            do
            {
                Console.Write("Nota 4: ");
                n4 = Convert.ToDouble(Console.ReadLine());
                if (n4 < 0 || n4 > 100)
                    Console.WriteLine("Error: la nota debe estar entre 0 y 100.");
            } while (n4 < 0 || n4 > 100);

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

            // filas.Add(nombre + "\t" + apellido + "\t" + n1 + "\t" + n2 + "\t" + n3 + "\t" + n4 + "\t" + promedio + "\t" + literal);
            filas.Add(string.Format("{0,-10}{1,-10}{2,6}{3,6}{4,6}{5,6}{6,10}{7,10}",
                apellido, nombre, n1, n2, n3, n4, promedio, literal));

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
