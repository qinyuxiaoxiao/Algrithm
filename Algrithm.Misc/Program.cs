using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Algrithm.InterpreterAlgrithm;
using Algrithm.Tree;
using Algrithm.Chain;
using Algrithm.Arrange;

namespace Algrithm
{
    class Program
    {
        private const string SPLITTER = "-------------------------------------------------------------------------------------------";
        static void Main(string[] args)
        {
            //ExecutePalinDrome();
            //ExecuteChess();

            //ExecuteSortBubble();
            //ExecuteSortQuick();
            //ExecuteSortStraightSelection();
            ExecuteSortHeap();
            //ExecuteSortInsertion();
            //ExecuteSortShell();

            //ExecuteHanoiTower();

            //ExecuteInterpreter();

            //ExecuteStringSequence();
            //ExecuteNumberSequence();

            //ExecuteStringReplace();

            //ExecuteScanTreeWide();


            //ExecuteCheckBalance();
            //ExecuteCheckBalance2();
            //ExecuteCheckBalance3();
            //ExecuteCheckBalance4();
            //ExecuteCheckBalance5();

            //ExecuteV2CheckBalance();
            //ExecuteV2CheckBalance2();
            //ExecuteV2CheckBalance3();
            //ExecuteV2CheckBalance4();
            //ExecuteV2CheckBalance5();


            //ExecuteRevertSingleChain();
            //ExecuteRecursiveRevertSingleChain();

            Console.Read();
        }


        private static void ExecuteStringSequence()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start String Sequence");
            Console.WriteLine("Input Text: ");
            Console.WriteLine(StringSequence.Input);
            List<string> allSequences = StringSequence.Execute();
            Console.WriteLine("End String Sequence");
            allSequences.ForEach(item => Console.WriteLine(item));
            Console.WriteLine("Total Count: " + allSequences.Count);
            Console.WriteLine(SPLITTER);
        }

