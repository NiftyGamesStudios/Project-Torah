using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableChest : MonoBehaviour
{
    [SerializeField] private float delay = 3;
    public GameObject PopUp;

    private bool canActivate = false;
    private bool finish = false;

    public UnityEvent action;

    public GameObject fadePanel;
    public string panel_Text;

    public Transform chest_Lid;

    void Enable()
    {
        if (!finish)
            canActivate = true;
    }

    void LateUpdate()
    {
        if (canActivate && Input.GetKeyUp(KeyCode.E))
        {
            Activate();
        }

    }
    void OnTriggerEnter2D(Collider2D obj)
    {

        if (obj.CompareTag("Player"))
        {
            Show();
          //  player = obj.transform;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
            Hide();
    }
    void Activate()
    {
        canActivate = false;
        if (!canActivate)
        {
            finish = true;
            this.Wait(delay, () => action.Invoke());

            this.GetComponent<AudioSource>().Play();
        }
    }

    void Show()
    {
        canActivate = true;
        PopUp.SetActive(canActivate);
    }

    void Hide()
    {
        canActivate = false;
        PopUp.SetActive(canActivate);
    }
    public void OpenChest()
    {
        chest_Lid.DOLocalRotate(new Vector3(-100, 0, 0), 1,RotateMode.Fast).SetEase(Ease.InBounce);
    }
}
