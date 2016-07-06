namespace moneyform
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddExpenseBtn = new System.Windows.Forms.Button();
            this.BalanceTB = new System.Windows.Forms.TextBox();
            this.TotalIncomeTB = new System.Windows.Forms.TextBox();
            this.ExpenseCB = new System.Windows.Forms.ComboBox();
            this.AddIncomeBtn = new System.Windows.Forms.Button();
            this.IncomeNUD = new System.Windows.Forms.NumericUpDown();
            this.ExpenseNUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BreakDownLbl = new System.Windows.Forms.Label();
            this.BreakDownDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.IncomeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreakDownDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // AddExpenseBtn
            // 
            this.AddExpenseBtn.Location = new System.Drawing.Point(147, 141);
            this.AddExpenseBtn.Name = "AddExpenseBtn";
            this.AddExpenseBtn.Size = new System.Drawing.Size(93, 27);
            this.AddExpenseBtn.TabIndex = 1;
            this.AddExpenseBtn.Text = "AddExpenseBtn";
            this.AddExpenseBtn.UseVisualStyleBackColor = true;
            this.AddExpenseBtn.Click += new System.EventHandler(this.AddExpenseBtn_Click);
            // 
            // BalanceTB
            // 
            this.BalanceTB.Location = new System.Drawing.Point(376, 55);
            this.BalanceTB.Name = "BalanceTB";
            this.BalanceTB.Size = new System.Drawing.Size(100, 20);
            this.BalanceTB.TabIndex = 4;
            // 
            // TotalIncomeTB
            // 
            this.TotalIncomeTB.Location = new System.Drawing.Point(376, 81);
            this.TotalIncomeTB.Name = "TotalIncomeTB";
            this.TotalIncomeTB.Size = new System.Drawing.Size(100, 20);
            this.TotalIncomeTB.TabIndex = 5;
            // 
            // ExpenseCB
            // 
            this.ExpenseCB.FormattingEnabled = true;
            this.ExpenseCB.Location = new System.Drawing.Point(12, 50);
            this.ExpenseCB.Name = "ExpenseCB";
            this.ExpenseCB.Size = new System.Drawing.Size(156, 21);
            this.ExpenseCB.TabIndex = 6;
            // 
            // AddIncomeBtn
            // 
            this.AddIncomeBtn.Location = new System.Drawing.Point(147, 89);
            this.AddIncomeBtn.Name = "AddIncomeBtn";
            this.AddIncomeBtn.Size = new System.Drawing.Size(93, 23);
            this.AddIncomeBtn.TabIndex = 7;
            this.AddIncomeBtn.Text = "Add Income";
            this.AddIncomeBtn.UseVisualStyleBackColor = true;
            this.AddIncomeBtn.Click += new System.EventHandler(this.AddIncomeBtn_Click);
            // 
            // IncomeNUD
            // 
            this.IncomeNUD.DecimalPlaces = 2;
            this.IncomeNUD.Location = new System.Drawing.Point(12, 92);
            this.IncomeNUD.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.IncomeNUD.Name = "IncomeNUD";
            this.IncomeNUD.Size = new System.Drawing.Size(120, 20);
            this.IncomeNUD.TabIndex = 8;
            // 
            // ExpenseNUD
            // 
            this.ExpenseNUD.DecimalPlaces = 2;
            this.ExpenseNUD.Location = new System.Drawing.Point(12, 141);
            this.ExpenseNUD.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.ExpenseNUD.Name = "ExpenseNUD";
            this.ExpenseNUD.Size = new System.Drawing.Size(120, 20);
            this.ExpenseNUD.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Total Income";
            // 
            // BreakDownLbl
            // 
            this.BreakDownLbl.AutoSize = true;
            this.BreakDownLbl.Location = new System.Drawing.Point(13, 187);
            this.BreakDownLbl.Name = "BreakDownLbl";
            this.BreakDownLbl.Size = new System.Drawing.Size(64, 13);
            this.BreakDownLbl.TabIndex = 12;
            this.BreakDownLbl.Text = "Breakdown:";
            // 
            // BreakDownDGV
            // 
            this.BreakDownDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BreakDownDGV.Location = new System.Drawing.Point(16, 204);
            this.BreakDownDGV.Name = "BreakDownDGV";
            this.BreakDownDGV.Size = new System.Drawing.Size(460, 228);
            this.BreakDownDGV.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 448);
            this.Controls.Add(this.BreakDownDGV);
            this.Controls.Add(this.BreakDownLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExpenseNUD);
            this.Controls.Add(this.IncomeNUD);
            this.Controls.Add(this.AddIncomeBtn);
            this.Controls.Add(this.ExpenseCB);
            this.Controls.Add(this.TotalIncomeTB);
            this.Controls.Add(this.BalanceTB);
            this.Controls.Add(this.AddExpenseBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.IncomeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreakDownDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddExpenseBtn;
        private System.Windows.Forms.TextBox BalanceTB;
        private System.Windows.Forms.TextBox TotalIncomeTB;
        private System.Windows.Forms.ComboBox ExpenseCB;
        private System.Windows.Forms.Button AddIncomeBtn;
        private System.Windows.Forms.NumericUpDown IncomeNUD;
        private System.Windows.Forms.NumericUpDown ExpenseNUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label BreakDownLbl;
        private System.Windows.Forms.DataGridView BreakDownDGV;
    }
}

