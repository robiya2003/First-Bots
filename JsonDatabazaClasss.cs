using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class JsonDatabazaClasss
    {
        public static string path = @"C:\Users\LENOVO\Desktop\BOT\ConsoleApp1\JsonDataBaza.json";

        public static bool Checking(long id)
        {
            string StringJson = File.ReadAllText(path);
            var JsonList = JsonConvert.DeserializeObject<List<Userr>>(StringJson);
            foreach (var el in JsonList)
            {
                if (el.chatid == id) { return false; }
            }
            return true;

        }
        public static void Apppend(long id, string n, string p)
        {
            string StringJson = File.ReadAllText(path);
            var JsonList = JsonConvert.DeserializeObject<List<Userr>>(StringJson);
            JsonList.Add(new Userr()
            {
                chatid = id,
                phonenumber = p,
                firstname = n,

            });
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(JsonConvert.SerializeObject(JsonList));
            }
        }
        public static string GetMe(long id)
        {
            string s = "";
            string StringJson = File.ReadAllText(path);
            var JsonList = JsonConvert.DeserializeObject<List<Userr>>(StringJson);
            foreach (var el in JsonList)
            {
                if (el.chatid == id) 
                {
                    s= s+"Chat Id : "+el.chatid +"\nName : "+ el.firstname+"\n Phone Number : "+el.phonenumber;
                }
            }
            return s;
        }
        public static List<Userr> GetAll()
        {
            string s = "";
            string StringJson = File.ReadAllText(path);
            var JsonList = JsonConvert.DeserializeObject<List<Userr>>(StringJson);
            return JsonList;
        }
    }
}
