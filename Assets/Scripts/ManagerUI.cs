using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    #region Singleton

    public static ManagerUI instance; //Instância a classe para acesso global

    private void Awake() //Método chamado ao inicializar o objeto
    {
        if (instance == null) //Verifica se já existe uma instância
        {
            instance = this;
        }
        else if (instance != this) //Define esta como a instância ativa
        {
            Destroy(gameObject); //Destroi objetos duplicados para manter apenas um ManagerUI ativo
        }

        timerText = GameObject.Find("Timer Text").GetComponent<TextMeshProUGUI>();
    }

    #endregion

    TextMeshProUGUI timerText; //Referência o texto que exibe o temporizador
    // Atualiza o texto do temporizador na UI com o valor fornecido
    public void UpdateTimerText(float value)
    {
        timerText.text = value.ToString("0.0"); 
    }

}
