using System;
using System.Diagnostics;

namespace CodeWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 1;
            Console.WriteLine("Welcome to Adapter Auto Configure" +
                "\n\n ! ! REMEMBER TO RUN AS ADMINISTRATOR ! ! " +
                "\n\nPayaneh Monitor \"1280 * 1024\"" +
                "\nLaptop Monitor \"1920 * 1080\"" +
                "\nHome Monitor \"1360 * 768 60.015Hz\"" +
                "\n\nWe have 12 operation:");
            while (number != 0)
            {
                Console.WriteLine(
                    "\nWifi :"+
                    "\n\t1 => make \"Wifi\" goes on \"DHCP\" mood" +
                    "\n\t2 => make \"Wifi\" goes on \"Home_Network_Config\" mood" +
                    "\n\t3 => make \"Wifi\" goes on \"Payaneh_Network_Config\" mood" +
                    "\n\t\t6 => make \"Wifi-DNS\" goes on \"Shecan\" mood" +
                    "\n\t\t8 => make \"Wifi-DNS\" goes on \"Normal\" mood" +
                    "\n========================================================================================="+
                    "\nEthernet :" +
                    "\n\t5 => make \"Ethernet\" goes on \"DHCP\" mood" +
                    "\n\t4 => make \"Ethernet\" goes on \"Payaneh_Network_Config\" mood" +
                    "\n\t\t7 => make \"Ethernet-DNS\" goes on \"Shecan\" mood" +
                    "\n\t\t9 => make \"Ethernet-DNS\" goes on \"Normal\" mood" +
                    "\n=========================================================================================" +
                    "\nAdditional Tools :" +
                    "\n\t10 => Reset network adapter" +
                    "\n\t11 => Check \"normal\" connetion" +
                    "\n\t12 => Check \"filtered\" connection" +
                    "\n\t0 => Exit\n");
                Console.Write("Enter your command number: ");
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine(" ! ! Please enter valid number ! !");
                    Console.Clear();
                    continue;

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
                    default:
                        try
                        {
                            Console.WriteLine(" ! ! Please enter valid number ! !");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(" ! ! Please enter valid number ! !");
                        }
                        break;
                }
                //Console.WriteLine("Press any key to exit");
                //Console.ReadKey();
                Console.Clear();
            }
        }
        static public void RunCommand(string command)
        {
            try
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", $"/c {command}");
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                string result = proc.StandardOutput.ReadToEnd();
                Console.WriteLine(result);
            }
            catch (Exception objException)
            {
                throw objException;
            }
        }
    }
}
// make the user not allow to type things unless numbers : Done only for specific numbers
