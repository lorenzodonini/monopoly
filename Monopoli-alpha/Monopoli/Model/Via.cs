using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monopoli.Model
{
    public class Via : Casella
    {
        private readonly Image _image;
        private readonly decimal _indennità;

        public Via(int id, string nome, string tipoCella, decimal indennità, Image image)
            : base(id, nome, tipoCella)
        {
            this._indennità = indennità;
            _image = image;
        }

        public decimal Indennità
        {
            get
            {
                return this._indennità;
            }
        }

        public Image Image
        {
            get { return _image; }
        }

        #region Casella
        public override void EseguiOperazione(Giocatore giocatore)
        {
            giocatore.IncrementaCapitale(this._indennità);

        }

        public override IEnumerable<object> GetParametriCella()
        {
            List<object> result = new List<object>();
            result.Add(ID);
            result.Add(Nome);
            result.Add(_image);
            return result;
        }
        #endregion
    }
}
