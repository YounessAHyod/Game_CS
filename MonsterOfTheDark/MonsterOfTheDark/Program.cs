using System;
using System.IO;
namespace MonsterOfTheDark
{
	class Program
	{
		const int CAVERN_WIDTH = 7;
		const int CAVERN_HEIGHT = 5;



		public struct CellPosition
		{
			public int x;
			public int y;
		}

		static void Main(string[] args)
		{

			Console.Title = "Monster Of The Dark";

			char[,] cavern = new char[CAVERN_WIDTH, CAVERN_HEIGHT];
			CellPosition playerPosition = new CellPosition();
			CellPosition PortalStone = new CellPosition();
			CellPosition Trap1 = new CellPosition();
			CellPosition Trap2 = new CellPosition();//
			CellPosition Monster = new CellPosition();


			

			int choice = 0;
			while (choice != 4)
			{


				Console.WriteLine();
				Console.WriteLine();
				DisplayMenu();
				choice = GetMainMenuChoice();

				switch (choice)
				{
					case 1:

						SetUpTrainingGame(cavern, ref playerPosition);
						//Random Stone generator
						Random random = new Random();
						int StonePosition = random.Next(0, 6);
						PortalStone.x = StonePosition;
						int StonePosition1 = random.Next(0, 4);
						PortalStone.y = StonePosition1;
						int StonePositionB = random.Next(0, 6);
						Trap2.x = StonePositionB;
						int StonePositionA = random.Next(0, 4);
						Trap2.y = StonePositionB;
						//characters
						SetPositionOfItem(cavern, 'P', ref PortalStone);
						SetPositionOfItem(cavern, 'T', ref Trap1);
						SetPositionOfItem(cavern, 'T', ref Trap2);// second
						SetPositionOfItem(cavern, ' ', ref Monster);



						int Count = 0;
						if (PortalStone.x == Trap1.x && PortalStone.y == Trap1.y)
						{
							//In case spawning in the same location
							Random secondary = new Random();
							int newlocation = random.Next(0, 6);
							int newlocation1 = random.Next(0, 4);

							Trap1.x = newlocation;
							Trap1.y = newlocation1;


							SetPositionOfItem(cavern, 'T', ref Trap1);

						}
						if (Monster.x == Trap1.x && Monster.y == Trap1.y)
						{
							//In case spawning in the same location
							Random secondary = new Random();
							int newlocation = random.Next(0, 6);
							int newlocation1 = random.Next(0, 4);
							Trap1.x = newlocation;
							Trap1.y = newlocation1;


							SetPositionOfItem(cavern, 'T', ref Trap1);

						}
						if (Trap1.x == playerPosition.x && Trap1.y == playerPosition.y)

						{
							Random secondary = new Random();
							int newlocation = random.Next(0, 6);
							int newlocation1 = random.Next(0, 4);
							playerPosition.x = newlocation;
							playerPosition.y = newlocation1;
						}
						if (Monster.x == PortalStone.x && Monster.y == PortalStone.y)
						{
							//In case spawning in the same location
							Random secondary = new Random();
							int newlocation = random.Next(0, 6);
							int newlocation1 = random.Next(0, 4);
							Monster.x = newlocation;
							Monster.y = newlocation1;


							SetPositionOfItem(cavern, 'M', ref PortalStone);

						}
						if (Monster.x == playerPosition.x && Monster.y == playerPosition.y)
						{
							//In case spawning in the same location
							Random secondary = new Random();
							int newlocation = random.Next(0, 6);
							int newlocation1 = random.Next(0, 4);
							Monster.x = newlocation;
							Monster.y = newlocation1;


							SetPositionOfItem(cavern, 'M', ref Monster);
						}

						if (PortalStone.x == playerPosition.x && PortalStone.y == playerPosition.y)

						{
							Random secondary = new Random();
							int newlocation = random.Next(0, 6);
							int newlocation1 = random.Next(0, 4);
							playerPosition.x = newlocation;
							playerPosition.y = newlocation1;
						}
						//In case spawning in the same location
						if ((PortalStone.x == Trap2.x && PortalStone.y == Trap2.y) || (playerPosition.x == Trap2.x && playerPosition.y == Trap2.y) || (Trap1.x == Trap2.x && Trap1.y == Trap2.y) || (Monster.x == Trap2.x && Monster.y == Trap2.y))

						{
							Random secondary = new Random();
							int newlocation = random.Next(0, 6);
							int newlocation1 = random.Next(0, 4);
							Trap2.x = newlocation;
							Trap2.y = newlocation1;
						}
						

						while (true)
						{
							DisplayCavern(cavern);
							DisplayMovements();
							string c = Console.ReadLine();
							if (c == "w")
							{
								MoveUp(cavern, ref playerPosition);
							}
							else if (c == "s")
							{
								MoveDown(cavern, ref playerPosition);
							}
							else if (c == "a")
							{
								MoveLeft(cavern, ref playerPosition);
							}
							else if (c == "d")
							{
								MoveRight(cavern, ref playerPosition);

							}
							else if (c == "m")
							{

								break;
							}
							else if (c == "g")
							{
								using (StreamWriter sw = new StreamWriter(@"c:\temp\savegameTextFile.txt"))
								{
									sw.WriteLine(playerPosition.x);
									sw.WriteLine(playerPosition.y);
									sw.WriteLine(Monster.x);
									sw.WriteLine(Monster.y);
									sw.WriteLine(PortalStone.x);
									sw.WriteLine(PortalStone.y);
									sw.WriteLine(Trap1.x);
									sw.WriteLine(Trap1.y);
									sw.WriteLine(Trap2.x);
									sw.WriteLine(Trap2.y);
								}

								break;
							}

							if (playerPosition.y == PortalStone.y && playerPosition.x == PortalStone.x)
							{
								Console.WriteLine();
								Console.WriteLine();
								Console.WriteLine();
								Console.WriteLine("VICTORY !!!!!! you will be redirected to Main Menu");
								Console.WriteLine();

								break;
							}
							if (Count == 0)
							{
								if ((playerPosition.x == Trap1.x && playerPosition.y == Trap1.y) || ((playerPosition.x == Trap2.x && playerPosition.y == Trap2.y)))
								{
									Count++;
								}

							}
							else
							{
								for (int i = 1; i <= 2; i++)
								{
									if (Monster.x > playerPosition.x)
									{
										SetPositionOfItem(cavern, ' ', ref Monster);
										Monster.x -= 1;
									}
									else if (Monster.x < playerPosition.x)
									{
										SetPositionOfItem(cavern, ' ', ref Monster);
										Monster.x += 1;
									}
									else if (Monster.y > playerPosition.y)
									{
										SetPositionOfItem(cavern, ' ', ref Monster);
										Monster.y -= 1;
									}
									else if (Monster.y < playerPosition.y)
									{
										SetPositionOfItem(cavern, ' ', ref Monster);
										Monster.y += 1;
									}
								}
								SetPositionOfItem(cavern, 'M', ref Monster);
							}
							if (playerPosition.y == Monster.y && playerPosition.x == Monster.x)
							{
								Console.WriteLine();
								Console.WriteLine();
								Console.WriteLine();
								Console.WriteLine("OH NO !!!! Monster got you!! Better Luck Next Time");
								Console.WriteLine();

								break;
							}
						}
						break;


					case 2:
						SetUpGame(cavern, ref playerPosition);
						//Random Stone generator
						Random random1 = new Random();
						int StonePosition2 = random1.Next(0, 6);
						PortalStone.x = StonePosition2;
						int StonePosition3 = random1.Next(0, 4);
						PortalStone.y = StonePosition3;
						int StonePositionC = random1.Next(0, 6);
						Trap2.x = StonePositionC;
						int StonePositionD = random1.Next(0, 4);
						Trap2.y = StonePositionD;
						//characters
						SetPositionOfItem(cavern, ' ', ref PortalStone);
						SetPositionOfItem(cavern, ' ', ref Trap1);
						SetPositionOfItem(cavern, ' ', ref Trap2);// second
						SetPositionOfItem(cavern, ' ', ref Monster);



						int Count1 = 0;
						if (PortalStone.x == Trap1.x && PortalStone.y == Trap1.y)
						{
							//In case spawning in the same location
							Random secondary = new Random();
							int newlocation = random1.Next(0, 6);
							int newlocation1 = random1.Next(0, 4);

							Trap1.x = newlocation;
							Trap1.y = newlocation1;


							SetPositionOfItem(cavern, ' ', ref Trap1);

						}
						if (Monster.x == Trap1.x && Monster.y == Trap1.y)
						{
							//In case spawning in the same location
							Random secondary = new Random();
							int newlocation = random1.Next(0, 6);
							int newlocation1 = random1.Next(0, 4);
							Trap1.x = newlocation;
							Trap1.y = newlocation1;


							SetPositionOfItem(cavern, ' ', ref Trap1);

						}
						if (Trap1.x == playerPosition.x && Trap1.y == playerPosition.y)

						{
							Random secondary = new Random();
							int newlocation = random1.Next(0, 6);
							int newlocation1 = random1.Next(0, 4);
							playerPosition.x = newlocation;
							playerPosition.y = newlocation1;
						}
						if (Monster.x == PortalStone.x && Monster.y == PortalStone.y)
						{
							//In case spawning in the same location
							Random secondary = new Random();
							int newlocation = random1.Next(0, 6);
							int newlocation1 = random1.Next(0, 4);
							Monster.x = newlocation;
							Monster.y = newlocation1;


							SetPositionOfItem(cavern, ' ', ref PortalStone);

						}
						if (Monster.x == playerPosition.x && Monster.y == playerPosition.y)
						{
							//In case spawning in the same location
							Random secondary = new Random();
							int newlocation = random1.Next(0, 6);
							int newlocation1 = random1.Next(0, 4);
							Monster.x = newlocation;
							Monster.y = newlocation1;


							SetPositionOfItem(cavern, ' ', ref Monster);
						}
						if (PortalStone.x == playerPosition.x && PortalStone.y == playerPosition.y)

						{
							Random secondary = new Random();
							int newlocation = random1.Next(0, 6);
							int newlocation1 = random1.Next(0, 4);
							playerPosition.x = newlocation;
							playerPosition.y = newlocation1;
						}
						if ((PortalStone.x == Trap2.x && PortalStone.y == Trap2.y) || (playerPosition.x == Trap2.x && playerPosition.y == Trap2.y) || (Trap1.x == Trap2.x && Trap1.y == Trap2.y) || (Monster.x == Trap2.x && Monster.y == Trap2.y))

						{
							Random secondary = new Random();
							int newlocation = random1.Next(0, 6);
							int newlocation1 = random1.Next(0, 4);
							Trap2.x = newlocation;
							Trap2.y = newlocation1;
						}
						while (true)
						{
							DisplayCavern(cavern);
							DisplayMovements();
							string c = Console.ReadLine();
							if (c == "w")
							{
								MoveUp(cavern, ref playerPosition);
							}
							else if (c == "s")
							{
								MoveDown(cavern, ref playerPosition);
							}
							else if (c == "a")
							{
								MoveLeft(cavern, ref playerPosition);
							}
							else if (c == "d")
							{
								MoveRight(cavern, ref playerPosition);

							}
							else if (c == "m")
							{

								break;
							}
							else if (c == "g")
							{
								using (StreamWriter sw = new StreamWriter(@"c:\temp\savegameTextFile.txt"))
								{
									sw.WriteLine(playerPosition.x);
									sw.WriteLine(playerPosition.y);
									sw.WriteLine(Monster.x);
									sw.WriteLine(Monster.y);
									sw.WriteLine(PortalStone.x);
									sw.WriteLine(PortalStone.y);
									sw.WriteLine(Trap1.x);
									sw.WriteLine(Trap1.y);
									sw.WriteLine(Trap2.x);
									sw.WriteLine(Trap2.y);
								}

								break;
							}

							if (playerPosition.y == PortalStone.y && playerPosition.x == PortalStone.x)
							{
								Console.WriteLine();
								Console.WriteLine();
								Console.WriteLine();
								Console.WriteLine("VICTORY !!!!!! you will be redirected to Main Menu");
								Console.WriteLine();

								break;
							}
							if (Count1 == 0)
							{
								if ((playerPosition.x == Trap1.x && playerPosition.y == Trap1.y) || ((playerPosition.x == Trap2.x && playerPosition.y == Trap2.y)))
								{
									SetPositionOfItem(cavern, ' ', ref Trap1);
									Count1++;
								}

							}
							else
							{
								for (int i = 1; i <= 2; i++)
								{
									if (Monster.x > playerPosition.x)
									{
										SetPositionOfItem(cavern, ' ', ref Monster);
										Monster.x -= 1;
									}
									else if (Monster.x < playerPosition.x)
									{
										SetPositionOfItem(cavern, ' ', ref Monster);
										Monster.x += 1;
									}
									else if (Monster.y > playerPosition.y)
									{
										SetPositionOfItem(cavern, ' ', ref Monster);
										Monster.y -= 1;
									}
									else if (Monster.y < playerPosition.y)
									{
										SetPositionOfItem(cavern, ' ', ref Monster);
										Monster.y += 1;
									}
								}
								SetPositionOfItem(cavern, 'M', ref Monster);
							}
							if (playerPosition.y == Monster.y && playerPosition.x == Monster.x)
							{
								Console.WriteLine();
								Console.WriteLine();
								Console.WriteLine();
								Console.WriteLine("OH NO !!!! Monster got you!! Better Luck Next Time");
								Console.WriteLine();

								break;
							}
						}
						break;

					case 3:
						
						using (StreamReader sr = new StreamReader(@"c:\temp\savegameTextFile.txt"))
						{
							string jj = null;
							int[] storeval = new int[10];
							int i = 0;
							while ((jj = sr.ReadLine()) != null)
							{
								jj = sr.ReadLine();
								storeval[i] = Int32.Parse(jj);
								i++;
							}
							playerPosition.x = storeval[0]; 
							

							playerPosition.y = storeval[1];
							

							Monster.x = storeval[2];

							Monster.y = storeval[3];

							PortalStone.x = storeval[4];

							PortalStone.y = storeval[5];

							Trap1.x = storeval[6];

							Trap1.y = storeval[7];

							Trap2.x = storeval[8];

							Trap2.y = storeval[9];

							
							SetPositionOfItem(cavern, 'P', ref PortalStone);
							SetPositionOfItem(cavern, 'T', ref Trap1);
							SetPositionOfItem(cavern, 'T', ref Trap2);
							SetPositionOfItem(cavern, ' ', ref Monster);
							

							int Count2 = 0;
							while (true)
							{
								DisplayCavern(cavern);
								DisplayMovements();
								string c = Console.ReadLine();
								if (c == "w")
								{
									MoveUp(cavern, ref playerPosition);
								}
								else if (c == "s")
								{
									MoveDown(cavern, ref playerPosition);
								}
								else if (c == "a")
								{
									MoveLeft(cavern, ref playerPosition);
								}
								else if (c == "d")
								{
									MoveRight(cavern, ref playerPosition);

								}
								else if (c == "m")
								{

									break;
								}
								else if (c == "g")
								{
									using (StreamWriter sw = new StreamWriter(@"c:\temp\savegameTextFile.txt"))
									{
										sw.WriteLine(playerPosition.x);
										sw.WriteLine(playerPosition.y);
										sw.WriteLine(Monster.x);
										sw.WriteLine(Monster.y);
										sw.WriteLine(PortalStone.x);
										sw.WriteLine(PortalStone.y);
										sw.WriteLine(Trap1.x);
										sw.WriteLine(Trap1.y);
										sw.WriteLine(Trap2.x);
										sw.WriteLine(Trap2.y);
									}

									break;
								}

								if (playerPosition.y == PortalStone.y && playerPosition.x == PortalStone.x)
								{
									Console.WriteLine();
									Console.WriteLine();
									Console.WriteLine();
									Console.WriteLine("VICTORY !!!!!! you will be redirected to Main Menu");
									Console.WriteLine();

									break;
								}
								
								if ( Count2 == 0)
								{
									if ((playerPosition.x == Trap1.x && playerPosition.y == Trap1.y) || ((playerPosition.x == Trap2.x && playerPosition.y == Trap2.y)))
									{
										Count2++;
									}

								}
								else
								{
									for (int j = 1; j <= 2; j++)
									{
										if (Monster.x > playerPosition.x)
										{
											SetPositionOfItem(cavern, ' ', ref Monster);
											Monster.x -= 1;
										}
										else if (Monster.x < playerPosition.x)
										{
											SetPositionOfItem(cavern, ' ', ref Monster);
											Monster.x += 1;
										}
										else if (Monster.y > playerPosition.y)
										{
											SetPositionOfItem(cavern, ' ', ref Monster);
											Monster.y -= 1;
										}
										else if (Monster.y < playerPosition.y)
										{
											SetPositionOfItem(cavern, ' ', ref Monster);
											Monster.y += 1;
										}
									}
									SetPositionOfItem(cavern, 'M', ref Monster);
								}
								if (playerPosition.y == Monster.y && playerPosition.x == Monster.x)
								{
									Console.WriteLine();
									Console.WriteLine();
									Console.WriteLine();
									Console.WriteLine("OH NO !!!! Monster got you!! Better Luck Next Time");
									Console.WriteLine();

									break;
								}
							}


						}
						break;
				}
			}
		}

