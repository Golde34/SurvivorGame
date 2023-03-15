using UnityEngine;

public class Spear : MonoBehaviour, IWeapon
{
    public string Name => "Spear";
    public int Damage => 5;
    public int FitPoint { get; set; }
    public Vector3 WeaponPoint { get; set; }

    public void Attack()
    {
    }
}
