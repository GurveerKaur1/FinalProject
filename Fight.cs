using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Fight
    {

        private Hero _hero;
        public Hero hero { get { return _hero; } }

        private Monster _monster;
        public Monster monster { get { return _monster; } }
        public string HeroTurn(Hero hero, Monster monster)
        {
            
            int heropower = hero.BaseStrength + hero.EquippedWeapon.PowerOfWeapon;
            int damageToMonster = heropower - monster.Defence;
            monster.CurrentHealth = monster.CurrentHealth - damageToMonster;
            if ( monster.CurrentHealth > 0)
            {
                monster.CurrentHealth = monster.CurrentHealth;
                Console.WriteLine($"Current health of monster is {monster.CurrentHealth}");
            }
            else
            {
                monster.CurrentHealth = 0;
               
                    Console.WriteLine($"Current health of monster is {monster.CurrentHealth}");
                Console.WriteLine($"Monster lost and {hero.Name} won the fight");
            }
            return "grui";
        }

        public string MonsterTurn(Monster monster, Hero hero)
        {
           int heroPower = hero.BaseDefence + hero.EquippedArmour.ArmourPower;
            int damageToHero = monster.Strength - hero.BaseDefence - hero.EquippedArmour.ArmourPower;
            hero.ExistingHealth = hero.ExistingHealth - damageToHero;
            if (hero.ExistingHealth > 0)
            {
              
                hero.ExistingHealth = hero.ExistingHealth;
                Console.WriteLine($"The current health of hero is {hero.ExistingHealth}");
           }
            else
            {
                hero.ExistingHealth = 0;
                Console.WriteLine($"The current health of hero is {hero.ExistingHealth}");
                Console.WriteLine("You lose");
              //  Loss(monster, hero);
            }
            return "guri";
        }

        public int NumberOfFightWon = 0;
        public bool  Win(Monster monster, Hero hero)
        {
           bool win = false;
            if(monster.CurrentHealth <= 0)
            {
                Console.WriteLine("You win");
                NumberOfFightWon++;
                win = true;
              // _monster.Remove(monster);
            }
            return win;
        }

     
        public string Loss(Monster monster, Hero hero)
        {
          //  bool loss = false;
           if(hero.ExistingHealth <= 0)
            {
                Console.WriteLine("You Loss");
                

            }
            return "grui";
            
        }

        public Fight(Hero hero, Monster monster)
        {
            _hero = hero;
            _monster = monster;
        }
    }
}
