using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject prefabProjectil;

    public float timeForShoot = 3f;
    public float timer;

    void Update() 
    {
        timer += Time.deltaTime;

        if (timer >= timeForShoot)
        {
            Shoot();
            timer = 0f;
        }
    }
    void Shoot()
    {
        Instantiate(prefabProjectil, transform.position, transform.rotation);
    }
}
