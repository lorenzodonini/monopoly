using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monopoli.Model
{
    public class TerrenoSpeciale : Terreno
    {
        private readonly Image _image;

        public TerrenoSpeciale(int id, string nome, string tipoCella, decimal valore, decimal valoreDiVendita, decimal[] valoriDiAffitto, 
            string nomeGruppo, Image image) : base(id, nome, tipoCella, valore, valoreDiVendita, valoriDiAffitto, nomeGruppo)
        {
            _image = image;
        }

        public Image Image
        {
            get { return _image; }
        }

        #region Terreno
        public override void AggiornaAffitto(int terreniDelGruppo)
        {
            if (Proprietario != null)
            {
                Affitto = ValoriDiAffitto[Proprietario.TerreniPerGruppo[NomeGruppo] - 1];
            }
            else
            {
                Affitto = ValoriDiAffitto[0];
            }
        }

        public override bool IsVendibile(int terreniDelGruppo, List<Terreno> terreniDelGruppoPosseduti)
        {
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
            result.Add(_image);
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
            result.Add(_image);
            return result;
        }
        #endregion
    }
}
