using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;

    [SerializeField]
    bool Gotop = false;
    [SerializeField]
    bool Gobottom = true;
    //[SerializeField]
    //bool setTime = false;
    [SerializeField]
    float currTime;
    [SerializeField]
    bool changeStatus;
    IEnumerator delayTime()
    {
        while (changeStatus == false)
        {
            yield return new WaitForSeconds(10);
            changeStatus = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If at the bottom then move up
        if(Gotop && this.transform.position.y < startPos.y)
        {
            this.transform.position = (new Vector3(this.transform.position.x, this.transform.position.y + 1 * Time.deltaTime, this.transform.position.z));
        }
        // if at the top then move down
        if(Gobottom && this.transform.position.y > endPos.y) 
        { 
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1 * Time.deltaTime, this.transform.position.z);
        }
        // If at the top then start a delay
        if (this.transform.position.y >= startPos.y && Gotop == true)
        {
            StartCoroutine("delayTime");
            if (changeStatus == true)
            {
                Gobottom = true;
                Gotop = false;
                changeStatus = false;

            }
        }
        // If at the bottom then start a delay
        if (this.transform.position.y <= endPos.y && Gobottom == true)
        {
            StartCoroutine("delayTime");
            if(changeStatus == true)
            {
                Gobottom = false;
                Gotop = true;
                changeStatus = false;

            }
        }
    }
}
