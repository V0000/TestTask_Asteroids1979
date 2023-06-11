using UnityEngine;

namespace Enemies.Movement
{
    public class UfoMovement : EnemyMovement
    {
        public float rotationSpeed = 100; 

        protected override void Update()
        {
            if (target != null)
            {
                Vector3 targetDirection = target.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, targetDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            
            transform.Translate(Vector3.up * (MovementSpeed * Time.deltaTime));
        }
    }
}
