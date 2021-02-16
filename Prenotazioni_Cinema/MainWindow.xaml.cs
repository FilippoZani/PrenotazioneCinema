using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Prenotazioni_Cinema
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Posto> posti;
        public MainWindow()
        {
            InitializeComponent();

            posti = new List<Posto>();

            LetturaPostiDaFile();

            ScritturaPostiSuLista();
        }

        public void LetturaPostiDaFile()
        {
            using(StreamReader file = new StreamReader("Posti.txt"))
            {
                string riga;

                while (!file.EndOfStream)
                {
                    try
                    {
                        riga = file.ReadLine();
                        string[] elementi = riga.Split('|');

                        if(elementi.Length == 2)
                        {
                            posti.Add(new Posto(int.Parse(elementi[0]), bool.Parse(elementi[1])));
                        }
                        else
                        {
                            posti.Add(new Posto(int.Parse(elementi[0]), true));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public void ScritturaPostiSuLista()
        {
            lstPrenotazioniPosti.Items.Clear();
            foreach(Posto p in posti)
            {
                lstPrenotazioniPosti.Items.Add(p.ToString());
            }
        }
    }
}