		public static void InitialiseCavern(char[,] cavern)
		{
			int row, column;

			for (row = 0; row < CAVERN_HEIGHT; row++)
			{
				for (column = 0; column < CAVERN_WIDTH; column++)
				{
					cavern[column, row] = ' ';
				}
			}
		}

		public static void DisplayCavern(char[,] cavern)
		{


			for (int row = 0; row < CAVERN_HEIGHT; row++)
			{
				Console.WriteLine("  --------------------------- ");

				for (int column = 0; column < CAVERN_WIDTH; column++)
				{
					if (cavern[column, row] == ' ' || cavern[column, row] == '*') //spawn player
					{

						Console.Write(" | " + cavern[column, row]);

					}
					else if (cavern[column, row] == ' ' || cavern[column, row] == 'P') // spawnstone
					{

						Console.Write(" | " + cavern[column, row]);

					}
					else if (cavern[column, row] == ' ' || cavern[column, row] == 'T') // spawnTrap1
					{

						Console.Write(" | " + cavern[column, row]);

					}
					else if (cavern[column, row] == ' ' || cavern[column, row] == 'L') // testTrap2
					{

						Console.Write(" | " + cavern[column, row]);

					}
					else if (cavern[column, row] == ' ' || cavern[column, row] == 'M') // spawnMonster
					{

						Console.Write(" | " + cavern[column, row]);

					}

					else
					{
						Console.Write(" |  ");
					}
				}

				Console.WriteLine(" | ");

			}

			Console.WriteLine("  --------------------------- ");
			Console.WriteLine();

		}

