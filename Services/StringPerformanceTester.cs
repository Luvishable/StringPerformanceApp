using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPerformanceApp.Services
{
    public class StringPerformanceTester
    {
        private readonly int _logCount;

        public StringPerformanceTester(int logCount)
        {
            _logCount = logCount;
        }

        public void RunAllTests()
        {
            Console.WriteLine($"Toplam {_logCount} log satırı oluşturulacak...\n");

            RunStringPlusTest();
            RunInterpolatedStringTest();
            RunAppendFormatTest();
            WriteToFileWithStringBuilder();
        }

        public void RunStringPlusTest()
        {
            Stopwatch sw = Stopwatch.StartNew();

            string result = "";
            for (int i = 0; i < _logCount; i++)
            {
                result += "[INFO] Log Line " + i + "\n";
            }
            sw.Stop();
            Console.WriteLine($"[string + ] time elapsed: {sw.ElapsedMilliseconds} ms");
        }

        public void RunInterpolatedStringTest()
        {
            Stopwatch sw = Stopwatch.StartNew();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _logCount; i++)
            {
                sb.AppendLine($"[INFO] Log Line {i}");
            }

            sw.Stop();
            Console.WriteLine($"[interpolated + StringBuilder] süresi: {sw.ElapsedMilliseconds} ms");
        }

        public void RunAppendFormatTest()
        {
            Stopwatch sw = Stopwatch.StartNew();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _logCount; i++)
            {
                sb.AppendFormat("[INFO] Log Line {0}\n", i);
            }

            sw.Stop();
            Console.WriteLine($"[AppendFormat] süresi: {sw.ElapsedMilliseconds} ms");
        }

        public void WriteToFileWithStringBuilder()
        {
            Stopwatch sw = Stopwatch.StartNew();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _logCount; i++)
            {
                sb.AppendLine($"[INFO] Log satırı {i}");
            }

            File.WriteAllText("log-output.txt", sb.ToString());

            sw.Stop();
            Console.WriteLine($"[Dosyaya yazım] süresi: {sw.ElapsedMilliseconds} ms");
        }
    } }
