using Assets.Script.Dialogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assembly_CSharp
{
    public class InventoryInputHandler : MonoBehaviour
    {
        public GameObject inventoryPanel;
        public TMP_Text inventoryText;

        private List<string> _inventoryItems = new List<string>();

        private void Start()
        {
            inventoryPanel.SetActive(false);
        }

        public void OnInventoryStart()
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);

            if (inventoryPanel.activeSelf)
            {
                DisplayInventory();
            }        
        }

        private void DisplayInventory()
        {
            _inventoryItems = DialogueManager.GetInventory();

            inventoryText.text = "";

            foreach (var item in _inventoryItems)
            {
                inventoryText.text += item + "\n";
            }
        }
    }
}
