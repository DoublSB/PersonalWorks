using System;

namespace Algorithm
{
    //https://www.acmicpc.net/problem/1992
    //Quad Tree Problem

    class Solving
    {
        short m_Size = 0;
        bool[,] InputValue;

        string Result = "";

        public void Solve()
        {
            Input();
            Result = GetResult(InputValue);

            Console.WriteLine(Result);
        }

        public void Input()
        {
            m_Size = short.Parse(Console.ReadLine());
            InputValue = new bool[m_Size, m_Size];

            string[] ReadValue = new string[m_Size];

            for (int i = 0; i < m_Size; i++)
            {
                ReadValue[i] = Console.ReadLine();
            }


            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    if (ReadValue[i][j] == '1') InputValue[i, j] = true;
                    else InputValue[i, j] = false;
                }
            }
        }

        public string GetResult(bool[,] value)
        {
            bool isSame = true;
            double Size = Math.Sqrt(value.Length);

            foreach (var item in value)
            {
                if (!(value[0,0] == item))
                {
                    isSame = false;
                    break;
                }
            }

            if (isSame)
            {
                if (value[0, 0]) return "1";
                else return "0";
            }

            else
            {
                string ReturnValue = "";

                ReturnValue += "(";

                foreach (bool[,] item in Slice_Value_4(value))
                {
                    ReturnValue += GetResult(item);
                }
               
                ReturnValue += ")";

                return ReturnValue;
            }
        }

        private bool[][,] Slice_Value_4(bool[,] value)
        {
            int NewSize = (int)(Math.Sqrt(value.Length) / 2);
            bool[][,] SlicedStrArr = new bool[4][,];

            for (int i = 0; i < 4; i++)
            {
                SlicedStrArr[i] = new bool[NewSize, NewSize];
            }

            for (int index = 0; index < 4; index++)
            {
                for (int i = 0; i < NewSize; i++)
                {
                    for (int j = 0; j < NewSize; j++)
                    {
                        SlicedStrArr[index][i, j] = value[((index/2) * NewSize) + i, ((index%2) * NewSize) + j];
                    }
                }
            }

            return SlicedStrArr;
        } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solving solve = new Solving();
            solve.Solve();
        }
    }
}
