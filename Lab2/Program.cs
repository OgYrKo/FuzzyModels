using System;

namespace Lab2
{
    class Program
    {
        const int Padding = -15;


        static void Main()
        {
            string[] professions = { "Сангвиник", "Холерик", "Меланхолик", "Флегматик" };
            string[] names = { "Петренко", "Іваненко", "Сидоренко", "Василенко", "Григоренко" };

            double variantValue = 0.01;

            string[] properties = new string[5];
            for (int i = 0; i < properties.Length; i++)
            {
                properties[i] = $"a{i + 1}";
            }

            // Нечітке відношення S профіль спеціальностей
            double[,] S = { { 0.6, 0.6, 0.6, 0.9, 0.1 },
                            { 0.9, 0.9, 0.9, 0.5, 0.4 },
                            { 0.4, 0.3, 0.4, 0.4, 0.9 },
                            { 0.1, 0.1, 0.5, 0.5, 0.1 }};

            //Зміна відповідно варіанту
            for (int i = 0; i < S.GetLength(0); i++)
            {
                for (int j = 0; j < S.GetLength(1); j++)
                {
                    S[i, j] += variantValue;
                }
            }


            /// Нечітке відношення T профіль кандидатів
            double[,] T = { { 0.9, 0.8, 0.7, 0.9, 1.0},
                       /*Y*/{ 0.6, 0.4, 0.8, 0.5, 0.6},
                            {0.5, 0.2, 0.3, 0.8, 0.7},
                            { 0.5, 0.9, 0.5, 0.8, 0.4},
                            {1.0, 0.6, 0.5, 0.7, 0.4}};
            int Q_Rows_From_S = S.GetUpperBound(0) + 1;
            int Q_Columns_From_T = T.Length / (T.GetUpperBound(0) + 1);

            // Нечітке відношення Q рекомендацій кандидатом відповідних спеціальностей.
            double[,] Q = new double[Q_Columns_From_T, Q_Rows_From_S];

            // Викликаємо метод обчислення матриці композиції.
            Calculation_Q(in S, in T, ref Q);

            PrintProperties(properties);
            PrintProfessions(professions, properties, S);
            PrintNames(names, properties, T);

            // Викликаємо метод виведення матриці композиції.
            Print_Q(Q, names, professions);
        }

        static void PrintProperties(in string[] properties)
        {
            Console.WriteLine($"{properties[0]} - Самооценка");
            Console.WriteLine($"{properties[1]} - Коммуникабельность");
            Console.WriteLine($"{properties[2]} - Отношение к нововведениям");
            Console.WriteLine($"{properties[3]} - Результативность труда");
            Console.WriteLine($"{properties[4]} - Подверженность влиянию");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void PrintProfessions(in string[] professions, in string[] properties, in double[,] values)
        {
            PritTable(properties, professions, values);
            Console.WriteLine();
            Console.WriteLine();
        }

        static void PrintNames(in string[] names, in string[] properties, in double[,] values)
        {
            PritTable(names, properties, values);
            Console.WriteLine();
            Console.WriteLine();
        }


        /// <summary>
        /// Виведення матриці композиції на консоль.
        /// </summary>
        /// <param name="Q">Матриця, що виводиться</param>
        static void Print_Q(in double[,] Q, in string[] names, in string[] professions)
        {
            Console.WriteLine("Матриця Q - це бінарна композиція матриць S і T. Висновок матриці Q:\n");
            PritTable(professions,names, Q);
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Обчислюємо матрицю композиції.
        /// </summary>
        /// <param name="S">Перша матриця нечітких відносин.</param>
        /// <param name="T">Друга матриця нечітких відносин.</param>
        /// <param name="Q">Результуюча матриця процесу максимінної згортки.</param>
        static void Calculation_Q(in double[,] S, in double[,] T, ref double[,] Q)
        {
            // T_Rows = S_Columns, S_Rows = T_Columns.
            int T_Rows = T.GetUpperBound(0) + 1;
            int T_Columns = T.Length / T_Rows;
            int S_Rows = S.GetUpperBound(0) + 1;
            int S_Columns = S.Length / S_Rows;
            // Проміжна змінна, яка зберігає число-претендент у результуючий масив.
            double tmp;
            for (int i = 0; i < T_Columns; i++)
            {
                for (int j = 0; j < S_Rows; j++)
                {
                    // Максимальний елемент масиву tmp.
                    double MaxElem = 0;
                    // Цикл, у якому відбувається (max-min)-композиція або ще так звана максимінна згортка.
                    for (int k = 0; k < S_Columns; k++)
                    {
                        tmp = T[k, i]* S[j, k];
                        if (tmp > MaxElem)
                        {
                            MaxElem = tmp;
                        }
                    }
                    // Запис отриманого значення результуючу матрицю.
                    Q[i, j] = MaxElem;
                }
            }
        }

        static void PritTable(string[] columns, string[] rows, double[,] values)
        {
            Console.Write($"{"",Padding}");
            for (int j = 0; j < columns.Length; j++)
            {
                Console.Write($"{columns[j],Padding}");
            }
            for (int i = 0; i < values.GetLength(0); i++)
            {
                Console.Write($"\n{rows[i],Padding}");
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    Console.Write($"{values[i,j],Padding}");
                }
            }
        }
    }
}
