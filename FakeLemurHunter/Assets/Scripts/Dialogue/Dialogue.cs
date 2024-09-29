using Assets.Script.Dialogue.Enums;
using System.Collections.Generic;


namespace Assets.Script.Dialogue
{
    [System.Serializable]
    public class Dialogue
    {
        public List<SerializedQuestion> Questions;

        public Dictionary<string, List<Question>> GetQuestionsDictionary()
        {
            var dictionary = new Dictionary<string, List<Question>>();

            foreach (var serializedQuestion in Questions)
            {
                var questionData = serializedQuestion.Question;

                var question = new Question
                {
                    UnityObject = (UnityObject)System.Enum.Parse(typeof(UnityObject), questionData.UnityObject),
                    QuestionGroup = questionData.QuestionGroup,
                    QuestionContent = questionData.QuestionContent,
                    Answer = questionData.Answer,
                    QuestionStatus = (Enums.QuestionStatus)System.Enum.Parse(typeof(Enums.QuestionStatus), questionData.QuestionStatus),
                    QuestionGroupAvailable = questionData.QuestionGroupAvailable
                };

                if (!dictionary.ContainsKey(serializedQuestion.Key))
                {
                    dictionary[serializedQuestion.Key] = new List<Question>();
                }

                dictionary[serializedQuestion.Key].Add(question);
            }

            return dictionary;
        }
    }
}
