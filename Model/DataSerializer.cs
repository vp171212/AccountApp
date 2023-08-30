using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp.Model
{
    internal class DataSerializer
    {
        public static void BinarySerializer(Account data, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, data);
            }
        }

        public static Account BinaryDeserialize(string filePath)
        {
            Account accountDetails = null;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                accountDetails = (Account)bf.Deserialize(fs);
            }
            return accountDetails;
        }
    }
}
