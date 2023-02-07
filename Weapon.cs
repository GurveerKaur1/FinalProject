using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Weapon
    {
        private string _name;
        public string Name { get { return _name; } }

        private int _powerOfWeapon;
        public int PowerOfWeapon { get { return _powerOfWeapon; } }

        public Weapon(string name, int powerOfWeapon)
        {
            _name = name;
            _powerOfWeapon = powerOfWeapon;
        }
    }
}
