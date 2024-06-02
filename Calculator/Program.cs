using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Calculator
{
    internal class Program
    {
        static void switchOp1(List<string>list,int j,int countArg)
        {
            switch (list[j])
            {
                case "*":

                    list[j + 1] = (double.Parse(list[j + 1]) * double.Parse(list[j - 1])).ToString();
                    list[j] = ""; list[j - 1] = "";
                    countArg++;
                    break;
                case "/":
                    list[j + 1] = (double.Parse(list[j - 1]) / double.Parse(list[j + 1])).ToString();
                    list[j] = ""; list[j - 1] = "";
                    countArg++;
                    break;
            }
        }
        static void switchOp2(List<string> list, int j, int countArg)
        {
            switch (list[j])
            {
                case "+":

                    list[j + 1] = (double.Parse(list[j + 1]) + double.Parse(list[j - 1])).ToString();
                    list[j] = ""; list[j - 1] = "";
                    countArg++;
                    break;
                case "-":
                    list[j + 1] = (double.Parse(list[j - 1]) - double.Parse(list[j + 1])).ToString();
                    list[j] = ""; list[j - 1] = "";
                    countArg++;
                    break;
            }
        }
        static void DeleteList(List<string> list, int index)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (list[j] == "")
                {
                    list.RemoveAt(j);
                    index = 0;
                    j = 0;
                }
            }
        }
        static void DeleteList(List<string> list)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (list[j] == "")
                {
                    list.RemoveAt(j);
                    j = 0;
                }
            }
        }
        static void operation(List<string> list)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (list.IndexOf("(") == -1 && list.IndexOf("(") == -1)
                {
                    switch (list[j])
                    {
                        case "*":
                            list[j + 1] = (double.Parse(list[j + 1]) * double.Parse(list[j - 1])).ToString();
                            list[j] = ""; list[j - 1] = "";
                            break;
                        case "/":
                            list[j + 1] = (double.Parse(list[j - 1]) / double.Parse(list[j + 1])).ToString();
                            list[j] = ""; list[j - 1] = "";
                            break;
                    }
                }
            }
        }
        static void EmptyStr(List<string> list, int index, int i)
        {
            if (index - i == -2 && (index - 1 < 0 || (list[index - 1] == "") && list[index] == "(" && list[i] == ")"))
            {
                list[i] = "";
                list[index] = "";
            }
        }
        static int GetStr(char[] array, string[] OutputString, int count, int index, char symb1, char symb2, char symb3)
        {
            if (array[index] == symb1 && array[index + 1] == symb2 && array[index + 2] == symb3)
            {
                OutputString[count] = ("" + array[index] + array[index + 1] + array[index + 2]).ToString();
                count++;
            }
            return count;
        }
        static int GetStr(char[] array, string[] OutputString, int count, int index, char symb1, char symb2, char symb3, char symb4)
        {
            if (array[index] == symb1 && array[index + 1] == symb2 && array[index + 2] == symb3 && array[index + 3] == symb4)
            {
                OutputString[count] = ("" + array[index] + array[index + 1] + array[index + 2] + array[index + 3]).ToString();
                count++;
            }
            return count;
        }
        static int GetStr(char[] array, string[] OutputString, int count, int index, char symb1, char symb2)
        {
            if (array[index] == symb1 && array[index + 1] == symb2)
            {
                OutputString[count] = ("" + array[index] + array[index + 1]).ToString();
                count++;
            }
            return count;
        }
        static int GetStr(char[] array, string[] OutputString, int count, int index, char symb1)
        {
            if (array[index] == symb1)
            {
                OutputString[count] = ("" + array[index]).ToString();
                count++;
            }
            return count;
        }
        static void Main(string[] args)
        {
            bool Error = false;
            string[,] operators = new string[,] {
                {"sin","cos","tan","ctg" },
                {"(",")","",""},
                {"+","-","/","*" },
                {"sqrt","exp","abs","ln"}
            };
            Console.WriteLine("please use these symbols");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(operators[i, j] + " , ");
                }
                Console.WriteLine();
            }
            while (true)
            {
                if (Error)
                {
                    Console.WriteLine("Error,write again");
                }
                string input = Console.ReadLine();
                char[] symbols = input.ToCharArray();
                string[] StringArray = new string[symbols.Length];
                int count = 0;
                int index_Count;
                string Num_Str = "";
                for (int i = 0; i < symbols.Length; i++)
                {
                    for (int j = i; j < symbols.Length; j++)
                    {
                        if (double.TryParse(symbols[j].ToString(), out double res))
                        {
                            Num_Str += symbols[j].ToString();
                            if(j ==  symbols.Length - 1) { i= symbols.Length-1; break; }
                        }
                        else
                        {
                            i = j;
                            break;
                        }
                    }
                    if (Num_Str != "")
                    {
                        StringArray[count] = Num_Str;
                        count++;
                    }
                    Num_Str = "";
                    
                    count = GetStr(symbols, StringArray, count, i, 's', 'i', 'n');
                    count = GetStr(symbols, StringArray, count, i, 'c', 'o', 's');
                    count = GetStr(symbols, StringArray, count, i, 't', 'a', 'n');
                    count = GetStr(symbols, StringArray, count, i, 'c', 't', 'g');
                    count = GetStr(symbols, StringArray, count, i, 's', 'q', 'r', 't');
                    count = GetStr(symbols, StringArray, count, i, 'l', 'n');
                    count = GetStr(symbols, StringArray, count, i, '(');
                    count = GetStr(symbols, StringArray, count, i, '+');
                    count = GetStr(symbols, StringArray, count, i, '-');
                    count = GetStr(symbols, StringArray, count, i, '*');
                    count = GetStr(symbols, StringArray, count, i, '/');
                    count = GetStr(symbols, StringArray, count, i, ')');
                }
                int index = 0;
                List<string> list = new List<string>(StringArray);

                while (list.IndexOf("(") != -1 || list.IndexOf(")") != -1 || list.IndexOf("+") != -1 || list.IndexOf("-") != -1 || list.IndexOf("/") != -1 ||
                    list.IndexOf("*") != -1 || list.IndexOf("ln") != -1 || list.IndexOf("ctg") != -1 || list.IndexOf("tan") != -1 || list.IndexOf("sin") != -1 ||
                    list.IndexOf("sqrt") != -1 || list.IndexOf("exp") != -1 || list.IndexOf("abs") != -1 || list.IndexOf("+") != -1 || list.IndexOf("-") != -1
                    || list.IndexOf("/") != -1 || list.IndexOf("*") != -1)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == "(")
                        {
                            index = i;
                        }
                        if (list[i] == ")")
                        {
                            if (i - index == 2)
                            {
                                if (index - 1 >= 0)
                                {
                                    if (list[index - 1] == "+" || list[index - 1] == "-" || list[index - 1] == "/" || list[index - 1] == "*")
                                    {
                                        list[index] = "";
                                        list[i] = "";
                                    }
                                }
                            }
                            int countArg = 0;
                            for (int j = index; j < i; j++)
                            {
                                switchOp1(list, j, countArg);
                            }
                            if (countArg == 0)
                            {
                                i = list.Count;
                            }
                            DeleteList(list, i);
                            EmptyStr(list, index, i);
                        }
                    }
                    index = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == "(")
                        {
                            index = i;
                        }
                        if (list[i] == ")")
                        {
                            int countArg = 0;
                            for (int j = index; j < i; j++)
                            {
                                switchOp2(list, j, countArg);
                            }
                            if (countArg == 0)
                            {
                                i = list.Count;
                            }
                            DeleteList(list, i);
                            EmptyStr(list, index, i);
                        }
                    }
                    index = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == "(")
                        {
                            index = i;
                        }
                        if (list[i] == ")")
                        {
                            for (int j = index - 1; j <= i; j++)
                            {
                                if (index - 1 >= 0 && i - index == 2)
                                {
                                    switch (list[j])
                                    {
                                        case "sin":
                                            list[j + 3] = (Math.Sin(double.Parse(list[j + 2]))).ToString();
                                            list[j] = ""; list[j + 1] = ""; list[j + 2] = "";
                                            break;
                                        case "cos":
                                            list[j + 3] = (Math.Cos(double.Parse(list[j + 2]))).ToString();
                                            list[j] = ""; list[j + 1] = ""; list[j + 2] = "";
                                            break;
                                        case "tan":
                                            list[j + 3] = (Math.Tan(double.Parse(list[j + 2]))).ToString();
                                            list[j] = ""; list[j + 1] = ""; list[j + 2] = "";
                                            break;
                                        case "ctg":
                                            list[j + 3] = (1 / Math.Tan(double.Parse(list[j + 2]))).ToString();
                                            list[j] = ""; list[j + 1] = ""; list[j + 2] = "";
                                            break;
                                        case "abs":
                                            list[j + 3] = (Math.Abs(double.Parse(list[j + 2]))).ToString();
                                            list[j] = ""; list[j + 1] = ""; list[j + 2] = "";
                                            break;
                                        case "exp":
                                            list[j + 3] = (Math.Exp(double.Parse(list[j + 2]))).ToString();
                                            list[j] = ""; list[j + 1] = ""; list[j + 2] = "";
                                            break;
                                        case "ln":
                                            list[j + 3] = (Math.Log10(double.Parse(list[j + 2]))).ToString();
                                            list[j] = ""; list[j + 1] = ""; list[j + 2] = "";
                                            break;
                                        case "sqrt":
                                            list[j + 3] = (Math.Sqrt(double.Parse(list[j + 2]))).ToString();
                                            list[j] = ""; list[j + 1] = ""; list[j + 2] = "";
                                            break;
                                    }
                                }
                            }
                        }
                        DeleteList(list, i);
                    }
                    operation(list);
                    DeleteList(list);
                    operation(list);
                    if (list.IndexOf("(") == -1 && list.IndexOf(")") == -1)
                    {
                        for (int j = index; j < list.Count; j++)
                        {
                            switchOp1(list, j, 0);
                            DeleteList(list);
                        }
                        for (int j = index; j < list.Count; j++)
                        {
                            switchOp2( list, j,0);
                            DeleteList(list);
                        }
                    }
                }
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
        }
    }
}