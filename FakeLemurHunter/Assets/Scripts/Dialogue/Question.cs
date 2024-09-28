using Assets.Script.Dialogue;
using Assets.Script.Dialogue.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Dialogue
{
    [System.Serializable]
    public class Question
    {
        public UnityObject UnityObject { get; set; }
        public string QuestionGroup { get; set; }
        public string QuestionContent { get; set; }
        public string Answer { get; set; }
        public Enums.QuestionStatus QuestionStatus { get; set; } = Enums.QuestionStatus.UnSelected;
        public List<string> QuestionGroupAvailable { get; set; }
    }
}
