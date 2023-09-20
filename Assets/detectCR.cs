using Vuforia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EditorTools;


public class targetsCR : DefaultObserverEventHandler
 
{

    public targetsCR[] otherTrackers; //trackers que se van a observar

    public GameObject assetCR15; //gmOb que se mostrara cuando se cumplan las condiciones
    public GameObject test = null;


    // Update se llama en cada frame, revisa si los trackers estan activos y si es asi activa el gmOb
    protected virtual void Update() 
    {
        checkTrackers();
    }

    public void checkTrackers()
    {
    bool allTracked = true;

    foreach (targetsCR tracker in otherTrackers)
    {
        if (tracker.mObserverBehaviour.TargetStatus.Status != Status.TRACKED) {
        allTracked = false;
        break;
        }
    }

    if(allTracked) {
        //Debug.Log("All trackers are tracked");
        if (test == null)
        {
            test = Instantiate(assetCR15, new Vector3(-0.03f, -0.05f, -0.0037f), Quaternion.identity);
            test.SetActive(true);
            // assetCR15.SetActive(true);
            // assetCR15.transform.position = new Vector3(-0.03f, -0.00250f, -0.00370f);
        }
    } else {
        test.SetActive(false); 
    }
    }

}

