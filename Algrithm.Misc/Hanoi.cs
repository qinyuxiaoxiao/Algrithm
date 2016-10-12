using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm
{
    class Hanoi
    {
        /*                      
                 1
                1 1
              1 1 1 1
            ------------ ------------- -------------
                 A             B             C
     
                1 1
              1 1 1 1		                 1
            ------------ ------------- -------------
                 A             B             C
     
    
              1 1 1 1         1 1            1
            ------------ ------------- -------------
                 A             B             C

                               1
             1 1 1 1          1 1             
            ------------ ------------- -------------
                 A             B             C
     
                               1
                              1 1         1 1 1 1     
            ------------ ------------- -------------
                 A             B             C

                         
                 1           1 1          1 1 1 1     
            ------------ ------------- -------------
                 A             B             C

         
                                            1 1 
                 1                        1 1 1 1     
            ------------ ------------- -------------
                 A             B             C
         
                                             1
                                            1 1                          
                                          1 1 1 1     
            ------------ ------------- -------------
                 A             B             C

        */

        private const string A = "A";
        private const string B = "B";
        private const string C = "C";
        
        public static readonly int TowerHeight = 5;
        public static List<string> HanoiPaths = new List<string>();


        public static List<string> ExecuteHanoiTower()
        {
            HanoiPaths.Clear();

            MoveRecursive(TowerHeight, A, B, C);

            return HanoiPaths;
        }

        private static void Move(string from, string to)
        {
            HanoiPaths.Add(from + "->" + to);
        }

        private static void MoveRecursive(int towerHeight, string towerA, string towerB, string towerC)
        {
            if (towerHeight == 1)
            {
                Move(towerA, towerC);
            }
            else
            {
                MoveRecursive(towerHeight - 1, towerA, towerC, towerB);
                Move(towerA, towerC);
                MoveRecursive(towerHeight - 1, towerB, towerA, towerC);
            }
        }   
    }
}
