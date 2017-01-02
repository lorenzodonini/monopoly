using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoli.Model;
using Monopoli.View;
using System.Windows.Forms;

namespace Monopoli.Controller
{
    public class GameController
    {
        private Partita _partita;
        private static BuildingDialog _buildingDialog;
        private static CardInstructionDialog _cardInstructionDialog;
        private static SellPropertyDialog _sellPropertyDialog;
        private string _currency;
        private ControlPanel _controlPanel;

        public GameController(string currency)
        {
            this._currency = currency;
        }

        public void SetGame(Partita partita, ControlPanel controlPanel)
        {
            _partita = partita;
            _controlPanel = controlPanel;
            _cardInstructionDialog = new CardInstructionDialog();
            _sellPropertyDialog = new SellPropertyDialog(_currency);
            _buildingDialog = new BuildingDialog(_currency);
            _partita.AvviaTimer();
        }

        #region GUI Events Procedures
        public void DemolisciEdificioClicked()
        {
            List<TerrenoNormale> terreniConEdifici = new List<TerrenoNormale>();
            Giocatore corrente = _partita.Giocatori[_partita.GiocatoreCorrente];
            foreach (Terreno terreno in corrente.Terreni)
            {
                if (terreno is TerrenoNormale)
                {
                    TerrenoNormale tn = (TerrenoNormale)terreno;
                    if (tn.NumeroEdifici > 0)
                    {
                        terreniConEdifici.Add(tn);
                    }
                }
            }
            DialogResult result = _buildingDialog.ShowDialogWithData(terreniConEdifici, BuildingDialog.Action.DEMOLISH, corrente.Nome);
            if (result == DialogResult.OK)
            {
                _buildingDialog.ToModify.DemolisciEdificio();
                _partita.AggiornaAffittoTerreniGiocatore();
            }
        }

        public void VendiTerrenoClicked()
        {
            List<Terreno> terreniVendibili = new List<Terreno>();
            Giocatore corrente = _partita.Giocatori[_partita.GiocatoreCorrente];
            List<Terreno> terreniDelGruppo = new List<Terreno>();
            foreach (Terreno terreno in corrente.Terreni)
            {
                terreniDelGruppo = corrente.Terreni.Where(t => t.NomeGruppo == terreno.NomeGruppo).ToList<Terreno>();
                if (terreno.IsVendibile(corrente.TerreniPerGruppo[terreno.NomeGruppo], terreniDelGruppo))
                {
                    terreniVendibili.Add(terreno);
                }
            }
            DialogResult result = _sellPropertyDialog.ShowDialogWithData(terreniVendibili, corrente.Nome);
            if (result == DialogResult.OK)
            {
                corrente.VendiTerreno(_sellPropertyDialog.ToSell);
                _partita.AggiornaAffittoTerreniGiocatore();
            }
        }

        public void AcquistaUnTerrenoClicked()
        {
            Giocatore giocatoreCorrente = _partita.GetGiocatoreCorrente();
            if(TentaPaga(((Terreno)giocatoreCorrente.PosizioneCorrente).Valore))
            {
                DialogResult res = WarningMessageBox.GetMessageBoxInstance().ShowDialogWithData("Vuoi davvero acquistare il terreno " 
                    + giocatoreCorrente.PosizioneCorrente.Nome + " per " + _currency + " " 
                    + ((Terreno)giocatoreCorrente.PosizioneCorrente).Valore + "?", "Conferma acquisto terreno", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    giocatoreCorrente.AcquistaTerreno((Terreno)giocatoreCorrente.PosizioneCorrente);
                    _partita.AggiornaAffittoTerreniGiocatore();
                    this._controlPanel.AcquistaTerrenoButton.Enabled = false;
                }

            }
        }

        public void PescaUnaCartaClicked()
        {
            Carta carta = null;
            Giocatore giocatoreCorrente = _partita.GetGiocatoreCorrente();
            if (_partita.CartaCorrente != null && _partita.CartaCorrente is Carta.CartaPagaPesca)
            {
                _controlPanel.PagaButton.Enabled = false;
                if (_partita.CartaCorrente.Tipo == Carta.TipoCarta.IMPREVISTI)
                {
                    carta = _partita.TavolaDaGioco.GetCartaPerTipo(Carta.TipoCarta.PROBABILITA);
                }
                else
                {
                    carta = _partita.TavolaDaGioco.GetCartaPerTipo(Carta.TipoCarta.IMPREVISTI);
                }
            }
            else
            {
                if (giocatoreCorrente.PosizioneCorrente is Imprevisti)
                {
                    carta = _partita.TavolaDaGioco.GetCartaPerTipo(Carta.TipoCarta.IMPREVISTI);
                }
                else if (giocatoreCorrente.PosizioneCorrente is Probabilità)
                {
                    carta = _partita.TavolaDaGioco.GetCartaPerTipo(Carta.TipoCarta.PROBABILITA);
                }
            }
            this._controlPanel.PescaUnaCartaButton.Enabled = false;
            _cardInstructionDialog.ShowDialogWithData(carta.Tipo.ToString(), carta.Istruzioni, carta.Colore);
            carta.EseguiOperazione(giocatoreCorrente);
        }

