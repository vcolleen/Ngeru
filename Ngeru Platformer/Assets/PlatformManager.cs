using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] platforms;

    int numberOfPlatforms;

    int toggleTime;

    [SerializeField]
    float cycleTime = 5f;

    // Use this for initialization
    void Start()
    {
        numberOfPlatforms = platforms.Length;

        if (numberOfPlatforms - 1 == 0)
            toggleTime = 3;
        else
            toggleTime = numberOfPlatforms - 1;

        StartCoroutine(StartManagingPlatforms());
    }

    IEnumerator StartManagingPlatforms()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            StartCoroutine(ManagePlatform(platforms[i]));
            yield return new WaitForSeconds(cycleTime);
        }
    }

    IEnumerator ManagePlatform(GameObject platform)
    {
        while (true)
        {
            platform.SetActive(true);
            yield return new WaitForSeconds(cycleTime);
            platform.SetActive(false);
            yield return new WaitForSeconds(toggleTime * cycleTime);
        }
    }

}
