using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiles_testing
{
    class Program
    {
        static void Main()
        {
            //Files paths
            const string file = @"C:\Users\Abdelrahman\Desktop\movie_lines.txt",
                            O = @"C:\Users\Abdelrahman\Desktop\O.txt";
            string go;

            string[] lines;

            lines = System.IO.File.ReadAllLines(file);
            for (int i = 0; i < lines.Count(); i++)
            {
                go = "\0";
                
                for (int j = lines[i].Count() - 1; j >= 0; j--)
                {
                    if (lines[i][j] == ' ' && lines[i][j - 1] == ' ')
                        continue;
                    

                    if (lines[i][j] == '-' && lines[i][j - 1] == ' ')
                        continue;
                    else if (lines[i][j] == '-' && lines[i][j - 1] == '-')
                        continue;
                    else if (lines[i][j] == '-' && lines[i][j - 1] != ' ' && (Char.IsNumber(lines[i][j - 1]) || Char.IsLetter(lines[i][j - 1])))
                    {
                        go = ' ' + go;
                        continue;
                    }
                    
                    if (lines[i][j] == '>')
                        for (; j >= 0; j--)
                        {
                            if(lines[i][j]=='<')
                            {
                                j--;
                                break;
                            }
                        }
                    if (lines[i][j] != '+')
                        go = lines[i][j] + go;
                    else if (lines[i][j - 1] == '+')
                    {
                        go = go.Substring(1, go.Count() - 2);
                        break;
                    }
                }

                using (System.IO.StreamWriter s = new System.IO.StreamWriter(O, true))
                {
                    s.WriteLine(go);
                }
                Console.Write(go+"\n");
            }

        }

    }
}