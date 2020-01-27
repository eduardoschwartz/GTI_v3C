using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI_Desktop.Classes {
    public static class GtiTypes {
        public static string UserBinary { get; set; }

        internal class CustomListBoxItem {
            public int _value { get; set; }
            public string _name { get; set; }

            public CustomListBoxItem(string name, int value) {
                _name = name;
                _value = value;
            }

            public override string ToString() {
                return _name;
            }
        }

        public class CustomListBoxItem2 {
            public int _value { get; set; }
            public string _name { get; set; }
            public bool _ativo { get; set; }

            public CustomListBoxItem2(string name, int value,bool ativo) {
                _name = name;
                _value = value;
                _ativo = ativo;
            }

            public override string ToString() {
                return _name;
            }
        }

        internal class CustomListBoxItem3 {
            public int _value { get; set; }
            public string _name { get; set; }
            public string _name2 { get; set; }

            public CustomListBoxItem3(string name, int value, string name2) {
                _name = name;
                _value = value;
                _name2 = name2;
            }

            public override string ToString() {
                return _name;
            }
        }

        internal class CustomListBoxItem4 {
            public int _value { get; set; }
            public string _name { get; set; }
            public decimal _value2 { get; set; }

            public CustomListBoxItem4(string name, int value, decimal value2) {
                _name = name;
                _value = value;
                _value2 = value2;
            }

            public override string ToString() {
                return _name;
            }
        }

        internal class CustomListBoxItem5 {
            public string _name { get; set; }
            public int _value { get; set; }
            public int _value2 { get; set; }

            public CustomListBoxItem5(string name, int value, int value2) {
                _name = name;
                _value = value;
                _value2 = value2;
            }

            public override string ToString() {
                return _name;
            }
        }

    }

}
