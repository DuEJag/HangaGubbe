using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Hänga_Gubbe
{
    class FileSaver
    {
        List<string> myWordList = null;
        string myCategory = null;
        string myDestination = null;

        public FileSaver(string aDestination, string aCategory)
        {
            myWordList = new List<string>();

            myCategory = aCategory;
            myDestination = aDestination;

            LoadFromFile(myCategory);
        }


        private void LoadFromFile(string aCategoryName)
        {
            StreamReader fileReader = null;

            if (File.Exists(@"" + myDestination + "/" + aCategoryName + ".txt") == false)
            {
                StreamWriter fileWriter = new StreamWriter(@"" + myDestination + "/" + aCategoryName + ".txt");
                fileWriter.Close();
            }

            fileReader = new StreamReader(@"" + myDestination + "/" + aCategoryName + ".txt");

            while (fileReader.EndOfStream == false)
            {
                myWordList.Add(fileReader.ReadLine());
            }

            fileReader.Close(); //you should always close the file
        }


        private void SaveToFile(string aCategoryName)
        {
            StreamWriter fileWriter = new StreamWriter(@"" + myDestination + "/" + aCategoryName + ".txt");

            for (int wordIndex = 0; wordIndex < myWordList.Count; wordIndex++)
            {
                fileWriter.WriteLine(myWordList[wordIndex].ToString());
            }

            fileWriter.Close(); //you should always close the file
        }


        public void AddWord(string aWord)
        {
            myWordList.Add(aWord);
        }


        public void Clear()
        {
            myWordList.Clear();
        }


        public void Save()
        {
            SaveToFile(myCategory);
        }
    }
}
