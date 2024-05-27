using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

public class HiddenPassage : MonoBehaviour
{

    [SerializeField] private float delay = 3;
    public GameObject PopUp;

    private bool canActivate = false;
    private bool finish = false;

    public UnityEvent action;

    private Transform player;
    public Transform destination;

    public GameObject fadePanel;
    public string panel_Text;

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
            player = obj.transform;
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
    public void TeleportAction()
    {
        StartCoroutine(Teleport());
    }
    IEnumerator Teleport()
    {
        fadePanel.SetActive(true);
        fadePanel.GetComponent<RectTransform>().DOAnchorPosY(0, 0.2f);
        fadePanel.GetComponentInChildren<TMP_Text>().text = panel_Text;
        yield return new WaitForSeconds(1);
        player.position = destination.transform.position;
        yield return new WaitForSeconds(1f);
        fadePanel.GetComponent<RectTransform>().DOAnchorPosY(1600, 0.5f);
    }
    
}
