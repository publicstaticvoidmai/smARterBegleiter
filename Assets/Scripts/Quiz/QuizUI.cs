using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Text questionText;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correct, wrong, normal;


    private QuizManager.Question question;
    private bool answered;

    public Text questionCount;
    public Text questionIndex;


    // Start is called before the first frame update
    void Start()
    {

        
        questionIndex.text = "1";

        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }

    void Update()
    {
        questionCount.text = quizManager.GetAmount().ToString();
    }

    public void SetQuestion(QuizManager.Question question)
    {
        this.question = question;
        questionText.text = question.questionInfo;
        int index = quizManager.HowManyAnswered() + 1;
        questionIndex.text = index.ToString();

        //shuffles answer options randomly
        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);

        for(int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normal;
        }

        answered = false;
    }

    

    private void OnClick(Button btn)
    {
        if (!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);
            if (val)
            {
                btn.image.color = correct;

            }
            else
            {
                btn.image.color = wrong;
            }
        }
    }
}
