using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.IO;

namespace InterviewQuestions
{
    class GetQuestions
    {
        // start process to get questions
        public void startGetQuestions()
        {
            getQuestions(getURLSDict());
            //tmpGetQuest();
        }

        private void tmpGetQuest()
        {
            HtmlWeb web = new HtmlWeb();
            var document = new HtmlDocument();
            document.Load(@"C:\Users\Administrator\Desktop\New Text Document (3).html");
            List<HtmlNode> data1 = document.DocumentNode.SelectNodes("//div[@class='post-excerpt']//td").ToList();


            //tst1(document);
            List<HtmlNode> data = getNodes(document);

            List<string> points = new List<string>();

            for (int i = 0; i < data.Count - 1; i++)
            {
                string tst = formatText(data[i]);
                if (!string.IsNullOrWhiteSpace(tst))
                {
                    points.Add(tst);
                }
            }

            List<Question> questions = new List<Question>();
            for(int i = 0; i<points.Count; i = i + 2)
            {
                string quest = points[i];
                string ans = points[i + 1];
                Question q = new Question(quest, ans);
                questions.Add(q);
            }

            SQLdata dat = new SQLdata();
            dat.checkAndUpdateData("TST3", questions);
        }

        private void getQuestions(Dictionary<string, List<string>> URLDict)
        {
            SQLdata dat = new SQLdata();
            foreach (KeyValuePair<string, List<string>> pair in URLDict)
            {
                string topic = pair.Key;
                List<Question> questions = new List<Question>();
                foreach (string URL in pair.Value)
                {
                    questions.AddRange(ParseURL(URL));
                    Thread.Sleep(800);
                }
                dat.checkAndUpdateData(topic, questions);
            }
        }

        private List<HtmlNode> getNodes(HtmlDocument document)
        {
            var divs = document.DocumentNode.SelectNodes("//div");
            if (divs != null)
            {
                foreach (var tag in divs)
                {
                    if (tag.Attributes["class"] != null && string.Compare(tag.Attributes["class"].Value, "fourm", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        tag.Remove();
                    }
                    else if (tag.Attributes["id"] != null && string.Compare(tag.Attributes["id"].Value, "fourm", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        tag.Remove();
                    }
                }
            }
            List<HtmlNode> data1 = document.DocumentNode.SelectNodes("//div[@class='post-excerpt']//td").ToList();
            return data1;
        }

        private List<Question> ParseURL(string URL)
        {
            List<Question> questions = new List<Question>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(URL);
            List<HtmlNode> data = getNodes(document);
            List<string> points = new List<string>();

            for (int i = 0; i < data.Count - 1; i++)
            {
                string tst = formatText(data[i]);
                if (!string.IsNullOrWhiteSpace(tst))
                {
                    points.Add(tst);
                }
            }

            for(int i = 0; i < points.Count - 1; i = i + 2)
            {
                string quest = points[i];
                string ans = points[i + 1];
                Question q = new Question(quest, ans);
                questions.Add(q);
            }

            return questions;
        }

        private string formatText(HtmlNode node)
        {
            string retString = "";
            HtmlNodeCollection children = node.ChildNodes;
            if (children.Count > 1)
            {
                foreach (var childe in children)
                {
                    retString = retString + formatText(childe);
                }
            }
            else
            {
                return (node.InnerText + "\n");
            }
            return retString;
        }

        private Dictionary<string, List<string>> getURLSDict()
        {
            Dictionary<string, List<string>> URLS;
            string json = File.ReadAllText("QuestionURLS.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            URLS = data.ToObject<Dictionary<string, List<string>>>();
            return URLS;
        }

    }
}
