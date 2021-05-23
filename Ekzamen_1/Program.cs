using System;
using System.Collections.Generic;
namespace Ekzamen_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> mass1 = new List<string>();
            List<string> mass2 = new List<string>();
            List<string> mass3 = new List<string>();
            mass1.Add("cat");
            mass1.Add("dog");
            mass2.Add("кошка");
            mass2.Add("собака");
            mass3.Add("");
            mass3.Add("песель");
            Dictionary dict = new Dictionary();
            dict.MakeNewDict(mass1, mass2,mass3);
            dict.Show();
            //dict.Save("testSave.bin");
        }   
    }
}
