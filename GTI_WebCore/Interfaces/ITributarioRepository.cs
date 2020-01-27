using GTI_WebCore.Models;
using System;
using System.Collections.Generic;

namespace GTI_WebCore.Interfaces {
    public interface ITributarioRepository {
        int Retorna_Codigo_Certidao(Functions.TipoCertidao tipo_certidao);
        chaveStruct Valida_Certidao(string Chave);
        Certidao_endereco Retorna_Certidao_Endereco(int Ano, int Numero, int Codigo);
        Certidao_valor_venal Retorna_Certidao_Valor_Venal(int Ano, int Numero, int Codigo);
        Certidao_isencao Retorna_Certidao_Isencao(int Ano, int Numero, int Codigo);
        Certidao_Inscricao Retorna_Certidao_Inscricao(int Ano, int Numero);
        Exception Insert_Certidao_Debito(Certidao_debito Reg);
        Exception Insert_Certidao_Debito_Doc(Certidao_debito_doc Reg);
        Exception Insert_Certidao_Endereco(Certidao_endereco Reg);
        Exception Insert_Certidao_Valor_Venal(Certidao_valor_venal Reg);
        Exception Insert_Certidao_Isencao(Certidao_isencao Reg);
        Exception Insert_Certidao_Inscricao(Certidao_Inscricao Reg);
        Exception Insert_Certidao_Inscricao_Extrato(Certidao_Inscricao_Extrato Reg);
        List<SpExtrato> Lista_Extrato_Tributo(int Codigo, short Ano1 = 1990, short Ano2 = 2050, short Lancamento1 = 1, short Lancamento2 = 99, short Sequencia1 = 0, short Sequencia2 = 9999,
                                              short Parcela1 = 0, short Parcela2 = 999, short Complemento1 = 0, short Complemento2 = 999, short Status1 = 0, short Status2 = 99, DateTime? Data_Atualizacao = null, string Usuario = "");
        List<SpExtrato> Lista_Extrato_Parcela(List<SpExtrato> Lista_Tributo);
        Certidao_debito_detalhe Certidao_Debito(int Codigo);
    }
}
