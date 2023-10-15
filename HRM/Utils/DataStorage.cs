using Newtonsoft.Json;

namespace HRM.Utils
{
    public static class DataStorage<T> where T : class
    {

        public static void SaveData(string path, T data)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(new List<T>() { data });
                File.WriteAllText(path, jsonData);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred while saving data: {e.Message}");
            }
        }

        public static void SaveData(string path, List<T> data)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(data);
                File.WriteAllText(path, jsonData);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred while saving data: {e.Message}");
            }
        }

        public static List<T> LoadData(string path)
        {

            try
            {
                if (File.Exists(path))
                {
                    string jsonData = File.ReadAllText(path);
                    return JsonConvert.DeserializeObject<List<T>>(jsonData);
                }

                return new List<T>();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred while loading data: {e.Message}");
            }

            return new List<T>();
        }
    }
}
