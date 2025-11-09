using UnityEngine;
using TMPro;
//import thư viện Events trong Unity
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;

    public ScoreCounter counter;

    //khai báo biến submitScoreEvent là UnityEvent gồm 1 kiểu string và int 
    public UnityEvent<string, int> submitScoreEvent;
    
    
   
    public void SubmitScore()
    {
        inputScore.text = counter.score.ToString();//hiện thị score lên UI
        //chuyển về đúng kiểu dữ liệu rồi gửi đi sử lý
        // Tham số của Leaderboard phải cùng kiểu dữ liệu của Event này(string,int)
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text)); // Ta sẽ Invoke 1 cái event gồm inputName và inputScore để leaderboard listen to

    }

}
