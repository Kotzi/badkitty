using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class LightController : MonoBehaviour
{    
    public float intensity {
        get {
            return Light.intensity;
        }
    }

    private float DesiredIntensity = 0f;
    private float AdjustIntensityMaxTime = 1f;
    private float AdjustIntensityTimer = 0f;
    private Light2D Light;
    private System.Action CompletionAction = null;

    void Start()
    {
        Light = GetComponent<Light2D>(); 
        DesiredIntensity = Light.intensity;
    }

    void Update()
    {
        if(Light.intensity != DesiredIntensity)
        {
            AdjustIntensityTimer += Time.deltaTime;
            Light.intensity = Mathf.Lerp(Light.intensity, DesiredIntensity, AdjustIntensityTimer);
            if (Light.intensity == DesiredIntensity || AdjustIntensityTimer >= AdjustIntensityMaxTime)
            {
                Light.intensity = DesiredIntensity;
                if (CompletionAction != null)
                {
                    CompletionAction();
                    CompletionAction = null;
                }
                AdjustIntensityTimer = 0f;
            }
        }
    }

    public void SetIntensity(float intensity, float duration, System.Action completionAction) 
    {
        DesiredIntensity = intensity;
        CompletionAction = completionAction;
        AdjustIntensityMaxTime = duration;
        AdjustIntensityTimer = 0f;
    }
}