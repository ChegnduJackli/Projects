using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLAViaCSharp.chapter17
{
    internal delegate void Feedback(Int32 value);
    internal delegate object MyCallback(FileStream fs);

    public class deleteGate
    {
        public static void StaticDelegateDemo()
        {
            Counter(1, 3, null);
            Counter(1, 3,new Feedback(FeedbackToConsole));
            Counter(1, 3, FeedbackToConsole);


            FileStream fs = new FileStream(@"C:\Users\lideng\Desktop\1.txt", FileMode.Append);
            MyCallback m = new MyCallback(FileStr);
            Console.WriteLine(m(fs));

            ThreadPool.QueueUserWorkItem(new WaitCallback(FeedbackToConsole1),4);
            ThreadPool.QueueUserWorkItem(FeedbackToConsole1, 5);
            ThreadPool.QueueUserWorkItem(obj=>Console.WriteLine("Lambda:"+obj),10);

            Func<Int32, string> f1 = (Int32 n) => n.ToString();
            Console.WriteLine("f1:"+f1(123));
        }

        private static void Counter(Int32 from, Int32 to, Feedback fb)
        {
            for (Int32 val = from; val <= to; val++)
            {
                if (fb != null)
                {
                    fb(val);
                }
            }
        }
        private static void FeedbackToConsole1(object value)
        {
            Console.WriteLine("Item " + value);
        }

        private static void FeedbackToConsole(Int32 value)
        {
            Console.WriteLine("Item " + value);
        }

        private static string FileStr(Stream s)
        {
            return "123";
        }
    }

    
}
