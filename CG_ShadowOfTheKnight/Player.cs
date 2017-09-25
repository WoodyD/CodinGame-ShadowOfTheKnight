using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    enum Direction{U, UR, R, DR, D, DL, L, UL}

    class House{
        public int xMin;
        public int yMin;
        public int xMax;
		public int yMax;

        public House(int xMax, int yMax){
            this.xMin = 0;
            this.yMin = 0;
            this.xMax = xMax;
            this.yMax = yMax;
        }
    }

    class Batman{
        public int curPosX;
        public int curPosY;
        House house;

        public Batman(int x, int y, House house){
            this.curPosX = x;
            this.curPosY = y;
            this.house = house;
        }

        public string BatmanMove(Direction dir){
            string toReturn = "";
            switch(dir){
                case Direction.U:
                    house.yMax = curPosY;
                    curPosY = MoveStraight(curPosY, house.yMin);
                    toReturn = curPosX + " " + curPosY;
                    break;
				case Direction.R:
                    house.xMin = curPosX;
                    curPosX = MoveStraight(curPosX, house.xMax);
					toReturn = curPosX + " " + curPosY;
					break;
				case Direction.D:
                    house.yMin = curPosY;
                    curPosY = MoveStraight(curPosY, house.yMax);
					toReturn = curPosX + " " + curPosY;
					break;
				case Direction.L:
                    house.xMax = curPosX;
                    curPosX = MoveStraight(curPosX, house.xMin);
					toReturn = curPosX + " " + curPosY;
					break;
                case Direction.UR:
					house.xMin = curPosX;
					curPosX = MoveStraight(curPosX, house.xMax);
					house.yMax = curPosY;
					curPosY = MoveStraight(curPosY, house.yMin);
                    toReturn = curPosX + " " + curPosY;
                    break;
                case Direction.DR:
					house.xMin = curPosX;
					curPosX = MoveStraight(curPosX, house.xMax);
					house.yMin = curPosY;
					curPosY = MoveStraight(curPosY, house.yMax);
                    toReturn = curPosX + " " + curPosY;
                    break;
                case Direction.DL:
					house.xMax = curPosX;
					curPosX = MoveStraight(curPosX, house.xMin);
					house.yMin = curPosY;
					curPosY = MoveStraight(curPosY, house.yMax);
                    toReturn = curPosX + " " + curPosY;
                    break;
				case Direction.UL:
					house.xMax = curPosX;
					curPosX = MoveStraight(curPosX, house.xMin);
					house.yMax = curPosY;
					curPosY = MoveStraight(curPosY, house.yMin);
					toReturn = curPosX + " " + curPosY;
                    break;
            }
            return toReturn;
        }

        int MoveStraight(int startPos, int endPos){
            int nextPos = (startPos + endPos)/2;
            return nextPos;
        }

    }

	static void Main(string[] args)
	{
		string[] inputs;
		inputs = Console.ReadLine().Split(' ');
		int W = int.Parse(inputs[0]); // width of the building.
		int H = int.Parse(inputs[1]); // height of the building.
		int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
		inputs = Console.ReadLine().Split(' ');
		int X0 = int.Parse(inputs[0]);
		int Y0 = int.Parse(inputs[1]);

        House house = new House(W, H);
        Batman batman = new Batman(X0, Y0, house);
        // game loop
        Direction curDir = Direction.U;
		while (true)
		{
			string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            Enum.TryParse(bombDir, out curDir);
            string nextMove = batman.BatmanMove(curDir);
			// the location of the next window Batman should jump to.
			Console.WriteLine(nextMove);
		}
	}

}
