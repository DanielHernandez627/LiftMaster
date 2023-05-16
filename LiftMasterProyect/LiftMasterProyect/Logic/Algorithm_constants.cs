using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftMasterProyect.Logic
{
    internal class Algorithm_constants
    {
        public static int CantMaxPisos { get; } = 6;
        public static int CantMinPisos { get; } = 1;
        public static int MaxPeso { get; } = 700;
        public static int CantMaxPersonas { get; } = 10;

        public int GetCantMaxPisos()
        {
            return CantMaxPisos;
        }

        public int GetCantMinPisos()
        {
            return CantMinPisos;
        }

        public int GetMaxPeso()
        {
            return MaxPeso;
        }

        public int GetCantMaxPersonas()
        {
            return CantMaxPersonas;
        }
    }
}
