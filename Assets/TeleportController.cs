using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TeleportController : MonoBehaviour
{
    public GameObject baseControllerGameObject;
    public GameObject teleportationGameObject;

    public InputActionReference teleportActivatationReference;
    
    



    [Space]
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;


    private void Start() {
        teleportActivatationReference.action.performed += TeleportModeActivate;
        teleportActivatationReference.action.canceled += TeleportModeCancel;
        
        //DontDestroyOnLoad(transform.root.gameObject);
    }

    private void TeleportModeActivate(InputAction.CallbackContext obj) =>  onTeleportActivate.Invoke(); 
    private void TeleportModeCancel(InputAction.CallbackContext obj) => Invoke("DeactivateTeleporter", .1f);

    void DeactivateTeleporter() =>  onTeleportCancel.Invoke();
    
    
    
}
