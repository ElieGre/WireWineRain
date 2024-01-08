using UnityEngine;

public class BuildingTriggerManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("Player"))
        {
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
