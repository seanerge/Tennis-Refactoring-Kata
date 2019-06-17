using System;
using System.Collections.Generic;

namespace Tennis
{
    internal class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
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
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            m_score1 = m_score1 >= 0 ? m_score1 : 0;
            m_score2 = m_score2 >= 0 ? m_score2 : 0;

            if (m_score1 == m_score2)
            {
                return GetEqualScore(m_score1);
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
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
            var scoreGap = Math.Abs(m_score1 - m_score2);

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
            return m_score1 > m_score2 ? "player1" : "player2";
        }

        private string GetEqualScore(int point)
        {
            return scoreEqualNameDic.ContainsKey(point) ? scoreEqualNameDic[point] : "Deuce";
        }

        private string GetOtherScore()
        {
            string scoreName1 = GetScoreName(m_score1);
            string scoreName2 = GetScoreName(m_score2);
            return $"{scoreName1}-{scoreName2}";
        }

        private string GetScoreName(int point)
        {
            return scoreNormalNameDic.ContainsKey(point) ? scoreNormalNameDic[point] : string.Empty;
        }
    }
}