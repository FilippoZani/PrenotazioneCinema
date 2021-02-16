using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prenotazioni_Cinema
{
    public class Posto
    {
        private int _numero;
        private bool _libero;

        public Posto(int numero, bool libero)
        {
            _numero = numero;
            _libero = libero;
        }

        public int Numero
        {
            get => _numero;
            set
            {
                if(Numero < 1 || Numero > 11)
                {
                    throw new Exception("Il numero del posto inserito non è disponibile");
                }

                _numero = Numero;
            }
        }

        public bool Libero
        {
            get => _libero;
            set
            {
                _libero = value;
            }
        }

        public override string ToString()
        {
            if(Libero == true)
            {
                return "Il posto n. " + Numero + " è libero";
            }
            else
            {
                return "Il posto n. " + Numero + " è occupato";
            }
        }
    }
}
