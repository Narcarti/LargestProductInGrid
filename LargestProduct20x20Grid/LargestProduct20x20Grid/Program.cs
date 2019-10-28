using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestProduct20x20Grid
{
    class Program
    {
        static void Main(string[] args)
        {

            int[][] jArry = new int[20][];

            using (StreamReader sr = new StreamReader("20x20.txt"))
            {
                int jIdx = 0;

                while (!sr.EndOfStream)
                {
                    string newL = sr.ReadLine();
                    int cntL = 0;
                    if (jIdx != 20)
                    {
                        string[] splLine = newL.Split(' ');
                        //int[] cnvtInt = new int[20];
                        jArry[jIdx] = new int[20];
                        foreach (string item in splLine)
                        {
                            jArry[jIdx][cntL] = int.Parse(item);
                            cntL++;
                        }
                        
                        //splLine.CopyTo(jArry[jIdx], 0);
                        jIdx++;
                    }
                }
            }
            
            int tmp1 = 0;
            int tmp2 = 0;
            long prod = 0;
            for (int arrIdx = 0; arrIdx < 20; arrIdx++)
            {
                for (int pos = 0; pos < 20; pos++)
                {
                    if (pos < 17)//checks from left to right
                    {
                        tmp1 = jArry[arrIdx][pos] * jArry[arrIdx][pos + 1] * jArry[arrIdx][pos+2] * jArry[arrIdx][pos+3];
                        if(tmp1 > prod) { prod = tmp1; }
                    }
                    if (arrIdx < 17)//checks down
                    {
                        tmp1 = jArry[arrIdx][pos] * jArry[arrIdx+1][pos ] * jArry[arrIdx+2][pos] * jArry[arrIdx+3][pos];
                        if (tmp1 > prod) { prod = tmp1; }
                    }
                    if (arrIdx< 17 && pos<17)//check diag down
                    {
                        tmp1 = jArry[arrIdx][pos] * jArry[arrIdx + 1][pos+1] * jArry[arrIdx + 2][pos+2] * jArry[arrIdx + 3][pos+3];
                        if (tmp1 > prod) { prod = tmp1; }
                    }
                    if (arrIdx>2 && pos<17)//check diag up
                    {
                        tmp1 = jArry[arrIdx][pos] * jArry[arrIdx - 1][pos + 1] * jArry[arrIdx - 2][pos + 2] * jArry[arrIdx -3][pos + 3];
                        if (tmp1 > prod) { prod = tmp1; }
                    }
                }
            }
            Console.WriteLine(prod);
            Console.ReadLine();
        }
    }
}
