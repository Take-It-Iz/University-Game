using System;
using UnityEngine;
using DG.Tweening;

public class MobAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.DOJump(new Vector2(0.5f, 0.5f), 0.5f, 1, 1f, false);
        transform.DOJump(new Vector2(-1f, -1f), 0.5f, 1, 1f, false);
    }
}
