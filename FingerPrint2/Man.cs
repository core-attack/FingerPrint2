using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FingerPrint2
{
    public class Man
    {
        public static Finger f1 = new Finger();
        public static Finger f2 = new Finger();
        public static Finger f3 = new Finger();
        public static Finger f4 = new Finger();
        public static Finger f5 = new Finger();

        public static Finger f6 = new Finger();
        public static Finger f7 = new Finger();
        public static Finger f8 = new Finger();
        public static Finger f9 = new Finger();
        public static Finger f10 = new Finger();


        public Finger[] arrFingersLeftHand = { f1, f2, f3, f4, f5 };
        public Finger[] arrFingersRightHand = { f6, f7, f8, f9, f10 };

        public Man()
        {
            f1.name = "большой";
            f2.name = "указательный";
            f3.name = "средний";
            f4.name = "безымянный";
            f5.name = "мизинец";

            f6.name = "большой";
            f7.name = "указательный";
            f8.name = "средний";
            f9.name = "безымянный";
            f10.name = "мизинец";

        }

        public Compositions composition = new Compositions();

        public void SetAllCompositions(int currentType)
        {
            if (currentType == 0)
            {
                composition.composition1(arrFingersLeftHand[0].m1lengthLine, arrFingersLeftHand[1].m1lengthLine, arrFingersLeftHand[2].m1lengthLine, arrFingersLeftHand[3].m1lengthLine, arrFingersLeftHand[4].m1lengthLine,
                           arrFingersLeftHand[0].m1kolPerLines, arrFingersLeftHand[1].m1kolPerLines, arrFingersLeftHand[2].m1kolPerLines, arrFingersLeftHand[3].m1kolPerLines, arrFingersLeftHand[4].m1kolPerLines);
                composition.composition3(arrFingersLeftHand[0].m3lengthKatetLeft, arrFingersLeftHand[1].m3lengthKatetLeft, arrFingersLeftHand[2].m3lengthKatetLeft, arrFingersLeftHand[3].m3lengthKatetLeft, arrFingersLeftHand[4].m3lengthKatetLeft,
                               arrFingersLeftHand[0].m3lengthGipotenusLeft, arrFingersLeftHand[1].m3lengthGipotenusLeft, arrFingersLeftHand[2].m3lengthGipotenusLeft, arrFingersLeftHand[3].m3lengthGipotenusLeft, arrFingersLeftHand[4].m3lengthGipotenusLeft,
                               arrFingersLeftHand[0].m3lengthKatetRight, arrFingersLeftHand[1].m3lengthKatetRight, arrFingersLeftHand[2].m3lengthKatetRight, arrFingersLeftHand[3].m3lengthKatetRight, arrFingersLeftHand[4].m3lengthKatetRight,
                               arrFingersLeftHand[0].m3lengthGipotenusRight, arrFingersLeftHand[1].m3lengthGipotenusRight, arrFingersLeftHand[2].m3lengthGipotenusRight, arrFingersLeftHand[3].m3lengthGipotenusRight, arrFingersLeftHand[4].m3lengthGipotenusRight);
                composition.composition5(arrFingersLeftHand[0].m5lengthBigOsn, arrFingersLeftHand[1].m5lengthBigOsn, arrFingersLeftHand[2].m5lengthBigOsn, arrFingersLeftHand[3].m5lengthBigOsn, arrFingersLeftHand[4].m5lengthBigOsn,
                               arrFingersLeftHand[0].m5lengthLeftAlp, arrFingersLeftHand[1].m5lengthLeftAlp, arrFingersLeftHand[2].m5lengthLeftAlp, arrFingersLeftHand[3].m5lengthLeftAlp, arrFingersLeftHand[4].m5lengthLeftAlp,
                               arrFingersLeftHand[0].m5lengthminOsn, arrFingersLeftHand[1].m5lengthminOsn, arrFingersLeftHand[2].m5lengthminOsn, arrFingersLeftHand[3].m5lengthminOsn, arrFingersLeftHand[4].m5lengthminOsn,
                               arrFingersLeftHand[0].m5lengthRightBeta, arrFingersLeftHand[1].m5lengthRightBeta, arrFingersLeftHand[2].m5lengthRightBeta, arrFingersLeftHand[3].m5lengthRightBeta, arrFingersLeftHand[4].m5lengthRightBeta,
                               arrFingersLeftHand[0].m5lengthOppositeBeta, arrFingersLeftHand[1].m5lengthOppositeBeta, arrFingersLeftHand[2].m5lengthOppositeBeta, arrFingersLeftHand[3].m5lengthOppositeBeta, arrFingersLeftHand[4].m5lengthOppositeBeta);
                composition.composition6(arrFingersLeftHand[0].m6bottomOsnTrap, arrFingersLeftHand[0].m6rightTrap, arrFingersLeftHand[0].m6leftTrap,  arrFingersLeftHand[0].m6upOsnTrap, 
                    arrFingersLeftHand[1].m6bottomOsnTrap, arrFingersLeftHand[1].m6rightTrap, arrFingersLeftHand[1].m6leftTrap,  arrFingersLeftHand[1].m6upOsnTrap, 
                    arrFingersLeftHand[2].m6bottomOsnTrap, arrFingersLeftHand[2].m6rightTrap, arrFingersLeftHand[2].m6leftTrap,  arrFingersLeftHand[2].m6upOsnTrap, 
                    arrFingersLeftHand[3].m6bottomOsnTrap, arrFingersLeftHand[3].m6rightTrap, arrFingersLeftHand[3].m6leftTrap,  arrFingersLeftHand[3].m6upOsnTrap, 
                    arrFingersLeftHand[4].m6bottomOsnTrap, arrFingersLeftHand[4].m6rightTrap, arrFingersLeftHand[4].m6leftTrap,  arrFingersLeftHand[4].m6upOsnTrap, 
                    arrFingersLeftHand[0].m6bottomOsnTrap, arrFingersLeftHand[0].m6rightTriangle, arrFingersLeftHand[0].m6leftTriangle, 
                    arrFingersLeftHand[1].m6bottomOsnTrap, arrFingersLeftHand[1].m6rightTriangle, arrFingersLeftHand[1].m6leftTriangle, 
                    arrFingersLeftHand[2].m6bottomOsnTrap, arrFingersLeftHand[2].m6rightTriangle, arrFingersLeftHand[2].m6leftTriangle, 
                    arrFingersLeftHand[3].m6bottomOsnTrap, arrFingersLeftHand[3].m6rightTriangle, arrFingersLeftHand[3].m6leftTriangle, 
                    arrFingersLeftHand[4].m6bottomOsnTrap, arrFingersLeftHand[4].m6rightTriangle, arrFingersLeftHand[4].m6leftTriangle
                    );
                composition.composition7(arrFingersLeftHand[0].m7osnTriangle, arrFingersLeftHand[0].m7rightTriangle, arrFingersLeftHand[0].m7leftTriangle, 
                    arrFingersLeftHand[1].m7osnTriangle, arrFingersLeftHand[1].m7rightTriangle, arrFingersLeftHand[1].m7leftTriangle, 
                    arrFingersLeftHand[2].m7osnTriangle, arrFingersLeftHand[2].m7rightTriangle, arrFingersLeftHand[2].m7leftTriangle, 
                    arrFingersLeftHand[3].m7osnTriangle, arrFingersLeftHand[3].m7rightTriangle, arrFingersLeftHand[3].m7leftTriangle, 
                    arrFingersLeftHand[4].m7osnTriangle, arrFingersLeftHand[4].m7rightTriangle, arrFingersLeftHand[4].m7leftTriangle,
                    arrFingersLeftHand[0].m7halfBigHalfAxis, arrFingersLeftHand[0].m7halfSmallHalfAxis,
                    arrFingersLeftHand[1].m7halfBigHalfAxis, arrFingersLeftHand[1].m7halfSmallHalfAxis,
                    arrFingersLeftHand[2].m7halfBigHalfAxis, arrFingersLeftHand[2].m7halfSmallHalfAxis,
                    arrFingersLeftHand[3].m7halfBigHalfAxis, arrFingersLeftHand[3].m7halfSmallHalfAxis,
                    arrFingersLeftHand[4].m7halfBigHalfAxis, arrFingersLeftHand[4].m7halfSmallHalfAxis
                    );
                
                composition.SetValue(true, currentType);

                composition.composition1(arrFingersRightHand[0].m1lengthLine, arrFingersRightHand[1].m1lengthLine, arrFingersRightHand[2].m1lengthLine, arrFingersRightHand[3].m1lengthLine, arrFingersRightHand[4].m1lengthLine,
                               arrFingersRightHand[0].m1kolPerLines, arrFingersRightHand[1].m1kolPerLines, arrFingersRightHand[2].m1kolPerLines, arrFingersRightHand[3].m1kolPerLines, arrFingersRightHand[4].m1kolPerLines);
                composition.composition3(arrFingersRightHand[0].m3lengthKatetLeft, arrFingersRightHand[1].m3lengthKatetLeft, arrFingersRightHand[2].m3lengthKatetLeft, arrFingersRightHand[3].m3lengthKatetLeft, arrFingersRightHand[4].m3lengthKatetLeft,
                               arrFingersRightHand[0].m3lengthGipotenusLeft, arrFingersRightHand[1].m3lengthGipotenusLeft, arrFingersRightHand[2].m3lengthGipotenusLeft, arrFingersRightHand[3].m3lengthGipotenusLeft, arrFingersRightHand[4].m3lengthGipotenusLeft,
                               arrFingersRightHand[0].m3lengthKatetRight, arrFingersRightHand[1].m3lengthKatetRight, arrFingersRightHand[2].m3lengthKatetRight, arrFingersRightHand[3].m3lengthKatetRight, arrFingersRightHand[4].m3lengthKatetRight,
                               arrFingersRightHand[0].m3lengthGipotenusRight, arrFingersRightHand[1].m3lengthGipotenusRight, arrFingersRightHand[2].m3lengthGipotenusRight, arrFingersRightHand[3].m3lengthGipotenusRight, arrFingersRightHand[4].m3lengthGipotenusRight);
                composition.composition5(arrFingersRightHand[0].m5lengthBigOsn, arrFingersRightHand[1].m5lengthBigOsn, arrFingersRightHand[2].m5lengthBigOsn, arrFingersRightHand[3].m5lengthBigOsn, arrFingersRightHand[4].m5lengthBigOsn,
                               arrFingersRightHand[0].m5lengthLeftAlp, arrFingersRightHand[1].m5lengthLeftAlp, arrFingersRightHand[2].m5lengthLeftAlp, arrFingersRightHand[3].m5lengthLeftAlp, arrFingersRightHand[4].m5lengthLeftAlp,
                               arrFingersRightHand[0].m5lengthminOsn, arrFingersRightHand[1].m5lengthminOsn, arrFingersRightHand[2].m5lengthminOsn, arrFingersRightHand[3].m5lengthminOsn, arrFingersRightHand[4].m5lengthminOsn,
                               arrFingersRightHand[0].m5lengthRightBeta, arrFingersRightHand[1].m5lengthRightBeta, arrFingersRightHand[2].m5lengthRightBeta, arrFingersRightHand[3].m5lengthRightBeta, arrFingersRightHand[4].m5lengthRightBeta,
                               arrFingersRightHand[0].m5lengthOppositeBeta, arrFingersRightHand[1].m5lengthOppositeBeta, arrFingersRightHand[2].m5lengthOppositeBeta, arrFingersRightHand[3].m5lengthOppositeBeta, arrFingersRightHand[4].m5lengthOppositeBeta
                    );
                composition.composition6(arrFingersRightHand[0].m6bottomOsnTrap, arrFingersRightHand[0].m6rightTrap, arrFingersRightHand[0].m6leftTrap,  arrFingersRightHand[0].m6upOsnTrap, 
                    arrFingersRightHand[1].m6bottomOsnTrap, arrFingersRightHand[1].m6rightTrap, arrFingersRightHand[1].m6leftTrap,  arrFingersRightHand[1].m6upOsnTrap, 
                    arrFingersRightHand[2].m6bottomOsnTrap, arrFingersRightHand[2].m6rightTrap, arrFingersRightHand[2].m6leftTrap,  arrFingersRightHand[2].m6upOsnTrap, 
                    arrFingersRightHand[3].m6bottomOsnTrap, arrFingersRightHand[3].m6rightTrap, arrFingersRightHand[3].m6leftTrap,  arrFingersRightHand[3].m6upOsnTrap, 
                    arrFingersRightHand[4].m6bottomOsnTrap, arrFingersRightHand[4].m6rightTrap, arrFingersRightHand[4].m6leftTrap,  arrFingersRightHand[4].m6upOsnTrap, 
                    arrFingersRightHand[0].m6bottomOsnTrap, arrFingersRightHand[0].m6rightTriangle, arrFingersRightHand[0].m6leftTriangle, 
                    arrFingersRightHand[1].m6bottomOsnTrap, arrFingersRightHand[1].m6rightTriangle, arrFingersRightHand[1].m6leftTriangle, 
                    arrFingersRightHand[2].m6bottomOsnTrap, arrFingersRightHand[2].m6rightTriangle, arrFingersRightHand[2].m6leftTriangle, 
                    arrFingersRightHand[3].m6bottomOsnTrap, arrFingersRightHand[3].m6rightTriangle, arrFingersRightHand[3].m6leftTriangle, 
                    arrFingersRightHand[4].m6bottomOsnTrap, arrFingersRightHand[4].m6rightTriangle, arrFingersRightHand[4].m6leftTriangle
                    );
                composition.composition7(arrFingersRightHand[0].m7osnTriangle, arrFingersRightHand[0].m7rightTriangle, arrFingersRightHand[0].m7leftTriangle, 
                    arrFingersRightHand[1].m7osnTriangle, arrFingersRightHand[1].m7rightTriangle, arrFingersRightHand[1].m7leftTriangle, 
                    arrFingersRightHand[2].m7osnTriangle, arrFingersRightHand[2].m7rightTriangle, arrFingersRightHand[2].m7leftTriangle, 
                    arrFingersRightHand[3].m7osnTriangle, arrFingersRightHand[3].m7rightTriangle, arrFingersRightHand[3].m7leftTriangle, 
                    arrFingersRightHand[4].m7osnTriangle, arrFingersRightHand[4].m7rightTriangle, arrFingersRightHand[4].m7leftTriangle,
                    arrFingersRightHand[0].m7halfBigHalfAxis, arrFingersRightHand[0].m7halfSmallHalfAxis,
                    arrFingersRightHand[1].m7halfBigHalfAxis, arrFingersRightHand[1].m7halfSmallHalfAxis,
                    arrFingersRightHand[2].m7halfBigHalfAxis, arrFingersRightHand[2].m7halfSmallHalfAxis,
                    arrFingersRightHand[3].m7halfBigHalfAxis, arrFingersRightHand[3].m7halfSmallHalfAxis,
                    arrFingersRightHand[4].m7halfBigHalfAxis, arrFingersRightHand[4].m7halfSmallHalfAxis
                    );

                    composition.SetValue(false, currentType);
            }
            else if (currentType == 1)
            {}
            else if (currentType == 2)
            {
                composition.composition1(arrFingersLeftHand[0].m1lengthLine, arrFingersLeftHand[1].m1lengthLine, arrFingersLeftHand[2].m1lengthLine, arrFingersLeftHand[3].m1lengthLine, arrFingersLeftHand[4].m1lengthLine,
                               arrFingersLeftHand[0].m1kolPerLines, arrFingersLeftHand[1].m1kolPerLines, arrFingersLeftHand[2].m1kolPerLines, arrFingersLeftHand[3].m1kolPerLines, arrFingersLeftHand[4].m1kolPerLines);
                composition.composition2(arrFingersLeftHand[0].m2lengthKatet, arrFingersLeftHand[1].m2lengthKatet, arrFingersLeftHand[2].m2lengthKatet, arrFingersLeftHand[3].m2lengthKatet, arrFingersLeftHand[4].m2lengthKatet,
                               arrFingersLeftHand[0].m2lengthGipotenus, arrFingersLeftHand[1].m2lengthGipotenus, arrFingersLeftHand[2].m2lengthGipotenus, arrFingersLeftHand[3].m2lengthGipotenus, arrFingersLeftHand[4].m2lengthGipotenus);
                composition.composition3(arrFingersLeftHand[0].m3lengthKatetLeft, arrFingersLeftHand[1].m3lengthKatetLeft, arrFingersLeftHand[2].m3lengthKatetLeft, arrFingersLeftHand[3].m3lengthKatetLeft, arrFingersLeftHand[4].m3lengthKatetLeft,
                               arrFingersLeftHand[0].m3lengthGipotenusLeft, arrFingersLeftHand[1].m3lengthGipotenusLeft, arrFingersLeftHand[2].m3lengthGipotenusLeft, arrFingersLeftHand[3].m3lengthGipotenusLeft, arrFingersLeftHand[4].m3lengthGipotenusLeft,
                               arrFingersLeftHand[0].m3lengthKatetRight, arrFingersLeftHand[1].m3lengthKatetRight, arrFingersLeftHand[2].m3lengthKatetRight, arrFingersLeftHand[3].m3lengthKatetRight, arrFingersLeftHand[4].m3lengthKatetRight,
                               arrFingersLeftHand[0].m3lengthGipotenusRight, arrFingersLeftHand[1].m3lengthGipotenusRight, arrFingersLeftHand[2].m3lengthGipotenusRight, arrFingersLeftHand[3].m3lengthGipotenusRight, arrFingersLeftHand[4].m3lengthGipotenusRight);
                composition.composition4(arrFingersLeftHand[0].m4lengthOsnObTrap, arrFingersLeftHand[1].m4lengthOsnObTrap, arrFingersLeftHand[2].m4lengthOsnObTrap, arrFingersLeftHand[3].m4lengthOsnObTrap, arrFingersLeftHand[4].m4lengthOsnObTrap,
                               arrFingersLeftHand[0].m4lengthRightBokSLeftTrap, arrFingersLeftHand[1].m4lengthRightBokSLeftTrap, arrFingersLeftHand[2].m4lengthRightBokSLeftTrap, arrFingersLeftHand[3].m4lengthRightBokSLeftTrap, arrFingersLeftHand[4].m4lengthRightBokSLeftTrap,
                               arrFingersLeftHand[0].m4lengthUpLeftTrap, arrFingersLeftHand[1].m4lengthUpLeftTrap, arrFingersLeftHand[2].m4lengthUpLeftTrap, arrFingersLeftHand[3].m4lengthUpLeftTrap, arrFingersLeftHand[4].m4lengthUpLeftTrap,
                               arrFingersLeftHand[0].m4lengthLeftBokSLeftTrap, arrFingersLeftHand[1].m4lengthLeftBokSLeftTrap, arrFingersLeftHand[2].m4lengthLeftBokSLeftTrap, arrFingersLeftHand[3].m4lengthLeftBokSLeftTrap, arrFingersLeftHand[4].m4lengthLeftBokSLeftTrap,
                               arrFingersLeftHand[0].m4lengthRightBokSRightTrap, arrFingersLeftHand[1].m4lengthRightBokSRightTrap, arrFingersLeftHand[2].m4lengthRightBokSRightTrap, arrFingersLeftHand[3].m4lengthRightBokSRightTrap, arrFingersLeftHand[4].m4lengthRightBokSRightTrap,
                               arrFingersLeftHand[0].m4lengthUpRightTrap, arrFingersLeftHand[1].m4lengthUpRightTrap, arrFingersLeftHand[2].m4lengthUpRightTrap, arrFingersLeftHand[3].m4lengthUpRightTrap, arrFingersLeftHand[4].m4lengthUpRightTrap,
                               arrFingersLeftHand[0].m4lengthLeftBokSRightTrap, arrFingersLeftHand[1].m4lengthLeftBokSRightTrap, arrFingersLeftHand[2].m4lengthLeftBokSRightTrap, arrFingersLeftHand[3].m4lengthLeftBokSRightTrap, arrFingersLeftHand[4].m4lengthLeftBokSRightTrap);
                composition.composition5(arrFingersLeftHand[0].m5lengthBigOsn, arrFingersLeftHand[1].m5lengthBigOsn, arrFingersLeftHand[2].m5lengthBigOsn, arrFingersLeftHand[3].m5lengthBigOsn, arrFingersLeftHand[4].m5lengthBigOsn,
                               arrFingersLeftHand[0].m5lengthLeftAlp, arrFingersLeftHand[1].m5lengthLeftAlp, arrFingersLeftHand[2].m5lengthLeftAlp, arrFingersLeftHand[3].m5lengthLeftAlp, arrFingersLeftHand[4].m5lengthLeftAlp,
                               arrFingersLeftHand[0].m5lengthminOsn, arrFingersLeftHand[1].m5lengthminOsn, arrFingersLeftHand[2].m5lengthminOsn, arrFingersLeftHand[3].m5lengthminOsn, arrFingersLeftHand[4].m5lengthminOsn,
                               arrFingersLeftHand[0].m5lengthRightBeta, arrFingersLeftHand[1].m5lengthRightBeta, arrFingersLeftHand[2].m5lengthRightBeta, arrFingersLeftHand[3].m5lengthRightBeta, arrFingersLeftHand[4].m5lengthRightBeta,
                               arrFingersLeftHand[0].m5lengthOppositeBeta, arrFingersLeftHand[1].m5lengthOppositeBeta, arrFingersLeftHand[2].m5lengthOppositeBeta, arrFingersLeftHand[3].m5lengthOppositeBeta, arrFingersLeftHand[4].m5lengthOppositeBeta
                               );

                composition.SetValue(true, currentType);

                composition.composition1(arrFingersRightHand[0].m1lengthLine, arrFingersRightHand[1].m1lengthLine, arrFingersRightHand[2].m1lengthLine, arrFingersRightHand[3].m1lengthLine, arrFingersRightHand[4].m1lengthLine,
                               arrFingersRightHand[0].m1kolPerLines, arrFingersRightHand[1].m1kolPerLines, arrFingersRightHand[2].m1kolPerLines, arrFingersRightHand[3].m1kolPerLines, arrFingersRightHand[4].m1kolPerLines);
                composition.composition2(arrFingersRightHand[0].m2lengthKatet, arrFingersRightHand[1].m2lengthKatet, arrFingersRightHand[2].m2lengthKatet, arrFingersRightHand[3].m2lengthKatet, arrFingersRightHand[4].m2lengthKatet,
                               arrFingersRightHand[0].m2lengthGipotenus, arrFingersRightHand[1].m2lengthGipotenus, arrFingersRightHand[2].m2lengthGipotenus, arrFingersRightHand[3].m2lengthGipotenus, arrFingersRightHand[4].m2lengthGipotenus);
                composition.composition3(arrFingersRightHand[0].m3lengthKatetLeft, arrFingersRightHand[1].m3lengthKatetLeft, arrFingersRightHand[2].m3lengthKatetLeft, arrFingersRightHand[3].m3lengthKatetLeft, arrFingersRightHand[4].m3lengthKatetLeft,
                               arrFingersRightHand[0].m3lengthGipotenusLeft, arrFingersRightHand[1].m3lengthGipotenusLeft, arrFingersRightHand[2].m3lengthGipotenusLeft, arrFingersRightHand[3].m3lengthGipotenusLeft, arrFingersRightHand[4].m3lengthGipotenusLeft,
                               arrFingersRightHand[0].m3lengthKatetRight, arrFingersRightHand[1].m3lengthKatetRight, arrFingersRightHand[2].m3lengthKatetRight, arrFingersRightHand[3].m3lengthKatetRight, arrFingersRightHand[4].m3lengthKatetRight,
                               arrFingersRightHand[0].m3lengthGipotenusRight, arrFingersRightHand[1].m3lengthGipotenusRight, arrFingersRightHand[2].m3lengthGipotenusRight, arrFingersRightHand[3].m3lengthGipotenusRight, arrFingersRightHand[4].m3lengthGipotenusRight);
                composition.composition4(arrFingersRightHand[0].m4lengthOsnObTrap, arrFingersRightHand[1].m4lengthOsnObTrap, arrFingersRightHand[2].m4lengthOsnObTrap, arrFingersRightHand[3].m4lengthOsnObTrap, arrFingersRightHand[4].m4lengthOsnObTrap,
                               arrFingersRightHand[0].m4lengthRightBokSLeftTrap, arrFingersRightHand[1].m4lengthRightBokSLeftTrap, arrFingersRightHand[2].m4lengthRightBokSLeftTrap, arrFingersRightHand[3].m4lengthRightBokSLeftTrap, arrFingersRightHand[4].m4lengthRightBokSLeftTrap,
                               arrFingersRightHand[0].m4lengthUpLeftTrap, arrFingersRightHand[1].m4lengthUpLeftTrap, arrFingersRightHand[2].m4lengthUpLeftTrap, arrFingersRightHand[3].m4lengthUpLeftTrap, arrFingersRightHand[4].m4lengthUpLeftTrap,
                               arrFingersRightHand[0].m4lengthLeftBokSLeftTrap, arrFingersRightHand[1].m4lengthLeftBokSLeftTrap, arrFingersRightHand[2].m4lengthLeftBokSLeftTrap, arrFingersRightHand[3].m4lengthLeftBokSLeftTrap, arrFingersRightHand[4].m4lengthLeftBokSLeftTrap,
                               arrFingersRightHand[0].m4lengthRightBokSRightTrap, arrFingersRightHand[1].m4lengthRightBokSRightTrap, arrFingersRightHand[2].m4lengthRightBokSRightTrap, arrFingersRightHand[3].m4lengthRightBokSRightTrap, arrFingersRightHand[4].m4lengthRightBokSRightTrap,
                               arrFingersRightHand[0].m4lengthUpRightTrap, arrFingersRightHand[1].m4lengthUpRightTrap, arrFingersRightHand[2].m4lengthUpRightTrap, arrFingersRightHand[3].m4lengthUpRightTrap, arrFingersRightHand[4].m4lengthUpRightTrap,
                               arrFingersRightHand[0].m4lengthLeftBokSRightTrap, arrFingersRightHand[1].m4lengthLeftBokSRightTrap, arrFingersRightHand[2].m4lengthLeftBokSRightTrap, arrFingersRightHand[3].m4lengthLeftBokSRightTrap, arrFingersRightHand[4].m4lengthLeftBokSRightTrap);
                composition.composition5(arrFingersRightHand[0].m5lengthBigOsn, arrFingersRightHand[1].m5lengthBigOsn, arrFingersRightHand[2].m5lengthBigOsn, arrFingersRightHand[3].m5lengthBigOsn, arrFingersRightHand[4].m5lengthBigOsn,
                               arrFingersRightHand[0].m5lengthLeftAlp, arrFingersRightHand[1].m5lengthLeftAlp, arrFingersRightHand[2].m5lengthLeftAlp, arrFingersRightHand[3].m5lengthLeftAlp, arrFingersRightHand[4].m5lengthLeftAlp,
                               arrFingersRightHand[0].m5lengthminOsn, arrFingersRightHand[1].m5lengthminOsn, arrFingersRightHand[2].m5lengthminOsn, arrFingersRightHand[3].m5lengthminOsn, arrFingersRightHand[4].m5lengthminOsn,
                               arrFingersRightHand[0].m5lengthRightBeta, arrFingersRightHand[1].m5lengthRightBeta, arrFingersRightHand[2].m5lengthRightBeta, arrFingersRightHand[3].m5lengthRightBeta, arrFingersRightHand[4].m5lengthRightBeta,
                               arrFingersRightHand[0].m5lengthOppositeBeta, arrFingersRightHand[1].m5lengthOppositeBeta, arrFingersRightHand[2].m5lengthOppositeBeta, arrFingersRightHand[3].m5lengthOppositeBeta, arrFingersRightHand[4].m5lengthOppositeBeta
                    );

                composition.SetValue(false, currentType);
            }
        }

        public void SetAllCompositions(int currentFinger, string hand)
        {
            switch (hand)
            {
                case "левая":
                    {
                            composition.composition1(arrFingersLeftHand[0].m1lengthLine, arrFingersLeftHand[1].m1lengthLine, arrFingersLeftHand[2].m1lengthLine, arrFingersLeftHand[3].m1lengthLine, arrFingersLeftHand[4].m1lengthLine,
                                       arrFingersLeftHand[0].m1kolPerLines, arrFingersLeftHand[1].m1kolPerLines, arrFingersLeftHand[2].m1kolPerLines, arrFingersLeftHand[3].m1kolPerLines, arrFingersLeftHand[4].m1kolPerLines);
                            composition.composition3(arrFingersLeftHand[0].m3lengthKatetLeft, arrFingersLeftHand[1].m3lengthKatetLeft, arrFingersLeftHand[2].m3lengthKatetLeft, arrFingersLeftHand[3].m3lengthKatetLeft, arrFingersLeftHand[4].m3lengthKatetLeft,
                                           arrFingersLeftHand[0].m3lengthGipotenusLeft, arrFingersLeftHand[1].m3lengthGipotenusLeft, arrFingersLeftHand[2].m3lengthGipotenusLeft, arrFingersLeftHand[3].m3lengthGipotenusLeft, arrFingersLeftHand[4].m3lengthGipotenusLeft,
                                           arrFingersLeftHand[0].m3lengthKatetRight, arrFingersLeftHand[1].m3lengthKatetRight, arrFingersLeftHand[2].m3lengthKatetRight, arrFingersLeftHand[3].m3lengthKatetRight, arrFingersLeftHand[4].m3lengthKatetRight,
                                           arrFingersLeftHand[0].m3lengthGipotenusRight, arrFingersLeftHand[1].m3lengthGipotenusRight, arrFingersLeftHand[2].m3lengthGipotenusRight, arrFingersLeftHand[3].m3lengthGipotenusRight, arrFingersLeftHand[4].m3lengthGipotenusRight);
                            composition.composition5(arrFingersLeftHand[0].m5lengthBigOsn, arrFingersLeftHand[1].m5lengthBigOsn, arrFingersLeftHand[2].m5lengthBigOsn, arrFingersLeftHand[3].m5lengthBigOsn, arrFingersLeftHand[4].m5lengthBigOsn,
                                           arrFingersLeftHand[0].m5lengthLeftAlp, arrFingersLeftHand[1].m5lengthLeftAlp, arrFingersLeftHand[2].m5lengthLeftAlp, arrFingersLeftHand[3].m5lengthLeftAlp, arrFingersLeftHand[4].m5lengthLeftAlp,
                                           arrFingersLeftHand[0].m5lengthminOsn, arrFingersLeftHand[1].m5lengthminOsn, arrFingersLeftHand[2].m5lengthminOsn, arrFingersLeftHand[3].m5lengthminOsn, arrFingersLeftHand[4].m5lengthminOsn,
                                           arrFingersLeftHand[0].m5lengthRightBeta, arrFingersLeftHand[1].m5lengthRightBeta, arrFingersLeftHand[2].m5lengthRightBeta, arrFingersLeftHand[3].m5lengthRightBeta, arrFingersLeftHand[4].m5lengthRightBeta,
                                           arrFingersLeftHand[0].m5lengthOppositeBeta, arrFingersLeftHand[1].m5lengthOppositeBeta, arrFingersLeftHand[2].m5lengthOppositeBeta, arrFingersLeftHand[3].m5lengthOppositeBeta, arrFingersLeftHand[4].m5lengthOppositeBeta);
                            composition.composition6(arrFingersLeftHand[0].m6bottomOsnTrap, arrFingersLeftHand[0].m6rightTrap, arrFingersLeftHand[0].m6leftTrap, arrFingersLeftHand[0].m6upOsnTrap,
                                arrFingersLeftHand[1].m6bottomOsnTrap, arrFingersLeftHand[1].m6rightTrap, arrFingersLeftHand[1].m6leftTrap, arrFingersLeftHand[1].m6upOsnTrap,
                                arrFingersLeftHand[2].m6bottomOsnTrap, arrFingersLeftHand[2].m6rightTrap, arrFingersLeftHand[2].m6leftTrap, arrFingersLeftHand[2].m6upOsnTrap,
                                arrFingersLeftHand[3].m6bottomOsnTrap, arrFingersLeftHand[3].m6rightTrap, arrFingersLeftHand[3].m6leftTrap, arrFingersLeftHand[3].m6upOsnTrap,
                                arrFingersLeftHand[4].m6bottomOsnTrap, arrFingersLeftHand[4].m6rightTrap, arrFingersLeftHand[4].m6leftTrap, arrFingersLeftHand[4].m6upOsnTrap,
                                arrFingersLeftHand[0].m6bottomOsnTrap, arrFingersLeftHand[0].m6rightTriangle, arrFingersLeftHand[0].m6leftTriangle,
                                arrFingersLeftHand[1].m6bottomOsnTrap, arrFingersLeftHand[1].m6rightTriangle, arrFingersLeftHand[1].m6leftTriangle,
                                arrFingersLeftHand[2].m6bottomOsnTrap, arrFingersLeftHand[2].m6rightTriangle, arrFingersLeftHand[2].m6leftTriangle,
                                arrFingersLeftHand[3].m6bottomOsnTrap, arrFingersLeftHand[3].m6rightTriangle, arrFingersLeftHand[3].m6leftTriangle,
                                arrFingersLeftHand[4].m6bottomOsnTrap, arrFingersLeftHand[4].m6rightTriangle, arrFingersLeftHand[4].m6leftTriangle
                                );
                            composition.composition7(arrFingersLeftHand[0].m7osnTriangle, arrFingersLeftHand[0].m7rightTriangle, arrFingersLeftHand[0].m7leftTriangle,
                                arrFingersLeftHand[1].m7osnTriangle, arrFingersLeftHand[1].m7rightTriangle, arrFingersLeftHand[1].m7leftTriangle,
                                arrFingersLeftHand[2].m7osnTriangle, arrFingersLeftHand[2].m7rightTriangle, arrFingersLeftHand[2].m7leftTriangle,
                                arrFingersLeftHand[3].m7osnTriangle, arrFingersLeftHand[3].m7rightTriangle, arrFingersLeftHand[3].m7leftTriangle,
                                arrFingersLeftHand[4].m7osnTriangle, arrFingersLeftHand[4].m7rightTriangle, arrFingersLeftHand[4].m7leftTriangle,
                                arrFingersLeftHand[0].m7halfBigHalfAxis, arrFingersLeftHand[0].m7halfSmallHalfAxis,
                                arrFingersLeftHand[1].m7halfBigHalfAxis, arrFingersLeftHand[1].m7halfSmallHalfAxis,
                                arrFingersLeftHand[2].m7halfBigHalfAxis, arrFingersLeftHand[2].m7halfSmallHalfAxis,
                                arrFingersLeftHand[3].m7halfBigHalfAxis, arrFingersLeftHand[3].m7halfSmallHalfAxis,
                                arrFingersLeftHand[4].m7halfBigHalfAxis, arrFingersLeftHand[4].m7halfSmallHalfAxis
                                );

                        /*composition.composition1(arrFingersLeftHand[currentFinger].m1lengthLine, arrFingersLeftHand[currentFinger].m1lengthLine, arrFingersLeftHand[currentFinger].m1lengthLine, arrFingersLeftHand[currentFinger].m1lengthLine, arrFingersLeftHand[currentFinger].m1lengthLine,
                           arrFingersLeftHand[currentFinger].m1kolPerLines, arrFingersLeftHand[currentFinger].m1kolPerLines, arrFingersLeftHand[currentFinger].m1kolPerLines, arrFingersLeftHand[currentFinger].m1kolPerLines, arrFingersLeftHand[currentFinger].m1kolPerLines);
                        composition.composition2(arrFingersLeftHand[currentFinger].m2lengthKatet, arrFingersLeftHand[currentFinger].m2lengthKatet, arrFingersLeftHand[currentFinger].m2lengthKatet, arrFingersLeftHand[currentFinger].m2lengthKatet, arrFingersLeftHand[currentFinger].m2lengthKatet,
                           arrFingersLeftHand[currentFinger].m2lengthGipotenus, arrFingersLeftHand[currentFinger].m2lengthGipotenus, arrFingersLeftHand[currentFinger].m2lengthGipotenus, arrFingersLeftHand[currentFinger].m2lengthGipotenus, arrFingersLeftHand[currentFinger].m2lengthGipotenus);
                        composition.composition3(arrFingersLeftHand[currentFinger].m3lengthKatetLeft, arrFingersLeftHand[currentFinger].m3lengthKatetLeft, arrFingersLeftHand[2].m3lengthKatetLeft, arrFingersLeftHand[currentFinger].m3lengthKatetLeft, arrFingersLeftHand[currentFinger].m3lengthKatetLeft,
                           arrFingersLeftHand[currentFinger].m3lengthGipotenusLeft, arrFingersLeftHand[currentFinger].m3lengthGipotenusLeft, arrFingersLeftHand[currentFinger].m3lengthGipotenusLeft, arrFingersLeftHand[currentFinger].m3lengthGipotenusLeft, arrFingersLeftHand[currentFinger].m3lengthGipotenusLeft,
                           arrFingersLeftHand[currentFinger].m3lengthKatetRight, arrFingersLeftHand[currentFinger].m3lengthKatetRight, arrFingersLeftHand[currentFinger].m3lengthKatetRight, arrFingersLeftHand[currentFinger].m3lengthKatetRight, arrFingersLeftHand[currentFinger].m3lengthKatetRight,
                           arrFingersLeftHand[currentFinger].m3lengthGipotenusRight, arrFingersLeftHand[currentFinger].m3lengthGipotenusRight, arrFingersLeftHand[currentFinger].m3lengthGipotenusRight, arrFingersLeftHand[currentFinger].m3lengthGipotenusRight, arrFingersLeftHand[currentFinger].m3lengthGipotenusRight);
                        composition.composition4(arrFingersLeftHand[currentFinger].m4lengthOsnObTrap, arrFingersLeftHand[1].m4lengthOsnObTrap, arrFingersLeftHand[currentFinger].m4lengthOsnObTrap, arrFingersLeftHand[currentFinger].m4lengthOsnObTrap, arrFingersLeftHand[currentFinger].m4lengthOsnObTrap,
                           arrFingersLeftHand[currentFinger].m4lengthRightBokSLeftTrap, arrFingersLeftHand[currentFinger].m4lengthRightBokSLeftTrap, arrFingersLeftHand[currentFinger].m4lengthRightBokSLeftTrap, arrFingersLeftHand[currentFinger].m4lengthRightBokSLeftTrap, arrFingersLeftHand[currentFinger].m4lengthRightBokSLeftTrap,
                           arrFingersLeftHand[currentFinger].m4lengthUpLeftTrap, arrFingersLeftHand[currentFinger].m4lengthUpLeftTrap, arrFingersLeftHand[currentFinger].m4lengthUpLeftTrap, arrFingersLeftHand[currentFinger].m4lengthUpLeftTrap, arrFingersLeftHand[currentFinger].m4lengthUpLeftTrap,
                           arrFingersLeftHand[currentFinger].m4lengthLeftBokSLeftTrap, arrFingersLeftHand[currentFinger].m4lengthLeftBokSLeftTrap, arrFingersLeftHand[currentFinger].m4lengthLeftBokSLeftTrap, arrFingersLeftHand[currentFinger].m4lengthLeftBokSLeftTrap, arrFingersLeftHand[currentFinger].m4lengthLeftBokSLeftTrap,
                           arrFingersLeftHand[currentFinger].m4lengthRightBokSRightTrap, arrFingersLeftHand[currentFinger].m4lengthRightBokSRightTrap, arrFingersLeftHand[currentFinger].m4lengthRightBokSRightTrap, arrFingersLeftHand[currentFinger].m4lengthRightBokSRightTrap, arrFingersLeftHand[currentFinger].m4lengthRightBokSRightTrap,
                           arrFingersLeftHand[currentFinger].m4lengthUpRightTrap, arrFingersLeftHand[currentFinger].m4lengthUpRightTrap, arrFingersLeftHand[currentFinger].m4lengthUpRightTrap, arrFingersLeftHand[currentFinger].m4lengthUpRightTrap, arrFingersLeftHand[currentFinger].m4lengthUpRightTrap,
                           arrFingersLeftHand[currentFinger].m4lengthLeftBokSRightTrap, arrFingersLeftHand[currentFinger].m4lengthLeftBokSRightTrap, arrFingersLeftHand[currentFinger].m4lengthLeftBokSRightTrap, arrFingersLeftHand[currentFinger].m4lengthLeftBokSRightTrap, arrFingersLeftHand[currentFinger].m4lengthLeftBokSRightTrap);
                        composition.composition5(arrFingersLeftHand[currentFinger].m5lengthBigOsn, arrFingersLeftHand[currentFinger].m5lengthBigOsn, arrFingersLeftHand[currentFinger].m5lengthBigOsn, arrFingersLeftHand[currentFinger].m5lengthBigOsn, arrFingersLeftHand[currentFinger].m5lengthBigOsn,
                           arrFingersLeftHand[currentFinger].m5lengthLeftAlp, arrFingersLeftHand[currentFinger].m5lengthLeftAlp, arrFingersLeftHand[currentFinger].m5lengthLeftAlp, arrFingersLeftHand[currentFinger].m5lengthLeftAlp, arrFingersLeftHand[currentFinger].m5lengthLeftAlp,
                           arrFingersLeftHand[currentFinger].m5lengthminOsn, arrFingersLeftHand[currentFinger].m5lengthminOsn, arrFingersLeftHand[currentFinger].m5lengthminOsn, arrFingersLeftHand[currentFinger].m5lengthminOsn, arrFingersLeftHand[currentFinger].m5lengthminOsn,
                           arrFingersLeftHand[currentFinger].m5lengthRightBeta, arrFingersLeftHand[currentFinger].m5lengthRightBeta, arrFingersLeftHand[currentFinger].m5lengthRightBeta, arrFingersLeftHand[currentFinger].m5lengthRightBeta, arrFingersLeftHand[currentFinger].m5lengthRightBeta,
                           arrFingersLeftHand[currentFinger].m5lengthOppositeBeta, arrFingersLeftHand[currentFinger].m5lengthOppositeBeta, arrFingersLeftHand[currentFinger].m5lengthOppositeBeta, arrFingersLeftHand[currentFinger].m5lengthOppositeBeta, arrFingersLeftHand[currentFinger].m5lengthOppositeBeta
                           );*/
                    }
                    break;
                case "правая": {

                    composition.composition1(arrFingersRightHand[0].m1lengthLine, arrFingersRightHand[1].m1lengthLine, arrFingersRightHand[2].m1lengthLine, arrFingersRightHand[3].m1lengthLine, arrFingersRightHand[4].m1lengthLine,
                                           arrFingersRightHand[0].m1kolPerLines, arrFingersRightHand[1].m1kolPerLines, arrFingersRightHand[2].m1kolPerLines, arrFingersRightHand[3].m1kolPerLines, arrFingersRightHand[4].m1kolPerLines);
                    composition.composition3(arrFingersRightHand[0].m3lengthKatetLeft, arrFingersRightHand[1].m3lengthKatetLeft, arrFingersRightHand[2].m3lengthKatetLeft, arrFingersRightHand[3].m3lengthKatetLeft, arrFingersRightHand[4].m3lengthKatetLeft,
                                   arrFingersRightHand[0].m3lengthGipotenusLeft, arrFingersRightHand[1].m3lengthGipotenusLeft, arrFingersRightHand[2].m3lengthGipotenusLeft, arrFingersRightHand[3].m3lengthGipotenusLeft, arrFingersRightHand[4].m3lengthGipotenusLeft,
                                   arrFingersRightHand[0].m3lengthKatetRight, arrFingersRightHand[1].m3lengthKatetRight, arrFingersRightHand[2].m3lengthKatetRight, arrFingersRightHand[3].m3lengthKatetRight, arrFingersRightHand[4].m3lengthKatetRight,
                                   arrFingersRightHand[0].m3lengthGipotenusRight, arrFingersRightHand[1].m3lengthGipotenusRight, arrFingersRightHand[2].m3lengthGipotenusRight, arrFingersRightHand[3].m3lengthGipotenusRight, arrFingersRightHand[4].m3lengthGipotenusRight);
                    composition.composition5(arrFingersRightHand[0].m5lengthBigOsn, arrFingersRightHand[1].m5lengthBigOsn, arrFingersRightHand[2].m5lengthBigOsn, arrFingersRightHand[3].m5lengthBigOsn, arrFingersRightHand[4].m5lengthBigOsn,
                                   arrFingersRightHand[0].m5lengthLeftAlp, arrFingersRightHand[1].m5lengthLeftAlp, arrFingersRightHand[2].m5lengthLeftAlp, arrFingersRightHand[3].m5lengthLeftAlp, arrFingersRightHand[4].m5lengthLeftAlp,
                                   arrFingersRightHand[0].m5lengthminOsn, arrFingersRightHand[1].m5lengthminOsn, arrFingersRightHand[2].m5lengthminOsn, arrFingersRightHand[3].m5lengthminOsn, arrFingersRightHand[4].m5lengthminOsn,
                                   arrFingersRightHand[0].m5lengthRightBeta, arrFingersRightHand[1].m5lengthRightBeta, arrFingersRightHand[2].m5lengthRightBeta, arrFingersRightHand[3].m5lengthRightBeta, arrFingersRightHand[4].m5lengthRightBeta,
                                   arrFingersRightHand[0].m5lengthOppositeBeta, arrFingersRightHand[1].m5lengthOppositeBeta, arrFingersRightHand[2].m5lengthOppositeBeta, arrFingersRightHand[3].m5lengthOppositeBeta, arrFingersRightHand[4].m5lengthOppositeBeta
                        );
                    composition.composition6(arrFingersRightHand[0].m6bottomOsnTrap, arrFingersRightHand[0].m6rightTrap, arrFingersRightHand[0].m6leftTrap, arrFingersRightHand[0].m6upOsnTrap,
                        arrFingersRightHand[1].m6bottomOsnTrap, arrFingersRightHand[1].m6rightTrap, arrFingersRightHand[1].m6leftTrap, arrFingersRightHand[1].m6upOsnTrap,
                        arrFingersRightHand[2].m6bottomOsnTrap, arrFingersRightHand[2].m6rightTrap, arrFingersRightHand[2].m6leftTrap, arrFingersRightHand[2].m6upOsnTrap,
                        arrFingersRightHand[3].m6bottomOsnTrap, arrFingersRightHand[3].m6rightTrap, arrFingersRightHand[3].m6leftTrap, arrFingersRightHand[3].m6upOsnTrap,
                        arrFingersRightHand[4].m6bottomOsnTrap, arrFingersRightHand[4].m6rightTrap, arrFingersRightHand[4].m6leftTrap, arrFingersRightHand[4].m6upOsnTrap,
                        arrFingersRightHand[0].m6bottomOsnTrap, arrFingersRightHand[0].m6rightTriangle, arrFingersRightHand[0].m6leftTriangle,
                        arrFingersRightHand[1].m6bottomOsnTrap, arrFingersRightHand[1].m6rightTriangle, arrFingersRightHand[1].m6leftTriangle,
                        arrFingersRightHand[2].m6bottomOsnTrap, arrFingersRightHand[2].m6rightTriangle, arrFingersRightHand[2].m6leftTriangle,
                        arrFingersRightHand[3].m6bottomOsnTrap, arrFingersRightHand[3].m6rightTriangle, arrFingersRightHand[3].m6leftTriangle,
                        arrFingersRightHand[4].m6bottomOsnTrap, arrFingersRightHand[4].m6rightTriangle, arrFingersRightHand[4].m6leftTriangle
                        );
                    composition.composition7(arrFingersRightHand[0].m7osnTriangle, arrFingersRightHand[0].m7rightTriangle, arrFingersRightHand[0].m7leftTriangle,
                        arrFingersRightHand[1].m7osnTriangle, arrFingersRightHand[1].m7rightTriangle, arrFingersRightHand[1].m7leftTriangle,
                        arrFingersRightHand[2].m7osnTriangle, arrFingersRightHand[2].m7rightTriangle, arrFingersRightHand[2].m7leftTriangle,
                        arrFingersRightHand[3].m7osnTriangle, arrFingersRightHand[3].m7rightTriangle, arrFingersRightHand[3].m7leftTriangle,
                        arrFingersRightHand[4].m7osnTriangle, arrFingersRightHand[4].m7rightTriangle, arrFingersRightHand[4].m7leftTriangle,
                        arrFingersRightHand[0].m7halfBigHalfAxis, arrFingersRightHand[0].m7halfSmallHalfAxis,
                        arrFingersRightHand[1].m7halfBigHalfAxis, arrFingersRightHand[1].m7halfSmallHalfAxis,
                        arrFingersRightHand[2].m7halfBigHalfAxis, arrFingersRightHand[2].m7halfSmallHalfAxis,
                        arrFingersRightHand[3].m7halfBigHalfAxis, arrFingersRightHand[3].m7halfSmallHalfAxis,
                        arrFingersRightHand[4].m7halfBigHalfAxis, arrFingersRightHand[4].m7halfSmallHalfAxis
                        );

                    /*composition.composition1(arrFingersRightHand[currentFinger].m1lengthLine, arrFingersRightHand[currentFinger].m1lengthLine, arrFingersRightHand[currentFinger].m1lengthLine, arrFingersRightHand[currentFinger].m1lengthLine, arrFingersRightHand[currentFinger].m1lengthLine,
                               arrFingersRightHand[currentFinger].m1kolPerLines, arrFingersRightHand[currentFinger].m1kolPerLines, arrFingersRightHand[currentFinger].m1kolPerLines, arrFingersRightHand[currentFinger].m1kolPerLines, arrFingersRightHand[currentFinger].m1kolPerLines);
                    composition.composition2(arrFingersRightHand[currentFinger].m2lengthKatet, arrFingersRightHand[currentFinger].m2lengthKatet, arrFingersRightHand[currentFinger].m2lengthKatet, arrFingersRightHand[currentFinger].m2lengthKatet, arrFingersRightHand[currentFinger].m2lengthKatet,
                                   arrFingersRightHand[currentFinger].m2lengthGipotenus, arrFingersRightHand[currentFinger].m2lengthGipotenus, arrFingersRightHand[currentFinger].m2lengthGipotenus, arrFingersRightHand[currentFinger].m2lengthGipotenus, arrFingersRightHand[currentFinger].m2lengthGipotenus);
                    composition.composition3(arrFingersRightHand[currentFinger].m3lengthKatetLeft, arrFingersRightHand[currentFinger].m3lengthKatetLeft, arrFingersRightHand[currentFinger].m3lengthKatetLeft, arrFingersRightHand[currentFinger].m3lengthKatetLeft, arrFingersRightHand[currentFinger].m3lengthKatetLeft,
                                   arrFingersRightHand[currentFinger].m3lengthGipotenusLeft, arrFingersRightHand[currentFinger].m3lengthGipotenusLeft, arrFingersRightHand[currentFinger].m3lengthGipotenusLeft, arrFingersRightHand[currentFinger].m3lengthGipotenusLeft, arrFingersRightHand[currentFinger].m3lengthGipotenusLeft,
                                   arrFingersRightHand[currentFinger].m3lengthKatetRight, arrFingersRightHand[currentFinger].m3lengthKatetRight, arrFingersRightHand[currentFinger].m3lengthKatetRight, arrFingersRightHand[currentFinger].m3lengthKatetRight, arrFingersRightHand[currentFinger].m3lengthKatetRight,
                                   arrFingersRightHand[currentFinger].m3lengthGipotenusRight, arrFingersRightHand[currentFinger].m3lengthGipotenusRight, arrFingersRightHand[currentFinger].m3lengthGipotenusRight, arrFingersRightHand[currentFinger].m3lengthGipotenusRight, arrFingersRightHand[currentFinger].m3lengthGipotenusRight);
                    composition.composition4(arrFingersRightHand[currentFinger].m4lengthOsnObTrap, arrFingersRightHand[currentFinger].m4lengthOsnObTrap, arrFingersRightHand[currentFinger].m4lengthOsnObTrap, arrFingersRightHand[currentFinger].m4lengthOsnObTrap, arrFingersRightHand[currentFinger].m4lengthOsnObTrap,
                                   arrFingersRightHand[currentFinger].m4lengthRightBokSLeftTrap, arrFingersRightHand[currentFinger].m4lengthRightBokSLeftTrap, arrFingersRightHand[currentFinger].m4lengthRightBokSLeftTrap, arrFingersRightHand[currentFinger].m4lengthRightBokSLeftTrap, arrFingersRightHand[currentFinger].m4lengthRightBokSLeftTrap,
                                   arrFingersRightHand[currentFinger].m4lengthUpLeftTrap, arrFingersRightHand[currentFinger].m4lengthUpLeftTrap, arrFingersRightHand[currentFinger].m4lengthUpLeftTrap, arrFingersRightHand[currentFinger].m4lengthUpLeftTrap, arrFingersRightHand[currentFinger].m4lengthUpLeftTrap,
                                   arrFingersRightHand[currentFinger].m4lengthLeftBokSLeftTrap, arrFingersRightHand[currentFinger].m4lengthLeftBokSLeftTrap, arrFingersRightHand[currentFinger].m4lengthLeftBokSLeftTrap, arrFingersRightHand[currentFinger].m4lengthLeftBokSLeftTrap, arrFingersRightHand[currentFinger].m4lengthLeftBokSLeftTrap,
                                   arrFingersRightHand[currentFinger].m4lengthRightBokSRightTrap, arrFingersRightHand[currentFinger].m4lengthRightBokSRightTrap, arrFingersRightHand[currentFinger].m4lengthRightBokSRightTrap, arrFingersRightHand[currentFinger].m4lengthRightBokSRightTrap, arrFingersRightHand[currentFinger].m4lengthRightBokSRightTrap,
                                   arrFingersRightHand[currentFinger].m4lengthUpRightTrap, arrFingersRightHand[currentFinger].m4lengthUpRightTrap, arrFingersRightHand[currentFinger].m4lengthUpRightTrap, arrFingersRightHand[currentFinger].m4lengthUpRightTrap, arrFingersRightHand[currentFinger].m4lengthUpRightTrap,
                                   arrFingersRightHand[currentFinger].m4lengthLeftBokSRightTrap, arrFingersRightHand[currentFinger].m4lengthLeftBokSRightTrap, arrFingersRightHand[currentFinger].m4lengthLeftBokSRightTrap, arrFingersRightHand[currentFinger].m4lengthLeftBokSRightTrap, arrFingersRightHand[currentFinger].m4lengthLeftBokSRightTrap);
                    composition.composition5(arrFingersRightHand[currentFinger].m5lengthBigOsn, arrFingersRightHand[currentFinger].m5lengthBigOsn, arrFingersRightHand[currentFinger].m5lengthBigOsn, arrFingersRightHand[currentFinger].m5lengthBigOsn, arrFingersRightHand[currentFinger].m5lengthBigOsn,
                                   arrFingersRightHand[currentFinger].m5lengthLeftAlp, arrFingersRightHand[currentFinger].m5lengthLeftAlp, arrFingersRightHand[currentFinger].m5lengthLeftAlp, arrFingersRightHand[currentFinger].m5lengthLeftAlp, arrFingersRightHand[currentFinger].m5lengthLeftAlp,
                                   arrFingersRightHand[currentFinger].m5lengthminOsn, arrFingersRightHand[currentFinger].m5lengthminOsn, arrFingersRightHand[currentFinger].m5lengthminOsn, arrFingersRightHand[currentFinger].m5lengthminOsn, arrFingersRightHand[currentFinger].m5lengthminOsn,
                                   arrFingersRightHand[currentFinger].m5lengthRightBeta, arrFingersRightHand[currentFinger].m5lengthRightBeta, arrFingersRightHand[currentFinger].m5lengthRightBeta, arrFingersRightHand[currentFinger].m5lengthRightBeta, arrFingersRightHand[currentFinger].m5lengthRightBeta,
                                   arrFingersRightHand[currentFinger].m5lengthOppositeBeta, arrFingersRightHand[currentFinger].m5lengthOppositeBeta, arrFingersRightHand[currentFinger].m5lengthOppositeBeta, arrFingersRightHand[currentFinger].m5lengthOppositeBeta, arrFingersRightHand[currentFinger].m5lengthOppositeBeta
                        );*/
                }
                    break; 
            }
            
        }
    }
}
