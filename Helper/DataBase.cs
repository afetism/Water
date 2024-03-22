using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WaterRemainder.Models;

namespace WaterRemainder.Helper
{
    internal class DataBase
    {
        public User User { get; set; }
        public string Path {  get; set; }
        public DataBase(string filePath)
        {

            Path = filePath;
            if (File.Exists(Path))
            {
                string jsonString = File.ReadAllText(Path);
                User = JsonSerializer.Deserialize<User>(jsonString);
            }
        }
        public void SavaData()
        {
          if(User is  null) return;
            string jsonString =JsonSerializer.Serialize(User);
            File.WriteAllText(Path, jsonString);
        }
    }
}