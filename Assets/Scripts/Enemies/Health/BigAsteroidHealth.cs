using UnityEngine;

namespace Enemies.Health
{
    public class BigAsteroidHealth : global::Health
    {
        [SerializeField] private GameObject littleAsteroid;
        [SerializeField] private int numberOfAsteroids = 2;

        protected override void OnKillThisObject()
        {
            for (int i = 0; i < numberOfAsteroids; i++)
            {
                GameObject asteroid = Instantiate(littleAsteroid, transform.position, Quaternion.identity);
                float randomRotationZ = Random.Range(0f, 360f);
                asteroid.transform.rotation = Quaternion.Euler(0f, 0f, randomRotationZ);
            }

            base.OnKillThisObject();
        }
    }
}