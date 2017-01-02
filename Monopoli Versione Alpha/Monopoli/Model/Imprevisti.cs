using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monopoli.Model
{
    class Imprevisti : Casella
    {
        public event EventHandler ImprevistiEvent;
        
        private readonly Image _image;

        public Imprevisti(int id, string nome, string tipoCella, Image image) :base(id, nome, tipoCella)
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
            if (ImprevistiEvent != null)
            {
                ImprevistiEvent(this, EventArgs.Empty);
            }
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
