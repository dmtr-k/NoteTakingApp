namespace NoteTakingApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBoxContent = new RichTextBox();
            titleTextBox = new TextBox();
            titleLabel = new Label();
            noteLabel = new Label();
            dataGridViewNotes = new DataGridView();
            newButton = new Button();
            saveButton = new Button();
            openButton = new Button();
            deleteButton = new Button();
            exportButton = new Button();
            searchTitleTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).BeginInit();
            SuspendLayout();
            // 
            // richTextBoxContent
            // 
            richTextBoxContent.Location = new Point(156, 85);
            richTextBoxContent.Name = "richTextBoxContent";
            richTextBoxContent.Size = new Size(362, 274);
            richTextBoxContent.TabIndex = 0;
            richTextBoxContent.Text = "";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(156, 45);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.PlaceholderText = "Enter a title...";
            titleTextBox.Size = new Size(166, 23);
            titleTextBox.TabIndex = 1;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Bookman Old Style", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new Point(61, 40);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(89, 32);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Title:";
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Font = new Font("Bookman Old Style", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            noteLabel.Location = new Point(85, 85);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new Size(58, 21);
            noteLabel.TabIndex = 3;
            noteLabel.Text = "Note:";
            // 
            // dataGridViewNotes
            // 
            dataGridViewNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNotes.Location = new Point(545, 85);
            dataGridViewNotes.Name = "dataGridViewNotes";
            dataGridViewNotes.RowTemplate.Height = 25;
            dataGridViewNotes.Size = new Size(178, 274);
            dataGridViewNotes.TabIndex = 4;
            // 
            // newButton
            // 
            newButton.Location = new Point(156, 369);
            newButton.Name = "newButton";
            newButton.Size = new Size(75, 23);
            newButton.TabIndex = 5;
            newButton.Text = "New";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += newButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(251, 369);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 6;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // openButton
            // 
            openButton.Location = new Point(545, 369);
            openButton.Name = "openButton";
            openButton.Size = new Size(75, 23);
            openButton.TabIndex = 7;
            openButton.Text = "Open";
            openButton.UseVisualStyleBackColor = true;
            openButton.Click += openButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(648, 369);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 8;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // exportButton
            // 
            exportButton.Location = new Point(443, 369);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(75, 23);
            exportButton.TabIndex = 9;
            exportButton.Text = "Export";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // searchTitleTextBox
            // 
            searchTitleTextBox.Location = new Point(545, 45);
            searchTitleTextBox.Name = "searchTitleTextBox";
            searchTitleTextBox.PlaceholderText = "Search a title...";
            searchTitleTextBox.Size = new Size(178, 23);
            searchTitleTextBox.TabIndex = 11;
            searchTitleTextBox.TextChanged += searchTitleTextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(searchTitleTextBox);
            Controls.Add(exportButton);
            Controls.Add(deleteButton);
            Controls.Add(openButton);
            Controls.Add(saveButton);
            Controls.Add(newButton);
            Controls.Add(dataGridViewNotes);
            Controls.Add(noteLabel);
            Controls.Add(titleLabel);
            Controls.Add(titleTextBox);
            Controls.Add(richTextBoxContent);
            Name = "Form1";
            Text = "Notes";
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBoxContent;
        private TextBox titleTextBox;
        private Label titleLabel;
        private Label noteLabel;
        private DataGridView dataGridViewNotes;
        private Button newButton;
        private Button saveButton;
        private Button openButton;
        private Button deleteButton;
        private Button exportButton;
        private TextBox searchTitleTextBox;
    }
}