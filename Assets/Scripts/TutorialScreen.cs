using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    public GameObject TutorialPanel;
    public GameObject TutorialText1;
    public GameObject TutorialText2;

    // Start is called before the first frame update
    void Start()
    {
        TutorialPanel.SetActive(true);
        StartCoroutine(TutorialFade());
        StartCoroutine(TutorialTextFade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TutorialFade()
    {
        yield return new WaitForSeconds(12);
        TutorialPanel.SetActive(false);

    }
    private IEnumerator TutorialTextFade()
    {
        yield return new WaitForSeconds(7.5f);
        TutorialText1.SetActive(false);
        TutorialText2.SetActive(false);

    }


}
