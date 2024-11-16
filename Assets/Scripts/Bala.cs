using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed = 10f; //Velocidade da bala
    [SerializeField] float damage = 10f; //Dano da bala

    Rigidbody2D rigidbody2D;

    void Start() //Metodo que � chamado quando dispar� a bala
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // Obt�m o componente Rigidbody2D anexado ao objeto
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic; // Define o tipo de corpo do Rigidbody2D como cinem�tico
        Destroy(gameObject, 10);  // Destr�i a bala ap�s 10 segundos para n�o ficar na cena indefinidamente
    }

    void Update()
    {

        Movement(); // Chama o m�todo respons�vel pelo movimento da bala.
    }

    void Movement()
    {
        // Aplica velocidade ao proj�til na dire��o que ele est� apontando (transform.up)
        rigidbody2D.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)  // M�todo chamado automaticamente ao detectar uma colis�o com outro objeto.
    {
        IDamageable damageable = collision.GetComponent<IDamageable>(); //Obtem a interface IDamageable do objeto colidido
        DestroyProjectile();   // Destr�i o proj�til independentemente do que ele atingir.
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
