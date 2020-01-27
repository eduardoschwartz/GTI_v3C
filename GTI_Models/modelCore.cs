

namespace GTI_Models {
    /// <summary>
    /// Classe que contêm os tipos utilizados no sistema
    /// </summary>
    public class modelCore {
        public enum TipoCertidao { Endereco, ValorVenal, Isencao, Debito, Comprovante_Pagamento,Alvara,Debito_Doc }
        public enum TipoCadastro { Imovel, Empresa, Cidadao }
        public enum RetornoCertidaoDebito { Negativa, Positiva, NegativaPositiva}
        public enum TipoEndereco { Local, Proprietario, Entrega }
        public enum TipoDocumento { Cpf,Cnpj}
        public enum TipoCarne { Iptu=1,Iss_Taxa=2,Iss_Estimado_Variavel=3,Taxa=4,Vigilancia=5,Cip=6}
    }

    public class CompetenciaISS {
        public int Codigo { get; set; }
        public int Ano_Competencia { get; set; }
        public int Mes_Competencia { get; set; }
        public bool Encerrada { get; set; }
        public bool Sem_Movimento { get; set; }
        public decimal Valor { get; set; }
    }


}
