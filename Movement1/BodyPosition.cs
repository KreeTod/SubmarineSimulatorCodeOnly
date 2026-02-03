using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPosition : MonoBehaviour
{
    public KeyCode CrawlKey = KeyCode.LeftControl;
    public bool isHoldToCrawl;

    private bool isSitting;

    [SerializeField] private Transform HeadObject;


    [SerializeField] private GameObject StandCapsuleObject;
    [SerializeField] private float StandHeadHeight = 1.8f;

    [SerializeField] private GameObject CrawlCapsuleObject;
    [SerializeField] private float CrawlHeadHeight = 1.1f;
    private void Update()
    {
        if (isHoldToCrawl)
        {
            if (Input.GetKeyDown(CrawlKey))
            {
                if (isSitting){ isSitting = false; }
                else{ isSitting = true; }
            }
        }
        else
        {
            if (Input.GetKey(CrawlKey)) { isSitting = true; }
            else { isSitting = false; }
        }


        if (isSitting)
        {
            StandCapsuleObject.SetActive(false);
            CrawlCapsuleObject.SetActive(true);
            //HeadObject.localPosition = new Vector3(0, _selfTransform.position.y + CrawlHeadHeight, 0);
            HeadObject.localPosition = new Vector3(0, CrawlHeadHeight, 0);
        }
        else
        {
            StandCapsuleObject.SetActive(true);
            CrawlCapsuleObject.SetActive(false);
            //HeadObject.localPosition = new Vector3(0, _selfTransform.position.y + StandHeadHeight, 0);
            HeadObject.localPosition = new Vector3(0, StandHeadHeight, 0);
        }

    }
}
