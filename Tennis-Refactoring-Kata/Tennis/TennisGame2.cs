namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";

            if (IsDrawCase())
            {
                score = GetDrawScore();
            }

            if (IsNormalCase())
            {
                score = GetNormalGameScore();
            }

            if (IsP1Advantage())
            {
                score = "Advantage player1";
            }

            if (IsP2Advantage())
            {
                score = "Advantage player2";
            }

            if (IsP1Winner() || IsP2Winner())
            {
                var winner = string.Empty;

                if (IsP1Winner())
                {
                    winner = "player1";
                }

                if (IsP2Winner())
                {
                    winner = "player2";
                }

                score = $"Win for {winner}";
            }
            return score;
        }

        private bool IsDrawCase()
        {
            return p1point == p2point;
        }

        private bool IsNormalCase()
        {
            return (p1point > 0 && p2point == 0)
                            || (p2point > 0 && p1point == 0)
                            || (p1point > p2point && p1point < 4)
                            || (p2point > p1point && p2point < 4);
        }

        private bool IsP2Advantage()
        {
            return p2point > p1point && p1point >= 3;
        }

        private bool IsP1Advantage()
        {
            return p1point > p2point && p2point >= 3;
        }

        private bool IsP2Winner()
        {
            return p2point >= 4 && (p2point - p1point) >= 2;
        }

        private bool IsP1Winner()
        {
            return p1point >= 4 && (p1point - p2point) >= 2;
        }

        private string GetDrawScore()
        {
            var score = string.Empty;

            if (p1point < 3)
            {
                score = GetScoreName(p1point);
                score += "-All";
            }
            if (p1point > 2)
                score = "Deuce";

            return score;
        }

        private string GetNormalGameScore()
        {
            return GetScoreName(p1point) + "-" + GetScoreName(p2point);
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
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