        public void CostruisciEdificioClicked()
        {
            List<TerrenoNormale> terreniEdificabili = new List<TerrenoNormale>();
            Giocatore corrente = _partita.Giocatori[_partita.GiocatoreCorrente];
            foreach(Terreno terreno in corrente.Terreni)
            {
                if (terreno is TerrenoNormale)
                {
                    TerrenoNormale tn = (TerrenoNormale)terreno;
                    if (tn.IsEdificabile(_partita.TavolaDaGioco.Gruppi[tn.NomeGruppo]))
                    {
                        terreniEdificabili.Add(tn);
                    }
                }
            }
            DialogResult result = _buildingDialog.ShowDialogWithData(terreniEdificabili, BuildingDialog.Action.BUILD, corrente.Nome);
            if (result == DialogResult.OK)
            {
                if (TentaPaga(_buildingDialog.ToModify.PrezzoCostruzioneEdificio))
                {
                    _buildingDialog.ToModify.CostruisciEdificio();
                    _partita.AggiornaAffittoTerreniGiocatore();
                }
            }
        }

        public void PagaCauzioneClicked()
        {
            Giocatore giocatoreCorrente = _partita.GetGiocatoreCorrente();
            if(TentaPaga(((Prigione)giocatoreCorrente.PosizioneCorrente).Cauzione))
            {
                giocatoreCorrente.DecrementaCapitale(((Prigione)giocatoreCorrente.PosizioneCorrente).Cauzione);
                giocatoreCorrente.InPrigione = false;
                giocatoreCorrente.TurniInPrigione = 0;
                _controlPanel.PagaCauzioneButton.Enabled = false;
                if (_partita.RisultatoDado1 == 0 && _partita.RisultatoDado2 == 0) //non ho ancora tirato i dadi
                {
                    this._controlPanel.TiraDadiButton.Enabled = true;
                }
                else  //dadi tirati ma il giocatore è spostato ora
                {
                    SettaParametriGiocatore(_partita.RisultatoDado1 + _partita.RisultatoDado2, true);
                }
            }
        }

        public void RitiraDallaPartitaClicked()
        {
            DialogResult res = WarningMessageBox.GetMessageBoxInstance().ShowDialogWithData("Una volta ritirato non potrai "+ 
                "più partecipare alla partita in corso.", "Vuoi davvero ritirarti dalla Partita?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                _controlPanel.PagaAffittoButton.Enabled = false;
                _controlPanel.PagaButton.Enabled = false;
                _controlPanel.PagaCauzioneButton.Enabled = false;
                _controlPanel.PagaTassaButton.Enabled = false;
                _controlPanel.PescaUnaCartaButton.Enabled = false;
                _partita.GetGiocatoreCorrente().Fallisci();
                TerminaTurnoClicked();
            }
        }

        public void TerminaTurnoClicked()
        {
            _partita.PassaTurnoAProssimoGiocatoreAttivo();
            _partita.RisultatoDado1 = 0;
            _partita.RisultatoDado2 = 0;
            _partita.NDoppi = 0;
            _controlPanel.TiraDadiButton.Focus();
        }

