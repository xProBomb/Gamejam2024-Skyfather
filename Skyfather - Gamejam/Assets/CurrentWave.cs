using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentWave : MonoBehaviour
{
    void Update()
    {
        // get the text component of TextMeshPro attached to this GameObject
        TextMeshProUGUI waveText = GetComponent<TextMeshProUGUI>();
        // get the WaveSpawner component from the scene it is tagged with "WaveSpawner"
        WaveSpawner waveSpawner = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveSpawner>();
        // update the text to show the current wave count
        waveText.text = waveSpawner.GetWaveCount().ToString();
        
    }
}
