using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftMasterProyect.Logic
{
    internal class Elevator_algorithm
    {
        Algorithm_constants _Constants = new Algorithm_constants();
        #region CantPisos
        public int[] Floor_to_climb(int cantidadPersonas)
        {
            int CantMaxPisos = _Constants.GetCantMaxPisos();
            int CantMinPisos = _Constants.GetCantMinPisos();

            int[] pisos = new int[cantidadPersonas];
            Random random = new Random();

            for (int i = 0; i < cantidadPersonas; i++)
            {
                int numero = random.Next(CantMinPisos, CantMaxPisos);

                if (Array.IndexOf(pisos, numero) != -1)
                    pisos[i] = 0;
                else
                    pisos[i] = numero;
            }


            return pisos;
        }
        #endregion

        #region CantPersonas
        public Tuple<int>[] Amount_of_people()
        {
            Random random = new Random();
            int limitePeso = _Constants.GetMaxPeso();
            int limitePersonas = _Constants.GetCantMaxPersonas();
            int cantidadPersonas = random.Next(1, limitePersonas);
            Tuple<int>[] personas = new Tuple<int>[cantidadPersonas];

            int pesoTotal = 0;

            for (int i = 0; i <= cantidadPersonas-1; i++)
            {
                int pesoAletorio = random.Next(70,90);
                pesoTotal += pesoAletorio;
                if (pesoTotal < limitePeso)
                {
                    personas[i] = Tuple.Create(pesoAletorio);
                }
                else
                {
                    personas[i] = Tuple.Create(0);
                }
            }


            return personas;
        }
        #endregion
    }
}
