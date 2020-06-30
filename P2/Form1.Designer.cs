namespace P2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Titlu = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.buttonConnect = new System.Windows.Forms.Button();
            this.stateLabel = new System.Windows.Forms.Label();
            this.buttonDeconnect = new System.Windows.Forms.Button();
            this.labelUmiditate = new System.Windows.Forms.Label();
            this.labelNivel = new System.Windows.Forms.Label();
            this.labelUmidVal = new System.Windows.Forms.Label();
            this.labelNivelVal = new System.Windows.Forms.Label();
            this.comBox = new System.Windows.Forms.ComboBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelProfilUmid = new System.Windows.Forms.Label();
            this.labelCantApa = new System.Windows.Forms.Label();
            this.textBoxUmid = new System.Windows.Forms.TextBox();
            this.textBoxCantApa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Titlu
            // 
            this.Titlu.AutoSize = true;
            this.Titlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlu.Location = new System.Drawing.Point(139, 9);
            this.Titlu.Name = "Titlu";
            this.Titlu.Size = new System.Drawing.Size(646, 39);
            this.Titlu.TabIndex = 0;
            this.Titlu.Text = "Minisistem pentru irigat plante - Proiect 2";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(12, 84);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(87, 24);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Stare uC:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(16, 127);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Conectare";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(105, 84);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(60, 24);
            this.stateLabel.TabIndex = 3;
            this.stateLabel.Text = "label1";
            // 
            // buttonDeconnect
            // 
            this.buttonDeconnect.Location = new System.Drawing.Point(109, 127);
            this.buttonDeconnect.Name = "buttonDeconnect";
            this.buttonDeconnect.Size = new System.Drawing.Size(78, 23);
            this.buttonDeconnect.TabIndex = 4;
            this.buttonDeconnect.Text = "Deconectare";
            this.buttonDeconnect.UseVisualStyleBackColor = true;
            this.buttonDeconnect.Click += new System.EventHandler(this.buttonDeconnect_Click);
            // 
            // labelUmiditate
            // 
            this.labelUmiditate.AutoSize = true;
            this.labelUmiditate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUmiditate.Location = new System.Drawing.Point(13, 233);
            this.labelUmiditate.Name = "labelUmiditate";
            this.labelUmiditate.Size = new System.Drawing.Size(198, 24);
            this.labelUmiditate.TabIndex = 5;
            this.labelUmiditate.Text = "Umiditatea in timp real:";
            // 
            // labelNivel
            // 
            this.labelNivel.AutoSize = true;
            this.labelNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNivel.Location = new System.Drawing.Point(13, 288);
            this.labelNivel.Name = "labelNivel";
            this.labelNivel.Size = new System.Drawing.Size(209, 24);
            this.labelNivel.TabIndex = 6;
            this.labelNivel.Text = "Nivelul apei in timp real:";
            // 
            // labelUmidVal
            // 
            this.labelUmidVal.AutoSize = true;
            this.labelUmidVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUmidVal.Location = new System.Drawing.Point(217, 233);
            this.labelUmidVal.Name = "labelUmidVal";
            this.labelUmidVal.Size = new System.Drawing.Size(60, 24);
            this.labelUmidVal.TabIndex = 7;
            this.labelUmidVal.Text = "label1";
            // 
            // labelNivelVal
            // 
            this.labelNivelVal.AutoSize = true;
            this.labelNivelVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNivelVal.Location = new System.Drawing.Point(228, 288);
            this.labelNivelVal.Name = "labelNivelVal";
            this.labelNivelVal.Size = new System.Drawing.Size(60, 24);
            this.labelNivelVal.TabIndex = 8;
            this.labelNivelVal.Text = "label2";
            // 
            // comBox
            // 
            this.comBox.FormattingEnabled = true;
            this.comBox.Location = new System.Drawing.Point(759, 127);
            this.comBox.Name = "comBox";
            this.comBox.Size = new System.Drawing.Size(121, 21);
            this.comBox.TabIndex = 9;
            this.comBox.SelectedIndexChanged += new System.EventHandler(this.comBox_SelectedIndexChanged);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(523, 197);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(367, 24);
            this.labelDate.TabIndex = 10;
            this.labelDate.Text = "Datele ce vor fi incarcate pe microcontroler";
            // 
            // labelProfilUmid
            // 
            this.labelProfilUmid.AutoSize = true;
            this.labelProfilUmid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProfilUmid.Location = new System.Drawing.Point(547, 273);
            this.labelProfilUmid.Name = "labelProfilUmid";
            this.labelProfilUmid.Size = new System.Drawing.Size(172, 24);
            this.labelProfilUmid.TabIndex = 11;
            this.labelProfilUmid.Text = "Umiditatea de prag:";
            // 
            // labelCantApa
            // 
            this.labelCantApa.AutoSize = true;
            this.labelCantApa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantApa.Location = new System.Drawing.Point(359, 320);
            this.labelCantApa.Name = "labelCantApa";
            this.labelCantApa.Size = new System.Drawing.Size(360, 24);
            this.labelCantApa.TabIndex = 12;
            this.labelCantApa.Text = "Cantitatea de apa cu care se va iriga solul:";
            // 
            // textBoxUmid
            // 
            this.textBoxUmid.Location = new System.Drawing.Point(726, 276);
            this.textBoxUmid.Name = "textBoxUmid";
            this.textBoxUmid.Size = new System.Drawing.Size(164, 20);
            this.textBoxUmid.TabIndex = 13;
            // 
            // textBoxCantApa
            // 
            this.textBoxCantApa.Location = new System.Drawing.Point(726, 324);
            this.textBoxCantApa.Name = "textBoxCantApa";
            this.textBoxCantApa.Size = new System.Drawing.Size(164, 20);
            this.textBoxCantApa.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(538, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Selectarea portului serial";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(770, 373);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(99, 48);
            this.buttonSend.TabIndex = 16;
            this.buttonSend.Text = "Trimitere catre uC";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(17, 337);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(103, 24);
            this.buttonUpdate.TabIndex = 17;
            this.buttonUpdate.Text = "Actualizare Date";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 552);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCantApa);
            this.Controls.Add(this.textBoxUmid);
            this.Controls.Add(this.labelCantApa);
            this.Controls.Add(this.labelProfilUmid);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.comBox);
            this.Controls.Add(this.labelNivelVal);
            this.Controls.Add(this.labelUmidVal);
            this.Controls.Add(this.labelNivel);
            this.Controls.Add(this.labelUmiditate);
            this.Controls.Add(this.buttonDeconnect);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.Titlu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Minisistem pentru irigat plante";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titlu;
        private System.Windows.Forms.Label statusLabel;
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Button buttonDeconnect;
        private System.Windows.Forms.Label labelUmiditate;
        private System.Windows.Forms.Label labelNivel;
        private System.Windows.Forms.Label labelUmidVal;
        private System.Windows.Forms.Label labelNivelVal;
        private System.Windows.Forms.ComboBox comBox;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelProfilUmid;
        private System.Windows.Forms.Label labelCantApa;
        private System.Windows.Forms.TextBox textBoxUmid;
        private System.Windows.Forms.TextBox textBoxCantApa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonUpdate;
    }
}

