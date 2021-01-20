﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "QuestionData")]
public class QuizDataScriptable : ScriptableObject
{
    public List<QuizManager.Question> questions;
    public List<QuizTFManager.Question> questionsTF;

}
