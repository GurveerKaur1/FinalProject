using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Monster
    {

        private string _monsterName;
        public string MonsterName { get { return _monsterName; } }

        private int _strength;
        public int Strength { get { return _strength; } }

        private int _defence;
        public int Defence { get { return _defence; } }

        private int _originalHealth;
        public int OriginalHealth {
            get { return _originalHealth; }
            set {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception("Health should be greater than zero");
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

        private int _currentHealth;

        public int CurrentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = value; }
        }


        //To get the data of the monster that remains the part of fight
        private HashSet<Fight> fights = new HashSet<Fight>();

        public HashSet<Fight> Fights()
        {
            return fights.ToHashSet();
        }

        public void AddMonsterToFight(Fight fight)
        {
            fights.Add(fight);
        }


        public Monster(string monsterName, int strength, int defence, int originalHealth, int currentHealth)
        {
            _monsterName = monsterName;
            _strength = strength;
            _defence = defence;
            OriginalHealth = originalHealth;
            CurrentHealth = currentHealth;
        }
    }
}
