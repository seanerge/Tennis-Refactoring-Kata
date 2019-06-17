using System;
using System.Collections.Generic;

namespace Tennis
{
    public enum GameStatus
    {
        Tie,
        Normal,
        GamePoint

    }

    internal class TennisGame1 : ITennisGame
    {
        private int player1Point = 0;
        private int player2Point = 0;
        private string player1Name;
        private string player2Name;

        private readonly Dictionary<int, string> scoreEqualNameDic = new Dictionary<int, string>()
        {
                { 0, "Love-All" },
                { 1, "Fifteen-All" },
                { 2, "Thirty-All" },
        };

        private readonly Dictionary<int, string> scoreNormalNameDic = new Dictionary<int, string>()
        {
                { 0, "Love" },
                { 1, "Fifteen" },
                { 2, "Thirty" },
                { 3, "Forty" },
        };

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this.player1Point++;
            else
                this.player2Point++;
        }

        public string GetScore()
        {
            this.player1Point = this.player1Point >= 0 ? this.player1Point : 0;
            this.player2Point = this.player2Point >= 0 ? this.player2Point : 0;
            var currentStatus = GetCurrentStatus();
            switch (currentStatus)
            {
                case GameStatus.Tie:
                    return GetEqualScore();
                case GameStatus.GamePoint:
                    return GetGamePointScore();
                case GameStatus.Normal:
                default:
                    return GetOtherScore();
            }
        }

        private GameStatus GetCurrentStatus()
        {
            if (this.player1Point == this.player2Point)
            {
                return GameStatus.Tie;
            }
            else if (this.player1Point >= 4 || this.player2Point >= 4)
            {
                return GameStatus.GamePoint;
            }
            else
            {
                return GameStatus.Normal;
            }
        }

        private string GetGamePointScore()
        {
            var scoreGap = Math.Abs(this.player1Point - this.player2Point);

            if (scoreGap >= 2)
            {
                return $"Win for {GetLeadingPlayer()}";
            }
            else
            {
                return $"Advantage {GetLeadingPlayer()}";
            }
        }

        private string GetLeadingPlayer()
        {
            return this.player1Point > this.player2Point ? "player1" : "player2";
        }

        private string GetEqualScore()
        {
            return scoreEqualNameDic.ContainsKey(this.player1Point) ? scoreEqualNameDic[this.player1Point] : "Deuce";
        }

        private string GetOtherScore()
        {
            string scoreName1 = GetScoreName(this.player1Point);
            string scoreName2 = GetScoreName(this.player2Point);
            return $"{scoreName1}-{scoreName2}";
        }

        private string GetScoreName(int point)
        {
            return scoreNormalNameDic.ContainsKey(point) ? scoreNormalNameDic[point] : string.Empty;
        }
    }
}