using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace TextovyEditor
{
    public partial class Form1 : Form
    {
        bool bold = false;
        bool italic = false;
        bool underline = false;

        public static Form thisForm;

        public Dictionary<char, String> morseovka = new Dictionary<char, String>()
        {
            {'A',".-"},
            {'B',"-..."},
            {'C',"-.-."},
            {'D',"-.."},
            {'E',"." },
            {'F',"..-."},
            {'G',"--."},
            {'H',"...."},
            {'a',"----"}, // nahrazuje jakoby CH
            {'I',".."},
            {'J',".---"},
            {'K',"-.-"},
            {'L',".-.."},
            {'M',"--"},
            {'N',"-."},
            {'O',"---"},
            {'P',".--."},
            {'Q',"--.-"},
            {'R',".-."},
            {'S',"..."},
            {'T',"-"},
            {'U',"..-"},
            {'V',"...-"},
            {'W',".--"},
            {'X',"-..-"},
            {'Y',"-.--"},
            {'Z',"--.."}

        };

        public Form1()
        {
            Form1.thisForm = this;
            InitializeComponent();
            this.Text = "Textový editor - Nový dokument";         
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Pismo.velikostPisma(cbVelikostPisma);
            Pismo.typPisma(cbPismo);
            Font m = new Font("Arial", 12, FontStyle.Regular);
            rtbDokument.SelectionFont = m;
            tsProgBar.Value = 50;
        }

        private void novýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soubor.novy(rtbDokument);
        }

        private void zavřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soubor.zavrit();
        }

        private void kopírovatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Upravy.kopirovat(rtbDokument);
        }

        private void vyjmoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Upravy.vyjmout(rtbDokument);
        }

        private void vložitrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upravy.vlozit(rtbDokument);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Soubor.novy(rtbDokument);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //button se chová jako checkbox
            if (bold == false)
            {
                bold = true;
            }
            else {
                bold = false;
            }
                
            Pismo.zmenaPisma(cbPismo, cbVelikostPisma, rtbDokument, bold, italic, underline);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //button se chová jako checkbox
            if (italic == false)
            {
                italic = true;
            }
            else {
                italic = false;
            }
                
            Pismo.zmenaPisma(cbPismo, cbVelikostPisma, rtbDokument, bold, italic, underline);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            //button se chová jako checkbox
            if (underline == false)
            {
                underline = true;
            }
            else {
                underline = false;
            }
                
            Pismo.zmenaPisma(cbPismo, cbVelikostPisma, rtbDokument, bold, italic, underline);
        }

        private void cbVelikostPisma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pismo.zmenaPisma(cbPismo, cbVelikostPisma, rtbDokument, bold, italic, underline);
        }
        private void cbPismo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pismo.zmenaPisma(cbPismo,cbVelikostPisma, rtbDokument, bold,italic,underline);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Soubor.otevri(openFileDialog1, rtbDokument);
        }

        private void otevřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soubor.otevri(openFileDialog1, rtbDokument);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Soubor.uloz(saveFileDialog1, rtbDokument);
        }

        private void tsbPlus_Click(object sender, EventArgs e)
        {
            Funkce.pribliz(rtbDokument,tsProgBar);
        }

        private void tsbMinus_Click(object sender, EventArgs e)
        {
            Funkce.oddal(rtbDokument, tsProgBar);
        }

        private void toolStripStatusLabel6_Click(object sender, EventArgs e)
        {
            Funkce.pribliz(rtbDokument, tsProgBar);
        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
            Funkce.oddal(rtbDokument, tsProgBar);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Funkce.zarovnaniStred(rtbDokument);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Funkce.zarovnaniLeva(rtbDokument);
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Funkce.zarovnaniPrava(rtbDokument);
        }

        private void rtbDokument_TextChanged(object sender, EventArgs e)
        {
            lblZnaky.Text = rtbDokument.TextLength.ToString();
            if (rtbDokument.TextLength > 2)
            {
                String text = rtbDokument.Text;
                int f = 0;
                for (int i = 1; i < text.Length; i++)
                {
                    if (text[i].Equals(' ') && !text[i - 1].Equals(' '))
                    {
                        f++;
                        lblSlova.Text = f.ToString();
                    }
                }
              }
           }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            Funkce.barvaPozadi(colorDialog1, rtbDokument);
        }
        //hledání
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Funkce.oznacit(toolStripTextBox1, rtbDokument);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Funkce.zrusitOznaceni(toolStripTextBox1, rtbDokument);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Soubor.nahledTisku(printPreviewDialog1,rtbDokument);
        }

        private void tiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soubor.tisk(printDialog1, rtbDokument);
        }

        private void rtbDokument_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                       contextMenuStrip1.Show(this, new Point(e.X, e.Y));
                    }
                    break;
            }
        }

        private void kopírovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upravy.kopirovat(rtbDokument);
        }

        private void vyjmoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upravy.vyjmout(rtbDokument);
        }

        private void vložitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upravy.vlozit(rtbDokument);
        }

        private void tsbOdrazka_Click(object sender, EventArgs e)
        {
           Funkce.odrazka();
        }

        private void tsbCaesar_Click(object sender, EventArgs e)
        {
            Caesar zprava = new Caesar(rtbDokument.Text.ToLower());
            File.WriteAllText(@"C:\Users\Public\Caesar.txt", zprava.posunuti(2));
            MessageBox.Show("Uloženo do: "+ @"C:\Users\Public\Caesar.txt");
        }
        private void tssbMorz_ButtonClick(object sender, EventArgs e)
        {
            Morz zprava = new Morz(rtbDokument.Text.ToUpper());
            File.WriteAllText(@"C:\Users\Public\Morzeovka.txt", zprava.morse(morseovka));
            MessageBox.Show("Uloženo do: " + @"C:\Users\Public\Morzeovka.txt");
        }

        private void tsmiMorz_Click(object sender, EventArgs e)
        {
            Morz zprava = new Morz(rtbDokument.Text.ToUpper());
            File.WriteAllText(@"C:\Users\Public\Morzeovka.txt", zprava.morse(morseovka));
            MessageBox.Show("Uloženo do: " + @"C:\Users\Public\Morzeovka.txt");
        }

        private void tsmiDeMorz_Click(object sender, EventArgs e)
        {
            Morz zprava = new Morz(rtbDokument.Text.ToUpper());
            File.WriteAllText(@"C:\Users\Public\OdmorzeovanaMorzeovka.txt", zprava.deMorse(morseovka));
            MessageBox.Show("Uloženo do: " + @"C:\Users\Public\OdmorzeovanaMorzeovka.txt");
        }

        private void tsmiBeep_Click(object sender, EventArgs e)
        {
            Morz.Beep(rtbDokument);
        }

        private void tsbMD5_Click(object sender, EventArgs e)
        {
            MD5 zprava = new MD5(rtbDokument.Text);
            File.WriteAllText(@"C:\Users\Public\MD5.txt", zprava.hashni());
            MessageBox.Show("Uloženo do: " + @"C:\Users\Public\MD5.txt");
        }
    }
 }