        public void TiraDadiClicked()
        {
            _partita.CartaCorrente = null;
            _controlPanel.AcquistaTerrenoButton.Enabled = false;
            if (_partita.TiraDadi() == true) //Doppio
            {
                if (_partita.GetGiocatoreCorrente().InPrigione == true)
                {
                    _partita.GetGiocatoreCorrente().InPrigione = false;
                    _partita.GetGiocatoreCorrente().TurniInPrigione = 0;
                    _controlPanel.TiraDadiButton.Enabled = false;
                    _controlPanel.TerminaTurnoButton.Enabled = true;
                    _controlPanel.PagaCauzioneButton.Enabled = false;
                }
                if (_partita.NDoppi == 3)
                {
                    SpostaInPrigione();
                    _controlPanel.TiraDadiButton.Enabled = false;
                    _controlPanel.TerminaTurnoButton.Enabled = true;
                }
                else
                {
                    _controlPanel.TerminaTurnoButton.Enabled = false;
                }
            }
            else //non è uscito un doppio
            {
                _controlPanel.TiraDadiButton.Enabled = false;
                _controlPanel.TerminaTurnoButton.Enabled = true;
                if (_partita.GetGiocatoreCorrente().InPrigione && _partita.GetGiocatoreCorrente().TurniInPrigione < 3)
                {
                    _controlPanel.PagaCauzioneButton.Enabled = false;
                }
                else if (_partita.GetGiocatoreCorrente().InPrigione && _partita.GetGiocatoreCorrente().TurniInPrigione == 3)
                {
                    _controlPanel.TerminaTurnoButton.Enabled = false;
                }
            }
            WarningMessageBox.GetMessageBoxInstance().ShowDialogWithData("DADO1=" + _partita.RisultatoDado1 + 
                "   DADO2=" + _partita.RisultatoDado2, null, MessageBoxButtons.OK);
            SettaParametriGiocatore(_partita.RisultatoDado1 + _partita.RisultatoDado2, true);
        }

        public void PagaTassaClicked()
        {
            Giocatore giocatore = _partita.GetGiocatoreCorrente();
            if(TentaPaga(((Tassa)giocatore.PosizioneCorrente).Importo))
            {
                giocatore.DecrementaCapitale(((Tassa)giocatore.PosizioneCorrente).Importo);
                _controlPanel.PagaTassaButton.Enabled = false;
                GiocaUnAltroTurno();
            }
        }

        public void PagaAffittoClicked()
        {
            Giocatore giocatoreCorrente = _partita.GetGiocatoreCorrente();
            Terreno terreno = (Terreno)giocatoreCorrente.PosizioneCorrente;
            if (TentaPaga(terreno.Affitto))
            {
                giocatoreCorrente.DecrementaCapitale(terreno.Affitto);
                terreno.Proprietario.IncrementaCapitale(terreno.Affitto);
                _controlPanel.PagaAffittoButton.Enabled = false;
                GiocaUnAltroTurno();
            }
            if (terreno.Proprietario != null && _partita.GetGiocatoreCorrente() != giocatoreCorrente)
            {
                terreno.Proprietario.IncrementaCapitale(terreno.Affitto);
            }
        }

        public void PagaClicked()
        {
            Carta carta = _partita.CartaCorrente;
            if (carta != null && carta is Carta.CartaPaga)
            {
                if (TentaPaga(((Carta.CartaPaga)carta).Importo))
                {
                    _partita.GetGiocatoreCorrente().DecrementaCapitale(((Carta.CartaPaga)carta).Importo);
                    GiocaUnAltroTurno();
                    _controlPanel.PagaButton.Enabled = false;
                }
            }
            else if (carta != null && carta is Carta.CartaPagaPerEdifici)
            {
                Carta.CartaPagaPerEdifici cartaPaga = (Carta.CartaPagaPerEdifici)carta;
                decimal importo = 0;
                foreach (Terreno terreno in _partita.GetGiocatoreCorrente().Terreni)
                {
                    if (terreno is TerrenoNormale)
                    {
                        TerrenoNormale tn = (TerrenoNormale)terreno;
                        if (tn.NumeroEdifici == tn.MaxEdifici)
                        {
                            importo += cartaPaga.ImportoAlbergo;
                        }
                        else
                        {
                            importo += cartaPaga.ImportoCasa * tn.NumeroEdifici;
                        }
                    }
                }
                if (TentaPaga(importo))
                {
                    _partita.GetGiocatoreCorrente().DecrementaCapitale(importo);
                    GiocaUnAltroTurno();
                    _controlPanel.PagaButton.Enabled = false;
                }
            }
            else if (_partita.CartaCorrente is Carta.CartaPagaPesca)
            {
                if (TentaPaga(((Carta.CartaPaga)carta).Importo))
                {
                    _partita.GetGiocatoreCorrente().DecrementaCapitale(((Carta.CartaPagaPesca)_partita.CartaCorrente).Importo);
                    _controlPanel.PescaUnaCartaButton.Enabled = false;
                    GiocaUnAltroTurno();
                    _controlPanel.PagaButton.Enabled = false;
                }
            }
        }
        #endregion

        #region Methods
        public void TerminaPartita()
        {
            _partita.ArrestaTimer();
            _cardInstructionDialog.Dispose();
            _sellPropertyDialog.Dispose();
            GameStatisticsDialog statistics = new GameStatisticsDialog();
            statistics.ShowDialogWithData(_partita.CalcolaStatistiche(), _currency);
            _partita.TavolaDaGioco.ResetTavolaDaGioco();
        }

