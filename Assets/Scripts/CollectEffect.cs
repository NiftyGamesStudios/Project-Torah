using UnityEngine;
using DG.Tweening;

public class CollectEffect : MonoBehaviour
{
    public float popDuration = 1f;
    public float stayDuration = 1f;
    public float flyDuration = 1.5f;
    public Vector3 targetPositionOffset = new Vector3(2f, 2f, 0f); // Adjust as needed
    public Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);
    public float moveForwardDistance = 1.5f;
    public float scaleUpDownDuration = 0.3f;
    public float moveUpDownAmount = 0.2f;
    public float moveLeftRightAmount = 0.2f;

    private void Start()
    {
        // Scale up and move forward
        transform.localScale = Vector3.zero;
        transform.DOScale(targetScale, popDuration).SetEase(Ease.OutBounce);
        transform.DOMoveX(transform.position.x + moveForwardDistance, popDuration).SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                // Smooth scale up and down, and move slightly
                transform.DOScale(targetScale * 1.2f, scaleUpDownDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
                transform.DOMoveY(transform.position.y + moveUpDownAmount, scaleUpDownDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
                transform.DOMoveX(transform.position.x + moveLeftRightAmount, scaleUpDownDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
                // Stay for a while
                DOVirtual.DelayedCall(stayDuration, () =>
                {
                    // Fly to the upper-right corner
                    Vector3 targetPosition = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f)) + targetPositionOffset;
                    transform.DOMove(targetPosition, flyDuration).SetEase(Ease.InOutSine)
                        .OnComplete(() =>
                        {
                            // Object collected and stored, you can do further actions here
                            Destroy(gameObject);
                        });
                });
            });

       /* */
    }
}
