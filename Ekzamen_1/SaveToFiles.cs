using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Ekzamen_1
{
    class SaveToFiles
    {
        BinaryFormatter binFormat = new BinaryFormatter();
        public void SaveToFile(DictMass temp, string filename)
        {
            using Stream fStream = File.Create(filename);
            binFormat.Serialize(fStream, temp);
        }   
        public DictMass WriteFromFile(string filename)
        {
            using Stream fStream = File.OpenRead(filename);
            return (DictMass)binFormat.Deserialize(fStream);
        }
    }
}
