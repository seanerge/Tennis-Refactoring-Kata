using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        Player p1, p2;

        public TennisGame2(string player1Name, string player2Name)
        {
            p1 = new Player(player1Name, 0);
            p2 = new Player(player2Name, 0);
        }

        public string GetScore()
        {
            var score = "";

            if (IsDrawCase())
            {
                score = GetDrawScore();
            }
            else
            {
                if ((p1.Point > 0 && p2.Point == 0)
                    || (p2.Point > 0 && p1.Point == 0)
                    || (p1.Point > p2.Point && p1.Point < 4)
                    || (p2.Point > p1.Point && p2.Point < 4))
                {
                    score = GetNormalGameScore();
                }

                if (p1.Point > p2.Point)
                {
                    if (p2.Point >= 3)
                    {
                        score = $"Advantage {GetLeaderName()}";
                    }

                    if (p1.Point >= 4 && Math.Abs(p1.Point - p2.Point) >= 2)
                    {
                        score = $"Win for {GetLeaderName()}";
                    }
                }
                else
                {
                    if (p1.Point >= 3)
                    {
                        score = $"Advantage {GetLeaderName()}";
                    }

                    if (p2.Point >= 4 && Math.Abs(p2.Point - p1.Point) >= 2)
                    {
                        score = $"Win for {GetLeaderName()}";
                    }
                }
            }

            return score;
        }

        private string GetLeaderName()
        {
            return p1.Point > p2.Point ? p1.Name : p2.Name;
        }

        private bool IsDrawCase()
        {
            return p1.Point == p2.Point;
        }

        private string GetDrawScore()
        {
            var score = string.Empty;

            if (p1.Point < 3)
            {
                score = GetScoreName(p1.Point);
                score += "-All";
            }
            if (p1.Point > 2)
                score = "Deuce";

            return score;
        }

        private string GetNormalGameScore()
        {
            return GetScoreName(p1.Point) + "-" + GetScoreName(p2.Point);
        }

        private string GetScoreName(int point)
        {
            var scoreName = "";
            if (point == 0)
                scoreName = "Love";
            if (point == 1)
                scoreName = "Fifteen";
            if (point == 2)
                scoreName = "Thirty";
            if (point == 3)
                scoreName = "Forty";

            return scoreName;
        }

        private void P1Score()
        {
            p1.Point++;
        }

        private void P2Score()
        {
            p2.Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }

    public class Player
    {
        public Player(string name, int point)
        {
            this.Name = name;
            this.Point = point;
        }

        public int Point { get; set; }
        public string Name { get; set; }


    }
}

