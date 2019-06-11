using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TextovyEditor
{
    class Funkce
    {

        public static void pribliz(RichTextBox rtb, ToolStripProgressBar tsPB)
        {
            if (rtb.ZoomFactor <= 1.50f)
            {
                rtb.ZoomFactor += 0.33f;
                tsPB.Value += 25;
            }
        }
        public static void oddal(RichTextBox rtb, ToolStripProgressBar tsPB)
        {
            if (rtb.ZoomFactor >= 0.5f)
            {
                rtb.ZoomFactor -= 0.33f;
                tsPB.Value -= 25;
            }
        }
        public static void zarovnaniStred(RichTextBox rtb)
        {
            rtb.SelectionAlignment = HorizontalAlignment.Center;
        }
        public static void zarovnaniLeva(RichTextBox rtb)
        {
            rtb.SelectionAlignment = HorizontalAlignment.Left;
        }
        public static void zarovnaniPrava(RichTextBox rtb)
        {
            rtb.SelectionAlignment = HorizontalAlignment.Right;
        }
        public static void barvaPozadi(ColorDialog cld, RichTextBox rtb)
        {
            if (cld.ShowDialog() == DialogResult.OK)
            {
                rtb.BackColor = cld.Color;
            }
        }
        public static void oznacit(ToolStripTextBox hledanyText, RichTextBox rtb)
        {
           if (hledanyText.ToString() == string.Empty)
                return;

            int s_start = rtb.SelectionStart, startIndex = 0, index;
            while ((index = rtb.Text.IndexOf(hledanyText.ToString(), startIndex)) != -1)
            {
                rtb.Select(index, hledanyText.ToString().Length);
                rtb.SelectionColor = Color.Orange;

                startIndex = index + hledanyText.ToString().Length;
            }
            rtb.SelectionStart = s_start;
            rtb.SelectionLength = 0;
        }
        public static void zrusitOznaceni(ToolStripTextBox hledanyText, RichTextBox rtb)
        {

            if (hledanyText.ToString() == string.Empty)
                return;

            int s_start = rtb.SelectionStart, startIndex = 0, index;
            while ((index = rtb.Text.IndexOf(hledanyText.ToString(), startIndex)) != -1)
            {
                rtb.Select(index, hledanyText.ToString().Length);
                rtb.SelectionColor = Color.Black;

                startIndex = index + hledanyText.ToString().Length;
            }
            rtb.SelectionStart = s_start;
            rtb.SelectionLength = 0;
        }
        public static void odrazka()
        {
            MessageBox.Show("Zmáčkni najednou CTRL,SHIFT a L (ušetříš práci mě i sobě)");
        }
    }
}
