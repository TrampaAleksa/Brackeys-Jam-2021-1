using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaFollowPath : MonoBehaviour
{
    public string pathName;
    public float time;

    private void Start()
    {
        iTween.MoveTo( gameObject,iTween.Hash("path",iTweenPath.GetPath(pathName), "easetype",iTween.EaseType.easeInOutSine, "time",time) );
    }
}
