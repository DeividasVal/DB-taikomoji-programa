
namespace DBlab
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
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.ld3DataSet = new DBlab.ld3DataSet();
            this.ld3DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dARBUOTOJASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dARBUOTOJASTableAdapter = new DBlab.ld3DataSetTableAdapters.DARBUOTOJASTableAdapter();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.button5 = new System.Windows.Forms.Button();
            this.dARBUOTOJASBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dARBUOTOJASBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dARBUOTOJASBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.dARBUOTOJASBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.dARBUOTOJASBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ld3DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ld3DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource5)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(298, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Rodyti";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nepasirinktas objektas";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(577, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 52);
            this.button2.TabIndex = 6;
            this.button2.Text = "Redaguoti";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ld3DataSet
            // 
            this.ld3DataSet.DataSetName = "ld3DataSet";
            this.ld3DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ld3DataSetBindingSource
            // 
            this.ld3DataSetBindingSource.DataSource = this.ld3DataSet;
            this.ld3DataSetBindingSource.Position = 0;
            // 
            // dARBUOTOJASBindingSource
            // 
            this.dARBUOTOJASBindingSource.DataMember = "DARBUOTOJAS";
            this.dARBUOTOJASBindingSource.DataSource = this.ld3DataSet;
            // 
            // dARBUOTOJASTableAdapter
            // 
            this.dARBUOTOJASTableAdapter.ClearBeforeFill = true;
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            this.advancedDataGridView1.AllowUserToOrderColumns = true;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(12, 143);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(672, 461);
            this.advancedDataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.TabIndex = 7;
            this.advancedDataGridView1.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.advancedDataGridView1_SortStringChanged);
            this.advancedDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(29, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 37);
            this.button3.TabIndex = 9;
            this.button3.Text = "Daryti ataskaitą";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(29, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 37);
            this.button4.TabIndex = 10;
            this.button4.Text = "Atnaujinti";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(609, 620);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Trinti";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dARBUOTOJASBindingSource1
            // 
            this.dARBUOTOJASBindingSource1.DataMember = "DARBUOTOJAS";
            this.dARBUOTOJASBindingSource1.DataSource = this.ld3DataSetBindingSource;
            // 
            // dARBUOTOJASBindingSource2
            // 
            this.dARBUOTOJASBindingSource2.DataMember = "DARBUOTOJAS";
            this.dARBUOTOJASBindingSource2.DataSource = this.ld3DataSet;
            // 
            // dARBUOTOJASBindingSource3
            // 
            this.dARBUOTOJASBindingSource3.DataMember = "DARBUOTOJAS";
            this.dARBUOTOJASBindingSource3.DataSource = this.ld3DataSet;
            // 
            // dARBUOTOJASBindingSource4
            // 
            this.dARBUOTOJASBindingSource4.DataMember = "DARBUOTOJAS";
            this.dARBUOTOJASBindingSource4.DataSource = this.ld3DataSetBindingSource;
            // 
            // dARBUOTOJASBindingSource5
            // 
            this.dARBUOTOJASBindingSource5.DataMember = "DARBUOTOJAS";
            this.dARBUOTOJASBindingSource5.DataSource = this.ld3DataSetBindingSource;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 655);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duomenų bazės taikomoji programa";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ld3DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ld3DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dARBUOTOJASBindingSource5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource ld3DataSetBindingSource;
        private ld3DataSet ld3DataSet;
        private System.Windows.Forms.BindingSource dARBUOTOJASBindingSource;
        private ld3DataSetTableAdapters.DARBUOTOJASTableAdapter dARBUOTOJASTableAdapter;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.BindingSource dARBUOTOJASBindingSource1;
        private System.Windows.Forms.BindingSource dARBUOTOJASBindingSource2;
        private System.Windows.Forms.BindingSource dARBUOTOJASBindingSource3;
        private System.Windows.Forms.BindingSource dARBUOTOJASBindingSource4;
        private System.Windows.Forms.BindingSource dARBUOTOJASBindingSource5;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

