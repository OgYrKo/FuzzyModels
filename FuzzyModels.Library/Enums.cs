using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyModels.Library
{

    /// <summary>
    /// Последовательность операций:
    /// 1) Отрицание
    /// 2) Конъюнкция
    /// 3) Дизъюнкция
    /// 4) Импликация
    /// </summary>
    public enum Conjunctions { Main, Algebra, Granichnaya}
    public enum Disjunctions { Main, Algebra, Granichnaya}
    public enum Implications { Zadeh, Mamdani, Lukasiewicz, Goguen}
    public enum Equalations { Main }
}
