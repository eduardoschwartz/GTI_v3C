using GTI_WebCore.Models;
using System.Collections.Generic;

namespace GTI_WebCore.Interfaces {
    public interface IEmpresaRepository {
        bool Existe_Empresa_Codigo(int Codigo);
        int Existe_Empresa_Cnpj(string Cnpj);
        int Existe_Empresa_Cpf(string Cpf);
        bool Empresa_Suspensa(int nCodigo);
        EmpresaStruct Dados_Empresa(int Codigo);
        bool Empresa_tem_VS(int nCodigo);
        bool Empresa_tem_TL(int nCodigo);
        string Retorna_Descricao_Cnae(string cnae);
        List<CnaeStruct> Lista_Cnae_Empresa(int nCodigo);
        string Regime_Empresa(int Codigo);
        bool Empresa_Mei(int nCodigo);
        List<int> Retorna_Codigo_por_CPF(string CPF);
        List<int> Retorna_Codigo_por_CNPJ(string CNPJ);
    }
}
