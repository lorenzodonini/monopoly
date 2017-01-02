using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monopoli.Model
{
    class ParcheggioGratuito : Casella
    {
        private Image _image;

        public ParcheggioGratuito(int id, string nome, string tipoCella, Image image) 
            : base(id, nome, tipoCella)
        {
            _image = image;
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
