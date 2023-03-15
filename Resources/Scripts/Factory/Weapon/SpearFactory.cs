using Unity.VisualScripting;
using UnityEngine;

public class SpearFactory : MonoBehaviour, IWeaponFactory
{
    public IWeapon CreateWeapon(Transform heroTransform)
    {
        //Create Weapon GUI
        var SpearGameObj = Resources.Load("Prefabs/Spear") as GameObject;
        var SpearObj = Instantiate(SpearGameObj.transform);
        SpearObj.transform.parent = heroTransform;
        SpearObj.transform.localPosition = new Vector3(0.2f, 0.1f, 1.0f);
        SpearObj.transform.localRotation = Quaternion.identity;

        Spear Spear = SpearObj.AddComponent<Spear>();
        Spear.FitPoint = 0;
        Spear.WeaponPoint = SpearObj.transform.position;
        return Spear;
    }
}