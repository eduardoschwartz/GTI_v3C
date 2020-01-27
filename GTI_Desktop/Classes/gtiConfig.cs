using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace GTI_Desktop.Classes {
    public class gtiConfig {
        private string _servername;
        private string _databasereal;
        private string _databaseteste;
        private string _pathapp;
        private string _pathreport;
        private string _pathanexo;
        private string _computername;
        private string _username;

        [CategoryAttribute("Acesso"), DescriptionAttribute("Nome do servidor"),DisplayName("Servidor de Dados")]
        public string ServerName {
            get { return _servername; }
            set { _servername = value; }
        }

        [CategoryAttribute("Acesso"), DescriptionAttribute("Nome do banco de dados real"), ReadOnly(true), DisplayName("Base de Dados Produção")]
        public string DataBaseReal {
            get { return _databasereal; }
            set { _databasereal = value; }
        }

        [CategoryAttribute("Acesso"), DescriptionAttribute("Nome do banco de dados teste"), ReadOnly(true), DisplayName("Base de Dados Teste")]
        public string DataBaseTeste {
            get { return _databaseteste; }
            set { _databaseteste = value; }
        }

        [CategoryAttribute("Acesso"), DescriptionAttribute("Caminho da aplicação"), ReadOnly(true), DisplayName("Caminho da Aplicação")]
        public string PathApp {
            get { return _pathapp; }
            set { _pathapp = value; }
        }

        [CategoryAttribute("Acesso"), DescriptionAttribute("Caminho dos relatórios"), ReadOnly(true), DisplayName("Caminho dos Relatórios")]
        public string PathReport {
            get { return _pathreport; }
            set { _pathreport = value; }
        }

        [CategoryAttribute("Acesso"), DescriptionAttribute("Caminho dos anexos"), ReadOnly(true), DisplayName("Caminho dos Anexos")]
        public string PathAnexo {
            get { return _pathanexo; }
            set { _pathanexo = value; }
        }

        [CategoryAttribute("Computador"), DescriptionAttribute("Nome do computador"), ReadOnly(true), DisplayName("Nome do Computador")]
        public string ComputerName {
            get { return _computername; }
            set { _computername = value; }
        }

        [CategoryAttribute("Computador"), DescriptionAttribute("Nome do usuário"), ReadOnly(true), DisplayName("Usuário Logado")]
        public string UserName {
            get { return _username; }
            set { _username = value; }
        }

    }




}
