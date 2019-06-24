namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";
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
            var score = GetDrawScore();

            if (p1point > 0 && p2point == 0)
            {
                score = GetNormalGameScore();
            }
            if (p1point > p2point && p1point < 4)
            {
                score = GetNormalGameScore();
            }


            if (p2point > 0 && p1point == 0)
            {
                score = GetNormalGameScore();
            }

            if (p2point > p1point && p2point < 4)
            {
                score = GetNormalGameScore();
            }



            if (p1point > p2point && p2point >= 3)
            {
                score = "Advantage player1";
            }

            if (p2point > p1point && p1point >= 3)
            {
                score = "Advantage player2";
            }

            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = "Win for player1";
            }
            if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        private string GetDrawScore()
        {
            var score = string.Empty;

            if (p1point == p2point)
            {
                if (p1point < 3)
                {
                    score = GetScoreName(p1point);
                    score += "-All";
                }
                if (p1point > 2)
                    score = "Deuce";
            }

            return score;
        }

        private string GetNormalGameScore()
        {
            string score;
            p1res = GetScoreName(p1point);
            p2res = GetScoreName(p2point);
            score = p1res + "-" + p2res;
            return score;
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

