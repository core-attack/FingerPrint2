using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FingerPrint2
{
    public class Finger
    {
        public string name = "";
        // метод количества пересекаемых линий
        // количество пересекаемых линий
        public int m1kolPerLines = 0;
        // длина пересекающего отрезка
        public double m1lengthLine = 0;

        // метод косинуса угла
        // длина катета
            public double m2lengthKatet = 0;
            // длина гипотенузы
            public double m2lengthGipotenus = 0;

        // метод отношения косинусов углов
            // длина катета для левого угла
            public double m3lengthKatetLeft = 0;
            // длина гипотенузы левого угла
            public double m3lengthGipotenusLeft = 0;
            // длина катета правого угла
            public double m3lengthKatetRight = 0;
            // длина гипотенузы правого угла
            public double m3lengthGipotenusRight = 0;

        // метод отношения площадей трапеций
            // длина нижнего основания обеих трапеций
            public double m4lengthOsnObTrap = 0;
            // длина правой боковой стороны левой трапеции
            public double m4lengthRightBokSLeftTrap = 0;
            // длина верхнего основания левой трапеции
            public double m4lengthUpLeftTrap = 0;
            // длина левой боковой стороны левой трапеции
            public double m4lengthLeftBokSLeftTrap = 0;
            // длина правой боковой стороны правой трапеции
            public double m4lengthRightBokSRightTrap = 0;
            // длина верхнего основания правой трапеции
            public double m4lengthUpRightTrap = 0;
            // длина левой боковой стороны правой трапеции
            public double m4lengthLeftBokSRightTrap = 0;

        // метод отношения площадей треугольников
            // длина стороны большого основания 
            public double m5lengthBigOsn = 0;
            // длина левой стороны от угла альфа
            public double m5lengthLeftAlp = 0;
            // длина меньшего основания
            public double m5lengthminOsn = 0;
            // длина стороны справа от бета
            public double m5lengthRightBeta = 0;
            // длина стороны напротив угла альфа (бета)
            public double m5lengthOppositeBeta = 0;

        //метод отношения площади треугольника и трапеции
            //нижнее основание трапеции
            public double m6bottomOsnTrap = 0;
            //правая боковая сторона трапеции
            public double m6rightTrap = 0;
            //верхнее основание трапеции
            public double m6upOsnTrap = 0;
            //левая боковая сторона трапеции
            public double m6leftTrap = 0;
            //правая боковая сторона треугольника
            public double m6rightTriangle = 0;
            //левая боковая сторона треугольника
            public double m6leftTriangle = 0;

        //метод отношения площади треугольника и эллипса
            //основание треугольника
            public double m7osnTriangle = 0;
            //правая боковая сторона треугольника
            public double m7rightTriangle = 0;
            //левая боковая сторона треугольника
            public double m7leftTriangle = 0;
            //половина большой полуоси эллипса
            public double m7halfBigHalfAxis = 0;
            //половина маой полуоси эллипса
            public double m7halfSmallHalfAxis = 0;
        /*// угол альфа
        public int m5angleAlp = 0;
        // угол бета
        public int m5angleBeta = 0;*/
        // возвращает количество всех параметров данного метода
        public int GET_ALL_PARAM = 0;

        //возвращает список всех длин и параметров этого пальца в одном массиве
        public List<double> GetDoubleList()
        {
            List<double> l = new List<double>();
            l.Add(m1kolPerLines);
            l.Add(m1lengthLine);
            l.Add(m2lengthKatet);
            l.Add(m2lengthGipotenus);
            l.Add(m3lengthKatetLeft);
            l.Add(m3lengthGipotenusLeft);
            l.Add(m3lengthKatetRight);
            l.Add(m3lengthGipotenusRight);
            l.Add(m4lengthOsnObTrap);
            l.Add(m4lengthRightBokSLeftTrap);
            l.Add(m4lengthUpLeftTrap);
            l.Add(m4lengthLeftBokSLeftTrap);
            l.Add(m4lengthRightBokSRightTrap);
            l.Add(m4lengthUpRightTrap);
            l.Add(m4lengthLeftBokSRightTrap);
            l.Add(m5lengthBigOsn);
            l.Add(m5lengthLeftAlp);
            l.Add(m5lengthminOsn);
            l.Add(m5lengthRightBeta);
            l.Add(m5lengthOppositeBeta);
            //l.Add(m5angleAlp);
            //l.Add(m5angleBeta);
            return l;
        }

        //задает значения всем компанентам для петлевого узора
        public void SetAll(int m1_kolPerLines, double m1_lengthLine, double m2_lengthKatet, double m2_lengthGipotenus,
            double m3_lengthKatetLeft, double m3_lengthGipotenusLeft, double m3_lengthKatetRight, double m3_lengthGipotenusRight,
            double m4_lengthOsnObTrap, double m4_lengthRightBokSLeftTrap, double m4_lengthUpLeftTrap, double m4_lengthLeftBokSLeftTrap,
            double m4_lengthRightBokSRightTrap, double m4_lengthUpRightTrap, double m4_lengthLeftBokSRightTrap,
            double m5_lengthBigOsn, double m5_lengthLeftAlp, double m5_lengthRightBeta, double m5_lengthminOsn, double m5_lengthOppositeBeta /*m5_angleAlp, int m5_angleBeta*/)
        {
            /*0*/m1kolPerLines = m1_kolPerLines; GET_ALL_PARAM++;
            /*1*/m1lengthLine = m1_lengthLine; GET_ALL_PARAM++;
            /*2*/m2lengthKatet = m2_lengthKatet; GET_ALL_PARAM++;
            /*3*/m2lengthGipotenus = m2_lengthGipotenus; GET_ALL_PARAM++;
            /*4*/m3lengthKatetLeft = m3_lengthKatetLeft; GET_ALL_PARAM++;
            /*5*/m3lengthGipotenusLeft = m3_lengthGipotenusLeft; GET_ALL_PARAM++;
            /*6*/m3lengthKatetRight = m3_lengthKatetRight; GET_ALL_PARAM++;
            /*7*/m3lengthGipotenusRight = m3_lengthGipotenusRight; GET_ALL_PARAM++;
            /*8*/m4lengthOsnObTrap = m4_lengthOsnObTrap; GET_ALL_PARAM++;
            /*9*/m4lengthRightBokSLeftTrap = m4_lengthRightBokSLeftTrap; GET_ALL_PARAM++;
            /*10*/m4lengthUpLeftTrap = m4_lengthUpLeftTrap; GET_ALL_PARAM++;
            /*11*/m4lengthLeftBokSLeftTrap = m4_lengthLeftBokSLeftTrap; GET_ALL_PARAM++;
            /*12*/m4lengthRightBokSRightTrap = m4_lengthRightBokSRightTrap; GET_ALL_PARAM++;
            /*13*/m4lengthUpRightTrap = m4_lengthUpRightTrap; GET_ALL_PARAM++;
            /*14*/m4lengthLeftBokSRightTrap = m4_lengthLeftBokSRightTrap; GET_ALL_PARAM++;
            /*15*/m5lengthBigOsn = m5_lengthBigOsn; GET_ALL_PARAM++;
            /*16*/m5lengthLeftAlp = m5_lengthLeftAlp; GET_ALL_PARAM++;
            /*17*/m5lengthminOsn = m5_lengthminOsn; GET_ALL_PARAM++;
            /*18*/m5lengthRightBeta = m5_lengthRightBeta; GET_ALL_PARAM++;
            /*19*/m5lengthOppositeBeta = m5_lengthOppositeBeta; GET_ALL_PARAM++;
            //*19*/m5angleAlp = m5_angleAlp; GET_ALL_PARAM++;
            //*20*/m5angleBeta = m5_angleBeta; GET_ALL_PARAM++;
        }

        //для дугового
        public void SetAllDug(int m1_kolPerLines, double m1_lengthLine, 
            double m3_lengthKatetLeft, double m3_lengthGipotenusLeft, double m3_lengthKatetRight, double m3_lengthGipotenusRight,
            double m5_lengthBigOsn, double m5_lengthLeftAlp, double m5_lengthminOsn, double m5_lengthRightBeta, double m5_lengthOppositeBeta, 
            double m6_bottomOsnTrap, double m6_rightTrap, double m6_upOsnTrap, double m6_leftTrap, double m6_rightTriangle, double m6_leftTriangle,
            double m7_osnTriangle, double m7_rightTriangle, double m7_leftTriangle, double m7_halfBigHalfAxis, double m7_halfSmallHalfAxis)
        {

            m1kolPerLines = m1_kolPerLines; GET_ALL_PARAM++;
            m1lengthLine = m1_lengthLine; GET_ALL_PARAM++;
            m3lengthKatetLeft = m3_lengthKatetLeft; GET_ALL_PARAM++;
            m3lengthGipotenusLeft = m3_lengthGipotenusLeft; GET_ALL_PARAM++;
            m3lengthKatetRight = m3_lengthKatetRight; GET_ALL_PARAM++;
            m3lengthGipotenusRight = m3_lengthGipotenusRight; GET_ALL_PARAM++;
            m5lengthBigOsn = m5_lengthBigOsn; GET_ALL_PARAM++;
            m5lengthLeftAlp = m5_lengthLeftAlp; GET_ALL_PARAM++;
            m5lengthRightBeta = m5_lengthRightBeta; GET_ALL_PARAM++;
            m5lengthminOsn = m5_lengthminOsn; GET_ALL_PARAM++;
            m5lengthOppositeBeta = m5_lengthOppositeBeta; GET_ALL_PARAM++;
            m6bottomOsnTrap = m6_bottomOsnTrap; GET_ALL_PARAM++;
            m6rightTrap = m6_rightTrap; GET_ALL_PARAM++;
            m6upOsnTrap = m6_upOsnTrap; GET_ALL_PARAM++;
            m6leftTrap = m6_leftTrap; GET_ALL_PARAM++;
            m6rightTriangle = m6_rightTriangle; GET_ALL_PARAM++;
            m6leftTriangle = m6_leftTriangle; GET_ALL_PARAM++;
            m7osnTriangle = m7_osnTriangle; GET_ALL_PARAM++;
            m7rightTriangle = m7_rightTriangle; GET_ALL_PARAM++;
            m7leftTriangle = m7_leftTriangle; GET_ALL_PARAM++;
            m7halfBigHalfAxis = m7_halfBigHalfAxis; GET_ALL_PARAM++;
            m7halfSmallHalfAxis = m7_halfSmallHalfAxis; GET_ALL_PARAM++;
            
        }
        // все композиции заполнены
        public bool AllKompositionFilled()
        {
            double n = m1kolPerLines + m1lengthLine + m2lengthKatet + m2lengthGipotenus + m3lengthKatetLeft +
                m3lengthGipotenusLeft + m3lengthKatetRight + m3lengthGipotenusRight + m4lengthOsnObTrap + m4lengthRightBokSLeftTrap +
                m4lengthUpLeftTrap + m4lengthLeftBokSLeftTrap + m4lengthRightBokSRightTrap + m4lengthUpRightTrap +
                m4lengthLeftBokSRightTrap + m5lengthBigOsn + m5lengthLeftAlp + m5lengthminOsn + m5lengthRightBeta + m5lengthOppositeBeta/*m5angleAlp + m5angleBeta*/;
            if (Convert.ToInt16(n) == 0)
                return false;
            else
                return true;
        }

        
    }
}
