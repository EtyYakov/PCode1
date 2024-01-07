using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fib
{
    internal class fibClass
    {
        public fibClass() { }

        public string allF(string note,string result, string item, string space,string author)
        {
            string[] lines;
            string allFiles = "";
            if(author != "")
            {
                allFiles += author;
            }
            if ( note == "yes")
            {
                switch (result)
                {
                    case "py":
                        allFiles += "#";
                        break;
                    case "ipynb":
                        allFiles += "#";
                        break;
                    case "cpp":
                        allFiles += "//";
                        break;
                    case "cs":
                        allFiles += "//";
                        break;
                    case "js":
                        allFiles += "//";
                        break;
                    default: break;

                }
                allFiles += item;
                allFiles += Environment.NewLine;
            }
            if (space == "yes")
            {
                lines = File.ReadAllLines(item);
                var nonEmptyLines = lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
                foreach (var item1 in nonEmptyLines)
                {
                    allFiles += item1;
                    allFiles += Environment.NewLine;
                }
            }
            else
            {
                allFiles += File.ReadAllText(item);
            }
            return allFiles;
        }
       

        public string resturnTowrite(string[] dirs, string[] langriges, string note, string result,string space,string author)
        {
            
            string allFiles = "";
            foreach (var item in dirs)
            {
                if (langriges[0] != "all")
                {
                    foreach (var lan in langriges)
                    {
                        if (item.EndsWith(lan))
                        {
                            allFiles=allF(note, result,item, space, author);
                        }
                    }
                }
                else
                {
                    allFiles = allF(note, result, item,space, author);
                }
            }
            return allFiles;
        }
    }
}
