using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Nombre del archivo donde se guardan los estudiantes
    static string archivo = "estudiantes.txt";

    static void Main()
    {
        string opcion;

        do
        {
            Console.WriteLine();
            Console.WriteLine("========= MENU =========");
            Console.WriteLine("1. Agregar un estudiante");
            Console.WriteLine("2. Eliminar un estudiante");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("4. Salir");
            Console.Write("Elija una opcion: ");
            opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    AgregarEstudiante();
                    break;
                case "2":
                    EliminarEstudiante();
                    break;
                case "3":
                    MostrarReporte();
                    break;
                case "4":
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Intente de nuevo.");
                    break;
            }

        } while (opcion != "4");
    }

    // ---------------- OPCION 1 ----------------
    static void AgregarEstudiante()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Primer apellido: ");
        string apellido = Console.ReadLine();

        double n1 = PedirNota("Nota 1: ");
        double n2 = PedirNota("Nota 2: ");
        double n3 = PedirNota("Nota 3: ");
        double n4 = PedirNota("Nota 4: ");

        // Se guarda una linea por estudiante, con los datos separados por ;
        string linea = nombre + ";" + apellido + ";" + n1 + ";" + n2 + ";" + n3 + ";" + n4;
        File.AppendAllText(archivo, linea + Environment.NewLine);

        Console.WriteLine("Estudiante agregado correctamente.");
    }

    // Pide una nota y la repite si no esta entre 0 y 100
    static double PedirNota(string mensaje)
    {
        double nota;
        do
        {
            Console.Write(mensaje);
            nota = Convert.ToDouble(Console.ReadLine());
            if (nota < 0 || nota > 100)
                Console.WriteLine("Error: la nota debe estar entre 0 y 100.");
        } while (nota < 0 || nota > 100);

        return nota;
    }

    // ---------------- OPCION 2 ----------------
    static void EliminarEstudiante()
    {
        if (!File.Exists(archivo) || File.ReadAllLines(archivo).Length == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }

        List<string> lineas = new List<string>(File.ReadAllLines(archivo));

        // Mostrar la lista numerada
        for (int i = 0; i < lineas.Count; i++)
        {
            string[] datos = lineas[i].Split(';');
            Console.WriteLine((i + 1) + ". " + datos[0] + " " + datos[1]);
        }

        Console.Write("Numero del estudiante a eliminar: ");
        int numero = Convert.ToInt32(Console.ReadLine());

        if (numero < 1 || numero > lineas.Count)
        {
            Console.WriteLine("Numero no valido.");
            return;
        }

        lineas.RemoveAt(numero - 1);          // Se quita de la lista
        File.WriteAllLines(archivo, lineas);  // Se reescribe el archivo sin ese estudiante

        Console.WriteLine("Estudiante eliminado correctamente.");
    }

    // ---------------- OPCION 3 ----------------
    static void MostrarReporte()
    {
        if (!File.Exists(archivo) || File.ReadAllLines(archivo).Length == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }

        string[] lineas = File.ReadAllLines(archivo);
        List<string> filas = new List<string>();

        int totalA = 0;
        int totalB = 0;
        int totalC = 0;
        int totalReprobados = 0;

        foreach (string linea in lineas)
        {
            // Separar la linea en sus partes: nombre;apellido;n1;n2;n3;n4
            string[] datos = linea.Split(';');

            string nombre = datos[0];
            string apellido = datos[1];
            double n1 = Convert.ToDouble(datos[2]);
            double n2 = Convert.ToDouble(datos[3]);
            double n3 = Convert.ToDouble(datos[4]);
            double n4 = Convert.ToDouble(datos[5]);

            double promedio = (n1 + n2 + n3 + n4) / 4;

            string literal;
            if (promedio >= 90)
            {
                literal = "A";
                totalA++;
            }
            else if (promedio >= 80)
            {
                literal = "B";
                totalB++;
            }
            else if (promedio >= 70)
            {
                literal = "C";
                totalC++;
            }
            else
            {
                literal = "D";
                totalReprobados++;
            }

            // El apellido va primero para poder ordenar por apellido
            filas.Add(string.Format("{0,-10}{1,-10}{2,6}{3,6}{4,6}{5,6}{6,10}{7,10}",
                apellido, nombre, n1, n2, n3, n4, promedio, literal));
        }

        filas.Sort();

        Console.WriteLine("              Colegio Dios es bueno.");
        Console.WriteLine("          Calificaciones del cuatrimestre");
        Console.WriteLine();
        Console.WriteLine("================================================================");
        Console.WriteLine("Apellido  Nombre     Nota1 Nota2 Nota3 Nota4  Promedio   Literal");
        Console.WriteLine("================================================================");

        foreach (string fila in filas)
            Console.WriteLine(fila);

        Console.WriteLine("================================================================");
        Console.WriteLine("Estudiantes en A: " + totalA);
        Console.WriteLine("Estudiantes en B: " + totalB);
        Console.WriteLine("Estudiantes en C: " + totalC);
        Console.WriteLine("Estudiantes Reprobados: " + totalReprobados);
    }
}