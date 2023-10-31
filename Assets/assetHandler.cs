using Vuforia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EditorTools;

public class assetHandler : DefaultObserverEventHandler
{

    public GameObject[] assetsPrefabs;
    private List<GameObject> pooledAssets;

    protected override void Start() {
        
        // Run DefaultObserverEventHandler Start()
        base.Start();

        // Pool the assets
        pooledAssets = new List<GameObject>();
        
        foreach (GameObject assetPrefab in assetsPrefabs) {
            GameObject asset = Instantiate(assetPrefab);
            // Remove Clone from name
            asset.name = assetPrefab.name;

            asset.transform.SetParent(transform);
            asset.transform.localPosition= new Vector3(0, 0, 0);
            asset.transform.localScale = Vector3.one;
            asset.transform.Rotate(0, 180, 0);

            asset.SetActive(false);
            pooledAssets.Add(asset);
        }
    }


    private GameObject searchAsset(string nameAsset) {

        foreach (GameObject poolAsset in pooledAssets){
            if (poolAsset.name == nameAsset) {
                return poolAsset;
            }
        }

        return null;

    }



    private void handleAssetOnTarget(GameObject asset) {
        asset.transform.SetParent(transform);
        asset.transform.localPosition= new Vector3(0, 0, 0);
        asset.transform.localScale = Vector3.one;
    }

    public void displayAsset(int num) {

        GameObject assetCase;
        Status status = this.mObserverBehaviour.TargetStatus.Status;

         // Switch para Costa Rica
        switch (num) 
        {
            case 111:
            assetCase = searchAsset("costarica+verano+5");

            if (status == Status.TRACKED) {
                //handleAssetOnTarget(assetCase);
                assetCase.SetActive(true);
            }
            else {
                assetCase.SetActive(false);
            }
        
            
            // display CR verano angulo 5
            break;

            case 121:
            // display CR invierno angulo 5
            break;

            case 211:
            // display CR verano angulo 15
            break;

            case 221:
            // display CR invierno angulo 15
            break;

            case 311:
            // display CR verano angulo 30
            break;

            case 321:
            // display CR invierno angulo 30
            break;

            case 411:
            // display CR verano angulo 35
            break;

            case 421:
            // display CR invierno angulo 35
            break;

            case 511:

            // display CR invierno angulo 90
            break;

            case 521:

            assetCase = searchAsset("costarica+invierno+90");

            if (status == Status.TRACKED) {
                //handleAssetOnTarget(assetCase);
                assetCase.SetActive(true);
            }
            else {
                assetCase.SetActive(false);
            }
            // dispaly CR invierno angulo 90
            break;

        }

        // Switch para Chile
        switch (num)
        {
            case 112:
            // display CHILE verano 5
            break;

            case 122:
            // display CHILE invierno 5
            break;

            case 212:
            // display CHILE verano 15
            break;

            case 222:
            // display CHILE invierno 15
            break;

            case 312:
            // display CHILE verano 30
            break;

            case 322:
            // display CHILE invierno 30
            break;

            case 412:
            // display CHILE verano 35
            break;

            case 422:
            // display CHILE invierno 35
            break;

            case 512:
            // display CHILE verano 90
            break;

            case 522:
            // display CHILE invierno 90
            break;
        }

        // Switch para Alemania
        switch (num)
        {
            case 113:
            // display GER verano 5
            break;

            case 123:
            // display GER invierno 5
            break;

            case 213:
            // display GER verano 15
            break;

            case 223:
            // display GER invierno 15
            break;

            case 313:
            // display GER verano 30
            break;

            case 323:
            // display GER invierno 30
            break;

            case 413:
            // display GER verano 35
            break;

            case 423:
            // display GER invierno 35
            break;

            case 513:
            // display GER verano 90
            break;

            case 523:
            // display GER invierno 90
            break;
        }



    }

}