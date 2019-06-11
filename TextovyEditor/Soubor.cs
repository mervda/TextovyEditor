using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextovyEditor
{
    class Soubor
    {
        public static void zavrit()
        {
            Application.Exit();
        }
        public static void novy(RichTextBox rtb)
        {
            rtb.Clear();
            MessageBox.Show("Byl vytvořen nový soubor");
        }
        public static void otevri(OpenFileDialog ofd, RichTextBox rtb)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rtb.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
                Form1.thisForm.Text = "Textový editor - " + ofd.FileName;
            }           
        }
        public static void uloz(SaveFileDialog sfd, RichTextBox rtb)
        {
            sfd.Filter = "Text Files (.txt) |*.txt|Ritch Text FIle (.rtf)|*.rtf";

            if (sfd.ShowDialog() == DialogResult.OK) {

                try
                {  if (sfd.FileName.ToString().Contains(".txt"))
                        rtb.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                    else if (sfd.FileName.ToString().Contains(".rtf"))
                        rtb.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                }   
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
            }
        }
        public static void nahledTisku(PrintPreviewDialog ppd, RichTextBox rtb)
        {
            ppd.ShowDialog();
        }
        public static void tisk(PrintDialog pd, RichTextBox rtb)
        {
            pd.ShowDialog();
        }
    }
}
