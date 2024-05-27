using MoreMountains.CorgiEngine;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image[] buttonImages;
    public Sprite[] images;
    public int currentScreen;

    [Tooltip("the MMFeedback to play when the item gets picked")]
    public MMFeedbacks PickFeedbacks;

    public GameObject keybaordScreen;
    public GameObject[] keyboardPhases;

    public GameObject touchScreen;
    public GameObject[] touchPhases;

    public GameObject Character;
    public bool GetInput = false;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Tut_Level1")
            InitializeUI();

        this.Character = FindObjectOfType<CorgiController>().gameObject;
    }
    public void GetInputSetter()
    {
        GetInput = true;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Tut_Level1")
        {
            CheckKeyboardInput();
        }
        else
        {
            // Handle other input methods or platforms
        }
    }

    private void InitializeUI()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.OSXPlayer:
                SetControlScheme(touchScreen: false, keybaordScreen: true);
                break;
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                SetControlScheme(touchScreen: true, keybaordScreen: false);
                break;
            default:
                // Handle other platforms or fall back to a generic scheme
                break;
        }
    }

    private void SetControlScheme(bool touchScreen, bool keybaordScreen)
    {
        this.touchScreen.SetActive(touchScreen);
        this.keybaordScreen.SetActive(keybaordScreen);
    }
    private int actionScore = 0;
    private bool firstActionDone = false;
    int aScore = 0;
    int dScore = 0;
    private void CheckKeyboardInput()
    {
        if (GetInput)
        {
            if (!firstActionDone)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    ChangeButtonImage(0);
                    aScore = 1;
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    ChangeButtonImage(1);
                    dScore = 1;
                }
            }
            if (aScore +dScore >=2)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    ChangeButtonImage(2);
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    {
                        ChangeButtonImage(4);
                        ChangeButtonImage(3);
                    }
                }

            }
        }
    }

        private void ChangeButtonImage(int index)
    {
        if (buttonImages[index].sprite == images[0])
        {
           // Debug.Log(!keyboardPhases[1].activeSelf + "; " + (!touchPhases[1].activeSelf));
            if (index == 2 && (!keyboardPhases[1].activeSelf && !touchPhases[1].activeSelf))
                return;
            
            else if (index == 3 && (!keyboardPhases[2].activeSelf && !touchPhases[2].activeSelf))
                return;
            if(index == 0)
            {
                buttonImages[0].sprite = images[1];
                buttonImages[5].sprite = images[1];
            }
            else if (index == 1)
            {
                buttonImages[1].sprite = images[1];
                buttonImages[6].sprite = images[1];
            }
            else if (index == 4)
            {
                buttonImages[4].sprite = images[1];
                buttonImages[7].sprite = images[1];
            }
            buttonImages[index].sprite = images[1];
            Effects();
            if (buttonImages[0].sprite == images[1] && buttonImages[1].sprite == images[1])
            {
                ChangeLayoutScreen(0, false);
                FindObjectOfType<DialogueTrigger>().TriggerDialogue(1);
            }
            if (buttonImages[2].sprite == images[1])
            {
                ChangeLayoutScreen(1,false);
                FindObjectOfType<DialogueTrigger>().TriggerDialogue(3);
            }
            if (buttonImages[3].sprite == images[1] && buttonImages[4].sprite == images[1])
            {
                ChangeLayoutScreen(2, false);
                FindObjectOfType<DialogueTrigger>().TriggerDialogue(5);
            }
        }       
    }
    public void ChangeLayoutScreen(int index,bool state, float delay = 0.3f)
    {
        this.Wait(delay, () =>
        {
            if (keybaordScreen.activeSelf)
            {
                keyboardPhases[index].SetActive(state);
            }
            else
            {
                touchPhases[index].SetActive(state);
            }
        });
    }

    public void SecondPhase()
    {
        ChangeLayoutScreen(1, true,0.1f);
    }
    public void ThirdPhase()
    {
        ChangeLayoutScreen(2, true, 0.1f);                     
    }

    protected virtual void Effects()
    {
        PickFeedbacks?.PlayFeedbacks();
    }
}
