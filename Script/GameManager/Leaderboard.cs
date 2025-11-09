using System.Collections.Generic;
using UnityEngine;
using TMPro;

//import thư viện leaderboard của danqzq
using Dan.Main;
using System;
using UnityEngine.UIElements;
public class Leaderboard : MonoBehaviour
{
    //  Leaderboard xay theo mô hình severless ==> database là 1 dịch vụ bên ngoài(service)==> ta chỉ truy xuất bằng API(sử dụng package)
    // link: https://danqzq.itch.io/leaderboard-creator

    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    //link Leaderboard web: https://danqzq.itch.io/leaderboard-creator

    //API KEY public
    private string publicLeaderboardKey = "9b367d18e817a1ef2331949f94117f2d8edd3b376c66fc1bd73ab0c5dbf400f4";
    
    private void Start()
    {
        GetLeaderBoard(); //cập nhật dữ liệu LeaderBoard trên database về
    }
    
    public void GetLeaderBoard()
    {
        //((msg) => {} (this is a callback function when request for getting the leaderboard is completed) 
        //dùng dấu => để định nghĩa 1 cái hàm trong 1 cái hàm
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            //Hàm Substring trong C# chỉ hợp lệ khi:0 <= startIndex < str.Length và 0 <= length <= str.Length - startIndex
            //Nếu startIndex hoặc length vượt ngoài phạm vi đó ⇒ lỗi ArgumentOutOfRangeException.

            //Nếu msg.Length nhỏ hơn names.Count,thì gán loopLength = msg.Length,ngược lại thì gán loopLength = names.Count ==> Đảm bảo vòng lặp for không bị lỗi vượt giới hạn mảng (out of range).
            //Nếu bảng xếp hạng chỉ có 3 người, mà bạn có 10 ô text trong UI,
            //thì msg.Length = 3, names.Count = 10.
            //bạn chỉ nên lặp 3 lần thôi — nếu không sẽ lỗi “index out of range”.
            int loopLenght = (msg.Length < names.Count) ? msg.Length : names.Count;
            //lặp qua List names và thay chúng bằng name mới trên leaderboard
            for (int i = 0;  i<loopLenght; ++i)
            {
                //thay chúng bằng names và score mới trên leaderboard
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }


    public void SetLeaderBoardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
        {

            LeaderboardCreator.ResetPlayer();//==>reset lại ID người chơi sau khi upload, để server hiểu rằng đây là một người chơi mới / một phiên mới.Cả hai lệnh trên đều dùng chung 1 ID người chơi, nên backend sẽ nghĩ đó là cùng 1 người,

            // chỉ lấy tối đa 4 ký tự, tránh lỗi Substring
            string safeName = (username.Length > 4) ? username.Substring(0, 4) : username;
            GetLeaderBoard();//gọi hàm này 1 lần nữa để update leaderboard cho user thấy được
        }));
    }

   
}
