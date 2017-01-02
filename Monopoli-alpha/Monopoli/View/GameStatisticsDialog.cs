using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monopoli.View
{
    public partial class GameStatisticsDialog : Form
    {
        private static System.Drawing.Font _defaultFont = new System.Drawing.Font("Microsoft Sans Serif", 
            9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private static System.Drawing.Font _customFont = new System.Drawing.Font("Microsoft Sans Serif", 
            9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        public GameStatisticsDialog()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialogWithData(List<Model.Partita.Statistica> statistiche, string currency)
        {
            _winnerLabel.Text = "Il vincitore della partita è " + statistiche[0]._nomeGiocatore;
            foreach (Model.Partita.Statistica statistica in statistiche)
            {
                this._statisticsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
                this._statisticsPanel.Controls.Add(this.CreateRowLabel(statistica._nomeGiocatore, _customFont));
                this._statisticsPanel.Controls.Add(this.CreateRowLabel(statistica._capitale + " "+ currency, _defaultFont));
                this._statisticsPanel.Controls.Add(this.CreateRowLabel(statistica._numeroTerreniPosseduti.ToString(), _defaultFont));
                this._statisticsPanel.Controls.Add(this.CreateRowLabel(statistica._valoreComplessivoTerreni + " " + currency, _defaultFont));
                this._statisticsPanel.Controls.Add(this.CreateRowLabel(statistica._numeroCasePossedute.ToString(), _defaultFont));
                this._statisticsPanel.Controls.Add(this.CreateRowLabel(statistica._numeroAlberghiPosseduti.ToString(), _defaultFont));
                this._statisticsPanel.Controls.Add(this.CreateRowLabel(statistica._valoreComplessivoEdifici + " " + currency, _defaultFont));
                this._statisticsPanel.Controls.Add(this.CreateRowLabel(statistica._valoreTotale + " " + currency, _customFont));
            }
            //this._statisticsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            return base.ShowDialog();
        }

        protected virtual Label CreateRowLabel(string text, System.Drawing.Font font)
        {
            Label result = new Label();
            result.Dock = DockStyle.Fill;
            result.Font = font;
            result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            result.Text = text;
            return result;
        }
    }
}
