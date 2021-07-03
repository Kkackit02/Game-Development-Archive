using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScroll : MonoBehaviour
{
    public const float scrollSpeed = 1.2f;
    //스크롤할 속도를 상수로 지정해 줍니다.
    private Material thisMaterial;
    void Start()
    {
        thisMaterial = GetComponent<Renderer>().material;
    }
    [TestMethod]
    public void Play()
    {
        StartCoroutine(Routine());
    }
    [TestMethod]
    public void Stop()
    {StopAllCoroutines();

    }
    IEnumerator Routine()
    {
        Vector2 newOffset = thisMaterial.mainTextureOffset;

        while (true)
        {
            newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0);
            thisMaterial.mainTextureOffset = newOffset;
            yield return null;
        }

    }
    [TestMethod]
    public void estMethodAttribute()
    {
        Debug.Log(5%6);
            Debug.Log(5%(2+4)*3);
    }
    
    }
