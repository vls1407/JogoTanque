using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed, damage;

    Rigidbody2D rigidbody2D;

    public float Damage
    {
        get => damage;
        set
        {
            if (damage == 0)
            {
                damage = value;
            }
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        Destroy(gameObject, 10);  // Projétil se destrói após 10 segundos, ajustável conforme necessário
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // O projétil se move na direção em que a torreta do tanque está apontando (transform.up)
        rigidbody2D.velocity = transform.up * speed;
    }

    protected virtual void DestroyProjectile()
    {
        ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            speed = 0;
            Destroy(gameObject, particleSystem.main.startLifetime.constant); // Usa a propriedade atualizada para pegar a duração correta
        }
        else
        {
            Destroy(gameObject); // Destrói imediatamente se não houver sistema de partículas
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null && !collision.CompareTag(transform.tag))
        {
            // Se o objeto que colidiu implementa IDamageable e não tem a mesma tag, causamos dano
            damageable.TakeDamage(damage);
            DestroyProjectile();
        }
        else if (collision.CompareTag("Wall") || collision.CompareTag("Obstacle"))
        {
            // Caso colida com obstáculos ou paredes (tags podem ser ajustadas conforme seu projeto)
            DestroyProjectile();
        }
    }
}
