using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    [SerializeField] private float[] answers;
    [SerializeField] private Animator anim;
    private bool correct = false;

    private void Update()
    {
        anim.SetBool("Correcet", correct);
    }
    public void checkAnswer(string answer)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            if(answers[i] == float.Parse(answer))
            {
                correct = true; 
                break;
            }else correct = false;
        }
    }
}
