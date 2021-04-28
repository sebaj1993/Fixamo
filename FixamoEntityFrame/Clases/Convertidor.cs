using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixamoEntityFrame.Clases
{
    class Convertidor
    {
        private static string letras;
        private static string Convertir(double nro)
        {
            if (nro == 0) letras = "CERO";
            else if (nro == 1) letras = "UN";
            else if (nro == 2) letras = "DOS";
            else if (nro == 3) letras = "TRES";
            else if (nro == 4) letras = "CUATRO";
            else if (nro == 5) letras = "CINCO";
            else if (nro == 6) letras = "SEIS";
            else if (nro == 7) letras = "SIETE";
            else if (nro == 8) letras = "OCHO";
            else if (nro == 9) letras = "NUEVE";
            else if (nro == 10) letras = "DIEZ";
            else if (nro == 11) letras = "ONCE";
            else if (nro == 12) letras = "DOCE";
            else if (nro == 13) letras = "TRECE";
            else if (nro == 14) letras = "CATORCE";
            else if (nro == 15) letras = "QUINCE";
            else if (nro < 20) letras = "DIECI" + Convertir(nro - 10);
            else if (nro == 20) letras = "VEINTE";
            else if (nro < 30) letras = "VEINTI" + Convertir(nro - 20);
            else if (nro == 30) letras = "TREINTA";
            else if (nro < 40) letras = "TREINTA Y " + Convertir(nro - 30);
            else if (nro == 40) letras = "CUARENTA";
            else if (nro < 50) letras = "CUARENTA Y " + Convertir(nro - 40);
            else if (nro == 50) letras = "CINCUENTA";
            else if (nro < 60) letras = "CINCUENTA Y " + Convertir(nro - 50);
            else if (nro == 60) letras = "SESENTA";
            else if (nro < 70) letras = "SESENTA Y " + Convertir(nro - 60);
            else if (nro == 70) letras = "SETENTA";
            else if (nro < 80) letras = "SETENTA Y " + Convertir(nro - 70);
            else if (nro == 80) letras = "OCHENTA";
            else if (nro < 90) letras = "OCHENTA Y " + Convertir(nro - 80);
            else if (nro == 90) letras = "NOVENTA";
            else if (nro < 100) letras = "NOVENTA Y " + Convertir(nro - 90);
            else if (nro == 100) letras = "CIEN";
            else if (nro < 200) letras = "CIENTO " + Convertir(nro - 100);
            else if (nro == 200) letras = "DOSCIENTOS";
            else if (nro < 300) letras = "DOSCIENTOS " + Convertir(nro - 200);
            else if (nro == 300) letras = "TRESCIENTOS";
            else if (nro < 400) letras = "TRESCIENTOS " + Convertir(nro - 300);
            else if (nro == 400) letras = "CUATROCIENTOS";
            else if (nro < 500) letras = "CUATROCIENTOS " + Convertir(nro - 400);
            else if (nro == 500) letras = "QUINIENTOS";
            else if (nro < 600) letras = "QUINIENTOS " + Convertir(nro - 500);
            else if (nro == 600) letras = "SEISCIENTOS";
            else if (nro < 700) letras = "SEISCIENTOS " + Convertir(nro - 600);
            else if (nro == 700) letras = "SETECIENTOS";
            else if (nro < 800) letras = "SETECIENTOS " + Convertir(nro - 700);
            else if (nro == 800) letras = "OCHOCIENTOS";
            else if (nro < 900) letras = "OCHOCIENTOS " + Convertir(nro - 800);
            else if (nro == 900) letras = "NOVECIENTOS";
            else if (nro < 1000) letras = "NOVECIENTOS " + Convertir(nro - 900);
            else if (nro == 1000) letras = "MIL";
            else if (nro < 2000) letras = "MIL " + Convertir(nro - 1000);
            else if (nro < 1000000)
            {
                if ((nro % 1000) == 0) letras = Convertir(nro / 1000) + " MIL";
                else letras = Convertir(Math.Truncate(nro / 1000)) + " MIL " + Convertir(Math.Truncate(nro % 1000));
            }
            else if (nro == 1000000) letras = "UN MILLON";
            else if (nro < 2000000) letras = "UN MILLON " + Convertir(nro - 1000000);
            else if (nro < 1000000000)
            {
                if ((nro % 1000000) == 0) letras = Convertir(nro / 1000000) + " MILLONES";
                else letras = Convertir(Math.Truncate(nro / 1000000)) + " MILLONES " + Convertir(Math.Truncate(nro % 1000000));
            }
            else if (nro == 1000000000) letras = "MIL MILLONES";
            else if (nro < 2000000000) letras = "MIL " + Convertir(Math.Truncate(nro % 1000000000));
            else if (nro < 1000000000000)
            {
                if ((nro % 1000000000) == 0) letras = Convertir(nro / 1000000000) + " MIL MILLONES";
                else letras = Convertir(Math.Truncate(nro / 1000000000)) + " MIL " + Convertir(Math.Truncate(nro % 1000000000));
            }
            return letras;
        }

        public static StringBuilder convertir_numero_a_letras(double nro)
        {
            double nro1 = Math.Round(nro, 2);
            StringBuilder s = new StringBuilder();
            //Me quedo con la parte entera del numero
            int parteEntera = (int)nro1 ;
            s.Append(Convertir(parteEntera) + " PESOS");//Devuelve la parte entera en letras
            //Me quedo con la parte decimal
            int parteDecimal = (int)nro1 % 100;
            if (parteDecimal > 0)
            { //Si tiene centavos, convertirlos a letras
                s.Append(" CON " + Convertir(parteDecimal) + " CENTAVOS");
            }
            return s;

        }
    }
}
