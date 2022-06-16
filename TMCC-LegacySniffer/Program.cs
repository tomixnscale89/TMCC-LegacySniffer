using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace TMCC_LegacySniffer
{
    // Based upon Microsoft Sample: https://docs.microsoft.com/en-us/dotnet/api/system.io.ports.serialport.datareceived?view=dotnet-plat-ext-6.0
    internal class Program
    {
        public static void Main()
        {
            bool exit = false;
            string comStringNum = "COM";
            Console.WriteLine("TMCC/Legacy Sniffer. Make sure your DB9 cable is connected to the LIONEL SER2, BASE 2, BASE1L, or BASE 1.");
            while (!exit)
            {
                Console.WriteLine("Enter a COM Port number to sniff: ");
                comStringNum = Console.ReadLine();
                SerialPort mySerialPort = new SerialPort("COM" + comStringNum);
                try
                {
                    mySerialPort.BaudRate = 9600;
                    mySerialPort.Parity = Parity.None;
                    mySerialPort.StopBits = StopBits.One;
                    mySerialPort.DataBits = 8;
                    mySerialPort.Handshake = Handshake.None;

                    mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                    mySerialPort.Open();

                    Console.WriteLine("Press any key to exit Sniffer...");
                    Console.WriteLine();
                    Console.ReadKey();
                    mySerialPort.Close();
                    exit = true;
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Invaid COM,try again");
                }
            }
        }

        // https://stackoverflow.com/questions/3581674/converting-a-byte-to-a-binary-string-in-c-sharp
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            int length = sp.BytesToRead;
            byte[] buf = new byte[length];

            sp.Read(buf, 0, length);
            Console.WriteLine("Hex: " + BitConverter.ToString(buf));
            Console.Write("Binary: ");
            for(int i = 0; i < length; i++)
            {
                Console.Write(" " + Convert.ToString(buf[i], 2).PadLeft(8, '0'));
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
