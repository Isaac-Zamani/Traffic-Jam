
using UnityEngine;
using UnityEngine.Events;

public class WinTrigger : MonoBehaviour
{
    public UnityEvent onWin;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player") onWin.Invoke();
    }
}
