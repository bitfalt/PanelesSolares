using Vuforia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EditorTools;

public class targetHandler : DefaultObserverEventHandler
{
    public targetHandler[] allTrackers; //trackers que se van a observar
    string targetName;
    bool check = false;

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

    protected override void Start() {

        // Run DefaultObserverEventHandler Start()
        base.Start();

        targetName = mObserverBehaviour.TargetName;

        if (targetName == "marcador-CR" || targetName == "marcador-GER" || targetName == "marcador-CHILE") {
            check = true;
        }
    }

    // Update se llama en cada frame, revisa si los trackers estan activos y si es asi activa el gmOb
    protected virtual void Update(){

        if (check) {
            checkTrackers();
        }
    }

    public void checkTrackers(){
        int numCase = 0;

        foreach (targetHandler tracker in allTrackers){   
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
        //Debug.Log("Numero de caso: " + numCase);
        assetHandler display = FindObjectOfType<assetHandler>();
        display.displayAsset(numCase);
    }

}

