using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestureRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            GestureRecognition gestures = new GestureRecognition(Thread.CurrentThread, "COM5");
            gestures.sampler.ProgressChanged += sampler_ProgressChanged;

            Console.ReadKey();
        }

        static void sampler_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                switch (e.ProgressPercentage)
                {
                    case 0:
                        Console.WriteLine("NEUTRAL");
                        break;
                    case 1:
                        Console.WriteLine("LEFT");
                        break;
                    case 2:
                        Console.WriteLine("RIGHT");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
