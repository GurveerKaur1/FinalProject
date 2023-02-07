using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalProject
{
    public class Hero
    {
        private string _name;
        public string Name { get { return _name; } }
        private void _setPlayerName(string name)
        {
            if (name.Length <= 3 || name.Length > 20 || !name.All(c => Char.IsLetter(c)))
            {
                Console.WriteLine("Name is not correct. Name should be between 3 to 20 characters long");
            }
            else
            {
                _name = name;
            }
        }


        private int _originalHealth;

        public int OriginalHealth
        {
            get { return _originalHealth; }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new Exception("Health should be greater than 0");
                    }
                    else
                    {
                        _originalHealth = value;
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                   
                }

            }
        }

        private int _existingHeath;
        public int ExistingHealth
        {
            get { return _existingHeath; }
            set { _existingHeath = value; }
        }

        //Getting instance of weapon in hero class
        private Weapon _equippedWeapon;
        public Weapon EquippedWeapon { get { return _equippedWeapon; } set { _equippedWeapon = value; } }

        //Method to change the hero equipped weapon
        public void ChangeEquippedWeapon(Hero hero)
        {
            bool value = true;

            while (value)
            {
                string changedWeapon = "";
                int power = 0;

                // intializing the weapon and its power
                Dictionary<string, int> weapons = new Dictionary<string, int>()
                {
                {"KNIFE", 20 },
                {"GRENADE", 40 },
                {"BOMB", 30 },
                {"SWORD", 10 }
                 };



                //displaying the list of weapons to choose one of these
                Console.WriteLine("You have");
                foreach (var weapon in weapons)
                {
                  Console.WriteLine(weapon.Key);
                }

                //methods to select the weapon that user want to fight with the monster
                Console.WriteLine("Choose any weapon from the list you want");
                string weaponName = Console.ReadLine().ToUpper();
                while (weaponName != "MAIN" && value)
                {
                    if (!weapons.ContainsKey(weaponName))
                    {
                        Console.WriteLine("Please choose from the above mentioned list");
                        weaponName = Console.ReadLine().ToUpper();
                    }
                    else
                    {
                        changedWeapon = weaponName;
                        power = weapons[changedWeapon];
                        Weapon newWeapon = new Weapon(changedWeapon, power);
                        Console.WriteLine($"Your weapon is {newWeapon.Name}");
                        hero.EquippedWeapon = newWeapon;
                        value = false;
                        Game.MainMenu();
                    }
                }
                if (weaponName == "MAIN")
                {
                    value = false;
                    Game.MainMenu();
                }
            }
        }


        //Getting instance of Armour in hero class
        private Armour _equippedArmour;
        public Armour EquippedArmour { get { return _equippedArmour; } set { _equippedArmour = value; } }

        //Method to change the Hero equipped Armour
        public void ChangeEquippedArmour(Hero hero)
        {
            bool name = true;
            while (name == true)
            {
                string changeArmour = "";
                int power = 0;

                //intializing the armours and its power
                Dictionary<string, int> armours = new Dictionary<string, int>()
                {
                {"STARCRAFT", 10 },
                {"VANQUISH", 8 },
                {"HALFLINE", 7 },
                {"SILVERSOUL", 6 }
                };


                //displaying the list of armours to othe user to choose one of these
                Console.WriteLine("You have");
                foreach (var armour in armours)
                {

                    Console.WriteLine(armour.Key);
                }

                //methods to change the already intialized armour name with the new one
                Console.WriteLine("Choose any armour from the list you want");
                string armourName = Console.ReadLine().ToUpper();
              
                while (armourName != "MAIN" && name)
                {
                    if (!armours.ContainsKey(armourName))
                    {
                        Console.WriteLine("Please choose from the above mentioned list");
                        armourName = Console.ReadLine().ToUpper();
                    }
                    else
                    {
                        changeArmour = armourName;
                        power = armours[changeArmour];
                        Armour newArmour = new Armour(changeArmour, power);
                        Console.WriteLine($"You choose {changeArmour} Armour");
                        hero.EquippedArmour = newArmour;
                        name = false;
                        Game.MainMenu();
                    }
                }
                if (armourName == "MAIN")
                {
                    name = false;
                    Game.MainMenu();
                }

            }

        }

        //Method to get the information about hero
        public void GetStats(Hero hero)
        {
            Console.WriteLine($"Hero name : {hero.Name}, Base strength of hero: {hero.BaseStrength}, Base Defence of Hero: {hero.BaseDefence}");
            Console.WriteLine($"Original Health of Hero : {hero._originalHealth}, Current health of Hero : {hero.ExistingHealth}");
        }

        //Method to get what the hero is equipped with
        public void GetInventory(Hero hero)
        {
            Console.WriteLine($"The weapon that hero has: {hero.EquippedWeapon.Name}");
            Console.WriteLine($"The armour that hero is equipped with: {hero.EquippedArmour.ArmourName}");
        }

        private int _baseStrength;
        public int BaseStrength { get { return _baseStrength; } }


        private int _baseDefence;
        public int BaseDefence { get { return _baseDefence; } }

        private HashSet<Fight> fights = new HashSet<Fight>();

        public HashSet<Fight> Fights()
        {
            return fights.ToHashSet();
        }

        public void AddHeroToFights(Fight fight)
        {
            fights.Add(fight);
        }

        public Hero(string name, int originalHealth, int existingHealth, Weapon equippedWeapon, Armour equippedArmour, int baseStrength, int baseDefence)
        {
            _setPlayerName(name);
            OriginalHealth = originalHealth;
            ExistingHealth = existingHealth;
            _equippedWeapon = equippedWeapon;
            _equippedArmour = equippedArmour;
            _baseStrength = baseStrength;
            _baseDefence = baseDefence;
        }
    }
}
