using GTI_WebCore.Models;
using System.Collections.Generic;

namespace GTI_WebCore.Interfaces {
    public interface IProcessoRepository {
        int DvProcesso(int Numero);
        ProcessoStruct Dados_Processo(int nAno, int nNumero);
        string Retorna_Assunto(int Codigo);
        List<ProcessoAnexoStruct> ListProcessoAnexo(int nAno, int nNumero);
        List<Anexo_logStruct> ListProcessoAnexoLog(int nAno, int nNumero);
        List<ProcessoDocStruct> ListProcessoDoc(int nAno, int nNumero);
        List<ProcessoEndStruct> ListProcessoEnd(int nAno, int nNumero);
    }
}
