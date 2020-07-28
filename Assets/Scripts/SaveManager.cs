using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Dots;

namespace Dots.Utils
{
    public static class SaveManager
    {
        public static void SaveProgress(int scores)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(GloalConstants.SavePath, FileMode.Create);

            ProgressData progressData = new ProgressData(scores);
            binaryFormatter.Serialize(stream, progressData);
            stream.Close();
        }

        public static ProgressData LoadProgress ()
        {
            if (File.Exists(GloalConstants.SavePath))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(GloalConstants.SavePath, FileMode.Open);

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
