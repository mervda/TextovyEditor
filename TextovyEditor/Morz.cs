using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextovyEditor
{
    class Morz
    {
        private string text;

        public Morz(string _text)
        {
            this.text = _text;
        }
        public string Text
        {
            get { return text; }
        }
        internal string morse(Dictionary<char, String> morseovka)
        {
            String vysledek = null;
            if (text.Contains("CH"))
            {
                text = text.Replace("CH", "a");
            }
            else

            for (int i = 0; i < text.Length; i++)
            {
                if (i > 0)
                {
                    vysledek += "/";
                }

                char znak = text[i];
                if (morseovka.ContainsKey(znak))
                {
                    vysledek += morseovka[znak];
                }
            }
            return vysledek;
        }
        internal string deMorse(Dictionary<char, String> morseovka)
        {
            String vysledek = null;
            text += "/";
            int count = 0;
            foreach (char c in text)
                if (c == '/') count++;

            string[] hodnoty = text.Split('/');
            for (int i = 0; i <= count; i++)
            {
                String hodnota = hodnoty[i];
                if (morseovka.ContainsValue(hodnota))
                {
                    if (!(hodnota == "----"))
                        vysledek += morseovka.FirstOrDefault(p => p.Value == hodnota).ToString().Substring(0, 2).Trim('[').ToLower();
                    if (hodnota == "----")
                        vysledek += "ch";
                }

            }
            return vysledek;
        }
        public static void Beep(RichTextBox rtb)
        {
            foreach (char item in rtb.Text)
            {
                if (item == '.')
                {
                    System.Media.SoundPlayer soundDot = new System.Media.SoundPlayer(Properties.Resources.dot);
                    soundDot.PlaySync();
                }
                if (item == '-')
                {
                    System.Media.SoundPlayer soundDash = new System.Media.SoundPlayer(Properties.Resources.dash);
                    soundDash.PlaySync();
                }
            }
        }
    }
}
