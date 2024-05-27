using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class HolyArk : MonoBehaviour
{
    
    private string _playerTag = "Player";
    public InventoryItem item;
    public UnityEvent onEventCall;
    public GameObject notification;
    private bool shouldNotify = true;
    public string message;

    //Ark
    public ParticleSystem waterRiseParticle;
    public Transform river;
    public GameObject holyArk;
    public Transform arkSpawnPoint;
    public float duration;
    public AudioSource audioOne, audioTwo;

    //Gate
    public Transform gate;
    public BoxCollider2D collider2D;

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag(_playerTag))
        {
            
            item.isUsable = true;
            if(shouldNotify)
                notification.SetActive(true);
            item.itemAction = onEventCall;
            notification.GetComponent<InventoryNotification>().InitizlizeNotification(message);
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag(_playerTag))
        {
            notification.GetComponent<FadeInOut>().Hide();
            item.isUsable = false;
        }
    }
    void DisableInventory()
    {
        // Assuming the child object with FadeInOut component has a unique name
        GameObject childObject = GameObject.Find("Inventory_Mask");

        if (childObject != null)
        {
            FadeInOut fadeInOutComponent = childObject.GetComponent<FadeInOut>();
            fadeInOutComponent.Hide();
        }
        else
        {
            // Handle the scenario where the child object is not found (optional)
            Debug.LogError("Child object with FadeInOut not found!");
        }
        shouldNotify = false;
        notification.GetComponent<FadeInOut>().Hide();
    }
    public void PlaceArk()
    {
        DisableInventory();
        GameObject ark = Instantiate(holyArk,arkSpawnPoint.position, Quaternion.identity);
        ark.GetComponent<Animator>().Play("ArkAnimation");
        this.Wait(2f, () => {
            audioOne.Play();
            waterRiseParticle.Play();
            river.DOMoveY(4.5f, duration).OnComplete(() => { 
                audioOne.Stop();
                this.Wait(0.5f, () => { waterRiseParticle.Stop(); audioOne.Stop(); });
            });
            
            collider2D.enabled = false;
            });       
    }

    public void OpenGate()
    {
        DisableInventory();
        gate.DORotate(Vector3.zero, duration);
        collider2D.enabled = false;
    }
    public void BreakStoneWall()
    {
        StoneThrower stoneThrower = FindObjectOfType<StoneThrower>();
        stoneThrower.ThrowStones();
        DisableInventory(); 
    }
}
