using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TutPhaseActivator : MonoBehaviour
{
    public string PlayerTag;
    private GameObject player;
    public UnityEvent my_Event;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerTag))
        {
            player = collision.gameObject;
            my_Event.Invoke();
            

        }
    }
    private void Start()
    {
        if(PlayerTag == "Player")
        {
            GameObject character = GameObject.FindGameObjectWithTag(PlayerTag);           
            if (SceneManager.GetActiveScene().buildIndex <= 4)
            {
                character.GetComponent<CharacterDash>().PermitAbility(false);
            }
            if (SceneManager.GetActiveScene().buildIndex <= 2)
            {
                character.GetComponent<CharacterDash>().PermitAbility(false);
                character.GetComponent<CharacterLadder>().PermitAbility(false);
            }
            if (SceneManager.GetActiveScene().buildIndex <= 1)
            {

                character.GetComponent<CharacterDash>().PermitAbility(false);
                character.GetComponent<CharacterLadder>().PermitAbility(false);
                character.GetComponent<CharacterHorizontalMovement>().PermitAbility(false);
                character.GetComponent<CharacterRun>().PermitAbility(false);
                character.GetComponent<CharacterJump>().PermitAbility(false);
            }
        }
        
       // characterMove.PermitAbility(true);
    }
    public void EnableCharacterMovement()
    {
        CharacterHorizontalMovement characterMove = GameObject.FindGameObjectWithTag(PlayerTag).GetComponent<CharacterHorizontalMovement>();
        if (characterMove != null)
        {
            characterMove.PermitAbility(true);
        }
    }
    public void EnableCharacterJump()
    {
        CharacterJump characterJump = player.GetComponent<CharacterJump>();
        if (characterJump != null)
        {
            characterJump.PermitAbility(true);
        }
    }
    public void EnableCharacterLadder()
    {
        CharacterLadder characterLadder = player.GetComponent<CharacterLadder>();
        if (characterLadder != null)
        {
            characterLadder.PermitAbility(true);
        }
    }
    public void EnableCharacterRun()
    {
        CharacterRun characterRun = player.GetComponent<CharacterRun>();
        if (characterRun != null)
        {
            characterRun.PermitAbility(true);
        }
    }
    public void EnableCharacterDash()
    {
        CharacterDash characterDash = player.GetComponent<CharacterDash>();
        if (characterDash != null)
        {
            characterDash.PermitAbility(true);
        }
    }
}
