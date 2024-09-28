using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Dialogue
{
    [System.Serializable]
    public class QuestionData
    {
        public string UnityObject;
        public string QuestionGroup;
        public string QuestionContent;
        public string Answer;
        public string QuestionStatus;
        public List<string> QuestionGroupAvailable;
    }
}
