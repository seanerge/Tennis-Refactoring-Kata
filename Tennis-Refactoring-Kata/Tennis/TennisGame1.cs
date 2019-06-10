using System;

namespace Tennis
{
    internal class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

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
            if (m_score1 == m_score2)
            {
                return GetEqualScore();
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
            var leader = m_score1 > m_score2 ? "player1" : "player2";

            var scoreGap = Math.Abs(m_score1 - m_score2);

            if (scoreGap >= 2)
            {
                return $"Win for {leader}";
            }
            else
            {
                return $"Advantage {leader}";

            }
        }

        private string GetEqualScore()
        {
            string score = "";
            switch (m_score1)
            {
                case 0:
                    score = "Love-All";
                    break;

                case 1:
                    score = "Fifteen-All";
                    break;

                case 2:
                    score = "Thirty-All";
                    break;

                default:
                    score = "Deuce";
                    break;
            }

            return score;
        }

        private string GetOtherScore()
        {
            string scoreName1 = ConvertScorePointToName(m_score1);
            string scoreName2 = ConvertScorePointToName(m_score2);
            return $"{scoreName1}-{scoreName2}";
        }

        private string ConvertScorePointToName(int point)
        {
            string scoreName = "";
            switch (point)
            {
                case 0:
                    scoreName = "Love";
                    break;

                case 1:
                    scoreName = "Fifteen";
                    break;

                case 2:
                    scoreName = "Thirty";
                    break;

                case 3:
                    scoreName = "Forty";
                    break;
            }

            return scoreName;
        }
    }
}