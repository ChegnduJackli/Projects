using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSample
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateReport gr = new GenerateReport();

            string body = gr.Generate();

            SendEmail.Send(body);
        }
    }
}
