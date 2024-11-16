using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed = 10f; //Velocidade da bala
    [SerializeField] float damage = 10f; //Dano da bala

    Rigidbody2D rigidbody2D;

    void Start() //Metodo que é chamado quando dispará a bala
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // Obtém o componente Rigidbody2D anexado ao objeto
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic; // Define o tipo de corpo do Rigidbody2D como cinemático
        Destroy(gameObject, 10);  // Destrói a bala após 10 segundos para não ficar na cena indefinidamente
    }

    void Update()
    {

        Movement(); // Chama o método responsável pelo movimento da bala.
    }

    void Movement()
    {
        // Aplica velocidade ao projétil na direção que ele está apontando (transform.up)
        rigidbody2D.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)  // Método chamado automaticamente ao detectar uma colisão com outro objeto.
    {
        IDamageable damageable = collision.GetComponent<IDamageable>(); //Obtem a interface IDamageable do objeto colidido
        DestroyProjectile();   // Destrói o projétil independentemente do que ele atingir.
        if (damageable != null && !collision.CompareTag(transform.tag))
        {
            // Aplica dano ao objeto atingido se ele implementar IDamageable
            damageable.TakeDamage(damage);
           
        }
    }

    protected virtual void DestroyProjectile()
    {
        Destroy(gameObject); // Destrói o projétil após a colisão
    }
}
