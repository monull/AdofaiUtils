using UnityEngine;
using UnityModManagerNet;

namespace AdofaiUtils
{
    public class PlayTimeSettings
    {
        [Draw("플레이 중일 때 텍스트 형식")] public string TextTemplate = "음악 시간 : <NowMinute>:<NowSecond> / <TotalMinute>:<TotalSecond>";
        
        [Draw("플레이 중이 아닐 때 텍스트 형식")] public string NotPlaying = "Not Playing";
        [Draw("위치 X좌표(Position X)")] public int PositionX = 0;
        [Draw("위치 Y좌표(Position Y)")] public int PositionY = 100;
        [Draw("글자 크기(Font Size)")] public int TextSize = 50;

        [Draw("텍스트 그림자 진하기(1~100)", Min = 0, Max = 100)] public int TextShadow = 50;
    }
}