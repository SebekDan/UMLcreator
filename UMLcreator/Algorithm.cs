using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLcreator
{
    class Algorithm
    {
        /*
                   .--._.--.
                  ( O     O )
                  /   . .   \
                 .`._______.'.
                /(           )\
              _/  \  \   /  /  \_
           .~   `  \  \ /  /  '   ~.
          {    -.   \  V  /   .-    }
        _ _`.    \  |  |  |  /    .'_ _
        >_       _} |  |  | {_       _<
         /. - ~ ,_-'  .^.  `-_, ~ - .\
                 '-'|/   \|`-`
        */
        private static string hippityHoppityGiveMeMyProperty(string modifierString, string[] words)
        {
            for (int i = 1; i < words.Length; i++)
            {

                if (!Enum.IsDefined(typeof(Keywords), words[i])&&i+1<words.Length)
                {
                    return modifierString + words[i + 1] + " : " + words[i];
                }
            }
            return "";
        }

        public static void CreateVariables(string fileinput, string fileoutput)
        {
            StreamReader sr = new StreamReader(fileinput);
            StreamWriter sw = new StreamWriter(fileoutput);
            string line1;
            string line2;
            string[] words;
            string f1;

            line1 = sr.ReadLine();
            while ((line2 = sr.ReadLine()) != null)
            {
                words = line1.Trim().Split(" ");
                line2= line2.Trim();
                f1 = Type(words);

                if (f1.Contains("public") && line2 != "{"&&!line2.Contains("//"))
                {
                    sw.WriteLine(hippityHoppityGiveMeMyProperty("+", words));
                    sw.Flush();
                }
                if (f1.Contains("private") && line2 != "{" && !line2.Contains("//"))
                {
                    sw.WriteLine(hippityHoppityGiveMeMyProperty("-", words));
                    sw.Flush();
                }
                if (f1.Contains("protected") && line2 != "{" && !line2.Contains("//"))
                {
                    sw.WriteLine(hippityHoppityGiveMeMyProperty("#", words));
                    sw.Flush();
                }
                line1 = line2;
            }

            sw.WriteLine("####################################################################################################################");
            sw.Close();
            sr.Close();
        }

        public static void CreateMethods(string fileinput, string fileoutput)
        {
            StreamReader sr = new StreamReader(fileinput);
            StreamWriter sw = new StreamWriter(fileoutput, true);
            string line = "";
            string[] words;
            string f1 = "";
            while ((line = sr.ReadLine()) != null)
            {
                words = line.Split(" ");
                f1 = Type(words);
                if (f1.Contains("public"))
                {
                    if (line.Contains("("))
                    {

                        words = ClassName(words);
                        int i = words[1].IndexOf('(');
                        words[1] = words[1].Substring(0, i);
                        string final = ("+" + words[1] + "() : " + words[0]);
                        sw.WriteLine(final);
                        sw.Flush();



                    }



                }
                if (f1.Contains("protected"))
                {
                    if (line.Contains("("))
                    {

                        words = ClassName(words);
                        int i = words[1].IndexOf('(');
                        words[1] = words[1].Substring(0, i);
                        string final = ("#" + words[1] + "() : " + words[0]);
                        sw.WriteLine(final);
                        sw.Flush();

                    }

                }
                if (f1.Contains("private"))
                {
                    if (line.Contains("("))
                    {
                        words = ClassName(words);
                        int i = words[1].IndexOf('(');
                        words[1] = words[1].Substring(0, i);
                        string final = ("-" + words[1] + "() : " + words[0]);
                        sw.WriteLine(final);
                        sw.Flush();

                    }

                }





            }
            sr.Close();
            sw.Close();




        }




        public static string[] ClassName(string[] words)
        {
            string[] x = new string[2];
            int x1 = 0;
            foreach (string s in words)
            {
                if (s.Contains("("))
                {
                    x[0] = words[x1 - 1];
                    x[1] = s;

                }
                x1++;
            }


            return x;
        }
        public static string Type(string[] words)
        {
            string x = "";
            foreach (string s in words)
            {
                if (s != string.Empty)
                {
                    x = s;


                    break;
                }
            }



            return x;
        }


    }
}
