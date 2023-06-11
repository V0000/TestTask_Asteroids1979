using UnityEngine;

namespace Ship
{
    public class SpaceshipHealth : Health
    {
        public delegate void PlayerDestroyed();
        public static event PlayerDestroyed OnPlayerDestroyed;
        protected override void OnKillThisObject()
        {
            
            OnPlayerDestroyed?.Invoke();
            if (base.destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }

            if (!godMode)
            {
                Destroy(gameObject);
            }
        }
    }
}