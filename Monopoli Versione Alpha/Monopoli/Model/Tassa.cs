using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monopoli.Model
{
    class Tassa : Casella
    {
        private readonly Image _image;
        private readonly decimal _importo;

        public event EventHandler TassaEvent;

        public Tassa(int id, string nome, string tipoCella, decimal importo, Image image)
            : base(id, nome, tipoCella)
        {
            this._importo = importo;
            _image = image;
        }

        public decimal Importo
        {
            get
            {
                return this._importo;
            }
        }

        public Image Image
        {
            get { return _image; }
        }

        #region Casella
        public override void EseguiOperazione(Giocatore giocatore)
        {
            if (TassaEvent != null)
            {
                TassaEvent(this, EventArgs.Empty);
            }
        }

        public override IEnumerable<object> GetParametriCella()
        {
            List<object> result = new List<object>();
            result.Add(ID);
            result.Add(Nome);
            result.Add(Importo);
            result.Add(Image);
            return result;
        }
        #endregion
    }
}
