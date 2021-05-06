using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator animator;
    public GameObject canvas;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        WaitCutscene();

    }

    public void WaitCutscene()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CutsceneAnim"))
        {
            canvas.SetActive(false);
        }
        else       
            canvas.SetActive(true);  
    }
}
