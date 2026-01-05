using UnityEngine;

public class TrashDetector : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask trashLayer;

    TrashOutline currentOutline;
    TrashCollect currentCollect;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, trashLayer))
        {
            TrashOutline outline = hit.collider.GetComponent<TrashOutline>();
            TrashCollect collect = hit.collider.GetComponent<TrashCollect>();

            if (outline != null)
            {
                if (currentOutline != outline)
                {
                    ClearCurrent();

                    currentOutline = outline;
                    currentCollect = collect;

                    currentOutline.EnableEmission();
                    currentCollect?.BeginCollect();
                }
                return;
            }
        }

        ClearCurrent();
    }

    void ClearCurrent()
    {
        if (currentOutline != null)
        {
            currentOutline.DisableEmission();
            currentCollect?.CancelCollect();
        }

        currentOutline = null;
        currentCollect = null;
    }
}