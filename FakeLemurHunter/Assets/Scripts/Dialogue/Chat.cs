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
    public class Chat
    {
        public UnityObject UnityObject;
        public string ChatGroup;
        public string ChatContent;
        public string Answer;
        public ChatStatus ChatsStatus = ChatStatus.UnSelected;
        public List<string> ChatsGroupAvailable;
    }
}
