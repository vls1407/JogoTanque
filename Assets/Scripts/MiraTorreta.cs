using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraTorreta : MonoBehaviour
{
  
 public Transform turret; // Torreta do tanque
 public float speed = 5f; // Velocidade de rotação da torreta

    private Vector2 mousePosition; // Posição do cursor do mouse

    void Update()
    {
        // Obtém a posição do cursor do mouse
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcula a direção da torreta para o cursor do mouse
        Vector2 direction = mousePosition - (Vector2)transform.position;

        // Rotação da torreta para seguir o cursor do mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // Rotação suave da torreta
        turret.rotation = Quaternion.Lerp(turret.rotation, rotation, speed * Time.deltaTime);
    }
}

