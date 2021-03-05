using System;

namespace ToeplitzMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("请输入一个矩阵");
            //TODO: 输入矩阵
            int[,] matrix = new int[,]
            {
                {1,2,4,5 },
                {3,1,2,4 },
                {6,3,1,2 },
                {7,6,3,1 },
                {8,7,6,3 }
            };

            Console.WriteLine(IsToeplitzMatrix(matrix));

        }

        public static bool IsToeplitzMatrix(int[,] matrix)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            for (int m = M - 2; m >= 0; m--)
            {
                if (!IsSameInRest(matrix, m, 0))
                    return false;
            }

            for (int n = N - 2; n > 0; n--)
            {
                if (!IsSameInRest(matrix, 0, n))
                    return false;
            }


            return true;
        }

        private static bool IsSameInRest(int[,] matrix, int m, int n)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);
            int number = matrix[m, n];
            m++;
            n++;
            while (m < M && n < N)
            {
                if (matrix[m, n] != number)
                    return false;
                m++;
                n++;
            }
            return true;
        }
    }
}
