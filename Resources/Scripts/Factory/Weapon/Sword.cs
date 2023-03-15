using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public string Name => "Sword";
    public int Damage => 3;
    public int FitPoint { get; set; }
    public Vector3 WeaponPoint { get; set; }

    public void Attack()
    {
    }
}
