using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace GoReloded
{
    class Program
    {
        static void Main()
        {
            string str = Start.ReadFile();
            ConvertText convertText = new ConvertText();
            List<string> stringToList = convertText.StringToArray(str);

            List<string> data = ModifyText.TransformToText(stringToList);
            string res = "";
            for (int i = 0; i < stringToList.Count; i++)
            {
                //stringToList[i] + " ");
                res += stringToList[i] + " ";
            }


            Start.WriteFile(res);
        }
    }
    class ConvertText
    {
        public List<string> StringToArray(string str)
        {
            List<string> list = new List<string>();
            string res = "";

            foreach (char v in str)
            {

                if (v == ' ')
                {
                    if (res.Length > 0)
                    {
                        list.Add(res);
                        res = "";
                    }
                }
                else
                {
                    res += v;
                }

            }
            if (res.Length > 0)
            {
                list.Add(res);
            }

            return list;
        }

    }
    class FunctionWork
    {
        protected static int SearchNum(string slice)
        {
            string num = slice.Substring(0, slice.Length - 1);
            int data = int.Parse(num);
            return data;
        }
        protected static string Cap(char[] cup)
        {
            string str = "";
            if (cup[0] >= 'a' && cup[0] <= 'z')
            {

                cup[0] = (char)(cup[0] - 32);
            }
            for (int j = 0; j < cup.Length; j++)
            {
                str += cup[j];
            }
            return str;
        }
        protected static string Low(char[] cup)
        {
            string str = "";
            foreach (char c in cup)
            {
                if (c >= 'A' && c <= 'Z')
                {

                    str += (char)(c + 32);
                }
            }
            return str;
        }
        protected static string Up(char[] cup)
        {
            string str = "";
            foreach (char c in cup)
            {
                if (c >= 'a' && c <= 'z')
                {

                    str += (char)(c - 32);
                }
            }
            return str;
        }
        protected static bool AandA(char[] cup)
        {
            char[] arr = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            for (int i = 0; i < arr.Count(); i++)
            {
                if (cup[0] == arr[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
    class ModifyText : FunctionWork
    {
        public static List<string> TransformToText(List<string> slice)
        {
            for (int i = 0; i < slice.Count; i++)
            {
                switch (slice[i])
                {

                    case "(cap)":

                        char[] cup = slice[i - 1].ToCharArray();
                        slice[i - 1] = Cap(cup);
                        break;
                    case "(up)":

                        char[] up = slice[i - 1].ToCharArray();
                        slice[i - 1] = Up(up);
                        break;
                    case "(cap,":
                        int numCup = SearchNum(slice[i + 1]);
                        for (int j = 1; j <= numCup; j++)
                        {
                            slice[i - j] = Cap(slice[i - j].ToCharArray());
                        }


                        break;
                    case "(up,":
                        int numUp = SearchNum(slice[i + 1]);
                        for (int j = 1; j <= numUp; j++)
                        {
                            slice[i - j] = Up(slice[i - j].ToCharArray());
                        }

                        break;

                    case "(low,":
                        int numLow = SearchNum(slice[i + 1]);
                        for (int j = 1; j <= numLow; j++)
                        {
                            slice[i - j] = Low(slice[i - j].ToCharArray());
                        }

                        break;
                    case "(bin)":
                        //int data = int.Parse(slice[i]);
                        //int numBin = SearchNum(slice[i]);
                        slice[i - 1] = Convert.ToInt32(slice[i - 1], 2).ToString();
                        break;
                    case "(hex)":
                        slice[i - 1] = Convert.ToInt32(slice[i - 1], 16).ToString();
                        break;
                    case "a":
                    case "an":
                        bool checkAn = AandA(slice[i + 1].ToCharArray());
                        if (checkAn)
                        {
                            slice[i] = "an";
                        }
                        else
                        {
                            slice[i] = "a";
                        }
                        break;
                }

            }
            return slice;

        }

    }
    class Start
    {
        public static string ReadFile()
        {
            // string path = "C:\\Users\\user\\source\\repos\\FirstProject\\FirstProject\\sample.txt";
        
          string path = Path.Combine(Directory.GetCurrentDirectory(), "sample.txt");
            string content = File.ReadAllText(path);
            return content;
        }
        public static void WriteFile(string str)
        {
            // string path = "C:\\Users\\user\\source\\repos\\FirstProject\\FirstProject\\result.txt";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "result.txt");
            File.WriteAllText(path, str);

        }

    }
}