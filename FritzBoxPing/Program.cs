using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace FritzBoxPing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await DoPing();
        }

        public static async Task DoPing()
        {
            var p = new Ping();
            var user = "JSchmid";
            string path = $@"C:\Users\{user}\Desktop\ping.txt";

            while (true)
            {
                var timeStamp = DateTime.Now.ToString();
                try
                {
                    p.Send("8.8.8.8");
                    File.AppendAllText(path, $"{timeStamp} [INFO] Google DNS Ping succeeded\n");
                    Console.WriteLine($"{timeStamp} [INFO] Google DNS Ping succeeded\n");
                }
                catch (Exception e)
                {
                    File.AppendAllText(path, $"{timeStamp} [ERROR] Google DNS Ping failed\n");
                    Console.WriteLine($"{timeStamp} [ERROR] Google DNS Ping failed\n");
                }

                try
                {
                    p.Send("fritz.box");
                    File.AppendAllText(path, $"{timeStamp} [INFO] FritzBox Ping succeeded\n");
                    Console.WriteLine($"{timeStamp} [INFO] FritzBox Ping succeeded\n");
                }
                catch (Exception e)
                {
                    File.AppendAllText(path, $"{timeStamp} [ERROR] FritzBox Ping failed\n");
                    Console.WriteLine($"{timeStamp} [ERROR] FritzBox Ping failed\n");
                }

                Console.WriteLine();

                await Task.Delay(TimeSpan.FromMinutes(3));
            }
        }
    }
}
