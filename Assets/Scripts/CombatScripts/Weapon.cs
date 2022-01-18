using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public float fireRate;
    public int damage;
    public float bulletSpeed;
    public Sprite sprite;
    [SerializeField] private GameObject projectilePrefab;
    
    public void Shoot(Transform shooter, float damageMultiplier, float bulletSpeedMultiplier)
    {
        GameObject projectile = Instantiate(projectilePrefab, shooter);
        if(weaponName == "Rocket Launcher")
        {
            projectile.GetComponent<Rocket>().damage = damage * damageMultiplier;
        }
        else
        {
            projectile.GetComponent<Bullet>().damage = damage * damageMultiplier;
        }
        projectile.GetComponent<Rigidbody2D>().velocity = shooter.gameObject.GetComponent<PlayerMovement>().facing * bulletSpeed * bulletSpeedMultiplier;
        projectile.transform.rotation = Quaternion.FromToRotation(new Vector3(1, 0, 0), shooter.GetComponent<PlayerMovement>().facing);
    }
    public void EnemyShoot(Transform shooter, float damageMultiplier, float bulletSpeedMultiplier, Vector2 target)
    {
        GameObject projectile = Instantiate(projectilePrefab, shooter);
        if (weaponName == "Rocket Launcher")
        {
            projectile.GetComponent<Rocket>().damage = damage * damageMultiplier;
        }
        else
        {
            projectile.GetComponent<Bullet>().damage = damage * damageMultiplier;
        }
        projectile.GetComponent<Rigidbody2D>().velocity = (target - (Vector2)shooter.position).normalized * bulletSpeed * bulletSpeedMultiplier;
        projectile.transform.rotation = Quaternion.FromToRotation(new Vector3(1, 0, 0), (target - (Vector2)shooter.position).normalized);
    }
}
