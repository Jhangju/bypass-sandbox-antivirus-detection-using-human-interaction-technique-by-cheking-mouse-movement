using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows;

namespace checksmousemovement
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        public struct POINT
        {
            public int X;
            public int Y;
        }

        static void Main(string[] args)
        {
            POINT current_pos, prev_pos;
            List<POINT> coords = new List<POINT>();

            prev_pos.X = 0;
            prev_pos.Y = 0;
            int i= 0;

            do
            {
               
                if (GetCursorPos(out current_pos))
                {

                    if ((current_pos.X != prev_pos.X) || (current_pos.Y != prev_pos.Y))
                    {
                        if (i==100)
                        {
                            go("start cmd");
                            go("start chrome");
                            //MessageBox.Show("Run malware");
                            break;
                        }
                      //  Console.WriteLine("({0},{1})", current_pos.X, current_pos.Y);
                        coords.Add(current_pos);
                        i++;
                    }
                    
                    prev_pos.X = current_pos.X;
                    prev_pos.Y = current_pos.Y;
                }

            } while (true);
            
            //Console.ReadKey();

           // Console.WriteLine("Press any key to play the recorded mouse positions.");
            //Console.ReadKey();
           // foreach (POINT coord in coords)
           // {
              //  SetCursorPos(coord.X, coord.Y);
             //   System.Threading.Thread.Sleep(50);
             //   if (Console.KeyAvailable) break;
            //}

           // Console.WriteLine("Ended");
           // Console.WriteLine("Ended");
           // Console.ReadLine();

        }
        public static void go(string com)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(com);
        }
    }
}