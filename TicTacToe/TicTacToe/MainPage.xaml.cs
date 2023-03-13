using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace TicTacToe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        public int[,] board;
        public bool player1 = true;
        public int moves;
        public bool gameFinished;

        readonly string xPlayerTurn = "X player's turn";
        readonly string oPlayerTurn = "O player's turn";
        readonly string xPlayerWin  = "X player wins";
        readonly string oPlayerWin  = "O player wins";

        public MainPage()
		{
			InitializeComponent();
            Reset();
        }

		void Reset()
		{
            moves = 0;
            gameFinished = false;
            player1 = true;
            board = new int[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = 0;
                }
            }
            Status.Text = xPlayerTurn;
            Status.TextColor = Color.Red;
            Button00.Text = "-";
            Button01.Text = "-";
            Button02.Text = "-";
            Button10.Text = "-";
            Button11.Text = "-";
            Button12.Text = "-";
            Button20.Text = "-";
            Button21.Text = "-";
            Button22.Text = "-";
            Button00.BackgroundColor = Color.Gray;
            Button01.BackgroundColor = Color.Gray;
            Button02.BackgroundColor = Color.Gray;
            Button10.BackgroundColor = Color.Gray;
            Button11.BackgroundColor = Color.Gray;
            Button12.BackgroundColor = Color.Gray;
            Button20.BackgroundColor = Color.Gray;
            Button21.BackgroundColor = Color.Gray;
            Button22.BackgroundColor = Color.Gray;
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            Reset();
        }

        void OnBlockClicked(object sender, EventArgs e){
            if (gameFinished)//check this first so that user cant click the box when the game is over/someone already won
            {
                return;
            }
            Xamarin.Forms.Button button = (Xamarin.Forms.Button)sender;
            int row = Grid.GetRow(button) - 2;//offset by 2 due to grid positioning
            int col = Grid.GetColumn(button) - 1;//offset by 1 due to grid positioning

            if (board[row, col]!=0)
            {
                return;
            }
            else
            {
                board[row, col] = player1 ? 1 : 2;//O for initial, 1 for X, 2 for O
                button.Text = player1 ? "X" : "O";
                button.BackgroundColor = player1 ? Color.Red : Color.Blue;
                Status.Text = !player1 ? xPlayerTurn : oPlayerTurn;
                Status.TextColor = !player1 ? Color.Red : Color.Blue;
                player1 = !player1;// reverse the player1 so that the next play will be detected as O player
            }
            moves++;
            if(moves >= 5)//minimum amount of moves that can result a win //less computation time or somthing, idk
            {
                CheckForWin();
            }

        }

        void CheckForWin()
        {
            for(int row = 0; row < 3; row++) //row check
            {
                if (board[row, 0]!= 0 && (board[row, 0] == board[row, 1]) && (board[row, 1] == board[row, 2]))
                {
                    Status.Text = board[row, 0]==1 ? xPlayerWin : oPlayerWin;
                    Status.TextColor = board[row, 0] == 1 ? Color.Red : Color.Blue;
                    gameFinished = true;
                    return;
                }
            }
            for (int col = 0; col < 3; col++) //column check
            {
                if (board[0, col] != 0 && (board[0, col] == board[1, col]) && (board[1, col] == board[2, col]))
                {
                    Status.Text = board[0, col]==1 ? xPlayerWin : oPlayerWin;
                    Status.TextColor = board[0, col] == 1 ? Color.Red : Color.Blue;
                    gameFinished = true;
                    return;
                }
            }

            if (board[0, 0] != 0 && (board[0, 0] == board[1, 1]) && (board[1, 1] == board[2, 2]))//diagonals
            {
                Status.Text = board[0, 0] == 1 ? xPlayerWin : oPlayerWin;
                Status.TextColor = board[0, 0] == 1 ? Color.Red : Color.Blue;
                gameFinished = true;
                return;
            }
            if (board[2, 0]!= 0 && (board[2, 0] == board[1, 1]) && (board[1, 1] == board[0, 2]))
            {
                Status.Text = board[2, 0] == 1 ? xPlayerWin : oPlayerWin;
                Status.TextColor = board[0, 0] == 1 ? Color.Red : Color.Blue;
                gameFinished = true;
                return;
            }
            if (moves == 9)
            {
                Status.Text = "Tie";
                gameFinished = true;
                Status.TextColor = Color.FromHex("#6b6b6b");
                return;
            }

        }

	}

}