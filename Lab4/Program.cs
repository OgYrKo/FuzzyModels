using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        /// <summary>
        /// Метод обчислення значень істинності нечітких висловлювань.
        /// </summary>
        /// <param name="result_value">Шукане значення істинності аналізованого заданого нечіткого висловлювання.</param>
        /// <param name="rules">Масив причинних взаємозв'язків між безліччю передумов та безліччю наслідків.</param>
        /// <param name="situations">Масив ситуацій огляду автомобіля, що склалися.</param>
        static void Calculation(out Tuple<double, string>[] result_value, Tuple<double, string>[] rules, Tuple<double, string>[] situations)
        {
            Tuple<double, string> on_rule_1 = new Tuple<double, string>(Math.Min(situations[0].Item1, rules[0].Item1), "Двигун не запускається через проблеми з акумулятором.");
            Tuple<double, string> on_rule_2 = new Tuple<double, string>(Math.Min(situations[0].Item1, rules[1].Item1), "Двигун не запускається через проблеми з карбюратором.");
            Tuple<double, string> on_rule_3 = new Tuple<double, string>(Math.Min(situations[0].Item1, rules[2].Item1), "Двигун не запускається через проблеми з бензином.");
            Tuple<double, string> on_rule_4 = new Tuple<double, string>(Math.Min(situations[0].Item1, rules[3].Item1), "Двигун не запускається через проблеми із системою запалювання.");
            Tuple<double, string> on_rule_5 = new Tuple<double, string>(Math.Min(situations[1].Item1, rules[4].Item1), "Двигун працює нестійко через проблеми з акумулятором.");
            Tuple<double, string> on_rule_6 = new Tuple<double, string>(Math.Min(situations[1].Item1, rules[5].Item1), "Двигун працює нестійко через проблеми з карбюратором.");
            Tuple<double, string> on_rule_7 = new Tuple<double, string>(Math.Min(situations[1].Item1, rules[6].Item1), "Двигун працює нестійко через проблеми з бензином.");
            Tuple<double, string> on_rule_8 = new Tuple<double, string>(Math.Min(situations[1].Item1, rules[7].Item1), "Двигун працює нестійко через проблеми із системою запалювання.");
            Tuple<double, string> on_rule_9 = new Tuple<double, string>(Math.Min(situations[2].Item1, rules[8].Item1), "Двигун не розвиває повної потужності через проблеми з акумулятором.");
            Tuple<double, string> on_rule_10 = new Tuple<double, string>(Math.Min(situations[2].Item1, rules[9].Item1), "Двигун не розвиває повної потужності через проблеми з карбюратором.");
            Tuple<double, string> on_rule_11 = new Tuple<double, string>(Math.Min(situations[2].Item1, rules[10].Item1), "Двигун не розвиває повної потужності через проблеми з бензином.");
            Tuple<double, string> on_rule_12 = new Tuple<double, string>(Math.Min(situations[2].Item1, rules[11].Item1), "Двигун не розвиває повної потужності через проблеми із системою запалювання." );
            result_value = new Tuple<double, string>[1];
            result_value[0] = new Tuple<double, string>(Math.Max(Math.Max(on_rule_1.Item1, on_rule_2.Item1), Math.Max(on_rule_3.Item1, on_rule_4.Item1)),"Проблема полягає або в несправності двигуна, або несправності системи запалення.");
        }
        /// <summary>
        /// Функція виведення консоль результатів обчислення.
        /// </summary>
        /// <param name="result">Результат</param>
        static void PrintResult(Tuple<double, string> result)
        {
            Console.WriteLine($"Значення істинності: {result.Item1}\nРезультат: {result.Item2}");
        }

        static void UpdateByVariant(Tuple<double, string>[] rules)
        {
            for(int i=0; i < rules.Length; i++)
            {
                rules[i] = new Tuple<double, string>(rules[i].Item1 - 0.1, rules[i].Item2);
            }
        }

        static void Main(string[] args)
        {
            const string y_1 = "двигун не запускається";
            const string y_2 = "двигун працює нестійко";
            const string y_3 = "двигун не розвиває повної потужності";
            const string x_1 = "несправність акумулятора";
            const string x_2 = "несправність карбюратора";
            const string x_3 = "низька якість бензину";
            const string x_4 = "несправність системи запалення";
            Tuple<double, string> rule_1 = new Tuple<double, string>(1.0, $"ЯКІ {y_1}, ТО {x_1}.");
            Tuple<double, string> rule_2 = new Tuple<double, string>(0.8, $"ЯКЩО {y_1}, ТО {x_2}.");
            Tuple<double, string> rule_3 = new Tuple<double, string>(0.7, $"ЯКІ {y_1}, ТО {x_3}.");
            Tuple<double, string> rule_4 = new Tuple<double, string>(1.0, $"ЯКЩО {y_1} ТО {x_4}.");
            Tuple<double, string> rule_5 = new Tuple<double, string>(0.1, $"ЯКІ {y_2}, ТО {x_1}.");
            Tuple<double, string> rule_6 = new Tuple<double, string>(0.9, $"ЯКІ {y_2}, ТО {x_2}.");
            Tuple<double, string> rule_7 = new Tuple<double, string>(0.8, $"ЯКІ {y_2}, ТО {x_3}.");
            Tuple<double, string> rule_8 = new Tuple<double, string>(0.5, $"ЯКІ {y_2}, ТО {x_4}.");
            Tuple<double, string> rule_9 = new Tuple<double, string>(0.2, $"ЯКІ {y_3}, ТО {x_1}.");
            Tuple<double, string> rule_10 = new Tuple<double, string>(1.0, $"ЯКІ {y_3}, ТО {x_2}.");
            Tuple<double, string> rule_11 = new Tuple<double, string>(0.5, $"ЯКІ {y_3}, ТО {x_3}.");
            Tuple<double, string> rule_12 = new Tuple<double, string>(0.2, $"ЯКІ {y_3}, ТО {x_4}.");
            Tuple<double, string> situation_1 = new Tuple<double, string>(0.9, $"{y_1}.");
            Tuple<double, string> situation_2 = new Tuple<double, string>(0.1, $"{y_2}.");
            Tuple<double, string> situation_3 = new Tuple<double, string>(0.2, $"{y_3}.");
            Tuple<double, string>[] rules = { rule_1, rule_2, rule_3, rule_4, rule_5, rule_6, rule_7, rule_8, rule_9, rule_10, rule_11, rule_12 };
            UpdateByVariant(rules);
            Tuple<double, string>[] situations = { situation_1, situation_2, situation_3 };
            Tuple<double, string>[] results;
            // Викликаємо метод обчислення.
            Calculation(out results, rules, situations);
            // Викликаємо метод виведення результатів на консоль.
            foreach(var result in results) PrintResult(result);
        }
    }
}
