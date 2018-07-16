using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class Question
    {
        string question;
        string answer;

        public Question(string question, string answer)
        {
            this.question = question;
            this.answer = answer;
        }
        public string getQuestion()
        {
            return question;
        }
        public string getAnswer()
        {
            return answer;
        }
    }
}
