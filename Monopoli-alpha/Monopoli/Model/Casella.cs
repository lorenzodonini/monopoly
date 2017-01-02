using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{

    public abstract class Casella
    {
        private readonly int _id;
        private readonly string _nome;
        private readonly string _tipoCella;

        protected Casella(int id, string nome, string tipoCella)
        {
            this._id = id;
            this._nome = nome;
            this._tipoCella = tipoCella;
        }

        #region Properties
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

        public string TipoCella
        {
            get { return _tipoCella; }
        }
        #endregion

        public abstract void EseguiOperazione(Giocatore giocatore);

        public abstract IEnumerable<object> GetParametriCella();
    }
}
