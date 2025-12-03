using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    internal sealed class Main : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
                Application.Quit();
        }

        public void OnRunButtonClicked()
        {
            const string tag = nameof(OnRunButtonClicked);

            AppendLine($"[{tag}]");
        }

        private void AppendLine(string text)
        {
            if (outputText == null)
                return;

            if (text is null)
                return;

            string oldText = outputText.text;
            string newText = oldText + Environment.NewLine + text;
            outputText.text = newText;
        }

#pragma warning disable 649
        [SerializeField] private InputField? inputField;
        [SerializeField] private Text? outputText;
#pragma warning restore 649
    }
}
