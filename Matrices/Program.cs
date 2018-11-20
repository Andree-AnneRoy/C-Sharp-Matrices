using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    class Program
    {
        // *****Les méthodes *****

        // afficher la matrice
        static void AffMatrice(int[,] MAT) //Méthode pour l'affichage des matrices.
        {

            int LIG;
            int COL;

            for (LIG = MAT.GetLowerBound(0); LIG <= MAT.GetUpperBound(0); LIG++)
            {
                for (COL = MAT.GetLowerBound(1); COL <= MAT.GetUpperBound(1); COL++)
                {
                    Console.Write(String.Format("{0:00 }", MAT[LIG, COL]));
                } // fin for COL ...
                Console.WriteLine();
            } // fin for LIG...
            Console.WriteLine();
        } // fin AffMatrice

        /* 
            01 01 01 01 01
            02 02 02 02 02
            03 03 03 03 03
            04 04 04 04 04
            05 05 05 05 05
       */
        static void InitMatNoLig(int[,] MAT) //1.1 --- Matrice initiale complète.
        {
            for (int LIG = MAT.GetLowerBound(0); LIG <= MAT.GetUpperBound(0); LIG++)
            {
                for (int COL = MAT.GetLowerBound(1); COL <= MAT.GetUpperBound(1); COL++)
                {
                    MAT[LIG, COL] = LIG + 1;
                }
            }
        }

        /* 
            00 00 00 00 01
            00 00 00 02 00
            00 00 03 00 00
            00 04 00 00 00
            05 00 00 00 00
        */
        static void InitDiagNordOuest(int[,] MAT) //1.2 --- Matrice diagonale du nord vers l'ouest (droite à gauche).
        {
            int tempor = 0;

            for (int LIG = MAT.GetUpperBound(0); LIG >= MAT.GetLowerBound(0); LIG--)
            {
                tempor = MAT.GetUpperBound(0) + 1;

                for (int COL = MAT.GetLowerBound(1); COL <= MAT.GetUpperBound(1); COL++)
                {
                    tempor--;
                    if (tempor == LIG)
                    {
                        MAT[LIG, COL] = LIG + 1;
                    }
                }
            }
        }

        /* 
            01 00 00 00 00
            00 02 00 00 00
            00 00 03 00 00
            00 00 00 04 00
            00 00 00 00 05
        */
        static void InitDiagNordEst(int[,] MAT) //1.3 --- Matrice diagonale du nord vers l'est (gauche à droite).
        {
            for (int LIG = MAT.GetLowerBound(0); LIG <= MAT.GetUpperBound(0); LIG++)
            {
                for (int COL = MAT.GetLowerBound(1); COL <= MAT.GetUpperBound(1); COL++)
                {
                    if (COL == LIG)
                    {
                        MAT[LIG, COL] = LIG + 1;
                    }
                }
            }
        }

        /* 
            11 21 31 41 51
            00 22 32 42 52
            00 00 33 43 53
            00 00 00 44 54
            00 00 00 00 55
        */
        public static void InitTriangleSup(int[,] MAT) //1.4 --- Matrice en triangle sur la partie supérieure du tableau.
        {

            for (int LIG = MAT.GetLowerBound(0); LIG <= MAT.GetUpperBound(0); LIG++)
            {
                int tempor = 0;

                for (int COL = MAT.GetLowerBound(1); COL <= MAT.GetUpperBound(1); COL++)
                {
                    tempor += 10;
                    if (COL >= LIG)
                    {
                        MAT[LIG, COL] += tempor + LIG + 1;
                    }
                }
            }
        }

        /*
            11 00 00 00 00
            21 22 00 00 00
            31 32 33 00 00
            41 42 43 44 00
            51 52 53 54 55
        */
        public static void InitTriangleInf(int[,] MAT) //1.5 --- Matrice en triangle sur la partie inférieure du tableau.
        {
            int tempor = 11;

            for (int LIG = MAT.GetLowerBound(0); LIG <= MAT.GetUpperBound(0); LIG++)
            {
                for (int COL = MAT.GetLowerBound(1); COL <= MAT.GetUpperBound(1); COL++)
                {
                    if (LIG >= COL)
                    {
                        MAT[LIG, COL] += LIG * 10 + tempor;
                        tempor++;
                    }
                }
                tempor = 11;
            }
        }

        /*
            00 00 00 00 00 00
            00 01 00 00 00 00
            00 01 01 00 00 00
            00 01 02 01 00 00
            00 01 03 03 01 00
            00 01 04 06 04 01
        */
        static void InitTrianglePascal(int[,] MAT) //1.6 --- Matrice en triangle Pascal 6x6.
        {
            for (int LIG = MAT.GetLowerBound(0) + 1; LIG <= MAT.GetUpperBound(0); LIG++)
            {
                for (int COL = MAT.GetLowerBound(1) + 1; COL <= MAT.GetUpperBound(1); COL++)
                {
                    if (LIG >= COL)
                    {
                        MAT[LIG, COL] = 1;

                        if (LIG != 1 && COL != 1)
                        {
                            MAT[LIG, COL] = (MAT[LIG - 1, COL] + MAT[LIG - 1, COL - 1]);
                        }
                    }
                }
            }
        }

        /*
            01 02 03 04 05
            06 07 08 09 10
            11 12 13 14 15
            16 17 18 19 20
            21 22 23 24 25
        */
        static void InitMatHorizontalement(int[,] MAT) //1.7 --- Matrice horizontale initialisée à partir de 1.
        {
            int compteur = 1;

            for (int LIG = MAT.GetLowerBound(0); LIG <= MAT.GetUpperBound(0); LIG++)
            {
                for (int COL = MAT.GetLowerBound(1); COL <= MAT.GetUpperBound(1); COL++)
                {
                    MAT[LIG, COL] = compteur;
                    compteur++;
                }
            }
        }

        /*
            01 02 03 04 05  15
            06 07 08 09 10  40
            11 12 13 14 15  65
            16 17 18 19 20  90
            21 22 23 24 25  115

            55 60 65 70 75
        */
        static void AffSommeLigCol(int[,] MAT) //1.8 --- Afficher la somme de chaque lignes et colonnes de la matrice.
        {
            int LIG, COL, SomLig = 0, SomCol = 0;

            for (LIG = MAT.GetLowerBound(0); LIG <= MAT.GetUpperBound(0); LIG++)
            {
                for (COL = MAT.GetLowerBound(1); COL <= MAT.GetUpperBound(1); COL++)
                {
                    SomLig = SomLig + MAT[LIG, COL];
                    Console.Write(String.Format("{0:00 }", MAT[LIG, COL]));

                    if (COL == MAT.GetLength(0) - 1)
                    {
                        Console.Write(" " + SomLig);
                        SomLig = 0;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (COL = MAT.GetLowerBound(1); COL <= MAT.GetUpperBound(1); COL++)
            {
                for (LIG = MAT.GetLowerBound(0); LIG <= MAT.GetUpperBound(0); LIG++)
                {
                    SomCol = SomCol + MAT[LIG, COL];
                }
                Console.Write(SomCol + " ");
                SomCol = 0;
            }
            Console.WriteLine();
        }

        /*
            85 95 57 11 07
            30 14 13 82 07
            47 72 08 43 39
            76 71 49 31 13
            42 08 40 02 39
        */
        static void InitMatHasard(int[,] MAT) //1.9 --- Initialiser une matrice avec des nombres au hasard.
        {
            Random rnd = new Random();

            for (int LIG = MAT.GetLowerBound(0); LIG <= MAT.GetUpperBound(0); LIG++)
            {
                for (int COL = MAT.GetLowerBound(1); COL <= MAT.GetUpperBound(1); COL++)
                {
                    MAT[LIG, COL] = rnd.Next(1, 100);
                }
            }
        }

        /* 
            Min : 2 
        */
        static int MinMatrice(int[,] MAT) //1.10 --- Afficher le minimum de la matrice avec des données au hasard.
        {
            int min = MAT[0, 0];

            foreach (var i in MAT)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }

        /*
            01 06 11 16 21
            02 07 12 17 22
            03 08 13 18 23
            04 09 14 19 24
            05 10 15 20 25
        */
        static int[,] Transposer(int[,] MAT) //1.11 --- Transposer la matrice.
        {
            int compt = 1;

            for (int LIG = MAT.GetLowerBound(1); LIG <= MAT.GetUpperBound(1); LIG++)
            {
                for (int COL = MAT.GetLowerBound(0); COL <= MAT.GetUpperBound(0); COL++)
                {
                    MAT[COL, LIG] = compt;
                    compt++;
                }
            }
            return MAT;
        }



        // *****main*****
        static void Main()
        {
            int BorneTableau = 5;
            int[,] Mat = new int[BorneTableau, BorneTableau];

            Console.WriteLine("1.1 - No de la ligne");
            Console.WriteLine();
            InitMatNoLig(Mat);
            AffMatrice(Mat);

            Mat = new int[BorneTableau, BorneTableau];

            Console.WriteLine("1.2 - Diagonale Nord-Ouest");
            InitDiagNordOuest(Mat);
            AffMatrice(Mat);

            Mat = new int[BorneTableau, BorneTableau];

            Console.WriteLine("1.3 - Diagonale Nord-Est");
            InitDiagNordEst(Mat);
            AffMatrice(Mat);

            Mat = new int[BorneTableau, BorneTableau];

            Console.WriteLine("1.4 - Triangle sup avec No. de colonne");
            InitTriangleSup(Mat);
            AffMatrice(Mat);

            Mat = new int[BorneTableau, BorneTableau];

            Console.WriteLine("1.5 - Triangle inf avec indices LIG et COL");
            InitTriangleInf(Mat);
            AffMatrice(Mat);

            Console.WriteLine("1.6 - Triangle de pascal de 6 x 6");
            int[,] Triangle = new int[BorneTableau + 1, BorneTableau + 1];
            InitTrianglePascal(Triangle);
            AffMatrice(Triangle);

            Console.WriteLine("1.7 - Initialiser à partir de 1 la matrice");
            InitMatHorizontalement(Mat);
            AffMatrice(Mat);
            Console.WriteLine("1.8 - Afficher la somme des lignes et des colonnes");
            AffSommeLigCol(Mat);
            Console.WriteLine();

            Console.WriteLine("1.9 - Initialiser une matrice avec des données au hasard");
            InitMatHasard(Mat);
            AffMatrice(Mat);
            Console.WriteLine("1.10 - Minimum de la matrice avec des données au hasard");
            int Min = MinMatrice(Mat);
            Console.WriteLine("Min : {0}", Min);
            Console.WriteLine();

            Console.WriteLine("1.11 - Transposer la matrice");
            Transposer(Mat);
            AffMatrice(Mat);

            Console.ReadLine();
        } // fin main

    }
}
