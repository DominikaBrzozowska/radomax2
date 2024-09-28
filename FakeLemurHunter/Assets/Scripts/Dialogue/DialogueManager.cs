using UnityEngine;
using System.IO;
using Assets.Script.Dialogue.Enums;
using System.Linq;

namespace Assets.Script.Dialogue
{

    public class DialogueManager : MonoBehaviour
    {
        private Dialogue dialogue;

        void Start()
        {
            string jsonFilePath = Path.Combine(Application.streamingAssetsPath, "dialogue.json");
            string json = File.ReadAllText(jsonFilePath);
            dialogue = JsonUtility.FromJson<Dialogue>(json);

            var questionsDictionary = dialogue.GetQuestionsDictionary();

            //if (questionsDictionary.TryGetValue("SCENARIO_01_KITCHEN_01", out var scenarioQuestions))
            //{
            //    foreach (var question in scenarioQuestions)
            //    {
            //        Debug.Log($"Question: {question.QuestionContent}, Answer: {question.Answer}, UnityObject: {question.UnityObject}");
            //    }
            //}
        }
    }
}