        private static void ExecuteNumberSequence()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start Number Sequence");
            Console.WriteLine(string.Format("Arrange {0} numbers from Candidates: {1} ", NumberSequence.NumberCount, String.Join(", ", NumberSequence.Candidates)));
            List<string> allSequences = NumberSequence.Execute();
            Console.WriteLine("End Number Sequence");
            allSequences.ForEach(item => Console.WriteLine(item));
            Console.WriteLine("Total Count: " + allSequences.Count);
            Console.WriteLine(SPLITTER);
        }
        

        private static void ExecutePalinDrome()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start extracting palin drome");
            Console.WriteLine("Input Text: ");
            Console.WriteLine(PalinDrome.InputText);
            List<string> palinDromes = PalinDrome.Execute();
            Console.WriteLine("Execute Result: ");
            palinDromes.ForEach(palinDrome => Console.WriteLine(palinDrome));
            Console.WriteLine("End extracting palin drome");
            Console.WriteLine(SPLITTER);
        }

        private static void ExecuteChess()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start executing chess seeking");
            Console.WriteLine(string.Format("From {0} To {1}", ChessBoard.Start, ChessBoard.End));
            List<List<ChessPosition>> allPaths = Chess.Execute();
            Console.WriteLine("Execute Result: ");
            allPaths.ForEach(path =>
                {
                    Console.WriteLine();
                    Console.WriteLine(string.Join(" -> ", path));
                    Console.WriteLine();
                });
            Console.WriteLine("End executing chess seeking");
            Console.WriteLine(string.Format("Find {0} Paths, and Total Recursive Count is {1} ", ChessBoard.ValidPathCount, ChessBoard.RecursiveCount));
            Console.WriteLine(SPLITTER);
        }


        private static void ExecuteSortBubble()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start bubbling");
            Console.WriteLine("Input Text: ");
            Console.WriteLine(string.Join(", ", Sort.IntArray));
            int[] array = Sort.ExecuteBubble();
            Console.WriteLine("Execute Result: ");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("End bubbling");
            Console.WriteLine(SPLITTER);
        }


        private static void ExecuteSortQuick()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start Quick Sort");
            Console.WriteLine("Input Text: ");
            Console.WriteLine(string.Join(", ", Sort.IntArray));
            int[] array = Sort.ExecuteQuick();
            Console.WriteLine("Execute Result: ");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("End Quick Srot");
            Console.WriteLine(SPLITTER);
        }


        private static void ExecuteSortStraightSelection()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start Straight Selection");
            Console.WriteLine("Input Text: ");
            Console.WriteLine(string.Join(", ", Sort.IntArray));
            int[] array = Sort.ExecuteStraightSelection();
            Console.WriteLine("Execute Result: ");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("End Straight Selection");
            Console.WriteLine(SPLITTER);
        }


        private static void ExecuteSortHeap()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start Sort Heap");
            Console.WriteLine("Input Text: ");
            Console.WriteLine(string.Join(", ", Sort.IntArray));
            int[] array = Sort.ExecuteHeap();
            Console.WriteLine("Execute Result: ");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("End Sort Heap");
            Console.WriteLine(SPLITTER);
        }

        private static void ExecuteSortInsertion()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start Insertion");
            Console.WriteLine("Input Text: ");
            Console.WriteLine(string.Join(", ", Sort.IntArray));
            int[] array = Sort.ExecuteInsertion();
            Console.WriteLine("Execute Result: ");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("End Insertion");
            Console.WriteLine(SPLITTER);
        }

        private static void ExecuteSortShell()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start Shell");
            Console.WriteLine("Input Text: ");
            Console.WriteLine(string.Join(", ", Sort.IntArray));
            int[] array = Sort.ExecuteShell();
            Console.WriteLine("Execute Result: ");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("End Shell");
            Console.WriteLine(SPLITTER);
        }


        private static void ExecuteHanoiTower()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start Hanoi Tower");
            Console.WriteLine("Hanoi Tower Height: " + Hanoi.TowerHeight);
            List<string> hanoiPaths = Hanoi.ExecuteHanoiTower();
            Console.WriteLine("Execute Result: ");
            Console.WriteLine(string.Join(", ", hanoiPaths));
            Console.WriteLine("End Hanoi Tower");
            Console.WriteLine(SPLITTER);
        }

        private static void ExecuteInterpreter()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start Interpeter");
            Console.WriteLine("Chinese Number: " + NumberInterpreter.ChineseNumber);
            long digitNumber = NumberInterpreter.Execute();
            Console.WriteLine("Execute Result: " + digitNumber);
            Console.WriteLine(SPLITTER);
        }

        private static void ExecuteStringReplace()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Start String Replace");
            Console.WriteLine("Text: " + StringReplacer.Text);
            Console.WriteLine("Repalce From: " + string.Join(", ", StringReplacer.ReplaceFroms));
            Console.WriteLine("Replace To: " + string.Join(", ", StringReplacer.ReplaceTos));
            Console.WriteLine("Result: " + StringReplacer.Replace());
            Console.WriteLine(SPLITTER);

        }

        private static void ExecuteScanTreeWide()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Scan Tree Wide");
            TreeNode topNode = BinaryTree.BuildBalanceTree(20);
            BinaryTree.ScanWide(topNode);
            Console.WriteLine(SPLITTER);

        }

        /*
                                                              20
                                     19                                                 18
                        17                      16                        15                         14
                13          12            11           10           9          8              7             6
              5   4        3  2         1
         
        */
        private static void ExecuteCheckBalance()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Check Balance");
            TreeNode topNode = BinaryTree.BuildBalanceTree(20);
            bool isBalanceTree = BinaryTree.CheckBalance(topNode);
            Console.WriteLine("Is balance Tree: " + isBalanceTree);
            Console.WriteLine(SPLITTER);

        }


        /*
                                                              20
                                     19                                                 18
                        17                      16                        15                         NULL
                13          12            11           10           9          8                           
              5   4        3  2         1
         
        */
        private static void ExecuteCheckBalance2()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Check Balance 2");
            TreeNode topNode = BinaryTree.BuildBalanceTree(20);
            topNode.Right.Right = null;
            bool isBalanceTree = BinaryTree.CheckBalance(topNode);
            Console.WriteLine("Is balance Tree: " + isBalanceTree);
            Console.WriteLine(SPLITTER);

        }



        /*
                                                              20
                                     19                                                 18
                           NULL                  16                        15                         14
                                          11           10           9          8              7             6
                                        1
         
        */
        private static void ExecuteCheckBalance3()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Check Balance");
            TreeNode topNode = BinaryTree.BuildBalanceTree(20);
            topNode.Left.Left = null;
            bool isBalanceTree = BinaryTree.CheckBalance(topNode);
            Console.WriteLine("Is balance Tree: " + isBalanceTree);
            Console.WriteLine(SPLITTER);

        }



        /*
                                                              20
                                     19                                                 18
                        17                      NULL                        15                         14
                13          12                                        9          8              7             6
              5   4        3  2         
         
        */
        private static void ExecuteCheckBalance4()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Check Balance");
            TreeNode topNode = BinaryTree.BuildBalanceTree(20);
            topNode.Left.Right = null;
            bool isBalanceTree = BinaryTree.CheckBalance(topNode);
            Console.WriteLine("Is balance Tree: " + isBalanceTree);
            Console.WriteLine(SPLITTER);


        }

        /*
                                                          20
                                 19                                                 18
                    17                      16                        15                         14
            13          NULL          11           10           9          8              7             6
          5   4                   1
         
        */
        private static void ExecuteCheckBalance5()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Check Balance");
            TreeNode topNode = BinaryTree.BuildBalanceTree(20);
            topNode.Left.Left.Right = null;
            bool isBalanceTree = BinaryTree.CheckBalance(topNode);
            Console.WriteLine("Is balance Tree: " + isBalanceTree);
            Console.WriteLine(SPLITTER);

        }



        /*
                                                              20
                                     19                                                 18
                        17                      16                        15                         14
                13          12            11           10           9          8              7             6
              5   4        3  2         1
         
        */
        private static void ExecuteV2CheckBalance()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("V2 Check Balance");
            TreeNode topNode = BinaryTree.BuildBalanceTree(20);
            bool isBalanceTree = BinaryTree.CheckBalanceV2(topNode);
            Console.WriteLine("Is balance Tree: " + isBalanceTree);
            Console.WriteLine(SPLITTER);

        }


        /*
                                                              20
                                     19                                                 18
                        17                      16                        15                         NULL
                13          12            11           10           9          8                           
              5   4        3  2         1
         
        */
        private static void ExecuteV2CheckBalance2()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("V2 Check Balance 2");
            TreeNode topNode = BinaryTree.BuildBalanceTree(20);
            topNode.Right.Right = null;
            bool isBalanceTree = BinaryTree.CheckBalanceV2(topNode);
            Console.WriteLine("Is balance Tree: " + isBalanceTree);
            Console.WriteLine(SPLITTER);

        }



        /*
                                                              20
                                     19                                                 18
                           NULL                  16                        15                         14
                                          11           10           9          8              7             6
                                        1
         
        */
        private static void ExecuteV2CheckBalance3()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("V2 Check Balance");
            TreeNode topNode = BinaryTree.BuildBalanceTree(20);
            topNode.Left.Left = null;
            bool isBalanceTree = BinaryTree.CheckBalanceV2(topNode);
            Console.WriteLine("Is balance Tree: " + isBalanceTree);
            Console.WriteLine(SPLITTER);

        }



        /*
                                                              20
                                     19                                                 18
                        17                      NULL                        15                         14
                13          12                                        9          8              7             6
              5   4        3  2         
         
        */
        private static void ExecuteV2CheckBalance4()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("V2 Check Balance");
            TreeNode topNode = BinaryTree.BuildBalanceTree(20);
            topNode.Left.Right = null;
            bool isBalanceTree = BinaryTree.CheckBalanceV2(topNode);
            Console.WriteLine("Is balance Tree: " + isBalanceTree);
            Console.WriteLine(SPLITTER);


        }

        /*
                                                          20
                                 19                                                 18
                    17                      16                        15                         14
            13          NULL          11           10           9          8              7             6
          5   4                   1
         
        */
        private static void ExecuteV2CheckBalance5()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("V2 Check Balance");
            TreeNode topNode = BinaryTree.BuildBalanceTree(20);
            topNode.Left.Left.Right = null;
            bool isBalanceTree = BinaryTree.CheckBalanceV2(topNode);
            Console.WriteLine("Is balance Tree: " + isBalanceTree);
            Console.WriteLine(SPLITTER);

        }
        



        private static void ExecuteRevertSingleChain()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Build Single Chain");
            ChainItem headItem = SingleChain.BuildSingleChain(10);
            SingleChain.ShowChain(headItem);
            Console.WriteLine("Revert Single Chain");
            ChainItem reversedHeadItem = SingleChain.Revert(headItem);
            SingleChain.ShowChain(reversedHeadItem);
            Console.WriteLine(SPLITTER);
        }

        private static void ExecuteRecursiveRevertSingleChain()
        {
            Console.WriteLine(SPLITTER);
            Console.WriteLine("Build Single Chain");
            ChainItem headItem = SingleChain.BuildSingleChain(10);
            SingleChain.ShowChain(headItem);
            Console.WriteLine("Recursive Revert Single Chain");
            ChainItem recursiveReversedHeadItem = SingleChain.RecursiveRevert(headItem);
            SingleChain.ShowChain(recursiveReversedHeadItem);
            Console.WriteLine(SPLITTER);
        }
    }

}
