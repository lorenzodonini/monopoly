using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    public class TerrenoSpeciale : Terreno
    {
        public TerrenoSpeciale(int id, string nome, decimal valore, decimal valoreDiVendita, decimal[] valoriDiAffitto, 
            string nomeGruppo) : base(id, nome, valore, valoreDiVendita, valoriDiAffitto, nomeGruppo)
        {
        }

        public override void AggiornaAffitto(int terreniDelGruppo)
        {
            Affitto = ValoriDiAffitto[Proprietario.TerreniPerGruppo[NomeGruppo] - 1];
        }

        public override bool IsVendibile(int terreniDelGruppo, List<Terreno> terreniDelGruppoPosseduti)
        {
            return true;
        }
    }
}
