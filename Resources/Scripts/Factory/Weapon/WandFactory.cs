using Unity.VisualScripting;
using UnityEngine;

public class WandFactory : MonoBehaviour, IWeaponFactory
{
    public IWeapon CreateWeapon(Transform heroTransform)
    {
        //Create Weapon GUI
        var WandGameObj = Resources.Load("Prefabs/Wand") as GameObject;
        var WandObj = Instantiate(WandGameObj.transform);
        WandObj.transform.parent = heroTransform;
        WandObj.transform.localPosition = new Vector3(0.2f, 0.1f, 1.0f);
        WandObj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        Wand Wand = WandObj.AddComponent<Wand>();
        Wand.Damage = 5;
        Wand.WeaponPoint = WandObj.transform.position;
        return Wand;
    }
}