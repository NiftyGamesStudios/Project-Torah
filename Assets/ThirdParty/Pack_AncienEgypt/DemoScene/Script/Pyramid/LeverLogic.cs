using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class LeverLogic : MonoBehaviour {

	public Renderer leverLight;
	public Light spotLight;
	public Animator LeverAnimator;
	private Transform Player;
	[SerializeField]private float delay = 3;
	public GameObject PopUp;

	private bool canActivate = false;
	private bool finish = false;

	public UnityEvent action;

	void Enable(){

		Player = GameObject.FindGameObjectWithTag("Player").transform;
		if(!finish)
			canActivate= true;
	}

	void OnBecameInvisible(){

		canActivate = false;
	}

	void LateUpdate(){
		if(canActivate && Input.GetKeyUp(KeyCode.E)){
			Activate();
		}

	}
	void OnTriggerEnter2D(Collider2D obj){

		if (obj.CompareTag("Player"))
		{
            Show();
            Player = obj.transform;           
        }			
	}

	void Activate(){
		canActivate = false;
		if(!canActivate){
			finish = true;
			LeverAnimator.SetTrigger("ActivateLever");
			leverLight.material.color = Color.green;
			spotLight.color = Color.green;
			this.Wait(delay, () =>
			{
				action.Invoke();
			});
		
			//StatueAnimatorToEnable.SetTrigger("ActivateStatue");

			this.GetComponent<AudioSource>().Play();
			
		}
	}

	void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
			Hide();
	}


	void Show(){
        canActivate = true;
        PopUp.SetActive(canActivate);

    }

	void Hide(){
        canActivate = false;
        PopUp.SetActive(canActivate);

    }

}