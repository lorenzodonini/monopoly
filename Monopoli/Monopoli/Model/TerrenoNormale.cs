using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    public delegate void BuildingChangedHandler(object sender, LogEventArgs e);

    public class TerrenoNormale : Terreno
    {
        private static int _maxEdifici = 5;
        private readonly decimal _prezzoCostruzioneEdificio;
        private int _numeroEdifici;

        public event BuildingChangedHandler BuildingChanged;

        public TerrenoNormale(int id, string nome, decimal valore, decimal valoreDiVendita, decimal[] valoriDiAffitto, string nomeGruppo, 
            decimal prezzoCostruzioneEdificio) : base(id, nome, valore, valoreDiVendita, valoriDiAffitto, nomeGruppo)
        {
            _prezzoCostruzioneEdificio = prezzoCostruzioneEdificio;
            _numeroEdifici = 0;
        }

        public decimal PrezzoCostruzioneEdificio
        {
            get { return _prezzoCostruzioneEdificio; }
        }

        public int NumeroEdifici
        {
            get { return _numeroEdifici; }
        }

        public int MaxEdifici
        {
            get { return _maxEdifici; }
        }

        public virtual void CostruisciEdificio()
        {
            if (NumeroEdifici == _maxEdifici)
            {
                throw new InvalidOperationException("Too much buildings on this property!");
            }
            _numeroEdifici++;
            Proprietario.DecrementaCapitale(_prezzoCostruzioneEdificio);
            OnBuildingChanged(this, new LogEventArgs(Proprietario.Nome + " ha costruito un edificio su " + Nome + " per ",_prezzoCostruzioneEdificio));
        }

        public virtual void DemolisciEdificio()
        {
            if (NumeroEdifici == 0)
            {
                throw new InvalidOperationException("No buildings on this property!");
            }
            _numeroEdifici--;
            Proprietario.IncrementaCapitale(_prezzoCostruzioneEdificio / 2);
            OnBuildingChanged(this, new LogEventArgs(Proprietario.Nome + " ha demolito un edificio su " + Nome + " per ", _prezzoCostruzioneEdificio));
        }

        public virtual bool IsEdificabile(int terreniDelGruppo)
        {
            if (_numeroEdifici == _maxEdifici || Proprietario.TerreniPerGruppo[NomeGruppo] < terreniDelGruppo)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public override void AggiornaAffitto(int terreniDelGruppo)
        {
            if (_numeroEdifici > 0)
            {
                Affitto = ValoriDiAffitto[_numeroEdifici];
            }
            else if (Proprietario.TerreniPerGruppo[NomeGruppo] == terreniDelGruppo)
            {
                Affitto = ValoriDiAffitto[_indiceAffittoBase] * 2;
            }
            else
            {
                Affitto = ValoriDiAffitto[_indiceAffittoBase];
            }
        }

        public void OnBuildingChanged(object sender, LogEventArgs e)
        {
            if (BuildingChanged != null)
            {
                BuildingChanged(sender, e);
            }
        }

        public override bool IsVendibile(int terreniDelGruppo, List<Terreno> terreniDelGruppoPosseduti)
        {
            if (terreniDelGruppo > terreniDelGruppoPosseduti.Count)
            {
                return true;
            }
            else
            {
                foreach (TerrenoNormale terreno in terreniDelGruppoPosseduti)
                {
                    if (terreno.NumeroEdifici > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void ResetEdifici()
        {
            this._numeroEdifici = 0;
            OnBuildingChanged(this,new LogEventArgs("Tutti gli edifici presenti su "+Nome+" sono stati demoliti", -1));
        }

    }
}
