using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Resources.Scripts.Factory.Weapon
{
    public abstract class Weapon
    {
        string name;
        int damage;
        public abstract void Attack();
    }
}
