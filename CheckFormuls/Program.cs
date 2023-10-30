using FuzzyModels.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckFormuls
{
    internal class Program
    {
        const int HeaderPadding = -15;
        const int ValuesPadding = -10;
        static void Main(string[] args)
        {
            decimal A, B;
            A = 0.8M;
            B = 0.5M;
            Console.WriteLine($"A = {A}\nB = {B}");

            Console.WriteLine("\nОтрицание:");
            Console.WriteLine($"Not A = {1-A}");

            Console.WriteLine("\nКонъюнкиция:");
            string[] conjunctionsNames = Enum.GetNames(typeof(Conjunctions));
            for(int i=0;i<conjunctionsNames.Length;i++)
            {
                Console.WriteLine($"{conjunctionsNames[i],HeaderPadding}{Formuls.Cojunction(A,B,(Conjunctions)i),ValuesPadding}");
            }

            Console.WriteLine("\nДизъюнкция:");

            string[] disjunctionsNames = Enum.GetNames(typeof(Disjunctions));
            for (int i = 0; i < disjunctionsNames.Length; i++)
            {
                Console.WriteLine($"{disjunctionsNames[i],HeaderPadding}{Formuls.Disjunction(A, B, (Disjunctions)i),ValuesPadding}");
            }

            Console.WriteLine("\nИмпликация:");


            string[] implicationNames = Enum.GetNames(typeof(Implications));
            for (int i = 0; i < implicationNames.Length; i++)
            {
                Console.WriteLine($"{implicationNames[i],HeaderPadding}{Formuls.Implication(A, B, (Implications)i),ValuesPadding}");
            }

            Console.WriteLine("\nЭквивалентность:");


            string[] equalationNames = Enum.GetNames(typeof(Equalations));
            for (int i = 0; i < equalationNames.Length; i++)
            {
                Console.WriteLine($"{equalationNames[i],HeaderPadding}{Formuls.Equalation(A, B, (Equalations)i),ValuesPadding}");
            }
        }
    }
}
