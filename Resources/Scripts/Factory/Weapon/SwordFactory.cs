using Unity.VisualScripting;
using UnityEngine;

public class SwordFactory : MonoBehaviour, IWeaponFactory
{
    public IWeapon CreateWeapon(Transform heroTransform)
    {
        //Create Weapon GUI
        var SwordGameObj = Resources.Load("Prefabs/Sword") as GameObject;
        var SwordObj = Instantiate(SwordGameObj.transform);
        SwordObj.transform.parent = heroTransform;
        SwordObj.transform.localPosition = new Vector3(0.2f, 0.1f, 1.0f);
        SwordObj.transform.localRotation = Quaternion.identity;

        Sword Sword = SwordObj.AddComponent<Sword>();
        Sword.FitPoint = 0;
        Sword.WeaponPoint = SwordObj.transform.position;
        return Sword;
    }
}