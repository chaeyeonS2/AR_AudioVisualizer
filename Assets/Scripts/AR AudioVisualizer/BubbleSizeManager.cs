using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using TMPro;
public class BubbleSizeManager : MonoBehaviour
{
    public AudioSource source;
    public AudioLoudnessDetection detector;
    public float loudnessSensibility;
    public float threshold = 0.1f;
    public ParticleSystem ps;
    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }

    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        if (loudness < threshold)
            loudness = 0;

        ps.startSize = loudness;
        Text.text = "Volume : "+(loudness*100).ToString();

    }

}
