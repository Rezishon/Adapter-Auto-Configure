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

                var chosenStr = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .PageSize(10)
                        .HighlightStyle(Style.Parse(Color.Purple.ToString()))
                        .AddChoices(
                            new[]
                            {
                                "Wifi => IP & DNS",
                                "Wifi => DNS",
                                "nEthernet => IP & DNS",
                                "nEthernet => DNS",
                                "Additional Tools",
                                "Exit"
                            }
                        )
                );

                switch (partNumbers[chosenStr])
                {
                    case 0:
                        Dictionary<string, int> wifiPartNumbers = new Dictionary<string, int>()
                        {
                            { "Wifi [bold blue]IP & DNS[/] goes on [bold green]DHCP[/]", 1 },
                            {
                                "Wifi [bold blue]IP & DNS[/] goes on [bold green]Home network config[/]",
                                2
                            },
                            {
                                "Wifi [bold blue]IP & DNS[/] goes on [bold green]Payaneh network config[/]",
                                3
                            },
                        };

                        var wifiChosenStr = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .PageSize(5)
                                .HighlightStyle(Style.Parse(Color.Purple.ToString()))
                                .AddChoices(
                                    new[]
                                    {
                                        "Wifi [bold blue]IP & DNS[/] goes on [bold green]DHCP[/]",
                                        "Wifi [bold blue]IP & DNS[/] goes on [bold green]Home network config[/]",
                                        "Wifi [bold blue]IP & DNS[/] goes on [bold green]Payaneh network config[/]",
                                        "Main menu"
                                    }
                                )
                        );

                        number =
                            wifiChosenStr == "Main menu" ? 777 : wifiPartNumbers[wifiChosenStr];
                        break;

                    case 1:
                        Dictionary<string, int> wifiDNSPartNumbers = new Dictionary<string, int>()
                        {
                            { "Wifi [bold blue]DNS[/] goes on [bold green]Shecan[/]", 6 },
                            { "Wifi [bold blue]DNS[/] goes on [bold green]Normal config[/]", 8 },
                        };

                        var wifiDNSChosenStr = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .PageSize(5)
                                .HighlightStyle(Style.Parse(Color.Purple.ToString()))
                                .AddChoices(
                                    new[]
                                    {
                                        "Wifi [bold blue]DNS[/] goes on [bold green]Shecan[/]",
                                        "Wifi [bold blue]DNS[/] goes on [bold green]Normal config[/]",
                                        "Main menu"
                                    }
                                )
                        );

                        number =
                            wifiDNSChosenStr == "Main menu"
                                ? 777
                                : wifiDNSPartNumbers[wifiDNSChosenStr];
                        break;

                    case 2:
                        Dictionary<string, int> ethernetPartNumbers = new Dictionary<string, int>()
                        {
                            { "Ethernet [bold blue]IP & DNS[/] goes on [bold green]DHCP[/]", 5 },
                            {
                                "Ethernet [bold blue]IP & DNS[/] goes on [bold green]Payaneh network config[/]",
                                4
                            },
                        };

                        var ethernetChosenStr = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .PageSize(5)
                                .HighlightStyle(Style.Parse(Color.Purple.ToString()))
                                .AddChoices(
                                    new[]
                                    {
                                        "Ethernet [bold blue]IP & DNS[/] goes on [bold green]DHCP[/]",
                                        "Ethernet [bold blue]IP & DNS[/] goes on [bold green]Payaneh network config[/]",
                                        "Main menu"
                                    }
                                )
                        );

                        number =
                            ethernetChosenStr == "Main menu"
                                ? 777
                                : ethernetPartNumbers[ethernetChosenStr];
                        break;

                    case 3:
                        Dictionary<string, int> ethernetDNSPartNumbers = new Dictionary<
                            string,
                            int
                        >()
                        {
                            { "Ethernet [bold blue]DNS[/] goes on [bold green]Shecan[/]", 7 },
                            { "Ethernet [bold blue]DNS[/] goes on [bold green]Normal config[/]", 9 }
                        };

                        var ethernetDNSChosenStr = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .PageSize(5)
                                .HighlightStyle(Style.Parse(Color.Purple.ToString()))
                                .AddChoices(
                                    new[]
                                    {
                                        "Ethernet [bold blue]DNS[/] goes on [bold green]Shecan[/]",
                                        "Ethernet [bold blue]DNS[/] goes on [bold green]Normal config[/]",
                                        "Main menu"
                                    }
                                )
                        );

                        number =
                            ethernetDNSChosenStr == "Main menu"
                                ? 777
                                : ethernetDNSPartNumbers[ethernetDNSChosenStr];
                        break;

                    case 4:
                        Dictionary<string, int> additionalToolsNumbers = new Dictionary<
                            string,
                            int
                        >()
                        {
                            { "Reset network adapter", 10 },
                            { "Ping Soft98.ir", 11 },
                            { "Ping Youtube.com", 12 }
                        };

                        var additionalToolsChosenStr = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .PageSize(5)
                                .HighlightStyle(Style.Parse(Color.Purple.ToString()))
                                .AddChoices(
                                    new[]
                                    {
                                        "Reset network adapter",
                                        "Ping Soft98.ir",
                                        "Ping Youtube.com",
                                        "Main menu"
                                    }
                                )
                        );

                        number =
                            additionalToolsChosenStr == "Main menu"
                                ? 777
                                : additionalToolsNumbers[additionalToolsChosenStr];
                        break;

                    default:
                        number = 0;
                        break;
                }

                switch (number)
                {
                    case 0:
                        flag = false;
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
