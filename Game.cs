using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalProject
{
    public class Game
    {
        // private static = null;

        //storing the name of player in Hashset
        private HashSet<Hero> hero = new HashSet<Hero>();

        private HashSet<Monster> monster = new HashSet<Monster>();
        private HashSet<Weapon> weapons = new HashSet<Weapon>();
        private HashSet<Armour> armors = new HashSet<Armour>();
        private HashSet<Fight> fights = new HashSet<Fight>();
        private HashSet<Monster> removedMonster = new HashSet<Monster>();
        private int NumberOfGames = 0;
        private int NumberOfFightsWon = 0;
        private int NumberOfFightsLoss = 0;
        private int j = 0;

        //Getting Player Name and storing it 
        public string GetHeroName()
        {
            bool checkName = true;
            try
            {
                while (checkName)
                {
                    Weapon newWeapon = new Weapon("Knife", 10);
                    Armour newArmour = new Armour("BlueVest", 10);
                    Console.WriteLine("Please enter player's name");
                    string heroName = Console.ReadLine();
                    Hero myHero = new Hero(heroName, 20, 20, newWeapon, newArmour, 10, 10);
                    // myHero.ChangeEquippedWeapon(newWeapon);
                    if (heroName == myHero.Name)
                    {
                        checkName = false;
                        hero.Add(myHero);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "guri";
        }

        //Main menu
        public static void MainMenu()
        {
            Console.WriteLine("The menu options are");
            Console.WriteLine("Press 1 to open the Statistics");
            Console.WriteLine("Press 2 to open the Inventory");
            Console.WriteLine("Press 3 to start the fight");
            // return "Guri";
        }

        // option one 
        public string ShowStatistics()
        {
            Console.WriteLine($"Number of Games played are {NumberOfGames}");
            Console.WriteLine($"Number of Fights Won are {NumberOfFightsWon}");
            Console.WriteLine($"Number of Fights Loss are {NumberOfFightsLoss}");
            return "Guri";
        }

        //Declaring weapon that is used in hero class to change
        //the weapon and is addded in the hashset of weapon
        public string DeclareWeapon()
        {
            Weapon knife = new Weapon("KNIFE", 20);
            Weapon grenade = new Weapon("GRENADE", 40);
            Weapon sword = new Weapon("SWORD", 30);
            Weapon bomb = new Weapon("BOMB", 10);
            weapons.Add(knife);
            weapons.Add(grenade);
            weapons.Add(sword);
            weapons.Add(bomb);
            return "Guri";
        }

        public Weapon? GetWeapon(string name)
        {
            Weapon weapon = null;

            foreach (Weapon w in weapons)
            {
                if (w.Name == name)
                {
                    weapon = w;
                    break;
                }
            }
            return weapon;
        }

        //Declaring Armour, use it in the hero class
        //to select the desired armour and add the armour to the hashset of armors
        public string DeclareArmour()
        {
            Armour starCraft = new Armour("STARCRAFT", 10);
            Armour vanquish = new Armour("VANQUISH", 8);
            Armour halfLine = new Armour("HALFLINE", 7);
            Armour silverSoul = new Armour("SILVERSOUL", 6);
            armors.Add(starCraft);
            armors.Add(vanquish);
            armors.Add(halfLine);
            armors.Add(silverSoul);
            return "guri";
        }

        //declaring monster and adding it to the hashset of monsters
        public void DeclareMonster()
        {
            Monster corpsewing = new Monster("corpsewing", 10, 7, 60, 60);
            Monster corpseface = new Monster("corpseface", 20, 10, 70, 70);
            Monster vexmutant = new Monster("vexmutant", 10, 5, 60, 60);
            Monster defautMan = new Monster("defeatMan", 8, 4, 60, 60);
            Monster spider = new Monster("spider", 5, 3, 40, 40);
            monster.Add(corpsewing);
            monster.Add(corpseface);
            monster.Add(vexmutant);
            monster.Add(defautMan);
            monster.Add(spider);
        }

        //method to get the random value of monster
        private int random = 0;
        private int i = 5;
        private void RandomMethod()
        {
            Random rnd = new Random();


            Console.WriteLine(rnd.Next(i));//returns random integers < 10
            random = rnd.Next(i);

        }
        //method to check if the monster get added or not
        public void find()
        {
            foreach (Monster m in monster)
            {
                Console.WriteLine(m.MonsterName);
            }
        }

        //option for two
        public void optionForTwo(Hero hero)
        {

            bool input = true;

            Console.WriteLine("Press 1 to select the desired weapon");
            Console.WriteLine("Press 2 to select the desired armour");
            Console.WriteLine("Enter Main to return to the main menu");
            //  string value = "";

            string value = Console.ReadLine().ToUpper();

            switch (value)
            {
                case "1":

                    hero.ChangeEquippedWeapon(hero);
                    // MainMenu();
                    break;
                case "2":
                    hero.ChangeEquippedArmour(hero);
                    // MainMenu();
                    break;
                case "MAIN":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid input to change the weapon or armour");
                    break;



            }

        }


        //Main method to start the game
        public string Start()
        {
            bool checkName = true;

            DeclareMonster();
            //method to ask for the player name and intialize the weapon and armour that the player will use
            Weapon newWeapon = new Weapon("Knife", 20);
            Armour newArmour = new Armour("BlueVest", 10);
            Hero myHero = new Hero(GetHeroName(), 100, 100, newWeapon, newArmour, 5, 5);
            Monster myMonster = monster.ToList()[random];

            //method for displaying the main menu
            MainMenu();

            //methods for getting the user input for menu options
            string userInput = "";
            bool requiredValidInput = true;
            bool checkMenu = true;

            //validating the user input for menu options
            while (requiredValidInput)
            {
                userInput = Console.ReadLine().ToUpper();
                while (checkMenu)
                {

                    switch (userInput)
                    {
                        case "1":
                            ShowStatistics();
                            MainMenu();
                            break;
                        case "2":

                            optionForTwo(myHero);
                            break;
                        case "3":

                            //main method to start the fight
                            NumberOfGames++;

                            //method to get the random monster
                            RandomMethod();
                            myMonster = monster.ToList()[random];
                            Fight newFight = new Fight(myHero, myMonster);

                            //Adding hero and monster to hashset in their own classes to have a record of that
                            myMonster.AddMonsterToFight(newFight);
                            myHero.AddHeroToFights(newFight);

                            //fight started
                            //method to check if the existing health of the hero is zero and then set this equal to original health
                            if (myHero.ExistingHealth <= 0 && i == 5)
                            {
                                myHero.ExistingHealth = myHero.OriginalHealth;
                                DeclareMonster();

                            }
                            while (myHero.ExistingHealth > 0 && myMonster.CurrentHealth > 0 && myHero.OriginalHealth > 0 && myMonster.OriginalHealth > 0)
                            {
                                int heroPower = myHero.BaseDefence + myHero.EquippedArmour.ArmourPower;
                                Console.WriteLine("Its hero turn");
                                newFight.HeroTurn(myHero, myMonster);
                                bool win = newFight.Win(myMonster, myHero);

                                //if-else statement to check who wins the game and who lost it
                                if (!win)
                                {

                                    newFight.MonsterTurn(myMonster, myHero);

                                }
                                else
                                {

                                    newFight.Loss(myMonster, myHero);

                                }

                                //another if-else statement to store the number of fights the hero loses and wins
                                if (myHero.ExistingHealth == 0)
                                {
                                    NumberOfFightsLoss++;
                                }
                                else if (myMonster.CurrentHealth == 0)
                                {
                                    NumberOfFightsWon++;
                                }

                            }

                            //method to remove the monster, if the monster health is less than or equal to zero
                            if (myMonster.CurrentHealth <= 0)
                            {
                                i--;
                                monster.Remove(myMonster);
                                removedMonster.Add(myMonster);
                                //  Console.WriteLine(removedMonster.Count());

                                // if all the monster will defeated by the hero then start again
                                while (i <= 0)
                                {
                                    Console.WriteLine("You defeated all the monsters .You won this Game. Now go to the main menu to start again");
                                    Console.WriteLine("Please enter Main to start again");
                                    userInput = Console.ReadLine().ToUpper();
                                    while (userInput != "MAIN")
                                    {
                                        Console.WriteLine("Please enter Main to start again");
                                        userInput = Console.ReadLine().ToUpper();
                                    }
                                    // MainMenu();
                                    DeclareMonster();
                                    i = 5;
                                    j = 0;
                                    removedMonster.Clear();
                                    break;
                                }
                            }



                            if (myHero.ExistingHealth <= 0 && i < 5 && j < 5)
                            {

                                myHero.ExistingHealth = myHero.OriginalHealth;
                                monster.Add(removedMonster.ToList()[j]);
                                j++;
                            }

                           
                            MainMenu();
                            break;
                        case "MAIN":
                            MainMenu();
                            break;
                        default:
                            Console.WriteLine("Menu options doesnot this option. Please choose a value from the list provided.");
                            MainMenu();
                            break;

                    }
                    if (myHero.OriginalHealth <= 0)
                    {
                        Console.WriteLine("Health should be greater than 0");
                        requiredValidInput = false;
                        // MainMenu();
                    }
                    if (myMonster.OriginalHealth <= 0)
                    {
                        Console.WriteLine("Health should be greater than zero");
                        requiredValidInput = false;
                    }
                    break;
                }


            }
            return "guri";

        }


    }
}
