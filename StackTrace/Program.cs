using System;

namespace StackTrace
{
    class Program
    {
        private static void test1(int a, double b)
        {
            test2();
        }

        private static void test2()
        {
            test3("test");
        }

        private static void test3(string s)
        {
            Console.WriteLine(GetStackTrace());
        }

        public static void Main(string[] args)
        {
            test1(2, 3.0);
            Console.ReadKey();
        }

        public static string GetStackTrace()
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
            System.Diagnostics.StackFrame[] sfs = st.GetFrames();
            string res = "";
            for (int i = 1; i < sfs.Length; i++)
            {
                var method = sfs[i].GetMethod();
                res += method.Name + "(";
                var parameters = method.GetParameters();
                int j = 0;
                for (; j < parameters.Length - 1; j++)
                    res += parameters[j].ParameterType + " " + parameters[j].Name + ", ";
                for (; j < parameters.Length; j++)
                    res += parameters[j].ParameterType + " " + parameters[j].Name;
                res += ")\n";
            }
            return res;
        }
    }
}
