using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

//marked for removal
namespace InterviewQuestions
{
    class GetQuestionURLS
    {
        public Dictionary<string,List<string>> getURLSDict()
        {
            Dictionary<string, List<string>> URLS;
            string json = File.ReadAllText("QuestionURLS.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            URLS = data.ToObject<Dictionary<string, List<string>>>();
            return URLS;
        }
    }
}
