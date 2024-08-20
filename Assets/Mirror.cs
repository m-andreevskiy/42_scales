using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Mirror : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    public Vector3 minScale;
    public Vector3 maxScale;
    public bool repeatFlag;
    public float scalingSpeed;
    public float scalingDuration;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        while (repeatFlag)
        {
            yield return RepeatLerping(minScale, maxScale, scalingDuration);
            yield return RepeatLerping(maxScale, minScale, scalingDuration);
        }

    }

    IEnumerator RepeatLerping(Vector3 startScalem, Vector3 endScale, float time)
    {
        float t = 0.0f;
        float rate = (1f / time) * scalingSpeed;
        while (t < 1f)
        {
            t += Time.deltaTime * rate;
            transform.localScale =  Vector3.Lerp(startScalem, endScale, t);
            transform.localScale = new Vector3(player.velocityOrientationMultiplier * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            yield return null;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
