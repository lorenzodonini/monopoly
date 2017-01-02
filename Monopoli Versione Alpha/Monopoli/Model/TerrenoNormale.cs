using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{

    public class TerrenoNormale : Terreno
    {
        private static int _maxEdifici = 5;
        private readonly decimal _prezzoCostruzioneEdificio;
        private int _numeroEdifici;

        public event EventHandler<LogEventArgs> BuildingChanged;

        public TerrenoNormale(int id, string nome, string tipoCella, decimal valore, decimal valoreDiVendita, 
            decimal[] valoriDiAffitto, string nomeGruppo, decimal prezzoCostruzioneEdificio) 
            : base(id, nome, tipoCella, valore, valoreDiVendita, valoriDiAffitto, nomeGruppo)
        {
            _prezzoCostruzioneEdificio = prezzoCostruzioneEdificio;
            _numeroEdifici = 0;
        }

        #region Properties
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
        #endregion

        #region Methods
        public virtual void CostruisciEdificio()
        {
            if (NumeroEdifici == _maxEdifici)
            {
                throw new InvalidOperationException("Too much buildings on this property!");
            }
            _numeroEdifici++;
            Proprietario.DecrementaCapitale(_prezzoCostruzioneEdificio);
            OnBuildingChanged(this, new LogEventArgs(Proprietario.Nome + " ha costruito un edificio su " 
                + Nome + " per ",_prezzoCostruzioneEdificio));
        }

        public virtual void DemolisciEdificio()
        {
            if (NumeroEdifici == 0)
            {
                throw new InvalidOperationException("No buildings on this property!");
            }
            _numeroEdifici--;
            Proprietario.IncrementaCapitale(_prezzoCostruzioneEdificio / 2);
            OnBuildingChanged(this, new LogEventArgs(Proprietario.Nome + " ha demolito un edificio su " 
                + Nome + " per ", (_prezzoCostruzioneEdificio/2)));
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

        public virtual void ResetEdifici()
        {
            this._numeroEdifici = 0;
            OnBuildingChanged(this, new LogEventArgs("Tutti gli edifici presenti su " + Nome + " sono stati demoliti", -1));
        }
        #endregion

        #region EventHandler
        public void OnBuildingChanged(object sender, LogEventArgs e)
        {
            if (BuildingChanged != null)
            {
                BuildingChanged(sender, e);
            }
        }
        #endregion

        #region Terreno
        public override void AggiornaAffitto(int terreniDelGruppo)
        {
            if (_numeroEdifici > 0)
            {
                Affitto = ValoriDiAffitto[_numeroEdifici];
            }
            else if (Proprietario!=null && Proprietario.TerreniPerGruppo[NomeGruppo] == terreniDelGruppo)
            {
                Affitto = ValoriDiAffitto[_indiceAffittoBase] * 2;
            }
            else
            {
                Affitto = ValoriDiAffitto[_indiceAffittoBase];
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

        public override IEnumerable<object> GetContratto()
        {
            List<object> result = new List<object>();
            result.Add(ID);
            result.Add(Nome);
            result.Add(Valore);
            result.Add(ValoreDiVendita);
            result.Add(ValoriDiAffitto);
            result.Add(NomeGruppo);
            result.Add(_prezzoCostruzioneEdificio);
            return result;
        }
        #endregion

        #region Casella
        public override IEnumerable<object> GetParametriCella()
        {
            List<object> result = new List<object>();
            result.Add(ID);
            result.Add(Nome);
            result.Add(Valore);
            result.Add(NomeGruppo);
            return result;
        }
        #endregion
    }
}
