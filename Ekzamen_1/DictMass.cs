using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Ekzamen_1
{
    [Serializable]
    class DictMass
    {
        BinaryFormatter binFormat = new BinaryFormatter();
        public List<string> words { get; set; }
        public List<string> translateWords { get; }
        public List<string> secondTranslateWords { get; }
        public DictMass()
        {
            words = new List<string>();
            translateWords = new List<string>();
            secondTranslateWords = new List<string>();
        }
        public void MakeNewDict(List<string> massWords, List<string> massTranslateWords,List<string >secondMassTranslateWords) 
        {
            foreach (var i in massWords)
                words.Add(i);
            foreach (var i in massTranslateWords)
                translateWords.Add(i);
            foreach (var i in secondMassTranslateWords)
                secondTranslateWords.Add(i);
        }
        public void Show()
        {
            foreach (var i in words)
                Console.WriteLine("Слово: " + i);
            Console.WriteLine();
            foreach (var i in translateWords)
                Console.WriteLine("Перевод1: " + i);
            foreach (var i in secondTranslateWords)
                Console.WriteLine("Перевод2: " + i);
        }
        
        public void SaveToFile(DictMass temp,string filename)
        {
            using Stream fStream = File.Create(filename);
            binFormat.Serialize(fStream, this);
        }
        public DictMass WriteFromFile(string filename)
        {
            using Stream fStream = File.OpenRead(filename);
             return (DictMass)binFormat.Deserialize(fStream);
        }
    }
}
