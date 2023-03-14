using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IWeapon
{
    string Name { get; }
    int Damage { get; set; }
    int FitPoint { get; set; }

    public void Attack()
    {
        // Attack here
    }
}
