using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed = 10f; // Defina a velocidade para um valor positivo
    [SerializeField] float damage = 10f;

    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        Destroy(gameObject, 10);  // Destr�i a bala ap�s 10 segundos para n�o ficar na cena indefinidamente
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Aplica velocidade ao proj�til na dire��o que ele est� apontando (transform.up)
        rigidbody2D.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        DestroyProjectile();
        if (damageable != null && !collision.CompareTag(transform.tag))
        {
            // Aplica dano ao objeto atingido se ele implementar IDamageable
            damageable.TakeDamage(damage);
           
        }
    }

    protected virtual void DestroyProjectile()
    {
        Destroy(gameObject); // Destr�i o proj�til ap�s a colis�o
    }
}
