using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prenotazioni_Cinema
{
    class Prenotazione
    {
        private List<Posto> _posti;

        public Prenotazione(List<Posto> posti)
        {
            _posti = posti;
        }

        public List<Posto> Posti
        {
            get => _posti;
            set
            {
                _posti = Posti;
            }
        }
    }
}
