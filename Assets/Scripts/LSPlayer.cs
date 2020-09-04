using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{

    public MapPoint currentPoint;
    public float moveSpeed = 10f;

    private bool levelLoading;

    public LSManager theManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, currentPoint.transform.position) < 0.1f && !levelLoading)
        { 

        if(Input.GetAxisRaw("Horizontal") > .5f)
        {
            if(currentPoint.right != null)
            {
                AudioManager.instance.PlaySFX(5);
                SetNextPoint(currentPoint.right);
            }
        }
        if (Input.GetAxisRaw("Horizontal") < -.5f)
        {
            if (currentPoint.left != null)
            {
                    AudioManager.instance.PlaySFX(5); 
                    SetNextPoint(currentPoint.left);
            }
        }
        if (Input.GetAxisRaw("Vertical") > .5f)
        {
            if (currentPoint.up != null)
            {
                    AudioManager.instance.PlaySFX(5); 
                    SetNextPoint(currentPoint.up);
            }
        }
        if (Input.GetAxisRaw("Vertical") < -.5f)
        {
            if (currentPoint.down != null)
            {
                    AudioManager.instance.PlaySFX(5); 
                    SetNextPoint(currentPoint.down);
            }
        }

        if(currentPoint.isLevel && currentPoint.levelToLoad != "" && !currentPoint.isLocked)
            {
                LSUIController.instance.ShowInfo(currentPoint);
                if(Input.GetButtonDown("Jump"))
                {
                    AudioManager.instance.PlaySFX(4);
                    levelLoading = true;
                    theManager.LoadLevel();
                }
            }
        }
    }

    public void SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;
        LSUIController.instance.HideInfo();
    }
}
