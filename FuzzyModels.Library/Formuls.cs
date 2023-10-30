using System;

namespace FuzzyModels.Library
{
    public static class Formuls
    {
        #region Conjunction
        private static decimal MainConjuction(decimal A, decimal B) => Math.Min(A, B);
        private static decimal AlgebraConjuction(decimal A, decimal B) => A * B;
        private static decimal BoundaryConjuction(decimal A, decimal B) => Math.Max(A + B - 1, 0);

        public static decimal Cojunction(decimal A, decimal B, Conjunctions alg = 0)
        {
            switch (alg)
            {
                case Conjunctions.Main:
                    return MainConjuction(A, B);
                case Conjunctions.Algebra:
                    return AlgebraConjuction(A, B);
                case Conjunctions.Granichnaya:
                    return BoundaryConjuction(A, B);
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion Conjunction

        #region Disjunction
        private static decimal MainDisjunctions(decimal A, decimal B) => Math.Max(A, B);
        private static decimal AlgebraDisjunctions(decimal A, decimal B) => A + B-A * B;
        private static decimal BoundaryDisjunctions(decimal A, decimal B) => Math.Min(A + B, 1);

        public static decimal Disjunction(decimal A, decimal B, Disjunctions alg = 0)
        {
            switch (alg)
            {
                case Disjunctions.Main:
                    return MainDisjunctions(A, B);
                case Disjunctions.Algebra:
                    return AlgebraDisjunctions(A, B);
                case Disjunctions.Granichnaya:
                    return BoundaryDisjunctions(A, B);
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion Disjunction

        #region Implication
        private static decimal ZadehImplication(decimal A, decimal B) => Math.Max(Math.Min(A,B),1-A);
        private static decimal MamdaniImplication(decimal A, decimal B) => Math.Min(A, B);
        private static decimal LukasiewiczImplication(decimal A, decimal B) => Math.Min(1, 1 - A + B);
        private static decimal GoguenImplication(decimal A, decimal B) => A==0?1:Math.Min(1,B/A);

        public static decimal Implication(decimal A, decimal B, Implications alg = 0)
        {
            switch (alg)
            {
                case Implications.Zadeh:
                    return ZadehImplication(A, B);
                case Implications.Mamdani:
                    return MamdaniImplication(A, B);
                case Implications.Lukasiewicz:
                    return LukasiewiczImplication(A, B);
                case Implications.Goguen:
                    return GoguenImplication(A, B);
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion Implication

        #region Disjunction
        private static decimal MainEqualations(decimal A, decimal B) => Math.Min(Math.Max(1-A,B),Math.Max(A,1-B));

        public static decimal Equalation(decimal A, decimal B, Equalations alg = 0)
        {
            switch (alg)
            {
                case Equalations.Main:
                    return MainEqualations(A, B);
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion Disjunction
    }
}
