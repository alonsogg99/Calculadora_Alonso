using System;

namespace Calculadora_Alonso
{
    internal class Program
    {
        static void Main(string[] args){
            Eleccion();
        }

        static void Eleccion(){
            int choice;
            Console.WriteLine("Elige la funcion a realizar:");
            Console.WriteLine("1. Calculo de determinante de matriz de orden 3");
            Console.WriteLine("2. Suma de matrices");
            Console.WriteLine("3. Resta de matrices");
            Console.WriteLine("4. Producto de dos matrices");
            Console.WriteLine("5. Calculo de determinante de matriz de cualquier orden");
            Console.WriteLine("0. Cerrar aplicación");

            string read = (Console.ReadLine());

            if (CheckInt(read)){
                choice = int.Parse(read);
                if (choice == 1) Determinante();
                if (choice == 2) Sumar();
                if (choice == 3) Restar();
                if (choice == 4) Producto();
                if (choice == 5) DeterminanteCualquierOrden(); 
                if (choice == 0) return;

            }

            else{
                Console.WriteLine("Error, elige una opción válida");
                Eleccion();
            }
        }

        static void Determinante(){
            int[,] matriz = new int[3, 3];

            Console.WriteLine("Introduce los elementos de la matriz:");
            for (int i = 0; i < 3; i++){
                for (int j = 0; j < 3; j++){
                    Console.Write("Matriz[{0},{1}] = ", i, j);
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int determinante = matriz[0, 0] * matriz[1, 1] * matriz[2, 2] +
                               matriz[0, 1] * matriz[1, 2] * matriz[2, 0] +
                               matriz[0, 2] * matriz[1, 0] * matriz[2, 1] -
                               matriz[0, 2] * matriz[1, 1] * matriz[2, 0] -
                               matriz[0, 1] * matriz[1, 0] * matriz[2, 2] -
                               matriz[0, 0] * matriz[1, 2] * matriz[2, 1];

            Console.WriteLine("El determinante de la matriz es: {0}", determinante);
        }

        static void Sumar(){
            int n = 0;
            int m = 0;
            //Para que puedan sumarse dos matrices deben tener la misma forma, asique pedimos al usuario que introduzca su tamaño
            Console.WriteLine("Introduce el numero de filas de las matrices");
            string read = Console.ReadLine();
            if (CheckInt(read)) n = int.Parse(read);

            Console.WriteLine("Introduce el numero de columnas de las matrices");
            read = Console.ReadLine();
            if (CheckInt(read)) m = int.Parse(read);

            int[,] matrizA = new int[n, m];
            int[,] matrizB = new int[n, m];
            int[,] matrizResultado = new int[n, m];

            Console.WriteLine("Introduce los elementos de la matriz A:");
            for (int i = 0; i < n; i++){
                for (int j = 0; j < m; j++){
                    Console.Write("Matriz[{0},{1}] = ", i, j);
                    matrizA[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Introduce los elementos de la matriz B:");
            for (int i = 0; i < n; i++){
                for (int j = 0; j < m; j++){
                    Console.Write("Matriz[{0},{1}] = ", i, j);
                    matrizB[i, j] = int.Parse(Console.ReadLine());
                }
            }


            // Suma las dos matrices
            for (int i = 0; i < n; i++){
                for (int j = 0; j < m; j++){
                    matrizResultado[i, j] = matrizA[i, j] + matrizB[i, j];
                }
            }

            // Imprime la matriz resultante
            for (int i = 0; i < n; i++){
                for (int j = 0; j < m; j++){
                    Console.Write("{0} ", matrizResultado[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Restar()
        {
            int n = 0;
            int m = 0;
            //Para que puedan restarse dos matrices deben tener la misma forma, asique pedimos al usuario que introduzca su tamaño
            Console.WriteLine("Introduce el numero de filas de las matrices");
            string read = Console.ReadLine();
            if (CheckInt(read)) n = int.Parse(read);

            Console.WriteLine("Introduce el numero de columnas de las matrices");
            read = Console.ReadLine();
            if (CheckInt(read)) m = int.Parse(read);

            int[,] matrizA = new int[n, m];
            int[,] matrizB = new int[n, m];
            int[,] matrizResultado = new int[n, m];

            Console.WriteLine("Introduce los elementos de la matriz A:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("Matriz[{0},{1}] = ", i, j);
                    matrizA[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Introduce los elementos de la matriz B:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("Matriz[{0},{1}] = ", i, j);
                    matrizB[i, j] = int.Parse(Console.ReadLine());
                }
            }


            // Suma las dos matrices
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrizResultado[i, j] = matrizA[i, j] - matrizB[i, j];
                }
            }

            // Imprime la matriz resultante
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0} ", matrizResultado[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Producto(){
            int n1 = 0;
            int m1 = 0;
            int n2 = 0;
            int m2 = 0;

            Console.WriteLine("Introduce el numero de filas de la matriz A");
            string read = Console.ReadLine();
            if (CheckInt(read)) n1 = int.Parse(read);

            Console.WriteLine("Introduce el numero de filas de la Matriz B");
            read = Console.ReadLine();
            if (CheckInt(read)) n2 = int.Parse(read);

            Console.WriteLine("Introduce el numero de columnas de la matriz A");
            read = Console.ReadLine();
            if (CheckInt(read)) m1 = int.Parse(read);

            Console.WriteLine("Introduce el numero de columnas de la Matriz B");
            read = Console.ReadLine();
            if (CheckInt(read)) m2 = int.Parse(read);

            int[,] matrizA = new int[n1, m1];
            int[,] matrizB = new int[n2, m2];
            int[,] matrizResultado = new int[n1, m2];

            Console.WriteLine("Introduce los elementos de la matriz A:");
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    Console.Write("Matriz[{0},{1}] = ", i, j);
                    matrizA[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Introduce los elementos de la matriz B:");
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    Console.Write("Matriz[{0},{1}] = ", i, j);
                    matrizB[i, j] = int.Parse(Console.ReadLine());
                }
            }

            if (n1 == m2 && n2 == m1)
            {
                int[,] result = new int[n1, m2];

                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        for (int k = 0; k < n1; k++)
                        {
                            result[i, j] += matrizA[i, k] * matrizB[k, j];
                        }
                    }
                }

                Console.WriteLine("Resulting Matrix:");
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        Console.Write(result[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            else{
                Console.WriteLine("Para que las matrices puedan multiplicarse, la primera debe ser m x n y la segunda n x m. Introduzca una operación válida");
                Eleccion();
            }
        }

        static double[,] ConstruirMatriz(){
            Console.WriteLine("Introduce el tamaño de la matriz.");
            int s = int.Parse(Console.ReadLine());

            double[,] matriz = new double[s, s];

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    Console.Write($"Matriz[{i},{j}]: ");
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return matriz;
        }

        static void DeterminanteCualquierOrden(){
            double[,] matriz = ConstruirMatriz();

            int n = matriz.GetLength(0);

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    double factor = matriz[i, k] / matriz[k, k];
                    for (int j = k + 1; j < n; j++)
                    {
                        matriz[i, j] = matriz[i, j] - factor * matriz[k, j];
                    }
                }
            }

            double det = 1;
            for (int i = 0; i < n; i++)
            {
                det *= matriz[i, i];
            }
            Console.WriteLine("El determinante de la matriz es ");
            Console.WriteLine(det);
        }

        static bool CheckInt(string num){

            int result;

            if (int.TryParse(num, out result)) return true;

            else return false;
        }
    }
}
