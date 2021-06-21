using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Debug = UnityEngine.Debug;

public class SceneDataWriter
{
    /// <summary>
    /// Loads a class from a flat file as a binary object.
    /// </summary>
    /// <typeparam name="T">Type of class</typeparam>
    /// <param name="filename">Name of the file we want to load from</param>
    /// <returns></returns>
    public static T Load<T>(string filename) where T : class
    {
        if (!File.Exists(filename))
            return default(T);  //Default probably will be a null

        try 
        {
            //Create a stream that is reading from the file specified by the user
            using (Stream inputStream = File.OpenRead(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(inputStream) as T;
            }

        }
        catch (Exception e)
        {
            Debug.LogError("SceneDataWriter: Error with file " + e.Message);
            return default(T);
        }
    }


    //Saving files (save class to a filename with data from the class)
    /// <summary>
    /// Saves the data from a specific class with its data to a file.
    /// </summary>
    /// <typeparam name="T">Type of class</typeparam>
    /// <param name="filename">Name of the file we want to write to</param>
    /// <param name="data">The data that needs to be written to the specified file</param>
    public static void Save<T> (string filename, T data) where T : class
    {
        using (Stream outputStream = File.OpenWrite(filename))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(outputStream, data);
        }
    }
}
