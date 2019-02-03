using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Framework.API
{
    public class Data
    {


        public class PostsData
        {
            public static IEnumerable Posts
            {
                get
                {
                    var reader = new StreamReader(Path.Combine(ConfigurationAPI.testDataPath, "postsData.csv"));
                    List<int> Ids = new List<int>();
                    List<int> userIds = new List<int>();
                    List<string> titles = new List<string>();
                    List<string> bodies = new List<string>();
                    while(!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        Ids.Add(int.Parse(values[0]));
                        userIds.Add(int.Parse(values[1]));
                        titles.Add(values[2]);
                        bodies.Add(values[3]);
                    }
                    for (int i = 0; i < Ids.Count; i++)
                    {
                        yield return new TestCaseData(Ids[i], userIds[i], titles[i], bodies[i]);
                    }
                }
            }
        }
    }
}
