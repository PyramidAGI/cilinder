using System.Collections.Generic;
using System.IO;

namespace cilinder
{
    class Counter
    {
        string mypath = "";
        public Counter(string path)
        {
            mypath = path;
        }
        List<crecord> Li = new List<crecord>();
        public List<crecord> GetLi()
        {
            return Li;
        }
        public List<crecord> Do()

        {

            StreamReader sr = new StreamReader(mypath + "input.txt");

            string line = "";

            string[] words;

            while ((line = sr.ReadLine()) != null)

            {

                words = line.Split(); //split each line into words

                foreach (var item in words) //inspect each word

                {

                    Runner(item);

                }

            }

            sr.Close();

            return Li;

        }

        public void Runner(string word)

        {
            word = word.ToLower();
            word = word.Replace(".", "");
            word = word.Replace(",", "");
            word = word.Replace(":", "");
            word = word.Replace("\"", "");
            word = word.Replace(";", "");

            ////
            bool found = false;

            foreach (var rec in Li)

            {

                if (rec.word == word)

                {

                    found = true;

                    rec.freq += 1;

                    break;

                }

            }

            if (!found)

            {

                var nwr = new crecord();

                nwr.word = word;

                nwr.freq = 1;

                Li.Add(nwr); //add record because word was not found in List

            }

        }
    }
}
