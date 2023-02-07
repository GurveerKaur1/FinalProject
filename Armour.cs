using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Armour
    {
        private string _armourName;
        public string ArmourName { get { return _armourName; } }

        private int _armourPower;
        public int ArmourPower { get { return _armourPower; } }

        public Armour(string armourName, int armourPower) 
        {
            _armourName= armourName;
            _armourPower= armourPower;
        }
    }
}