        private void SettaParametriGiocatore(int spostamento, bool passaDalVia)
        {
            Giocatore giocatoreCorrente = _partita.GetGiocatoreCorrente();
            if (giocatoreCorrente.InPrigione)
            {
                giocatoreCorrente.TurniInPrigione++;
                return;
            }
            int indiceCasellaCorrente = giocatoreCorrente.PosizioneCorrente.ID;
            int indiceNuovaCella = (indiceCasellaCorrente + spostamento);
            int nCelle = _partita.TavolaDaGioco.Caselle.Length;
            Casella nuovaCasella = _partita.TavolaDaGioco.Caselle[indiceNuovaCella % nCelle];
            if (giocatoreCorrente.InPrigione == false)
            {
                if (indiceNuovaCella >= nCelle && passaDalVia)
                {
                    _partita.TavolaDaGioco.Caselle[0].EseguiOperazione(giocatoreCorrente);
                }
                GiocaUnAltroTurno();
                giocatoreCorrente.PosizioneCorrente = nuovaCasella;
            }
            nuovaCasella.EseguiOperazione(giocatoreCorrente);
        }

        private void SettaParametriGiocatore(string destinazione, bool passaDalVia)
        {
            Giocatore giocatoreCorrente = _partita.GetGiocatoreCorrente();
            if (giocatoreCorrente.InPrigione)
            {
                giocatoreCorrente.TurniInPrigione++;
                return;
            }
            Casella nuovaCasella = _partita.TavolaDaGioco.Caselle.Single(casella => casella.Nome.Equals(destinazione));
            if (nuovaCasella.ID < giocatoreCorrente.PosizioneCorrente.ID && passaDalVia && nuovaCasella.ID != 0)
            {
                _partita.TavolaDaGioco.Caselle[0].EseguiOperazione(giocatoreCorrente);
            }
            GiocaUnAltroTurno();
            giocatoreCorrente.PosizioneCorrente = nuovaCasella;
            nuovaCasella.EseguiOperazione(giocatoreCorrente);
        }

        public void SpostaInPrigione()
        {
            _partita.GetGiocatoreCorrente().TurniInPrigione = 1;
            _partita.GetGiocatoreCorrente().InPrigione = true;
            _partita.GetGiocatoreCorrente().PosizioneCorrente = _partita.TavolaDaGioco.Caselle.Single(casella => casella.Nome == "Prigione");
            _controlPanel.TerminaTurnoButton.Enabled = true;
        }

        private void GiocaUnAltroTurno()
        {
            if (_partita.GetGiocatoreCorrente().Attivo && _partita.RisultatoDado1 == _partita.RisultatoDado2 
                && _partita.RisultatoDado1 > 0 && !_partita.GetGiocatoreCorrente().InPrigione 
                && _partita.GetGiocatoreCorrente().TurniInPrigione == 0)
            {
                _controlPanel.TiraDadiButton.Enabled = true;
                _controlPanel.TiraDadiButton.Focus();
                _controlPanel.TerminaTurnoButton.Enabled = false;
            }
            else
            {
                _controlPanel.TiraDadiButton.Enabled = false;
                _controlPanel.TerminaTurnoButton.Enabled = true;
                _controlPanel.TerminaTurnoButton.Focus();
            }
        }

        public void SpostaGiocatore()
        {
            int i;
            if (_partita.CartaCorrente is Carta.CartaMuoviAvanti)
            {
                Carta.CartaMuoviAvanti carta= (Carta.CartaMuoviAvanti)_partita.CartaCorrente;
                if (Int32.TryParse(carta.Destinazione, out i))
                {
                    SettaParametriGiocatore(i, true);
                }
                else
                {
                    SettaParametriGiocatore(carta.Destinazione, true);
                }
            }
            else
            {
                Carta.CartaMuoviIndietro carta = (Carta.CartaMuoviIndietro)_partita.CartaCorrente;
                if (Int32.TryParse(carta.Destinazione, out i))
                {
                    SettaParametriGiocatore(-i, false);
                }
                else
                {
                    SettaParametriGiocatore(carta.Destinazione, false);
                }
            }
        }
      
        private bool TentaPaga(decimal importo)
        {
            if (_partita.GetGiocatoreCorrente().Capitale - importo < 0)
            {
                DialogResult res=WarningMessageBox.GetMessageBoxInstance().ShowDialogWithData("Il pagamento di " + _currency + 
                    importo + " comporterà un fallimento!", "Sei sicuro di voler fallire?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    _partita.GetGiocatoreCorrente().Fallisci();
                    TerminaTurnoClicked();
                }
                return false;
            }
            return true;
        }
        #endregion
    }
}
