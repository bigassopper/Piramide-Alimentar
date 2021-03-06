﻿using UnityEngine;

/// <summary>
/// Script que vai lidar com a ação de atirar
/// </summary>
public class ManagerDoTiro : MonoBehaviour
{
    [SerializeField] private Transform SpawnDoTiro;
    [SerializeField] private GameObject[] Tiro;
    [SerializeField] private AudioSource SomDoTiro;

    private Animator Anim;
    private float Timer;
    private int SpriteDoTiro = 0;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Jogo.Pausado) return;
        //Utilizo um timer pra limitar o player a atirar apenas a cada quarto de segundo.
        Timer += Time.deltaTime;

        //Quando o player utilizar algum dos inputs, o tiro vai ser spawnado e o timer resetado
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space) && Timer >= .75f){
            SomDoTiro.Play();
            Anim.SetTrigger("Atirar");
            SpriteDoTiro++;
            Timer = 0f;
        }

        //Ciclo progressivo das sprites do tiro
        if (SpriteDoTiro > 6) SpriteDoTiro = 0;
    }

    
    //Função de atirar que vai ser utilizada no fim da animação
    public void Atirar()
    {
        Instantiate(Tiro[SpriteDoTiro], SpawnDoTiro.position, Quaternion.identity);
    }
}
