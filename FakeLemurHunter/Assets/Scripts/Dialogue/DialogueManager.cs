using UnityEngine;
using System.IO;
using Assets.Script.Dialogue.Enums;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Assets.Script.Dialogue
{

    public class DialogueManager : MonoBehaviour
    {
        private static Dialogue _dialogue;
        private void Start()
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, "dialogue.json");
            string json = File.ReadAllText(filePath);
            _dialogue = JsonUtility.FromJson<Dialogue>(json);

            //Debug.Log(GetChatByChatGroup("SCENARIO_01_KITCHEN").Select(_ => _.Chat.ChatContent).FirstOrDefault());
            //Debug.Log(GetAnswerByKey("SCENARIO_01_KITCHEN_01"));
            Debug.Log(GetInventory());
        }

        public List<ChatWrapper> GetChatByChatGroup(string ChatGroup)
        {
            return _dialogue.Chats.Where(_ => _.Chat.ChatGroup == ChatGroup).ToList();

        }

        public ChatWrapper GetChatByKey(string Key)
        {
            return _dialogue.Chats.Where(_ => _.Key == Key).First();

        }

        public void SetAsSelected(string Key)
        {
            var dialogueToUpdate = _dialogue.Chats.Where(_ => _.Key == Key).First();
            dialogueToUpdate.Chat.ChatsStatus = ChatStatus.Selected;
        }

        public List<string> GetInventory()
        {
            return _dialogue.Chats
                .Where(_ => _.Chat.Clue != null && _.Chat.ChatsStatus == ChatStatus.Selected)
                .Select(_ => _.Chat.Clue)
                .ToList();
        }
    }
}
