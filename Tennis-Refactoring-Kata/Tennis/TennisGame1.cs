using System;
using System.Collections.Generic;

namespace Tennis
{
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
                player1Point ++;
            else
                player2Point ++;
        }

        public string GetScore()
        {
            player1Point = player1Point >= 0 ? player1Point : 0;
            player2Point = player2Point >= 0 ? player2Point : 0;

            if (player1Point == player2Point)
            {
                return GetEqualScore(player1Point);
            }
            else if (player1Point >= 4 || player2Point >= 4)
            {
                return GetGamePointScore();
            }
            else
            {
                return GetOtherScore();
            }
        }

        private string GetGamePointScore()
        {
            var scoreGap = Math.Abs(player1Point - player2Point);

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
            return player1Point > player2Point ? "player1" : "player2";
        }

        private string GetEqualScore(int point)
        {
            return scoreEqualNameDic.ContainsKey(point) ? scoreEqualNameDic[point] : "Deuce";
        }

        private string GetOtherScore()
        {
            string scoreName1 = GetScoreName(player1Point);
            string scoreName2 = GetScoreName(player2Point);
            return $"{scoreName1}-{scoreName2}";
        }

        private string GetScoreName(int point)
        {
            return scoreNormalNameDic.ContainsKey(point) ? scoreNormalNameDic[point] : string.Empty;
        }
    }
}