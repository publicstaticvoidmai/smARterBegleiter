using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizDataScriptable quizData;

    private List<Question> questions;
    //private List<Question> quizDataQuestions;

    private Question selectedQuestion;

    public GameObject quizModel;
    public GameObject finishedQuizModel;

    public GameObject finishedPanel;
    public GameObject quizPanel;

    public bool finishedQuiz;


    // Start is called before the first frame update
    void Start()
    {
        
        finishedPanel.SetActive(false);
        finishedQuiz = false;
        quizModel.SetActive(true);
        finishedQuizModel.SetActive(false);

        questions = quizData.questions;
        //SetUp(4);
        SelectQuestion();
        ResetQuestions();

    }

    //public void SetUp(int optionAmount)
    //{
    //    quizDataQuestions = quizData.questions;

    //    for (int i = 0; i < quizDataQuestions.Count; i++)
    //    {
    //        if(quizDataQuestions[i].options.Count == 4)
    //        {
    //            this.questions.Add(quizDataQuestions[i]);
    //        }
    //    }
    //}

    public int GetAmount()
    {
        return questions.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(finishedQuiz == true)
        {
            Finished();
        }
    }

    void SelectQuestion()
    {

        if (HowManyAnswered() == GetAmount())
        {
            finishedQuiz = true;
        }

        int val = Random.Range(0, GetAmount());
        if (!questions[val].answered)
        {
            selectedQuestion = questions[val];
            quizUI.SetQuestion(selectedQuestion);
        }
        else if(HowManyAnswered() < GetAmount())
        {
            SelectQuestion();
        }
    }

    private void Finished()
    {
        finishedPanel.SetActive(true);
        quizModel.SetActive(false);
        finishedQuizModel.SetActive(true);
        quizPanel.SetActive(false);
        

    }

    public bool Answer(string answered)
    {
        bool outcome = false;

        if(answered == selectedQuestion.correctAnswer)
        {
            outcome = true;
        }
        else
        {
            outcome = false;
        }

        selectedQuestion.answered = true;
        Invoke("SelectQuestion", 0.4f);
        return outcome;
    }


    public int HowManyAnswered()
    {
        int count = 0;
        for (int i = 0; i < GetAmount(); i++)
        {
            if (questions[i].answered)
            {
                count++;
            }
        }
        return count;
    }
    private void ResetQuestions()
    {
        for (int i = 0; i < GetAmount(); i++)
        {
            questions[i].answered = false;
            
        }
    }

    [System.Serializable]
    public class Question
    {
        public string questionInfo;
        public List<string> options;
        public string correctAnswer;
        public bool answered;
    }

}