		public static void SetPositionOfItem(char[,] cavern, char item, ref CellPosition objectPosition)
		{
			cavern[objectPosition.x, objectPosition.y] = item;
		}

		public static void SetUpGame(char[,] cavern, ref CellPosition playerPosition)
		{
			InitialiseCavern(cavern);

			playerPosition.x = 0;
			playerPosition.y = 0;

			SetPositionOfItem(cavern, '*', ref playerPosition);

		}

		public static void SetUpPortalStone(char[,] cavern, ref CellPosition PortalStone)
		{

			Random random = new Random();
			int StonePosition = random.Next(0, 6);
			int StonePosition1 = random.Next(0, 4);

			PortalStone.x = StonePosition;
			PortalStone.y = StonePosition1;

			SetPositionOfItem(cavern, 'P', ref PortalStone);

		}
		// setting trap 1
		public static void SetUpTrap1(char[,] cavern, ref CellPosition Trap1)
		{
			Random random = new Random();
			int StonePosition = random.Next(0, 6);
			int StonePosition1 = random.Next(0, 4);

			Trap1.x = StonePosition;
			Trap1.y = StonePosition1;

			SetPositionOfItem(cavern, 'T', ref Trap1);

		}


		public static void SetUpMonster(char[,] cavern, ref CellPosition Monster)
		{


			Random random = new Random();
			int StonePosition = random.Next(0, 6);
			int StonePosition1 = random.Next(0, 4);

			Monster.x = StonePosition;
			Monster.y = StonePosition1;

			SetPositionOfItem(cavern, 'M', ref Monster);

		}


