using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsController : MonoBehaviour
{

    Animator skillsAnimator;

    void Start()
    {
        skillsAnimator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void UsingSkills(bool isUsingSKills)
    {
        skillsAnimator.SetBool("isUsingSkills", true);
    }


}
