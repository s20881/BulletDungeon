using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public int magSize;
    public float reloadTime;
    public float fireRate;
    public int baseDamage;
    public float bulletSpeed;
    public float recoilForce;
    public float recoilSpeed;
    public Vector2 muzzlePos;
    public Sprite sprite;
    [SerializeField] private GameObject projectilePrefab;
    
    public void Shoot(GameObject shooter, float damageMultiplier, float bulletSpeedMultiplier, Vector2 bulletPos, Vector2 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, bulletPos, Quaternion.FromToRotation(new Vector3(1, 0, 0), direction));
        if(weaponName == "Rocket Launcher")
        {
            projectile.GetComponent<Rocket>().damage = baseDamage * damageMultiplier;
        }
        else
        {
            projectile.GetComponent<Bullet>().damage = baseDamage * damageMultiplier;
            projectile.GetComponent<Bullet>().shooter = shooter;
        }
        projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed * bulletSpeedMultiplier;
    }
}
