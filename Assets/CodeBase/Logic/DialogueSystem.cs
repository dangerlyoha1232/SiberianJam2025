using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic
{
    public class DialogueSystem : MonoBehaviour
    {
        public TMP_Text DialogueText;

        public List<string> _lines;
        public float _speedText;

        private int _index;

        public void Initialize(DialogueData data)
        {
            _lines = data.Lines;
            _speedText = data.SpeedText;

            DialogueText.text = string.Empty;
        }

        public void StartDialogue()
        {
            _index = 0;
            StartCoroutine(TypeLine());
        }
        
        private IEnumerator TypeLine()
        {
            foreach (char c in _lines[_index])
            {
                DialogueText.text += c;
                yield return new WaitForSeconds(_speedText);
            }
        }

        public void SkipText()
        {
            if (DialogueText.text == _lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                DialogueText.text = _lines[_index];
            }
        }

        private void NextLine()
        {
            if (_index < _lines.Count - 1)
            {
                _index++;
                DialogueText.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
                gameObject.SetActive(false);
        }
        
        public void ShowDialogue() =>
            gameObject.SetActive(true);
        public void HideDialogue() =>
            gameObject.SetActive(false);
    }
}