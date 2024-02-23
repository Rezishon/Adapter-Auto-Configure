using System;
using System.Collections.Generic;
using System.Diagnostics;
using Spectre.Console;

namespace CodeWars
{
    internal class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            bool flag = true;
            int number = 1;
            Dictionary<string, int> partNumbers = new Dictionary<string, int>()
            {
                { "Wifi => IP & DNS", 0 },
                { "Wifi => DNS", 1 },
                { "nEthernet => IP & DNS", 2 },
                { "nEthernet => DNS", 3 },
                { "Additional Tools", 4 },
                { "Exit", 777 },
            };

            while (flag)
            {
                AnsiConsole.Write(new FigletText("AAC").Centered().Color(Color.Purple));
                AnsiConsole.Render(
                    new Text(
                        "Adapter Auto Configure\n",
                        Style.Parse("italic purple bold")
                    ).Centered()
                );

                var rule = new Rule("[italic blue]What command you want to run?[/]");
                rule.Justification = Justify.Left;
                AnsiConsole.Write(rule);
                AnsiConsole.MarkupLine("");
                {

                }

                switch (number)
                {
                    case 0:
                        break;
                    case 1:
                        RunCommand("netsh interface ipv4 set address name=\"Wi-Fi\" source=dhcp");
                        RunCommand("netsh interface ipv4 set dnsservers name=\"Wi-Fi\" source=dhcp");
                        break;
                    case 2:
                        RunCommand("netsh interface ipv4 set address name=\"Wi-Fi\" static 192.168.1.100 255.255.255.0 192.168.1.1");
                        RunCommand("netsh interface ipv4 set dns name=\"Wi-Fi\" static 8.8.8.8");
                        RunCommand("netsh interface ipv4 add dns name=\"Wi-Fi\" 4.2.2.4 index=2");
                        break;
                    case 3:
                        RunCommand("netsh interface ipv4 set address name=\"Wi-Fi\" static 192.168.85.62 255.255.255.0 192.168.85.1");
                        RunCommand("netsh interface ipv4 set dns name=\"Wi-Fi\" static 8.8.8.8");
                        RunCommand("netsh interface ipv4 add dns name=\"Wi-Fi\" 4.2.2.4 index=2");
                        break;
                    case 4:
                        RunCommand("netsh interface ipv4 set address name=\"Ethernet\" static 192.168.85.61 255.255.255.0 192.168.85.1");
                        RunCommand("netsh interface ipv4 set dns name=\"Ethernet\" static 8.8.8.8");
                        RunCommand("netsh interface ipv4 add dns name=\"Ethernet\" 4.2.2.4 index=2");
                        break;
                    case 5:
                        RunCommand("netsh interface ipv4 set address name=\"Ethernet\" source=dhcp");
                        RunCommand("netsh interface ipv4 set dnsservers name=\"Ethernet\" source=dhcp");
                        break;
                    case 6:
                        RunCommand("netsh interface ipv4 set dns name=\"Wi-Fi\" static 185.51.200.2");
                        RunCommand("netsh interface ipv4 add dns name=\"Wi-Fi\" 178.22.122.100 index=2");
                        break;
                    case 7:
                        RunCommand("netsh interface ipv4 set dns name=\"Ethernet\" static 185.51.200.2");
                        RunCommand("netsh interface ipv4 add dns name=\"Ethernet\" 178.22.122.100 index=2");
                        break;
                    case 8:
                        RunCommand("netsh interface ipv4 set dns name=\"Wi-Fi\" static 8.8.8.8");
                        RunCommand("netsh interface ipv4 add dns name=\"Wi-Fi\" 4.2.2.4 index=2");
                        break;
                    case 9:
                        RunCommand("netsh interface ipv4 set dns name=\"Ethernet\" static 8.8.8.8");
                        RunCommand("netsh interface ipv4 add dns name=\"Ethernet\" 4.2.2.4 index=2");
                        break;
                    case 10:
                        Console.WriteLine("\n=========================================================================================");
                        RunCommand("ipconfig /flushdns");
                        Console.WriteLine("\n=========================================================================================");
                        RunCommand("ipconfig /release");
                        Console.WriteLine("\n=========================================================================================");
                        RunCommand("ipconfig /renew");
                        Console.WriteLine("\t\tPress any key to exit");
                        Console.ReadKey();

                        break;
                    case 11:
                        Console.WriteLine("\n=========================================================================================");
                        RunCommand("ping -a -n 2 8.8.8.8");
                        Console.WriteLine("\n=========================================================================================");
                        RunCommand("ping -a -n 2 soft98.ir");
                        Console.WriteLine("\t\tPress any key to exit");
                        Console.ReadKey();

                        break;
                    case 12:
                        Console.WriteLine("\n=========================================================================================");
                        RunCommand("ping -a -n 2 youtube.com");
                        Console.WriteLine("\n=========================================================================================");
                        RunCommand("ping -a -n 2 pornhub.com");
                        Console.WriteLine("\t\tPress any key to exit");
                        Console.ReadKey();

                        break;
                }
                Console.Clear();
            }
        }

        public static void RunCommand(string command)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    Verb = "runas", // Run as administrator
                    LoadUserProfile = true,
                    FileName = "powershell.exe",
                    Arguments = command,
                    RedirectStandardOutput = false,
                    UseShellExecute = true,
                    CreateNoWindow = false,
                };

                Process.Start(processInfo);
            }
            catch (Exception objException)
            {
                throw objException;
            }
        }
    }
}
