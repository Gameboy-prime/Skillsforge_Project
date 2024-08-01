using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLeanTween : MonoBehaviour
{
    
    [SerializeField] GameObject[] gameName;
    [SerializeField] GameObject arena;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject startImage;
    [SerializeField] GameObject settingButton;

    [SerializeField] GameObject settingBox;
    [SerializeField] GameObject audioBox;
    [SerializeField] GameObject videoBox;
    [SerializeField] GameObject creditBox;
    [SerializeField] GameObject arenaBox;
    [SerializeField] GameObject creditNameBox;



   
    // Start is called before the first frame update
    void Start()
    {

        
        Time.timeScale = 1;

        if(gameName != null)
        {
            StartCoroutine(AnimateGameName());
        }

        if(arena != null)
        {
            AnimateArena();
        }
        if(shop != null)
        {
            AnimateShop();
        }
        
        
        if(settingButton!= null)
        {
            AnimateSettingButton();
        }

        if(creditNameBox != null)
        {
            AnimateCredits();
        }

        



    }

    
    

    IEnumerator AnimateGameName()
    {
        
        foreach (GameObject letter in gameName)
        {
           
            yield return new WaitForSeconds(.06f);
            
            LeanTween.rotateAroundLocal(letter, Vector3.forward, 360, 1);

        }
    }

    public void AnimateArena()
    {
        LeanTween.scale(arena, new Vector3(1.3f, 1.3f, 1.3f), 1).setEaseInCubic().setLoopPingPong().setDelay(2);
    }

    public void AnimateShop()
    {
        LeanTween.scale(shop, new Vector3(1.1f, 1.1f, 1.1f), 1).setDelay(4).setLoopPingPong().setEaseInExpo();
    }
    public void AnimateStartImage()
    {
        LeanTween.scale(startImage, new Vector3(1.1f, 1.1f, 1.1f), 1).setEaseInOutQuad().setLoopType(LeanTweenType.easeInQuad);
    }





    public void AnimateOpenSetting()
    {
        settingBox.transform.localPosition = new Vector3(0, -Screen.height);
        LeanTween.scale(settingBox, Vector3.zero, 0);
        LeanTween.moveLocalY(settingBox, 0, .4f);
        LeanTween.scale(settingBox, new Vector3(1, 1, 1), .4f);
       
    }

    public void AnimateCloseSetting()
    {
        LeanTween.moveLocalY(settingBox, -Screen.height, .4f);
        LeanTween.scale(settingBox, Vector3.zero, .4f);
    }

  
    public void AnimateOpenBox( GameObject boxObject)
    {
        boxObject.transform.localPosition = new Vector3(0, -Screen.height);
        LeanTween.scale(boxObject, Vector3.zero, 0).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(boxObject, 0, .4f).setIgnoreTimeScale(true);
        LeanTween.scale(boxObject, new Vector3(1, 1, 1), .4f).setIgnoreTimeScale(true);
    }

    IEnumerator AnimatingCloseBox( GameObject boxObject )
    {
        LeanTween.moveLocalY(boxObject, -Screen.height, .4f).setIgnoreTimeScale(true);
        LeanTween.scale(boxObject, Vector3.zero, .4f).setIgnoreTimeScale(true);
        yield return new WaitForSeconds(.4f);
        boxObject.SetActive(false);

    }

    public void AnimateCloseBox(GameObject boxObject)
    {
        StartCoroutine(AnimatingCloseBox(boxObject));
        
    }
    public void AnimateGameObjectOnHoverEnter(GameObject ObjectToAnimate)
    {
        LeanTween.scale(ObjectToAnimate, new Vector3(1.1f,1.1f,1.1f), .4f).setIgnoreTimeScale(true);

    }

    public void AnimateGameObjectOnHoverExit(GameObject ObjectToAnimate)
    {
        LeanTween.scale(ObjectToAnimate, new Vector3(1, 1, 1), .4f).setIgnoreTimeScale(true);

    }

    public void AnimateSettingButton()
    {
        LeanTween.rotateAroundLocal(settingButton, Vector3.forward, 360, 2).setLoopType(LeanTweenType.linear);
    }

    public void AnimateCredits()
    {
        LeanTween.moveLocalX(creditNameBox, -1840, 15).setLoopType(LeanTweenType.linear).setDelay(2);
    }


}
