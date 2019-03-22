using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace aplikacja_przychodnia
{
    public static class BinarySerializer<T>
    {
        //serializacja binarna
        public static void Serialize(string path, T obj)
        {

            if (obj != null)
            {

                using (var fs = new FileStream(path, FileMode.Create))
                {

                    var bf = new BinaryFormatter();

                    bf.Serialize(fs, obj);

                }

            }

        }
        //desreializacja binarna
        public static T Deserialize(string path)
        {

            T temp = default(T);

            if (File.Exists(path))
            {

                using (var fs = new FileStream(path, FileMode.Open))
                {

                    if (fs.Length > 0)
                    {

                        var bf = new BinaryFormatter();

                        return (T)bf.Deserialize(fs);

                    }

                }

            }

            return temp;

        }

    }
}
