using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Dialogue
{
    [System.Serializable]
    public class ChatData
    {
        public string UnityObject;
        public string ChatGroup;
        public string ChatContent;
        public string Answer;
        public string ChatStatus;
        public List<string> ChatGroupAvailable;
    }
}
