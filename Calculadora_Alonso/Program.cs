using System;

namespace Calculadora_Alonso{
    internal class Program{
        static bool CheckInt(string num){
            int result;

            if (int.TryParse(num, out result)) return true;
            else return false;
        }
        static double[,] ConstruirMatrizCuadrada(){
            Console.WriteLine("Introduce el tamaño de la matriz.");
            int s = int.Parse(Console.ReadLine());
            double[,] matriz = new double[s, s];
            Console.WriteLine("Introduce uno a uno los elementos de la matriz.");

            for (int i = 0; i < s; i++){
                for (int j = 0; j < s; j++){
                    Console.Write($"Matriz[{i},{j}]: ");
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return matriz;
        }

        static double[,] ConstruirMatriz(){
            Console.WriteLine("Introduce el numero de filas de la matriz.");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el numero de columnas de la matriz.");
            int n = int.Parse(Console.ReadLine());
            double[,] matriz = new double[m, n];
            Console.WriteLine("Introduce uno a uno los elementos de la matriz.");

            for (int i = 0; i < m; i++){
                for (int j = 0; j < n; j++){
                    Console.Write($"Matriz[{i},{j}]: ");
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return matriz;
        }

        static void ImprimirMatriz(double[,] matriz){
            for (int i = 0; i < matriz.GetLength(0); i++){
                for (int j = 0; j < matriz.GetLength(1); j++){
                    Console.Write("{0} ", matriz[i, j]);
                }
                Console.WriteLine();
            }
        }

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
            Console.WriteLine("6. Calculo de una matriz inversa");
            Console.WriteLine("0. Cerrar aplicación");
            string read = (Console.ReadLine());

            if (CheckInt(read)){
                choice = int.Parse(read);
                if (choice == 1) Determinante();
                if (choice == 2) Sumar();
                if (choice == 3) Restar();
                if (choice == 4) Producto();
                if (choice == 5) DeterminanteCualquierOrden();
                if (choice == 6) MatrizInversa();
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
            Eleccion();
        }

        static void Sumar(){
            Console.WriteLine("MATRIZ A.");
            double[,] matrizA = ConstruirMatriz();
            Console.WriteLine("MATRIZ B.");
            double[,] matrizB = ConstruirMatriz();
            double[,] matrizResultado = new double[matrizA.GetLength(0), matrizA.GetLength(1)];

            if (matrizA.GetLength(0) != matrizB.GetLength(0) || matrizA.GetLength(1) != matrizB.GetLength(1)){
                Console.WriteLine("Las matrices deben tener la misma forma, introduce matrices validas");
                Sumar();
            }

            for (int i = 0; i < matrizA.GetLength(0); i++) {
                for (int j = 0; j < matrizA.GetLength(1); j++){
                    matrizResultado[i, j] = matrizA[i, j] + matrizB[i, j];
                }
            }
            ImprimirMatriz(matrizResultado);
            Eleccion();
        }

        static void Restar(){
            Console.WriteLine("RESTA DE MATRIZ A - MATRIZ B");
            Console.WriteLine("MATRIZ A.");
            double[,] matrizA = ConstruirMatriz();
            Console.WriteLine("MATRIZ B.");
            double[,] matrizB = ConstruirMatriz();
            double[,] matrizResultado = new double[matrizA.GetLength(0), matrizA.GetLength(1)];

            if (matrizA.GetLength(0) != matrizB.GetLength(0) || matrizA.GetLength(1) != matrizB.GetLength(1)){
                Console.WriteLine("Las matrices deben tener la misma forma, introduce matrices validas");
                Restar();
            }
            for (int i = 0; i < matrizA.GetLength(0); i++){
                for (int j = 0; j < matrizA.GetLength(1); j++){
                    matrizResultado[i, j] = matrizA[i, j] - matrizB[i, j];
                }
            }
            ImprimirMatriz(matrizResultado);
            Eleccion();
        }

        static void Producto(){
            Console.WriteLine("PRODUCTO DE MATRIZ A x MATRIZ B");
            Console.WriteLine("MATRIZ A");
            double[,] matrizA = ConstruirMatriz();
            Console.WriteLine("MATRIZ B");
            double[,] matrizB = ConstruirMatriz();

            if (matrizA.GetLength(0) == matrizB.GetLength(1) && matrizB.GetLength(0) == matrizA.GetLength(1)){
                double[,] result = new double[matrizA.GetLength(0), matrizB.GetLength(1)];
                for (int i = 0; i < matrizA.GetLength(0); i++){
                    for (int j = 0; j < matrizB.GetLength(1); j++){
                        for (int k = 0; k < matrizA.GetLength(0); k++){
                            result[i, j] += matrizA[i, k] * matrizB[k, j];
                        }
                    }
                }
                Console.WriteLine("Resultado:");
                ImprimirMatriz(result);
            }
            else{
                Console.WriteLine("Para que las matrices puedan multiplicarse, la primera debe ser m x n y la segunda n x m. Introduzca una operación válida");
                Eleccion();
            }
            Eleccion();
        }

        static void DeterminanteCualquierOrden(){
            double[,] matriz = ConstruirMatrizCuadrada();
            for (int k = 0; k < matriz.GetLength(0) - 1; k++){
                for (int i = k + 1; i < matriz.GetLength(0); i++){
                    double factor = matriz[i, k] / matriz[k, k];
                    for (int j = k + 1; j < matriz.GetLength(0); j++){
                        matriz[i, j] = matriz[i, j] - factor * matriz[k, j];
                    }
                }
            }
            double det = 1;
            for (int i = 0; i < matriz.GetLength(0); i++){
                det *= matriz[i, i];
            }
            Console.WriteLine("El determinante de la matriz es ");
            Console.WriteLine(det);
            Eleccion();
        }

        static void MatrizInversa(){
            double[,] matriz = ConstruirMatrizCuadrada();
            double det = DeterminanteGeneral(matriz);
            if (det == 0){
                Console.WriteLine("La matriz no es invertible puesto que su determinante es igual a 0, elige otra matriz válida.");
                MatrizInversa();
            }
            else{
                double[,] matrizA = MatrizAdjunta(matriz);
                double[,] matrizT = MatrizTraspuesta(matrizA);
                double fac = 1 / det;
                double[,] matrizI = MatrizPorEscalar(matrizT, fac);
                Console.WriteLine("La matriz inversa es:");
                for (int i = 0; i < matriz.GetLength(0); i++){
                    for (int j = 0; j < matriz.GetLength(1); j++){
                        Console.Write(matrizI[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static double[,] MatrizTraspuesta(double[,] matriz){
            double[,] matrizT = new double[matriz.GetLength(1), matriz.GetLength(0)];
            double[,] matrizP = new double[matriz.GetLength(0), matriz.GetLength(1)];
            for (int i = 0; i < matriz.GetLength(0); i++){
                for (int j = 0; j < matriz.GetLength(1); j++){
                    matrizT[i, j] = matriz[j, i];
                }
            }
            return matrizT;
        }

        static double[,] MatrizAdjunta(double[,] matriz){
            int n = matriz.GetLength(0);
            double[,] matrizAdjunta = new double[n, n];
            for (int i = 0; i < n; i++){
                for (int j = 0; j < n; j++){
                    int signo = ((i + j) % 2 == 0) ? 1 : -1;
                    double[,] submatriz = Submatriz(matriz, i, j);
                    double determinante = DeterminanteGeneral(submatriz);
                    matrizAdjunta[i, j] = signo * determinante;
                }
            }
            return matrizAdjunta;
        }

        static double[,] Submatriz(double[,] matriz, int fila, int columna){
            int n = matriz.GetLength(0);
            double[,] submatriz = new double[n - 1, n - 1];
            int iSub = 0;
            for (int i = 0; i < n; i++){
                if (i == fila) continue;
                int jSub = 0;
                for (int j = 0; j < n; j++){
                    if (j == columna) continue;
                    submatriz[iSub, jSub] = matriz[i, j];
                    jSub++;
                }
                iSub++;
            }
            return submatriz;
        }

        static double[,] MatrizPorEscalar(double[,] matriz, double escalar){
            double[,] matrizResultado = new double[matriz.GetLength(0), matriz.GetLength(1)];
            for (int i = 0; i < matriz.GetLength(0); i++){
                for (int j = 0; j < matriz.GetLength(1); j++){
                    matrizResultado[i, j] = matriz[i, j] * escalar;
                }
            }
            return matrizResultado;
        }

        static double DeterminanteGeneral(double[,] matriz){
            for (int k = 0; k < matriz.GetLength(0) - 1; k++){
                for (int i = k + 1; i < matriz.GetLength(0); i++){
                    double factor = matriz[i, k] / matriz[k, k];
                    for (int j = k + 1; j < matriz.GetLength(0); j++){
                        matriz[i, j] = matriz[i, j] - factor * matriz[k, j];
                    }
                }
            }
            double det = 1;
            for (int i = 0; i < matriz.GetLength(0); i++) det *= matriz[i, i];
            return det;
        }
    }
}
