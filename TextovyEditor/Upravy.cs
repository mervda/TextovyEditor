using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextovyEditor
{
    class Upravy
    {
        public static void kopirovat(RichTextBox rtb)
        {
            rtb.Copy();
        }

        public static void vyjmout(RichTextBox rtb)
        {
            rtb.Cut();
        }

        public static void vlozit(RichTextBox rtb)
        {
            rtb.Paste();
        }

    }
}
