using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualObjectProjectR
{
    public partial class Form2 : Form
    {
        int Row = 5, Col = 5, Bomb = 1;
        public Tarla[,] butonlar;

        public Form2(int row, int colum, int bomb)
        {
            InitializeComponent();

            Row = row; Col = colum; Bomb = bomb;
            butonlar = new Tarla[Row, Col];

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.Location = new Point(10, 50);
            tableLayoutPanel.ColumnCount = Col;
            tableLayoutPanel.RowCount = Row;
            tableLayoutPanel.Dock = DockStyle.Fill;

            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            }
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            }

            this.Controls.Add(tableLayoutPanel);

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    Tarla tarla = new Tarla(i, j); 
                  
                    tarla.Dock = DockStyle.Fill;
                    tarla.Text = "  ";
                    tarla.Click += Button_Click;

                    tableLayoutPanel.Controls.Add(tarla, j, i); 
                    butonlar[i, j] = tarla; 
                }
            }

            Random random = new Random();
            for (int i = 0; i < Bomb; i++)
            {
                int bombPlaceRow = random.Next(0, Row);
                int bombPlaceCol = random.Next(0, Col);
                butonlar[bombPlaceRow, bombPlaceCol].Value = -1; 


                
                for (int j = -1; j <= 1; j++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        int neighborRow = bombPlaceRow + j;
                        int neighborCol = bombPlaceCol + k;

                     

                        if (neighborRow >= 0 && neighborRow < Row && neighborCol >= 0 && neighborCol < Col)
                        {
                            if (butonlar[neighborRow, neighborCol].Value != -1)
                            {
                                butonlar[neighborRow, neighborCol].Value++;
                            }
                        }
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Tarla onclicked = sender as Tarla;
            if (onclicked != null && !onclicked.IsOpened) 
            {
                if (onclicked.Value == -1) 
                {
                    MessageBox.Show("LOSE!", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit(); 
                }
                else
                {
                    onclicked.open(); 

                    
                    if (onclicked.Value == 0)
                    {
                        int yer = onclicked.Row;
                        int colIndex = onclicked.Col;

                       
                        for (int i = yer - 1; i <= yer + 1; i++)
                        {
                            for (int j = colIndex - 1; j <= colIndex + 1; j++)
                            {
                               
                                if (i >= 0 && i < Row && j >= 0 && j < Col && (i != yer || j != colIndex))
                                {
                                    butonlar[i, j].PerformClick(); 
                                }
                            }
                        }
                    }

                    
                    CheckWin();
                }
            }
        }

        private void CheckWin()
        {
            bool allOpened = true;

            
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                  
                    if (butonlar[i, j].Value != -1 && !butonlar[i, j].IsOpened)
                    {
                        allOpened = false; 
                        break;
                    }
                }
                if (!allOpened) break; 
            }

            if (allOpened) 
            {
                MessageBox.Show("WİN!", "GAME OVER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }

    public partial class Tarla : Button
    {
        private int value = 0;
        private bool isOpened = false; 

        
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public bool IsOpened
        {
            get { return isOpened; }
            set { isOpened = value; }
        }

        private int row = 0;
        public int Row
        {
            get { return row; }
            set { this.row = value; }
        }

        private int col = 0;
        public int Col
        {
            get { return col; }
            set { this.col = value; }
        }

        public Tarla(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public void open()
        {
            this.Text = this.Value.ToString(); 
            this.IsOpened = true; 
        }
    }
}
