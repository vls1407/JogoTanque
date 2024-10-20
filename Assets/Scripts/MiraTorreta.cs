using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraTorreta : MonoBehaviour
{
    [SerializeField] private Transform turret; // A refer�ncia � torreta do tanque
    [SerializeField] private Camera mainCamera; // Refer�ncia � c�mera principal do jogo

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Se n�o for atribu�da, tenta pegar a c�mera principal
        }
    }

    void Update()
    {
        RotateTurret();
    }

    void RotateTurret()
    {
        // Pega a posi��o do mouse em coordenadas de tela e converte para o mundo
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Calcula a dire��o para a qual a torreta deve apontar
        Vector3 direction = worldPosition - turret.position;
        direction.z = 0; // Como � um jogo 2D, garantimos que o eixo Z permane�a inalterado

        // Calcula o �ngulo de rota��o com base na dire��o e aplica na rota��o da torreta
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        turret.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // Ajusta para a rota��o correta
    }
}

