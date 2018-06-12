

using System;
using System.IO;
using System.Windows;

namespace CarService.Data.Helpers
{
    public static class Logger
    {
        public static void Fix(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("../../../CarService.Data/logs.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Error: " + DateTime.Now);
                    sw.WriteLine(message);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Не найден файл для логирования");
            }

        }
    }
}