		public static void SetUpTrainingGame(char[,] cavern, ref CellPosition playerPosition)
		{
			InitialiseCavern(cavern);

			playerPosition.x = 5;
			playerPosition.y = 3;

			SetPositionOfItem(cavern, '*', ref playerPosition);
		}


		public static void PlayGame(char[,] cavern, ref CellPosition playerPosition)
		{
			DisplayCavern(cavern);
		}

		public static void MoveUp(char[,] cavern, ref CellPosition playerPosition)
		{
			SetPositionOfItem(cavern, ' ', ref playerPosition);

			playerPosition.y = playerPosition.y - 1;

			if (playerPosition.y < 0)// limit top
			{
				playerPosition.y = 0;
			}

			SetPositionOfItem(cavern, '*', ref playerPosition);

		}
		public static void MoveDown(char[,] cavern, ref CellPosition playerPosition)
		{
			SetPositionOfItem(cavern, ' ', ref playerPosition);

			playerPosition.y = playerPosition.y + 1;

			if (playerPosition.y > 4)// limit bottom
			{
				playerPosition.y = 4;
			}

			SetPositionOfItem(cavern, '*', ref playerPosition);

		}
		public static void MoveRight(char[,] cavern, ref CellPosition playerPosition)
		{

			SetPositionOfItem(cavern, ' ', ref playerPosition);
			playerPosition.x = playerPosition.x + 1;

			if (playerPosition.x > 6)// limit right
			{
				playerPosition.x = 6;
			}

			SetPositionOfItem(cavern, '*', ref playerPosition);

		}
		public static void MoveLeft(char[,] cavern, ref CellPosition playerPosition)
		{
			SetPositionOfItem(cavern, ' ', ref playerPosition);

			playerPosition.x = playerPosition.x - 1;

			if (playerPosition.x < 0) //limit left
			{
				playerPosition.x = 0;
			}

			SetPositionOfItem(cavern, '*', ref playerPosition);

		}

		public static void DisplayMenu()
		{
			Console.WriteLine("MAIN MENU");
			Console.WriteLine();
			Console.WriteLine("1. Training Game");
			Console.WriteLine("2. New Game");
			Console.WriteLine("3. Load Game");
			Console.WriteLine("4. Exit");
			Console.WriteLine();
			Console.WriteLine(" Please enter your choice");
		}

		public static int GetMainMenuChoice()
		{
			int choice;
			choice = int.Parse(Console.ReadLine());
			Console.WriteLine();
			return choice;

		}

		public static void DisplayMovements()
		{
			Console.WriteLine("  Please select a key from the following options:");
			Console.WriteLine();
			Console.WriteLine("  W to move Up");
			Console.WriteLine("  S to move Down");
			Console.WriteLine("  A to move Left");
			Console.WriteLine("  D to move Right");
			Console.WriteLine();
			Console.WriteLine("  M to Go Back to Main Menu");
			Console.WriteLine("  G to Save your Game");

		}
	}

}



