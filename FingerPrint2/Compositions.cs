using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FingerPrint2
{
    public class Compositions
    {
        public double[] VALUE_LEFT_HAND = new double[5];
        public double[] VALUE_RIGHT_HAND = new double[5];
        public double[] ratio_c1 = new double[5];
        public double[] ratio_c2 = new double[5];
        public double[] ratio_c3 = new double[5];
        public double[] ratio_c4 = new double[5];
        public double[] ratio_c5 = new double[5];
        public double[] ratio_c6 = new double[5];
        public double[] ratio_c7 = new double[5];


        string error = "";

        // компизиция 1:  композиция количества пересекаемых линий
        public void composition1(double f1, double f2, double f3, double f4, double f5,
            int n1, int n2, int n3, int n4, int n5)
        {
            // 1
            double[] FingersLength = new double[5]; // для длин отрезков
            int[] FingersKolLines = new int[5]; // для количества пересекаемых линий
            FingersLength[0] = f1;
            FingersLength[1] = f2;
            FingersLength[2] = f3;
            FingersLength[3] = f4;
            FingersLength[4] = f5;

            FingersKolLines[0] = n1;
            FingersKolLines[1] = n2;
            FingersKolLines[2] = n3;
            FingersKolLines[3] = n4;
            FingersKolLines[4] = n5;
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    ratio_c1[i] = FingersLength[i] / FingersKolLines[i];
                }
            }
            catch (DivideByZeroException e)
            {
                error = "Недопустимое значение одного из параметров: проверьте правильность вычисления количества пересекаемых линий.";
            }
        }

        // компизиция 2:  композиция косинуса угла
        public void composition2(double f1, double f2, double f3, double f4, double f5,
            double f6, double f7, double f8, double f9, double f10)
        {
            // 2
            double[] FingersLengthCos = new double[10]; // для косинусов
            FingersLengthCos[0] = f1; // первые пять - для прилежащего катета
            FingersLengthCos[1] = f2;
            FingersLengthCos[2] = f3;
            FingersLengthCos[3] = f4;
            FingersLengthCos[4] = f5;

            FingersLengthCos[5] = f6; // вторые пять - для гипотенузы
            FingersLengthCos[6] = f7;
            FingersLengthCos[7] = f8;
            FingersLengthCos[8] = f9;
            FingersLengthCos[9] = f10;

            try
            {
                for (int i = 0; i < ratio_c2.Length; i++)
                {
                    ratio_c2[i] = FingersLengthCos[i] / FingersLengthCos[5 + i]; // вычисление косинуса угла
                }
            }
            catch (DivideByZeroException e)
            {
                error = "Недопустимое значение одного из параметров: проверьте правильность вычисления гипотенузы.";
            }
        }

        // компизиция 3:  композиция отношения косинусов углов
        public void composition3(double f1, double f2, double f3, double f4, double f5,
                                        double f6, double f7, double f8, double f9, double f10,
                                        double f11, double f12, double f13, double f14, double f15,
                                        double f16, double f17, double f18, double f19, double f20)
        {
            // 3
            double[] FingersLengthTwoCos = new double[20]; // для отношения косинусов
            FingersLengthTwoCos[0] = f1; // первые пять - для прилежащего катета левого треугольника
            FingersLengthTwoCos[1] = f2;
            FingersLengthTwoCos[2] = f3;
            FingersLengthTwoCos[3] = f4;
            FingersLengthTwoCos[4] = f5;

            FingersLengthTwoCos[5] = f6; // вторые пять - для гипотенузы левого треугольника
            FingersLengthTwoCos[6] = f7;
            FingersLengthTwoCos[7] = f8;
            FingersLengthTwoCos[8] = f9;
            FingersLengthTwoCos[9] = f10;

            FingersLengthTwoCos[10] = f11; // первые пять - для прилежащего катета правого треугольника
            FingersLengthTwoCos[11] = f12;
            FingersLengthTwoCos[12] = f13;
            FingersLengthTwoCos[13] = f14;
            FingersLengthTwoCos[14] = f15;

            FingersLengthTwoCos[15] = f16; // вторые пять - для гипотенузы правого треугольника
            FingersLengthTwoCos[16] = f17;
            FingersLengthTwoCos[17] = f18;
            FingersLengthTwoCos[18] = f19;
            FingersLengthTwoCos[19] = f20;

            try
            {
                for (int i = 0; i < ratio_c3.Length; i++)
                {
                    ratio_c3[i] = (FingersLengthTwoCos[10 + i] / FingersLengthTwoCos[15 + i]) / (FingersLengthTwoCos[i] / FingersLengthTwoCos[5 + i]); // вычисление косинуса угла
                }
            }
            catch (DivideByZeroException e)
            {
                error = "Недопустимое значение одного из параметров: проверьте правильность вычисления обеих гипотенуз.";
            }
        }

        // компизиция 4: композиция отношения площадей трапеций
        public void composition4(double f1, double f2, double f3, double f4, double f5,// нижние основания трапеций
                                        double f6, double f7, double f8, double f9, double f10, // правые боковые стороны левых трапеций
                                        double f11, double f12, double f13, double f14, double f15, // верхние основания левых трапеций
                                        double f16, double f17, double f18, double f19, double f20, // левые боковые стороны левых трапеций
                                        double f21, double f22, double f23, double f24, double f25,// правые боковые стороны правых трапеций
                                        double f26, double f27, double f28, double f29, double f30, // верхние основания правых трапеций
                                        double f31, double f32, double f33, double f34, double f35) // левые боковые стороны правых трапеций
        {
            // 4
            double[] FingersLengthTrap = new double[35]; // для отношения трапеций
            FingersLengthTrap[0] = f1;
            FingersLengthTrap[1] = f2;
            FingersLengthTrap[2] = f3;
            FingersLengthTrap[3] = f4;
            FingersLengthTrap[4] = f5;

            FingersLengthTrap[5] = f6;
            FingersLengthTrap[6] = f7;
            FingersLengthTrap[7] = f8;
            FingersLengthTrap[8] = f9;
            FingersLengthTrap[9] = f10;

            FingersLengthTrap[10] = f11;
            FingersLengthTrap[11] = f12;
            FingersLengthTrap[12] = f13;
            FingersLengthTrap[13] = f14;
            FingersLengthTrap[14] = f15;

            FingersLengthTrap[15] = f16;
            FingersLengthTrap[16] = f17;
            FingersLengthTrap[17] = f18;
            FingersLengthTrap[18] = f19;
            FingersLengthTrap[19] = f20;

            FingersLengthTrap[20] = f21;
            FingersLengthTrap[21] = f22;
            FingersLengthTrap[22] = f23;
            FingersLengthTrap[23] = f24;
            FingersLengthTrap[24] = f25;

            FingersLengthTrap[25] = f26;
            FingersLengthTrap[26] = f27;
            FingersLengthTrap[27] = f28;
            FingersLengthTrap[28] = f29;
            FingersLengthTrap[29] = f30;

            FingersLengthTrap[30] = f31;
            FingersLengthTrap[31] = f32;
            FingersLengthTrap[32] = f33;
            FingersLengthTrap[33] = f34;
            FingersLengthTrap[34] = f35;
            double s1 = 0.0;
            double s2 = 0.0;
            try
            {

                for (int i = 0; i < ratio_c4.Length; i++)
                {
                    s1 = S_trap(FingersLengthTrap[10 + i], FingersLengthTrap[i], FingersLengthTrap[15 + i], FingersLengthTrap[5 + i]);
                    s2 = S_trap(FingersLengthTrap[i], FingersLengthTrap[25 + i], FingersLengthTrap[30 + i], FingersLengthTrap[20 + i]);
                    ratio_c4[i] = s1 / s2;
                }
            }
            catch (DivideByZeroException e)
            {
                error = "Недопустимое значение одного из параметров: ";
                error += "S2 = " + Convert.ToString(s2);
                //e.Message = error;
            }
        }

        /*вычисление площади трапеции*/
        private double S_trap(double a, double b, double c, double d) /*a - верхнее основание, b - нижнее основание, c - левая боковая, d - правая боковая трапеции*/
        {
            try
            {
                double x = (a + b) / (4 * (a - c));
                double y = (a + b - c + d) * (a - b - c + d) * (a + b - c - d) * (-a + b + c + d);
                double z = Math.Abs(x) * Math.Sqrt(Math.Abs(y));

                //double x = 0.5 * (a + b);
                //double y = c * c - (((b - a) * (b - a) + c * c - d * d) / (2 * (b - a))) * (((b - a) * (b - a) + c * c - d * d) / (2 * (b - a)));
                //double z = x * Math.Sqrt(y);
                return z;
                //return 0.5 * (a + b) * Math.Sqrt(c * c - (((b - a) * (b - a) + c * c - d * d) / (2 * (b - a))) * (((b - a) * (b - a) + c * c - d * d) / (2 * (b - a))));
            }
            catch (DivideByZeroException e)
            {
                error = "Недопустимое значение одного из параметров: ";
                if (a == 0.0)
                    error += "a = " + Convert.ToString(a);
                else if (b == 0.0)
                    error += "b = " + Convert.ToString(b);
                else if (c == 0.0)
                    error += "c = " + Convert.ToString(c);
                else if (d == 0.0)
                    error += "d = " + Convert.ToString(d);
                //e.Message = error;
                return -1;
            }
        }
        // компизиция 5:  композиция отношения площадей треугольников
        public void composition5(double f1, double f2, double f3, double f4, double f5, //основание большого
                                        double f6, double f7, double f8, double f9, double f10, // левые от альфа
                                        double f11, double f12, double f13, double f14, double f15, // правые от бета
                                        double f16, double f17, double f18, double f19, double f20, // основание малого
                                        double f21, double f22, double f23, double f24, double f25 // напротив от бета
                                        /*int a, int b*/)
        {
            // 5
            double[] FingersLengthTriangle = new double[25]; // для отношения треугольников
            FingersLengthTriangle[0] = f1;
            FingersLengthTriangle[1] = f2;
            FingersLengthTriangle[2] = f3;
            FingersLengthTriangle[3] = f4;
            FingersLengthTriangle[4] = f5;
            FingersLengthTriangle[5] = f6;
            FingersLengthTriangle[6] = f7;
            FingersLengthTriangle[7] = f8;
            FingersLengthTriangle[8] = f9;
            FingersLengthTriangle[9] = f10;
            FingersLengthTriangle[10] = f11;
            FingersLengthTriangle[11] = f12;
            FingersLengthTriangle[12] = f13;
            FingersLengthTriangle[13] = f14;
            FingersLengthTriangle[14] = f15;
            FingersLengthTriangle[15] = f16;
            FingersLengthTriangle[16] = f17;
            FingersLengthTriangle[17] = f18;
            FingersLengthTriangle[18] = f19;
            FingersLengthTriangle[19] = f20;
            FingersLengthTriangle[20] = f21;
            FingersLengthTriangle[21] = f22;
            FingersLengthTriangle[22] = f23;
            FingersLengthTriangle[23] = f24;
            FingersLengthTriangle[24] = f25;

            double s1 = 0.0;
            double s2 = 0.0;
            try
            {

                for (int i = 0; i < ratio_c5.Length; i++)
                {
                    //s1 = S_triangle(b, FingersLengthTriangle[i], FingersLengthTriangle[5 + i]);
                    //s2 = S_triangle(a, FingersLengthTriangle[10 + i], FingersLengthTriangle[15 + i]);
                    s1 = S_triangle_geron(FingersLengthTriangle[i], FingersLengthTriangle[5 + i], FingersLengthTriangle[10 + i]);
                    s2 = S_triangle_geron(FingersLengthTriangle[15 + i], FingersLengthTriangle[20 + i], FingersLengthTriangle[10 + i]);
                    ratio_c5[i] = s1 / s2;
                }
            }
            catch (DivideByZeroException e)
            {
                error = "Недопустимое значение одного из параметров: ";
                error += "S2 = " + Convert.ToString(s2);
                //e.Message = error;
            }
        }

        /*вычисление площади треугольника*/
        private double S_triangle(int angle, double a, double b) /*angle - угол в градусах, a и b - стороны треугольника, образующие этот угол*/
        {
            double alpha = Convert.ToDouble(angle) * (Math.PI / 180);
            return (0.5 * Math.Sin(alpha) * a * b);
        }

        double S_triangle_geron(double a, double b, double c)
        {
            double p = 0.5 * (a + b + c);
            double s = Math.Sqrt(Math.Abs(p * (p - a) * (p - b) * (p - c)));
            return s;
        }
        // задаёт выводимые на график значения обеих рук
        public void SetValue(bool lefthand, int currentType)
        { 
            if (currentType == 0)
            {
                if (lefthand)
                    for (int i = 0; i < VALUE_LEFT_HAND.Length; i++)
                    {
                        VALUE_LEFT_HAND[i] = (ratio_c1[i] + ratio_c3[i] + ratio_c5[i] + ratio_c6[i] + ratio_c7[i]) / 5;
                    }
                else
                    for (int i = 0; i < VALUE_RIGHT_HAND.Length; i++)
                    {
                        VALUE_RIGHT_HAND[i] = (ratio_c1[i] + ratio_c3[i] + ratio_c5[i] + ratio_c6[i] + ratio_c7[i]) / 5;
                    }
            }
            else if (currentType == 1)
            { }
            else if (currentType == 2)
            {
                if (lefthand)
                    for (int i = 0; i < VALUE_LEFT_HAND.Length; i++)
                    {
                        VALUE_LEFT_HAND[i] = (ratio_c1[i] + ratio_c2[i] + ratio_c3[i] + ratio_c4[i] + ratio_c5[i]) / 5;
                    }
                else
                    for (int i = 0; i < VALUE_RIGHT_HAND.Length; i++)
                    {
                        VALUE_RIGHT_HAND[i] = (ratio_c1[i] + ratio_c2[i] + ratio_c3[i] + ratio_c4[i] + ratio_c5[i]) / 5;
                    }
            }
        }
        // композиция 6: отношение площади треугольника к площади трапеции
        public void composition6(double trapBOsn1, double trapR1, double trapL1, double trapMOst1,
                                    double trapBOsn2, double trapR2, double trapL2, double trapMOst2,
                                    double trapBOsn3, double trapR3, double trapL3, double trapMOst3,
                                    double trapBOsn4, double trapR4, double trapL4, double trapMOst4,
                                    double trapBOsn5, double trapR5, double trapL5, double trapMOst5,

                                   double triangleOsn1, double triangleR1, double triangleL1,
                                    double triangleOsn2, double triangleR2, double triangleL2,
                                    double triangleOsn3, double triangleR3, double triangleL3,
                                    double triangleOsn4, double triangleR4, double triangleL4,
                                    double triangleOsn5, double triangleR5, double triangleL5)
        {
            double[] trapBOsn = new double[5];
            double[] trapR = new double[5];
            double[] trapL = new double[5];
            double[] trapMOst = new double[5];
            double[] triangleOsn = new double[5];
            double[] triangleR = new double[5];
            double[] triangleL = new double[5];

            trapBOsn[0] = trapBOsn1;
            trapBOsn[1] = trapBOsn2;
            trapBOsn[2] = trapBOsn3;
            trapBOsn[3] = trapBOsn4;
            trapBOsn[4] = trapBOsn5;

            trapR[0] = trapR1;
            trapR[1] = trapR2;
            trapR[2] = trapR3;
            trapR[3] = trapR4;
            trapR[4] = trapR5;

            trapL[0] = trapL1;
            trapL[1] = trapL2;
            trapL[2] = trapL3;
            trapL[3] = trapL4;
            trapL[4] = trapL5;

            trapMOst[0] = trapMOst1;
            trapMOst[1] = trapMOst2;
            trapMOst[2] = trapMOst3;
            trapMOst[3] = trapMOst4;
            trapMOst[4] = trapMOst5;

            triangleOsn[0] = triangleOsn1;
            triangleOsn[1] = triangleOsn2;
            triangleOsn[2] = triangleOsn3;
            triangleOsn[3] = triangleOsn4;
            triangleOsn[4] = triangleOsn5;

            triangleR[0] = triangleR1;
            triangleR[1] = triangleR2;
            triangleR[2] = triangleR3;
            triangleR[3] = triangleR4;
            triangleR[4] = triangleR5;

            triangleL[0] = triangleL1;
            triangleL[1] = triangleL2;
            triangleL[2] = triangleL3;
            triangleL[3] = triangleL4;
            triangleL[4] = triangleL5;

            double strap = 0;
            double striangle = 0;
            try
            {
                for (int i = 0; i < ratio_c5.Length; i++)
                {
                    strap = S_trap(trapBOsn[i], trapMOst[i], trapL[i], trapR[i]);
                    striangle = S_triangle_geron(triangleOsn[i], triangleR[i], triangleL[i]);
                    ratio_c6[i] = striangle / strap;
                }
            }
            catch (DivideByZeroException e)
            {
                error = "Недопустимое значение одного из параметров: ";
                error += "sellipse = " + Convert.ToString(strap);
                //e.Message = error;
            }
        }
        // композиция 7: отношение площади треугольника к площади эллипса
        public void composition7(double triangleOsn1, double triangleR1, double triangleL1,
                                    double triangleOsn2, double triangleR2, double triangleL2,
                                    double triangleOsn3, double triangleR3, double triangleL3,
                                    double triangleOsn4, double triangleR4, double triangleL4,
                                    double triangleOsn5, double triangleR5, double triangleL5,

                                   double halfBigHalfAxis1, double halfSmallHalfAxis1,
                                    double halfBigHalfAxis2, double halfSmallHalfAxis2,
                                    double halfBigHalfAxis3, double halfSmallHalfAxis3,
                                    double halfBigHalfAxis4, double halfSmallHalfAxis4,
                                    double halfBigHalfAxis5, double halfSmallHalfAxis5)
        {
            double[] triangleOsn = new double[5];
            double[] triangleR = new double[5];
            double[] triangleL = new double[5];
            double[] halfBigHalfAxis = new double[5];
            double[] halfSmallHalfAxis = new double[5];

            triangleOsn[0] = triangleOsn1;
            triangleOsn[1] = triangleOsn2;
            triangleOsn[2] = triangleOsn3;
            triangleOsn[3] = triangleOsn4;
            triangleOsn[4] = triangleOsn5;

            triangleR[0] = triangleR1;
            triangleR[1] = triangleR2;
            triangleR[2] = triangleR3;
            triangleR[3] = triangleR4;
            triangleR[4] = triangleR5;

            triangleL[0] = triangleL1;
            triangleL[1] = triangleL2;
            triangleL[2] = triangleL3;
            triangleL[3] = triangleL4;
            triangleL[4] = triangleL5;

            halfBigHalfAxis[0] = halfBigHalfAxis1;
            halfBigHalfAxis[1] = halfBigHalfAxis2;
            halfBigHalfAxis[2] = halfBigHalfAxis3;
            halfBigHalfAxis[3] = halfBigHalfAxis4;
            halfBigHalfAxis[4] = halfBigHalfAxis5;

            halfSmallHalfAxis[0] = halfSmallHalfAxis1;
            halfSmallHalfAxis[1] = halfSmallHalfAxis2;
            halfSmallHalfAxis[2] = halfSmallHalfAxis3;
            halfSmallHalfAxis[3] = halfSmallHalfAxis4;
            halfSmallHalfAxis[4] = halfSmallHalfAxis5;
            double striangle = 0;
            double sellipse = 0;
            try
            {
                for (int i = 0; i < ratio_c5.Length; i++)
                {
                    striangle = S_triangle_geron(triangleOsn[i], triangleR[i], triangleL[i]);
                    sellipse = S_ellipse(2 * halfBigHalfAxis[i], 2 * halfSmallHalfAxis[i]);
                    ratio_c7[i] = striangle / sellipse;
                }
            }
            catch (DivideByZeroException e)
            {
                error = "Недопустимое значение одного из параметров: ";
                error += "sellipse = " + Convert.ToString(sellipse);
                //e.Message = error;
            }
        }

        double S_ellipse(double a, double b) // a - big half axis, b - small half axis
        {
            return Math.PI * a * b;
        }
    }
}
