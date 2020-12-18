using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreenBarSystem : MonoBehaviour {

    public GameObject bar;
    public bool backGroundImageAndLoop;
    public float LoopTime;
    public GameObject[] backgroundImages;

    private MouseFollow mouseFollow;
    
    public void loadingScreen ()
    {
        this.gameObject.SetActive(true);
        //導蟲取得
        mouseFollow = GameObject.Find("ScoutfliesCanvas").GetComponent<MouseFollow>();
        mouseFollow.mouseFlag = false;
    }

    private void Start()
    {
        
        if (backGroundImageAndLoop)
        {
            StartCoroutine(transitionImage());
        }
    }

    private IEnumerator transitionImage()
    {
        while (true)
        {
            for (int j = 0; j < backgroundImages.Length; j++)
            {
                backgroundImages[j].SetActive(false);
            }

            backgroundImages[Random.Range(0, backgroundImages.Length)].SetActive(true);
            yield return new WaitForSeconds(LoopTime);
        }
    }
}
