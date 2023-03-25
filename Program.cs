using System.Diagnostics;
using System.IO;

namespace Binary_Insortion_Sort;

public static class Sort
{
    public class Program
    {
        public static void Main()
        {
            string inputFile = "/Users/arturminnusin/RiderProjects/Binary Insertion Sort/bin/Debug/net7.0/Data";
            string outputFile = "/Users/arturminnusin/RiderProjects/Binary Insertion Sort/bin/Debug/net7.0/SortArray.txt";
            string diagnosticFile = "/Users/arturminnusin/RiderProjects/Binary Insertion Sort/bin/Debug/net7.0/Diagnostic.txt";

            GenerateDataInFile(inputFile);
            SortAllArrays(inputFile, outputFile, diagnosticFile);
        }
        
        public static int[] BinaryInsortionSort(int[] mas)
        {
            Stopwatch time = new Stopwatch();
            var iter = 0;
            
            time.Start();
            for (int i = 1; i < mas.Length; i++)
            {
                var low = 0;
                var high = i - 1;
                var cur = mas[i];

                while (low <= high)
                {
                    iter++;
                    int mid = (low + high) / 2;

                    if (cur < mas[mid])
                        high = mid - 1;
                    else
                        low = mid + 1;
                }

                for (int j = i - 1; j >= low; j--)
                {
                    mas[j + 1] = mas[j];
                    iter++;
                }
                
                mas[low] = cur;
            }

            iter += mas.Length;
            time.Stop();

            var x = new int[3] {mas.Length, iter, (int)time.ElapsedTicks};

            return x;
        }

        public static void SortAllArrays(string input, string output ,string diagnostic)
        {
            StreamReader file = new StreamReader(input);
            StreamWriter file1 = new StreamWriter(output);
            StreamWriter fileD = new StreamWriter(diagnostic);
            while (!file.EndOfStream)
            {
                var line = file.ReadLine().Split(",");
                var a = new int[line.Length];
                
                for (int i = 0; i < a.Length; i++)
                    a[i] = int.Parse(line[i]);
               
                var d = BinaryInsortionSort(a);

                foreach (var item in d)
                {
                    fileD.Write(item + ",");
                }
                fileD.WriteLine();
                
                for (int i = 0; i < a.Length; i++)
                {
                    if (a.Length - i != 0)
                        file1.Write(a[i] + ",");
                    else
                        file1.Write(a[i]);
                }
                
                file1.WriteLine();
                file1.WriteLine("------------------------------------------------------------");
            }
            file.Close();
            file1.Close();
            fileD.Close();
        }
        
        public static void GenerateDataInFile(string fileName)
        {
            if (fileName == null)
                throw new ArgumentException("Нет имени файла!");
        
            int counter1 = 0;
            int counter2 = 100;
            StreamWriter file = new StreamWriter(fileName);
            Random r = new Random();
        
            while (counter1 < 100)
            {
                for (int i = 0; i < counter2; i++)
                {
                    var item = r.Next(1, 10);
                    if(counter2 - i != 1)
                        file.Write(item + ",");
                    else
                        file.Write(item);
                
                }
                file.WriteLine();
                counter1++;
                counter2 += 99;
            }
            file.Close();
        }
    }
}
