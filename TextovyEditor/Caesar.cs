using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextovyEditor
{
    class Caesar
    {
        private string text;

        public Caesar(string _text)
        {
            this.text = _text;
        }

        public string Text
        {
            get { return text; }
        }

        internal string posunuti(int posun)
        {
            char[] pole = text.ToCharArray();

            for (int i = 0; i < pole.Length; i++)
            {
                char znak = pole[i];
                znak = (char)(znak + posun);
                if (znak > 'z')
                    znak = (char)(znak - 26);
                else if (znak < 'a')
                    znak = (char)(znak + 26);

                pole[i] = znak;
            }
            return new string(pole);
        }
    }
}

