using Assets.Script.Dialogue;
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
        public string UnityObject;
        public string ChatGroup;
        public string ChatContent;
        public string Answer;
        public string ChatStatus;
        public List<string> ChatsGroupAvailable;
        public string Clue;
    }
}
