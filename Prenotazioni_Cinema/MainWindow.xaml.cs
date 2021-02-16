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
using System.Threading;

namespace Prenotazioni_Cinema
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Posto> posti;
        public int postiRimanenti;
        public int numeroPostiDaPrenotare;
        public MainWindow()
        {
            InitializeComponent();

            posti = new List<Posto>();

            LetturaPostiDaFile();

            ScritturaPostiSuLista();

            CalcolaPostiRimanenti();
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

        public void CalcolaPostiRimanenti()
        {
            postiRimanenti = 0;
            foreach (Posto p in posti)
            {
                if (p.Libero == true)
                {
                    postiRimanenti ++;
                }
            }
        }

        private void btnPrenotaPosto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                numeroPostiDaPrenotare = int.Parse(txtPostoDaPrenotare.Text);

                if (numeroPostiDaPrenotare > 0 && numeroPostiDaPrenotare <= postiRimanenti)
                {
                    Threads tr1 = new Threads();

                    Thread t1 = new Thread(new ThreadStart(tr1.Thread1));
                    Thread t2 = new Thread(new ThreadStart(tr1.Thread2));

                    t1.Start();
                    t2.Start();
                }
                else
                {
                    throw new Exception("Non sono disponibili altri posti in sala");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnPrenotazioneRandomica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random rnd = new Random();
                numeroPostiDaPrenotare = rnd.Next(1, postiRimanenti + 1);

                Threads tr1 = new Threads();

                Thread t1 = new Thread(new ThreadStart(tr1.Thread1));
                Thread t2 = new Thread(new ThreadStart(tr1.Thread2));

                t1.Start();
                t2.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
