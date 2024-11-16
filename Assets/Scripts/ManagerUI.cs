using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    #region Singleton

    public static ManagerUI instance; //Inst�ncia a classe para acesso global

    private void Awake() //M�todo chamado ao inicializar o objeto
    {
        if (instance == null) //Verifica se j� existe uma inst�ncia
        {
            instance = this;
        }
        else if (instance != this) //Define esta como a inst�ncia ativa
        {
            Destroy(gameObject); //Destroi objetos duplicados para manter apenas um ManagerUI ativo
        }

        timerText = GameObject.Find("Timer Text").GetComponent<TextMeshProUGUI>();
    }

    #endregion

    TextMeshProUGUI timerText; //Refer�ncia o texto que exibe o temporizador
    // Atualiza o texto do temporizador na UI com o valor fornecido
    public void UpdateTimerText(float value)
    {
        timerText.text = value.ToString("0.0"); 
    }

}
