using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int bombId;
    [SerializeField] private float radius;
    [SerializeField] private float damages = 100f;
    [SerializeField] private float impulseForce = 50f;
    [SerializeField] private AnimationCurve fallOff;

    public void Detonate(int detonatorId)
    {
        if(detonatorId == bombId)
        {
            Collider2D[] tabTarget = Physics2D.OverlapCircleAll(transform.position, radius);

            foreach (Collider2D target in tabTarget)
            {
                var distance = Vector2.Distance(target.transform.position, transform.position);
                var ratio = 1 - (distance / radius);
                var multiplier = fallOff.Evaluate(ratio);

                var direction = (target.transform.position - transform.position).normalized;
                Rigidbody2D rb = target.attachedRigidbody;
                if (rb != null) {
                    rb.AddForceAtPosition(direction * impulseForce * multiplier, transform.position, ForceMode2D.Impulse);
                }

                target.SendMessage("takeDamage", damages * multiplier, SendMessageOptions.DontRequireReceiver);
            }

            gameObject.SendMessage("DoDie");
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.15f);
        Gizmos.DrawSphere(transform.position, radius);
    }
}
