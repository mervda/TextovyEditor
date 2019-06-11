using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace TextovyEditor
{
    class Pismo
    {

  		/// <summary>
        /// Metoda pro tučné písmo
        /// </summary>
        /// <param name="dokument"></param>


        public static void velikostPisma(ToolStripComboBox tscb) {
            for (int i = 1; i < 73; i++)
            {
                if(i % 2 == 0)
                {
                    tscb.Items.Add(i.ToString());
                }
            }
        }
        public static void typPisma(ToolStripComboBox tscb)
        {
            InstalledFontCollection ifc = new InstalledFontCollection();
            for (int i = 0; i < ifc.Families.Length; i++)
            {
                tscb.Items.Add(ifc.Families[i].Name);
            }
        }
        public Boolean stavButtonuBold(Boolean bold)
        {
            return bold = true;
        }
        public Boolean stavButtonuItalic(Boolean italic)
        {
            return italic = true;
        }
        public Boolean stavButtonuUnderline(Boolean underline)
        {
            return underline = true;
        }
        public static void zmenaPisma(ToolStripComboBox tscb, ToolStripComboBox tscb2, RichTextBox dokument, Boolean bold, Boolean italic, Boolean underline)
        {

            Font m = new Font(tscb.Text, int.Parse(tscb2.Text),FontStyle.Regular);

            if (bold == true && italic == true && underline == true)
            {
                 m = new Font(tscb.Text, int.Parse(tscb2.Text), FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            }
            else if (bold == true && italic == true && underline == false)
            {
                 m = new Font(tscb.Text, int.Parse(tscb2.Text), FontStyle.Bold | FontStyle.Italic );
            }
            else if (bold == true && italic == false && underline == false)
            {
                 m = new Font(tscb.Text, int.Parse(tscb2.Text), FontStyle.Bold );
            }
            else if (bold == false && italic == true && underline == true)
            {
                 m = new Font(tscb.Text, int.Parse(tscb2.Text),FontStyle.Italic | FontStyle.Underline);
            }
            else if (bold == false && italic == false && underline == true)
            {
                 m = new Font(tscb.Text, int.Parse(tscb2.Text),FontStyle.Underline);
            }
            else if (bold == true && italic == false && underline == true)
            {
                 m = new Font(tscb.Text, int.Parse(tscb2.Text), FontStyle.Bold | FontStyle.Underline);
            }
            else if (bold == false && italic == true && underline == false)
            {
                 m = new Font(tscb.Text, int.Parse(tscb2.Text),FontStyle.Italic);
            }
            else
            {
                 m = new Font(tscb.Text, int.Parse(tscb2.Text), FontStyle.Regular);
            }


            dokument.SelectionFont = m;
         }
    }
}
