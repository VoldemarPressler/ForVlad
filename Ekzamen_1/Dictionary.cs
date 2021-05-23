using System;
using System.Collections.Generic;
using System.Text;

namespace Ekzamen_1
{
    [Serializable]
    public class Dictionary
    {
        
        DictMass diction;
        private string Type { set; get; }
        public Dictionary()
        {
            diction = new DictMass(); 
        }
        public void MakeNewDict(List<string> massWords, List<string> massTranslateWords,List<string> secondMassTranslateWords)
        {
            diction.MakeNewDict(massWords, massTranslateWords, secondMassTranslateWords); 
        }
        
        public List<string> FindTranslate(string findWord)
        {
            List<string> temp = new List<string>();
            for(int i = 0; i < diction.words.Count; ++i)
            {
                if (diction.words[i] == findWord)
                {
                    temp.Add(diction.translateWords?[i]);
                    temp.Add(diction.secondTranslateWords?[i]);
                    break;
                }
                else if (diction.translateWords[i] == findWord)
                {
                    temp.Add(diction.words?[i]);
                    temp.Add(diction.secondTranslateWords?[i]);
                    break;
                }
                else if (diction.secondTranslateWords[i] == findWord)
                {
                    temp.Add(diction.words?[i]);
                    temp.Add(diction.translateWords?[i]);
                    break;
                }
                if(i == diction.words.Count)
                    throw new Exception("Нет такого слова!");
            }
            foreach (var i in temp)
                if(i != "")Console.WriteLine("Слово: " + i);
            return temp;
        }
        public void ReplaceWord(string findWord, string replaceWord)
        {
            string temp = "";
            for (int i = 0; i < diction.words.Count; ++i)
            {
                if (diction.words[i] == findWord)
                {
                    diction.words[i] = replaceWord;
                    break;
                }
                else if (diction.translateWords[i] == findWord)
                {
                    diction.translateWords[i] = replaceWord;
                    break;
                }
                else if (diction.secondTranslateWords[i] == findWord)
                {
                    diction.secondTranslateWords[i] = replaceWord;
                    break;
                }
                if (i == diction.words.Count)
                    throw new Exception("Нет такого слова!");
            }
            Console.WriteLine("Слово заменено на " + replaceWord);
        }
        public void DeleteWord(string findWord)
        {
            for (int i = 0; i < diction.words.Count; ++i)
            {
                if (diction.words[i] == findWord)
                {
                    diction.words.Remove(findWord);
                    diction.translateWords.Remove(diction.translateWords[i]);
                    diction.secondTranslateWords.Remove(diction.secondTranslateWords[i]);
                    break;
                }
                else if (diction.translateWords[i] == findWord)
                {
                    if (diction.secondTranslateWords[i] != "")
                        diction.translateWords[i] = "";
                    break;
                }
                else if (diction.secondTranslateWords[i] == findWord)
                {
                    if (diction.translateWords[i] != "")
                        diction.secondTranslateWords[i] = "";
                    else throw new Exception("Это единственный вариант перевода"); 
                    break;
                }
                if (i == diction.words.Count)
                    throw new Exception("Нет такого слова!");
            }
        }
        public void Show()
        {
            diction.Show();
        }
        public void Save(string filename)
        {
            DictMass temp = new DictMass();
            diction.SaveToFile(temp, filename);
            //SaveToFiles a = new SaveToFiles();
            //a.SaveToFile(diction,filename);
        }
        public void Read(string filename)
        {
            diction.WriteFromFile(filename);
        }
    }
}
