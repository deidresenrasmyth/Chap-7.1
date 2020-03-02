using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07TryOut02
{
    class Program
    {
        static string[] eTypes = {"none","simple","index","nested indedx"};

        static void Main(string[] args)
        {
            foreach (string eTypes in eTypes)
            {
                try
                {
                    Console.WriteLine("Main() try  block reached."); //Line 19
                    Console.WriteLine("ThrowException(\"{0}\") called",eTypes);
                    ThrowException(eTypes);
                    Console.WriteLine("Main() try block continues."); //line 22
                }
                catch(System.IndexOutOfRangeException e)
                {
                    Console.WriteLine("Main() System.IndexOutOfRangeException catch block reached. Message: \n\"{0}\"",e.Message);
                }
                catch //line 28
                {
                    Console.WriteLine("Main() catch block reached."); //line 20
                }
                finally
                {
                    Console.WriteLine("Main() finnely block reached.");
                }
            }
            Console.ReadKey();
        }

        static void ThrowException(string exceptionType)
        {
            Console.WriteLine("ThrowException(\"{0}\") reached.", exceptionType);
            switch (exceptionType)
            {
                case "none":
                    Console.WriteLine("Not throwing an exception.");
                    break;
                case "simple":
                    Console.WriteLine("Throwing System.Exception.");
                    break;
                case "index":
                    Console.WriteLine("Throwing System.IndexOutOfRangeException.");
                    eTypes[4] = "error";
                    break;
                case "nested index":
                    try
                    {
                        Console.WriteLine("ThrowException (\"nested index\") try block reached.");
                        Console.WriteLine("ThrowException (\"index\") called.");
                        ThrowException("index");
                    }
                    catch
                    {
                        Console.WriteLine("ThrowException (\"nested index\") general catch block reached.");
                    }
                    finally
                    {
                        Console.WriteLine("ThrowException (\"nested index\") general finally block reached.");
                    }
                    break;
            }
        }
    }
}
