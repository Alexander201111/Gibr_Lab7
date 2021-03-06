﻿namespace Gibr_Lab7
{
    public class ForSolver
    {
        /// <summary>Количество потоков</summary>
        public int count { get; set; }

        /// <summary>Показатель измеряемости счетчиков</summary>
        public double[] Ii { get; set; }

        /// <summary>Погрешность</summary>
        public double[] w { get; set; }

        /// <summary>Результат суммы потоков для узла</summary>
        public double[] b { get; set; }

        /// <summary>Значения, замеренные счетчиком</summary>
        public double[] d { get; set; }

        /// <summary>Знак потока для каждого узла</summary>
        public double[][] A { get; set; }

        /// <summary>Отношение одного потока к другому</summary>
        public double[][] extra { get; set; }

        /// <summary>Ограничения значений</summary>
        public Limitation[] limitations { get; set; }

        public ForSolver(int _count, double[] _Ii, double[] _w, double[] _d, double[] _b, double[][] _A, double[][] _extra = null, Limitation[] _limitations = null)
        {
            count = _count;
            Ii = _Ii;
            w = _w;
            d = _d;
            b = _b;
            A = _A;
            extra = _extra;
            limitations = _limitations;
        }
    }
}
