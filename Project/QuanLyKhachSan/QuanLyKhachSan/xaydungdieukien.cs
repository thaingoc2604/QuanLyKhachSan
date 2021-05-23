using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    class xaydungdieukien
    {
        public string orAnd { get; set; }
        public string Feild { get; set; }

        public string Operator { get; set; }

        public string inputsearching { get; set; }
        public string convertOperatorWithInput { get; set; }
        public string buildMotDieuKien { get; set; }
        public xaydungdieukien(string _orAnd, string _Feild, string _Operator, string _inputsearching)
        {
            this.orAnd = _orAnd;
            this.Feild = _Feild;
            this.Operator = _Operator;
            this.inputsearching = _inputsearching;

        }
        public string motDieuKien(string _orAnd, string _Feild, string _Operator, string _inputsearching)
        {
            /*if(_Operator == "Equal")
            {
                convertOperatorWithInput = " = '" + _inputsearching + "'";
                return convertOperatorWithInput;
            }Containt
                Not containt*/
            switch (_Operator)
            {
                case "Equal":
                    convertOperatorWithInput = " = '" + _inputsearching + "' ";
                    break;
                case "Containt":
                    convertOperatorWithInput = " LIKE '%" + _inputsearching + "%' ";
                    break;
                case "Not containt":
                    convertOperatorWithInput = " != '" + _inputsearching + "' ";
                    break;
                default:
                    break;

            }
            buildMotDieuKien = " " + _orAnd + " " + _Feild + " " + convertOperatorWithInput + ""; 
            return buildMotDieuKien;
        }

    }
}
