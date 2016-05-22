using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originRotation;
    public float shake_decay;
    public float shake_intensity;

    void Update()
    {
        if (shake_intensity > 0)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shake_intensity;
            transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
                originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,
                originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
                originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2f);
            shake_intensity -= shake_decay;
        }
        if (GlobalVariable.Instance.shake)
        {
            Shake();
            GlobalVariable.Instance.shake = false;
        }
    }

    public void Shake()
    {
        originalPosition = transform.position;
        originRotation = transform.rotation;
        shake_intensity = .05f;
        shake_decay = 0.002f;
    }

}
