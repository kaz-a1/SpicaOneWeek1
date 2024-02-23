using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameTransform : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("targetObjectÇ™ê›íËÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetObject.transform.position;
    }
}
