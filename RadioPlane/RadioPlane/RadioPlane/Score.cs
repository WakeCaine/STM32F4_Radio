using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RadioPlane
{
    class Score
    {
        string path = "score.txt";
        public List<string> Scoress;
        public int[] intScores;
        const int N = 11;
        FileStream file;
        StreamReader rFile;
        StreamWriter wFile;

        public Score()
        {
            Scoress = new List<string>();
            intScores = new int[N];
            for (int i = 0; i < N; i++) intScores[i] = 0;
            LoadScore();
            stringToInt();
        }

        public int ConvertToInt(string line)
        {
            int i = 0;
            string number = "";
            while (line[i] != (char)32)
            {
                number += line[i];
                i++;
            }
            return Convert.ToInt32(number);
        }

        public void stringToInt()
        {
            for (int i = 0; i < Scoress.Count; i++)
            {
                intScores[i] = ConvertToInt(Scoress[i]);
            }
        }

        public void Sort()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N-1; j++)
                {
                    if (intScores[j] == 0 || intScores[j + 1] == 0) break;
                    if (intScores[j] < intScores[j + 1])
                    {
                        int temp = intScores[j];
                        intScores[j] = intScores[j+1];
                        intScores[j+1] = temp;
                        string tmp = Scoress[j];
                        Scoress[j] = Scoress[j+1];
                        Scoress[j+1] = tmp;
                    }
                }
            }
        }

        public void LoadScore()
        {
            file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            rFile = new StreamReader(file);
            while (!rFile.EndOfStream)
            {
                Scoress.Add(rFile.ReadLine());
            }
            rFile.Close();
        }

        public void AddScore(string s)
        {
            DateTime czas = DateTime.Now;
            Scoress.Add(s + " - " + czas.ToString());
            if(intScores[10] != 0) intScores[10] = Convert.ToInt32(s);
            else {
                for (int i = 0; i < N; i++)
                {
                    if (intScores[i] == 0) { intScores[i] = Convert.ToInt32(s); break; }
                }
            }
            Sort();
            if (Scoress.Count > 10) Scoress.RemoveAt(Scoress.Count-1);
            SaveScore();
        }

        public void SaveScore()
        {
            file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            wFile = new StreamWriter(file);
            for (int i = 0; i < Scoress.Count; i++)
            {
                wFile.WriteLine(Scoress[i]);
            }
            wFile.Close();
        }
        public void ReloadList()
        {
            Scoress.RemoveRange(0, Scoress.Count);
            LoadScore();
        }
    }
}
