using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    public class TavolaDaGioco
    {
        private readonly Casella[] _caselle;
        private readonly Carta[] _imprevisti;
        private readonly Carta[] _probabilità;
        private int _cimaImprevisti;
        private int _cimaProbabilità;
        private readonly Dictionary<string, int> _gruppi;

        public TavolaDaGioco(Casella[] caselle, Carta[] imprevisti, Carta[] probabilità)
        {
            _caselle = caselle;
            _imprevisti = imprevisti;
            _probabilità = probabilità;
            ShuffleUtility.Shuffle(Imprevisti, Imprevisti.Length);
            ShuffleUtility.Shuffle(Probabilità, Probabilità.Length);
            _cimaImprevisti = 0;
            _cimaProbabilità = 0;
            _gruppi = new Dictionary<string, int>();
            foreach(Casella casella in _caselle)
            {
                if (casella is Terreno)
                {
                    Terreno terreno = (Terreno)casella;
                    if (_gruppi.ContainsKey(terreno.NomeGruppo))
                    {
                        _gruppi[terreno.NomeGruppo]++;
                    }
                    else
                    {
                        _gruppi.Add(terreno.NomeGruppo, 1);
                    }
                }
            }
        }

        public Casella[] Caselle
        {
            get { return _caselle; }
        }

        public Carta[] Imprevisti
        {
            get { return _imprevisti; }
        }

        public Carta[] Probabilità
        {
            get { return _probabilità; }
        }

        public int CimaImprevisti
        {
            get { return _cimaImprevisti; }
        }

        public int CimaProbabilità
        {
            get { return _cimaProbabilità; }
        }

        public Dictionary<string, int> Gruppi
        {
            get { return _gruppi; }
        }

        public virtual Carta GetCartaPerTipo(Carta.TipoCarta tipo)
        {
            Carta result = null;
            if (tipo.Equals(Carta.TipoCarta.IMPREVISTI))
            {
                result = _imprevisti[_cimaImprevisti];
                _cimaImprevisti++;
                if ((_cimaImprevisti % _imprevisti.Length) == 0)
                {
                    _cimaImprevisti = 0;
                }
            }
            else if (tipo.Equals(Carta.TipoCarta.PROBABILITA))
            {
                result = _probabilità[_cimaProbabilità];
                _cimaProbabilità++;
                if ((_cimaProbabilità % _probabilità.Length) == 0)
                {
                    _cimaProbabilità = 0;
                }
            }
            return result;
        }
    }
}
