using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tools.BuilderGenerator
{
    public class Generator
    {
        public List<string > Content { get; set; }
        public string Path { get; set; }
        public TypeFormat Formato { get; set; }
        public TypeCharacter Character { get; set; }

        //guarda archivo
        public void Save()
        {
            //evaluo cual viene!
            string result = "";
            result = Formato == TypeFormat.Json ? GetJson() : GetPipes();   

            if(Character == TypeCharacter.UpperCase)
            {
                result = result.ToUpper();
            }
            else if(Character == TypeCharacter.LowerCase)
            {

                result = result.ToLower();  
            }

            File.WriteAllText(Path, result);
        }

        public string GetJson()
        {
            string result = JsonSerializer.Serialize(Content);
            return result;
        }

        public string GetPipes()
        {
            string result = Content.Aggregate((accum,actual)=> accum + "|" + actual);
            return result;
        }

        }
}
