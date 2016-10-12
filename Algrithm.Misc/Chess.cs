using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm
{
    class ChessPosition
    {
        public ChessPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X;
        public int Y;

        public override bool Equals(object obj)
        {
            ChessPosition position = (ChessPosition)obj;
            return position.X == this.X && position.Y == this.Y;
        }

        public static bool operator ==(ChessPosition chessPosition1, ChessPosition chessPosition2)
        {
            return chessPosition1.Equals(chessPosition2);
        }

        public static bool operator !=(ChessPosition chessPosition1, ChessPosition chessPosition2)
        {
            return !chessPosition1.Equals(chessPosition2);
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /*
     * Chess of 6 X 6, S=Start(2,0), E=End(5,3)
     * 
          A (0, 0)                       B (5, 0)
                ----------S---------------
                |    |    |    |    |    | 
                --------------------------
                |    |    |    |    |    |
                --------------------------
                |    |    |    |    |    |
                -------------------------E
                |    |    |    |    |    |
                --------------------------
                |    |    |    |    |    |
                --------------------------
          C (0, 5)                       D (5, 5)  
    */
    class ChessBoard
    {
        // If RADIUS = 3, then the ChessBoard is 4 X 4
        private const int RADIUS = 4;

        /*
           If RADIUS = 2,   valid paths is              2  
                            and RecursiveCount is       9
         * 
           If RADIUS = 3,   valid paths is              98
                            and RecursiveCount is       615
         * 
           If RADIUS = 4,   valid paths is              99411
                            and RecursiveCount is       878233
         * 
           If RADIUS = 5,   valid paths is              752658422
                            and RecursiveCount is       9540326956
        */
        public static long RecursiveCount
        {
            set;
            get;
        }
        
        public static long ValidPathCount
        {
            set;
            get;
        }
        
        public static readonly ChessPosition Start = new ChessPosition(0, 1);
        public static readonly ChessPosition End = new ChessPosition(RADIUS, RADIUS - 1);
                
        public static List<ChessPosition> NextPostions(ChessPosition currentPostion)
        {
            int X = currentPostion.X;
            int Y = currentPostion.Y;

            List<ChessPosition> nextPositions = new List<ChessPosition>
            {
                new ChessPosition(X + 1, Y - 2),
                new ChessPosition(X + 2, Y - 1),
                new ChessPosition(X + 2, Y + 1),
                new ChessPosition(X + 1, Y + 2),
                new ChessPosition(X - 1, Y + 2),
                new ChessPosition(X - 2, Y + 1),
                new ChessPosition(X - 2, Y - 1),
                new ChessPosition(X - 1, Y - 2)
            };

            return nextPositions.FindAll(nextPosition => nextPosition.X >= 0
                                                && nextPosition.X <= RADIUS
                                                && nextPosition.Y >= 0
                                                && nextPosition.Y <= RADIUS);

        }
    }
    
    class Chess
    {
        public static List<List<ChessPosition>> Execute()
        {
            List<List<ChessPosition>> allPaths = new List<List<ChessPosition>>();
            List<ChessPosition> passedPositions = new List<ChessPosition>();
            ChessBoard.RecursiveCount = 0;
            ChessBoard.ValidPathCount = 0;
            Seek(passedPositions, ChessBoard.Start, allPaths);
            return allPaths;
        }

        /* 
         * Below code is applied to large RADUIS case, because the number of valid paths is too huge so that it may
           cause the out of memory issue. So here the valid path is not stored.
        */
        private static void Seek(List<ChessPosition> passedPositions, ChessPosition currentPosition, List<List<ChessPosition>> allPaths)
        {
            //if (ChessBoard.ValidPathCount == 2) return;

            ChessBoard.RecursiveCount++;

            passedPositions.Add(currentPosition);

            if (currentPosition == ChessBoard.End)
            {
                ChessBoard.ValidPathCount++;
                if (ChessBoard.ValidPathCount % 1000000 == 0) Console.WriteLine(string.Format("Find {0} Paths, and Total Recursive Count is {1}", ChessBoard.ValidPathCount, ChessBoard.RecursiveCount));
                allPaths.Add(new List<ChessPosition>(passedPositions));
                // Print out the Frame count
                //System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                //Console.WriteLine("Frame Count " + st.FrameCount);
                return;
            }

            List<ChessPosition> nextPositions = ChessBoard.NextPostions(currentPosition);
            foreach (ChessPosition nextPosition in nextPositions)
            {
                if (!passedPositions.Contains(nextPosition))
                {
                    // Solution 1:
                    int passedPositionCountBackup = passedPositions.Count;
                    Seek(passedPositions, nextPosition, allPaths);
                    if (passedPositions.Count > passedPositionCountBackup)
                    {
                        passedPositions.RemoveAt(passedPositions.Count - 1);
                    }

                    // Solution 2:
                    //List<ChessPosition> copyPassedPositions = new List<ChessPosition>(passedPositions);
                    //Seek(copyPassedPositions, nextPosition, allPaths);
                }
            }
        }

        //// Below code can be applied to cases of RADIUS less than 4
        //private static void Seek(List<ChessPosition> passedPositions, ChessPosition currentPosition, List<List<ChessPosition>> allPaths)
        //{
        //    ChessBoard.RecursiveCount++;

        //    passedPositions.Add(currentPosition);
        //    if (currentPosition == ChessBoard.End)
        //    {
        //        List<ChessPosition> validPath = new List<ChessPosition>(passedPositions); // Create a copy
        //        allPaths.Add(validPath);
        //        ChessBoard.ValidPathCount++;
        //        return;
        //    }

        //    List<ChessPosition> nextPositions = ChessBoard.NextPostions(currentPosition);
        //    foreach (ChessPosition nextPosition in nextPositions)
        //    {
        //        if (!passedPositions.Contains(nextPosition))
        //        {
        //            // Solution 1:
        //            int passedPositionCountBackup = passedPositions.Count;
        //            Seek(passedPositions, nextPosition, allPaths);
        //            if (passedPositions.Count > passedPositionCountBackup)
        //            {
        //                passedPositions.RemoveAt(passedPositions.Count - 1);
        //            }

        //            // Solution 2:
        //            //List<ChessPosition> copyPassedPositions = new List<ChessPosition>(passedPositions);
        //            //Seek(copyPassedPositions, nextPosition, allPaths);

        //        }
        //    }
        //}
        
    }
}
