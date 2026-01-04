using UnityEngine;

public class TrashDetector : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask trashLayer;

    TrashOutline currentTrash;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, trashLayer))
        {
            TrashOutline trash = hit.collider.GetComponent<TrashOutline>();

            if (trash != null)
            {
                if (currentTrash != trash)
                {
                    ClearCurrentTrash();
                    currentTrash = trash;
                    currentTrash.EnableEmission();
                }
                return;
            }
        }

        ClearCurrentTrash();
    }

    void ClearCurrentTrash()
    {
        if (currentTrash != null)
        {
            currentTrash.DisableEmission();
            currentTrash = null;
        }
    }
}