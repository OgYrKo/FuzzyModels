using System;

namespace Lab3
{
    class Program
    {
        /// <summary>
        /// Метод обчислення значень істинності нечітких висловлювань.
        /// </summary>
        /// <param name="result_1">Шукане значення істинності аналізованого першого нечіткого висловлювання.</param>
        /// <param name="result_2">Шукане значення істинності другого нечіткого висловлювання, що розглядається.</param>
        /// <param name="rules">Масив наявних правил на митниці.</param>
        /// <param name="situations">Масив ситуацій, що склалися на митниці.</param>
        static void Calculation(out Tuple<double, string> result_1_value, out Tuple<double, string> result_2_value, Tuple<double, string>[] rules, Tuple<double, string>[] situations)
        {
            Tuple<double, string> on_rule_1 = new Tuple<double, string>(Math.Min(1.0 - situations[0].Item1, rules[0].Item1), "Громадяни будуть піддані митному огляду.");

            Tuple<double, string> on_rule_2 = new Tuple<double, string>(Math.Min(situations[0].Item1, rules[1].Item1), "Громадяни не будуть піддані митному огляду.");
            Tuple<double, string> on_rule_3 = new Tuple<double, string>(Math.Min(situations[0].Item1, rules[2].Item1), "Не виключається можливість перевезення наркотиків.");
            Tuple<double, string> on_rule_4 = new Tuple<double, string>(Math.Min(1.0 - situations[1].Item1, rules[3].Item1), "Контролер відчуває втому.");
            Tuple<double, string> on_rule_5 = new Tuple<double, string>(Math.Min(on_rule_4.Item1, rules[4].Item1), "Не виключається можливість перевезення наркотиків.");
            Tuple<double, string> on_rule_6 = new Tuple<double, string>(Math.Min(Math.Min(on_rule_1.Item1, situations[3].Item1), rules[5].Item1), "Виключається можливiсть перевезення наркотикiв");
            Tuple<double, string> on_rule_7 = new Tuple<double, string>(Math.Min(Math.Min(on_rule_1.Item1, situations[2].Item1), rules[6].Item1), "Виключається можливість перевезення наркотиків. ");
            result_1_value = new Tuple<double, string>(Math.Max(on_rule_6.Item1, on_rule_7.Item1), "Виключається можливість перевезення наркотиків.");
            result_2_value = new Tuple<double, string>(Math.Max(on_rule_3.Item1, on_rule_5.Item1), "Не виключається можливість перевезення наркотиків.");
        }
        /// <summary>
        /// Функція виведення консоль результатів обчислення.
        /// </summary>
        /// <param name="results">Масив результатів</param>
        static void PrintResult(Tuple<double, string>[] results)
        {
            for (int i = 0; i < results.Length; ++i)
            {
                Console.WriteLine($"Значення істинності: {results[i].Item1} першого нечіткого висловлювання: {results[i].Item2}");
            }
        }
        static void Main(string[] args)
        {
            Tuple<double, string> rule_1 = new Tuple<double, string>(1.0, "ЯКЩО громадянин не є високопоставленим чиновником, ТО він піддається митному огляду.");
            Tuple<double, string> rule_2 = new Tuple<double, string>(0.9, "ЯКЩО громадянин є високопоставленим чиновником, ТО він не піддається митному огляду.");
            Tuple<double, string> rule_3 = new Tuple<double, string>(0.8, "ЯКЩО громадянин не піддається митному огляду, ТО не виключається можливість перевезення наркотиків.");
            Tuple<double, string> rule_4 = new Tuple<double, string>(0.6, "ЯКЩО кількість громадян, що проходять митний огляд, велика, ТО контролер відчуває втому.");
            Tuple<double, string> rule_5 = new Tuple<double, string>(0.7, "ЯКЩО контролер відчуває втому, ТО не виключається можливість провезення наркотиків.");
            Tuple<double, string> rule_6 = new Tuple<double, string>(0.95, "ЯКЩО громадянин піддається митному огляду І щодо цього громадянина є агентурна інформація," + "ТО виключається можливість перевезення наркотиків.");
            Tuple<double, string> rule_7 = new Tuple<double, string>(0.95, "ЯКЩО громадянин піддається митному огляду І контролер використовує новітні технічні засоби," + "ТО виключається можливість перевезення наркотиків.");

            Tuple<double, string> situation_1 = new Tuple<double, string>(0.2, "Серед громадян, які в'їжджають у країну, знаходяться високопосадовці.");
            Tuple<double, string> situation_2 = new Tuple<double, string>(0.1, "Кількість громадян, які проходять митний огляд невелика.");
            Tuple<double, string> situation_3 = new Tuple<double, string>(0.8, "Митний пункт контролю оснащений новітніми технічними засобами.");
            Tuple<double, string> situation_4 = new Tuple<double, string>(0.9, "Яка-небудь попередня інформація про наявність наркотиків в окремих громадян відсутня.");
            Tuple<double, string>[] rules = { rule_1, rule_2, rule_3, rule_4, rule_5, rule_6, rule_7 };
            Tuple<double, string>[] situations = { situation_1, situation_2, situation_3, situation_4 };
            Tuple<double, string> result_1;
            Tuple<double, string> result_2;
            // Викликаємо метод обчислення.
            Calculation(out result_1, out result_2, rules, situations);
            Tuple<double, string>[] results = { result_1, result_2 };
            // Викликаємо метод виведення результатів на консоль.
            PrintResult(results);
        }
    }
}
