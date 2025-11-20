using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManger : MonoBehaviour
{
    // Start is called before the first frame update
    public List<QuestionAndAnswer> questionAndAnswers;
    [SerializeField] private GameObject objectToDestroy;
    public GameObject[] options;
    public GameObject quizObject;
    public int quantityToWin;

    public BeijinhoBossController beijinhoBoss;
    public PlayerController playerController;

    public int score = 0;

    public int currentQuestion;

    public Text questionText;

    private void Start()
    {
        GenerateQuestion();
    }

    public void Correct()
    {
        score++;
        // errorTextObject.SetActive(false);
        // correctTextObject.SetActive(true);
        
        if (score == quantityToWin)
        {
            Destroy(objectToDestroy);
        }
        
        if (beijinhoBoss != null)
        {
            beijinhoBoss.TakeDamage(50);
        }

        Close();
        
        questionAndAnswers.RemoveAt(currentQuestion);

        GenerateQuestion();
    }

    public void Wrong()
    {
        if (playerController != null)
        {
            playerController.PlayerIncreaseFatRate(10f);
        }

        // correctTextObject.SetActive(false);

        // errorTextObject.SetActive(true);

        GenerateQuestion();
        // Invoke(nameof(GenerateQuestion), 2f);
    }

    // void DesactivateErrorTextAndGenerate() {
    //     errorTextObject.SetActive(false);

    // }

    public void Close(){
        quizObject.SetActive(false);

        Invoke(nameof(Open), 3f);
    }

    public void Open(){
        if (score < quantityToWin)
        {
            quizObject.SetActive(true);
        }
    }

    public void DisableButtons()
    {
        foreach (var option in options)
        {
        CanvasGroup canvasGroup = option.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = option.AddComponent<CanvasGroup>(); // Adiciona o CanvasGroup se não existir
        }

        canvasGroup.interactable = false;   // Desativa a interatividade
        canvasGroup.blocksRaycasts = false;
        }
    }

    public void EnableButtons()
    {
        foreach (var option in options)
        {
            // option.GetComponent<Button>().interactable = true; // Reativa os botões
                    CanvasGroup canvasGroup = option.GetComponent<CanvasGroup>();

            if (canvasGroup != null)
            {
                canvasGroup.interactable = true;   // Reativa a interatividade
                canvasGroup.blocksRaycasts = true; // Permite cliques novamente
            }
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = questionAndAnswers[currentQuestion].answers[i];

            if (questionAndAnswers[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        // correctTextObject.SetActive(false);
        // errorTextObject.SetActive(false);

        currentQuestion = Random.Range(0, questionAndAnswers.Count);

        questionText.text = questionAndAnswers[currentQuestion].question;
        SetAnswers();

        EnableButtons();

        // questionAndAnswers.RemoveAt(currentQuestion);
    }
}