using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public string Name => "Sword";
    public int Damage { get; set; }
    public int FitPoint { get; set; }
    public Vector3 WeaponPoint { get; set; }

    public void Attack()
    {
        StartCoroutine(MoveBackAndForth());
    }

    IEnumerator MoveBackAndForth()
    {
        gameObject.transform.localPosition = new Vector3(0.3f, -0.1f, 1.0f);
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 270));
        yield return new WaitForSeconds(0.3f);
        gameObject.transform.localPosition = new Vector3(0.2f, 0.1f, 1.0f);
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        yield break;
    }
}
