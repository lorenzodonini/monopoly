using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    public delegate void CasellaHandler(object sender, EventArgs e);

    public abstract class Casella
    {
        private int _id;
        private string _nome;

        protected Casella(int id, string nome)
        {
            this._id = id;
            this._nome = nome;
        }

        public int ID
        {
            get
            {
                return this._id;
            }
        }

        public string Nome
        {
            get
            {
                return this._nome;
            }
        }

        public abstract void EseguiOperazione(Giocatore giocatore);
    }
}
