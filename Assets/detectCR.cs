using Vuforia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EditorTools;

public class targetsCR : DefaultObserverEventHandler
{
    public targetsCR[] allTrackers; //trackers que se van a observar

    public GameObject[] assets; //gmOb que se mostrara cuando se cumplan las condiciones

    public int debugNumCase;


    private Dictionary<string, int> markerValues = new Dictionary<string, int>{
        {"marcador-CR", 1},
        {"marcador-CHILE", 2},
        {"marcador-GER", 3},
        {"marcador-verano", 10},
        {"marcador-invierno", 20},
        {"marcador-5", 100},
        {"marcador-15", 200},
        {"marcador-30", 300},
        {"marcador-35", 400},
        {"marcador-90", 500}
    };

    // Update se llama en cada frame, revisa si los trackers estan activos y si es asi activa el gmOb
    protected virtual void Update(){
        checkTrackers();
    }

    public void checkTrackers(){
        int numCase = 0;

        foreach (targetsCR tracker in allTrackers){   
            // Obtiene el nombre del target (nombre registrado en la base de datos)
            var name = tracker.mObserverBehaviour.TargetName;

            // Obtiene el status actual del target
            Status status = tracker.mObserverBehaviour.TargetStatus.Status;

            if (markerValues.ContainsKey(name) && status == Status.TRACKED){
                numCase += markerValues[name];
            }
        }
        // Se pasa el numero segun los marcadores detectados para mostrar el asset correspondiente
        debugNumCase = numCase;
        Debug.Log("Numero de caso: " + numCase);
        displayAsset(numCase);
    }

    public void displayAsset(int num)
    {
        foreach (GameObject asset in assets){
            asset.SetActive(false);
        }

        // Switch para Costa Rica
        switch (num) 
        {
            case 111:
            assets[0].SetActive(true);
            assets[0].transform.position = new Vector3(0, 0.051f, 0.127f);
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
            // dispaly CR verano angulo 90
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
            // display CHILE verano 90
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

