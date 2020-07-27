using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dots.Utils
{
    public static class SaveManager
    {
        public static void SaveProgress(int scores)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/save.dobro";
            FileStream stream = new FileStream(path, FileMode.Create);

            ProgressData progressData = new ProgressData(scores);
            binaryFormatter.Serialize(stream, progressData);
            stream.Close();
        }

        public static ProgressData LoadProgress ()
        {
            string path = Application.persistentDataPath + "/save.dobro";
            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                ProgressData data = binaryFormatter.Deserialize(stream) as ProgressData;
                stream.Close();
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}
