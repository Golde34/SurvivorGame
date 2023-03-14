using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpearFactory : MonoBehaviour, IWeaponFactory
{
    public IWeapon CreateWeapon(Transform heroTransform)
    {
        //Create Weapon GUI
        var SpearGameObj = Resources.Load("Prefabs/Spear") as GameObject;
        Vector3 position;
        position.x = heroTransform.position.x + 0.2f;
        position.y = heroTransform.position.y + 0.2f;
        position.z = heroTransform.position.z;
        if (SpearGameObj != null)
        {
            var SpearObj = Instantiate(
                SpearGameObj.transform,
                position,
                Quaternion.identity
            );
            Spear Spear = new Spear(); ;
            Spear.Damage = 5;
            Spear.FitPoint = 0;
            Spear.WeaponPoint = position;
            return Spear;
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }
}