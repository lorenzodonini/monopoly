using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monopoli.Model
{
    public class Prigione : Casella
    {
        private decimal _cauzione;
        private Image _image;

        public Prigione(int id, string nome, string tipoCella, decimal cauzione, Image image)
            : base(id, nome, tipoCella)
        {
            this._cauzione = cauzione;
            _image = image;
        }

        public decimal Cauzione
        {
            get
            {
                return this._cauzione;
            }
        }

        public Image Image
        {
            get { return _image; }
        }

        #region Casella
        public override void EseguiOperazione(Giocatore giocatore)
        {
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
