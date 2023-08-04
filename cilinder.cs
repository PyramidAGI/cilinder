using System;
using System.Collections.Generic;
using System.IO;

namespace cilinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\argonaut\";
            Counter cnt = new Counter(documentsPath);
            List<string> li = new List<string>();
            List<flowfieldrecord> ff = new List<flowfieldrecord>();
            StreamReader sr = new StreamReader(documentsPath + "cilinder.txt");
            string line = "";
            while ((line=sr.ReadLine())!=null)
            {
                li.Add(line);
            }
            sr.Close();
            //-----------
            StreamReader sr2 = new StreamReader(documentsPath + "flowfield.txt");
            line = "";
            string[] word;
            while ((line = sr2.ReadLine()) != null)
            {
                var rec = new flowfieldrecord();
                word = line.Split('|');
                rec.ffid = word[0];
                rec.cardid = word[1];
                rec.e0 = word[2];
                rec.e1 = word[3];
                rec.e2 = word[4];
                rec.e3 = word[5];
                rec.val = Convert.ToByte(word[6]);
                rec.perc = Convert.ToByte(word[7]);
                rec.nlsentence = word[8];
                ff.Add(rec);
            }
            sr2.Close();
            string message = "";

            string[] sentpart;
            while (message !="q")
            {
                Console.WriteLine("please give your input");
                message = Console.ReadLine();
                foreach (var item in li)
                {
                    sentpart = item.Split('|');
                    if (sentpart[0].Contains(message)) //search in first part of record
                    {
                        Console.WriteLine(" found line = " + item);
                    }
                }
            }
            //ptd: test: print flowfield records
            string flowfield_e2 = "";
            StreamWriter sw = new StreamWriter(documentsPath + "input.txt"); //used to store quark hits in and used by counter.cs
            foreach (var item in ff)
            {
                Console.WriteLine("flowfield rec = " + item.e1 + " ; " + item.cardid + " ; "+ item.nlsentence);
                //stack element e2
                flowfield_e2 += item.e2 + " ";
                sw.WriteLine(item.e2);
            }
            sw.Close();
            Console.WriteLine("stacked flowfield e2 = " + flowfield_e2);
            //PTD: TTD: implement freq count here
            List<crecord> freq = cnt.Do();
            int maxfreq = 0;
            string maxquark = "";
            foreach (var item in freq)
            {
                Console.WriteLine(item.word + "; freq = " + item.freq);
                int freqint = Convert.ToInt32(item.freq);
                if (freqint > maxfreq)
                {
                    maxfreq = freqint;
                    maxquark = item.word;
                }
            }
            Console.WriteLine("the most traction is detected on : " + maxquark + " with freq = " + maxfreq.ToString());
            Console.ReadLine();
        }
    }
}

//C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe cilinder.cs counter.cs crecord.cs flowfieldrecord.cs