using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float thrust;
    [SerializeField] private float knockTime;
    [SerializeField] private string otherTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object's tag matches the expected tag and if it is a trigger
        if (!string.IsNullOrEmpty(otherTag) && other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            // Try to get the Rigidbody2D component from the parent
            Rigidbody2D hit = other.GetComponentInParent<Rigidbody2D>();
            if (hit != null)
            {
                // Apply knockback force using DOTween
                Vector3 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.DOMove(hit.transform.position + difference, knockTime);

                // Check if it's an enemy and handle the enemy knockback
                Enemy enemy = other.GetComponent<Enemy>();
                if (enemy != null && other.gameObject.CompareTag("enemy"))
                {
                    enemy.currentState = EnemyState.stagger;
                    enemy.Knock(hit, knockTime);
                }

                // Handle player knockback
                PlayerMovement player = other.GetComponentInParent<PlayerMovement>();
                if (player != null && player.currentState != PlayerState.stagger)
                {
                    player.currentState = PlayerState.stagger;
                    player.Knock(knockTime);
                }
            }
            else
            {
                Debug.LogWarning("Rigidbody2D not found on parent of the collided object.");
            }
        }
        else
        {
            Debug.LogWarning("Tag mismatch or object is not a trigger.");
        }
    }
}
