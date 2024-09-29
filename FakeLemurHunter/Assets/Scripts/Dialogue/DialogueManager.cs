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
        private static DialogueManager _instance;
        private static Dialogue _dialogue;


        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject); 
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, "dialogue.json");
            string json = File.ReadAllText(filePath);
            _dialogue = JsonUtility.FromJson<Dialogue>(json);
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
            _dialogue.Chats.Where(_ => _.Key == Key).First().Chat.ChatsStatus = ChatStatus.Selected;
        }

        public static List<string> GetInventory()
        {
            return _dialogue.Chats
                .Where(_ => _.Chat.Clue != null && _.Chat.ChatsStatus == ChatStatus.Selected)
                .Select(_ => _.Chat.Clue)
                .ToList();
        }
    }
}
