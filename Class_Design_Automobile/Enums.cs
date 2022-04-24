using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Design_Automobile
{
    enum Marks { Mercedes, BMW, Shevrolet };
    enum BodyVersions { Sedan, Hatchback, Minivan };
    enum Motors { Petrol, Diesel, Gas, Electric };

    static class EnumText
    {

        public static string[] GetEnumText(Enum element)
        {
            string path = @"";

            using (StreamReader fstream = new(path))
            {
                string answer = "";
                try
                {
                    switch (element)
                    {
                        case Marks:
                            answer = File.ReadLines(path).Skip(0).First();
                            break;
                        case BodyVersions:
                            answer = File.ReadLines(path).Skip(1).First();
                            break;
                        case Motors:
                            answer = File.ReadLines(path).Skip(2).First();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка");
                }

                return answer.Split(", ");
            }

        }

        public static string GetEnumElementText(Marks mark) => GetEnumText(mark)[(int)mark];
        
        public static string GetEnumElementText(BodyVersions version) => GetEnumText(version)[(int)version];
        
        public static string GetEnumElementText(Motors motor) => GetEnumText(motor)[(int)motor];
        
    }
}
