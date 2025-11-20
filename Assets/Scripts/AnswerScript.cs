using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
     public int score = 0;
     public bool isCorrect = false;
     [SerializeField] private GameObject errorTextObject;
     [SerializeField] private GameObject correctTextObject;
     public QuizManger quizManager;

     private Button button; 
    
    private void Start()
    {
        button = GetComponent<Button>(); // Obtém o componente Button do GameObject
    }

    public void Answer()
     {
          if (isCorrect)
          {
            ChangeColor(Color.green);
            correctTextObject.SetActive(true);
            errorTextObject.SetActive(false);
            Invoke(nameof(CorrectAnswer), 1.2f);
          } else {
            ChangeColor(Color.red);
            correctTextObject.SetActive(false);
            errorTextObject.SetActive(true);
            Invoke(nameof(WrongAnswer), 1.4f);
          }
    }

    void ChangeColor(Color color)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = color;
        colors.selectedColor = color;
        button.colors = colors;
    }

    void CorrectAnswer() {
      ResetColor();
      quizManager.DisableButtons();
      correctTextObject.SetActive(false);
      quizManager.Correct();

    }

    void WrongAnswer() {
      ResetColor();
      quizManager.DisableButtons();
      errorTextObject.SetActive(false);
      quizManager.Wrong();
    }

    void ResetColor()
    {
        ChangeColor(Color.white); // Ou qualquer cor padrão que você quiser
    }
}
