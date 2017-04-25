using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace BumChessV2
{
    class Grid : Control
    {

        char[] verticalABC = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M'};

        private Team _cellState = Team.None;

        public Form form { get; set; }

        public int Dimension { get; set; }

        public Team CurrentPlayer { get; set; }

        public Team CellState
        {
            get { return _cellState; }
            set {
                if (_cellState == Team.None)               
                        _cellState = value;               
              }
        }


        public Grid(int dimension)
        {
            CurrentPlayer = Team.X;
            this.Dimension = dimension;
        }


        //render board, using verticalABC array to set proper names on cells
        public void RenderBoard(Form form)
        {
            int top = 2;
            int left = 2;
            int cellNo = 1;
            int nextRow = 0;

            for (int i = 0; i < Dimension; i++)
            {
                for (int i2 = 0; i2 < Dimension; i2++)
                {
                    Button cell = new Button();
                    cell.Click += new EventHandler(cell_Clicked);

                    cell.Width = 50;
                    cell.Height = 50;
                    cell.Left = left;
                    cell.Top = top + nextRow;
                    form.Controls.Add(cell);
                    left += cell.Width + 2;                  
                    cell.Name = "cell" + verticalABC[i] + (cellNo).ToString();                 
                    cellNo++;
                }

                nextRow = nextRow + 50;
                cellNo = 1;
                left = 2;
                top = 2;
            }        
        }

   
        //event handler for pressing the dynamic buttons
        private void cell_Clicked(object sender, EventArgs e)
        {
            Button currentCell = (Button)sender; 
            currentCell.BackColor = Color.DimGray;

            if (CellState == Team.None)
            {
                currentCell.Text = CurrentPlayer.ToString();
            }
            ChangePlayer();
            Invalidate();
        }


        private void ChangePlayer()
        {
            if (CurrentPlayer == Team.X)
                CurrentPlayer = Team.O;
            else
                CurrentPlayer = Team.X;
        }


        public void CheckIfWin()
        {
            List<string> boardList = new List<string>();

            foreach (Control c in form.Controls)
            {

                string tmpName = "cell";
                if (c.Name.Contains(tmpName))
                {
                    boardList.Add(c.Name + "_" + c.Text);
                }
            }

            do
            {
                foreach (string s in boardList)
                {

                }

            } while (true);


            for (int i = 0; i < Dimension; i++)
            {
                for (int i2 = 0; i2 < Dimension; i2++)
                {
                    if (i2 - 1 >= 0 && i2 + 1 < Dimension &&
                    Cells[i, i2 - 1].CellState == Cells[i, i2].CellState &&
                    Cells[i, i2].CellState == Cells[i, i2 + 1].CellState &&
                    Cells[i, i2].CellState != Team.Undetermined)
                    {
                        CellsEnabled = false;
                        Color blinkColor = (Cells[i, i2].CellState == Team.X) ? Color.Red : Color.Green;
                        Cell[] cellsToBlink = { Cells[i, i2 - 1], Cells[i, i2], Cells[i, i2 + 1] };
                        CellBlinker.BlinkCells(blinkColor, cellsToBlink);
                        Debug.WriteLine("Vertical win found!");
                        return true;
                    }
                }
            }




        }




    }
}
