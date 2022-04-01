using System;

namespace AsyncCalcTestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();
            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
