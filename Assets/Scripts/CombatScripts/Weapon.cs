using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public int magSize;
    public float fireRate;
    public int baseDamage;
    public float bulletSpeed;
    public Sprite sprite;
    [SerializeField] private GameObject projectilePrefab;
    
    public void Shoot(Transform shooter, float damageMultiplier, float bulletSpeedMultiplier, Vector2 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, shooter);
        if(weaponName == "Rocket Launcher")
        {
            projectile.GetComponent<Rocket>().damage = baseDamage * damageMultiplier;
        }
        else
        {
            projectile.GetComponent<Bullet>().damage = baseDamage * damageMultiplier;
        }
        projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed * bulletSpeedMultiplier;
        projectile.transform.rotation = Quaternion.FromToRotation(new Vector3(1, 0, 0), direction);
    }
}
