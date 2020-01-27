using GTI_Dal.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;

namespace GTI_Bll.Classes {
    public class Eicon_bll {
        private static string _connection;

        public Eicon_bll(string sConnection) {
            _connection = sConnection;
        }

        /// <summary>
        /// Retorna a lista das competências pagas de ISS
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<CompetenciaISS> Resumo_CompetenciaISS(int Codigo) {
            Eicon_Data obj = new Eicon_Data(_connection);
            return obj.Resumo_CompetenciaISS(Codigo);
        }


    }
}
