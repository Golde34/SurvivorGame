using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class SwordFactory : MonoBehaviour, IWeaponFactory
{
    public IWeapon CreateWeapon(Transform heroTransform)
    {
        //Create Weapon GUI
        var swordGameObj = Resources.Load("Prefabs/Sword") as GameObject;
        if (swordGameObj != null)
        {
            var swordObj = Instantiate(
                swordGameObj.transform,
                new Vector3(
                    //hero position
                    heroTransform.position.x + 20,
                    heroTransform.position.y + 20,
                    heroTransform.position.z
                ),
                Quaternion.identity
            );
            //GameObject swordObj = new GameObject("Sword");
            Sword sword = swordObj.AddComponent<Sword>();
            sword.Damage = 5;
            sword.FitPoint = 0;

            return sword;
        } else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }
}