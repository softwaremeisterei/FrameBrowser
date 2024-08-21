using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameBrowser
{
    public static class Prompt
    {
        public static string ShowDialog(Form owner, string caption, string label, string? defaultValue = null)
        {
            Form prompt = new Form()
            {
                Owner = owner,
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = label };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            if (defaultValue != null) {
                textBox.Text = defaultValue;
            }

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
