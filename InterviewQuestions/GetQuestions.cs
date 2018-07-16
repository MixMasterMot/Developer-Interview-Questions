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
            List<Question> questions = new List<Question>();

            //HtmlWeb web = new HtmlWeb();
            //HtmlDocument document = web.Load(URL);

            var document = new HtmlDocument();
            document.Load(@"C:\Users\Administrator\Desktop\New Text Document (2).html");

            HtmlNode[] data = document.DocumentNode.SelectNodes("//div[@class='post-excerpt']//td").ToArray();

            for (int i = 0; i < data.Length; i = i + 5)
            {
                string quest = formatText(data[i]);
                string ans = formatText(data[i + 1]);
                Question q = new Question(quest, ans);
                questions.Add(q);
            }

            SQLdata dat = new SQLdata();
            dat.checkAndUpdateData("tst", questions);
        }

        private void getQuestions(Dictionary<string, List<string>> URLDict)
        {
            SQLdata dat = new SQLdata();
            foreach(KeyValuePair<string,List<string>> pair in URLDict)
            {
                string topic = pair.Key;
                List<Question> questions = new List<Question>();
                foreach (string URL in pair.Value)
                {
                    questions.AddRange(ParseURL(URL));
                    Thread.Sleep(600);
                }
                dat.checkAndUpdateData(topic, questions);
            }
        }

        private List<Question> ParseURL(string URL)
        {
            List<Question> questions = new List<Question>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(URL);
            //HtmlNode[] questions = document.DocumentNode.SelectNodes("//div[@class='post-excerpt']//td").ToArray();
            HtmlNode[] data = document.DocumentNode.SelectNodes("//div[@class='post-excerpt']//td").ToArray();

            for(int i = 0; i<data.Length; i = i + 5)
            {
                string quest = formatText(data[i]);
                string ans = formatText(data[i+1]);
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
