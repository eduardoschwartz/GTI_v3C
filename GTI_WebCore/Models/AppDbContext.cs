using Microsoft.EntityFrameworkCore;

namespace GTI_WebCore.Models {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Anexo>().HasKey(c => new { c.Ano, c.Numero });
            modelBuilder.Entity<Areas>().HasKey(c => new { c.Codreduzido, c.Seqarea });
            modelBuilder.Entity<Bairro>().HasKey(c =>new { c.Siglauf, c.Codcidade,c.Codbairro });
            modelBuilder.Entity<Cep>().HasKey(c => new { c.Codlogr, c.cep, c.Valor1 });
            modelBuilder.Entity<Certidao_debito>().HasKey(c => new { c.Numero, c.Ano,c.Ret });
            modelBuilder.Entity<Certidao_debito_doc>().HasKey(c => new { c.Numero, c.Ano, c.Ret });
            modelBuilder.Entity<Certidao_endereco>().HasKey(c => new { c.Numero, c.Ano });
            modelBuilder.Entity<Certidao_Inscricao>().HasKey(c => new { c.Numero, c.Ano });
            modelBuilder.Entity<Certidao_Inscricao_Extrato>().HasKey(c => new { c.Numero_certidao, c.Ano_certidao,c.Codigo,c.Ano,c.Lancamento_Codigo,c.Sequencia,c.Parcela,c.Complemento });
            modelBuilder.Entity<Certidao_isencao>().HasKey(c => new { c.Numero, c.Ano });
            modelBuilder.Entity<Certidao_valor_venal>().HasKey(c => new { c.Numero, c.Ano });
            modelBuilder.Entity<Cidade>().HasKey(c => new { c.Siglauf, c.Codcidade });
            modelBuilder.Entity<Cnaesubclasse>().HasKey(c => new { c.Secao, c.Divisao, c.Grupo, c.Classe, c.Subclasse });
            modelBuilder.Entity<Facequadra>().HasKey(c => new { c.Coddistrito, c.Codsetor, c.Codquadra, c.Codface });
            modelBuilder.Entity<Isencao>().HasKey(c => new { c.Codreduzido, c.Anoisencao, c.Codisencao });
            modelBuilder.Entity<Laseriptu>().HasKey(c => new { c.Ano, c.Codreduzido});
            modelBuilder.Entity<Mobiliariocnae>().HasKey(c => new { c.Codmobiliario, c.Secao, c.Divisao, c.Grupo, c.Classe, c.Subclasse });
            modelBuilder.Entity<Mobiliarioevento>().HasKey(c => new { c.Codmobiliario, c.Codtipoevento,c.Seqevento });
            modelBuilder.Entity<Mobiliarioatividadeiss>().HasKey(c => new { c.Codmobiliario, c.Codtributo, c.Codatividade, c.Seq });
            modelBuilder.Entity<Mobiliarioproprietario>().HasKey(c => new { c.Codmobiliario, c.Codcidadao });
            modelBuilder.Entity<Mobiliariovs>().HasKey(c => new { c.Codigo, c.Cnae, c.Criterio });
            modelBuilder.Entity<Processoend>().HasKey(c => new { c.Ano, c.Numprocesso,c.Codlogr,c.Numero });
            modelBuilder.Entity<Processodoc>().HasKey(c => new { c.Ano, c.Numero, c.Coddoc });
            modelBuilder.Entity<Processogti>().HasKey(c => new { c.Ano, c.Numero});
            modelBuilder.Entity<Proprietario>().HasKey(c => new { c.Codreduzido, c.Codcidadao });
            modelBuilder.Entity<SpCalculo>().HasKey(c => new { c.Codigo, c.Ano });
            modelBuilder.Entity<SpExtrato>().HasKey(c => new { c.Usuario, c.Codreduzido,  c.Anoexercicio, c.Codlancamento, c.Seqlancamento, c.Numparcela, c.Codcomplemento,c.Codtributo });
        }


        public DbSet<Anexo> Anexo { get; set; }
        public DbSet<Anexo_log> Anexo_Log { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Benfeitoria> Benfeitoria { get; set; }
        public DbSet<Cadimob> Cadimob { get; set; }
        public DbSet<Categprop> Categprop { get; set; }
        public DbSet<Centrocusto> Centrocusto { get; set; }
        public DbSet<Cep> Cep { get; set; }
        public DbSet<Certidao_debito> Certidao_Debito { get; set; }
        public DbSet<Certidao_debito_doc> Certidao_Debito_Doc { get; set; }
        public DbSet<Certidao_endereco> Certidao_Endereco { get; set; }
        public DbSet<Certidao_Inscricao> Certidao_Inscricao { get; set; }
        public DbSet<Certidao_Inscricao_Extrato> Certidao_Inscricao_Extrato { get; set; }
        public DbSet<Certidao_isencao> Certidao_Isencao { get; set; }
        public DbSet<Certidao_valor_venal> Certidao_Valor_Venal { get; set; }
        public DbSet<Cidadao> Cidadao { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Cnae> Cnae { get; set; }
        public DbSet<Cnaesubclasse> Cnaesubclasse { get; set; }
        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public DbSet<Endentrega> Endentrega { get; set; }
        public DbSet<Facequadra> Facequadra { get; set; }
        public DbSet<Horario_funcionamento> Horario_funcionamento { get; set; }
        public DbSet<Isencao> Isencao { get; set; }
        public DbSet<Laseriptu> LaserIPTU { get; set; }
        public DbSet<Logradouro> Logradouro { get; set; }
        public DbSet<Mobiliario> Mobiliario { get; set; }
        public DbSet<Mobiliarioatividadeiss> Mobiliarioatividadeiss { get; set; }
        public DbSet<Mobiliariocnae> Mobiliariocnae { get; set; }
        public DbSet<Mobiliarioevento> Mobiliarioevento { get; set; }
        public DbSet<Mobiliarioproprietario> Mobiliarioproprietario { get; set; }
        public DbSet<Mobiliariovs> Mobiliariovs { get; set; }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Pedologia> Pedologia { get; set; }
        public DbSet<Periodomei> Periodomei { get; set; }
        public DbSet<Processogti> Processogti { get; set; }
        public DbSet<Processoend> Processoend { get; set; }
        public DbSet<Processodoc> Processodoc { get; set; }
        public DbSet<Proprietario> Proprietario { get; set; }
        public DbSet<Situacao> Situacao { get; set; }
        public DbSet<SpCalculo> SpCalculo { get; set; }
        public DbSet<SpExtrato> SpExtrato { get; set; }
        public DbSet<Topografia> Topografia { get; set; }
        public DbSet<Usoterreno> Usoterreno { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Vwproprietarioduplicado> Vwproprietarioduplicado { get; set; }
    }
}
