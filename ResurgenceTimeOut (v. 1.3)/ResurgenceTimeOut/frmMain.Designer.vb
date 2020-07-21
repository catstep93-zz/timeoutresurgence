<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudScheduleMean = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudItems = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbLeft = New System.Windows.Forms.ComboBox()
        Me.cmbMiddle = New System.Windows.Forms.ComboBox()
        Me.cmbRight = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.nudPhase1Duration = New System.Windows.Forms.NumericUpDown()
        Me.nudPhase2Duration = New System.Windows.Forms.NumericUpDown()
        Me.nudPhase3Duration = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudTimeOutDuration = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nudComponentDuration = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbFirstComponent = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtParticipantID = New System.Windows.Forms.TextBox()
        Me.txtExperimenterID = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbSessionNumber = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnChangeParameters = New System.Windows.Forms.Button()
        CType(Me.nudScheduleMean, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPhase1Duration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPhase2Duration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPhase3Duration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTimeOutDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudComponentDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(367, 427)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(132, 44)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "VI Value (s):"
        '
        'nudScheduleMean
        '
        Me.nudScheduleMean.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudScheduleMean.Location = New System.Drawing.Point(171, 38)
        Me.nudScheduleMean.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudScheduleMean.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.nudScheduleMean.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudScheduleMean.Name = "nudScheduleMean"
        Me.nudScheduleMean.Size = New System.Drawing.Size(66, 35)
        Me.nudScheduleMean.TabIndex = 2
        Me.nudScheduleMean.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 78)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 29)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "# VI Values:"
        '
        'nudItems
        '
        Me.nudItems.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudItems.Location = New System.Drawing.Point(171, 78)
        Me.nudItems.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudItems.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.nudItems.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudItems.Name = "nudItems"
        Me.nudItems.Size = New System.Drawing.Size(66, 35)
        Me.nudItems.TabIndex = 4
        Me.nudItems.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 34)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 29)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Left Lever:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 74)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(172, 29)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Middle Lever:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 115)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 29)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Right Lever:"
        '
        'cmbLeft
        '
        Me.cmbLeft.FormattingEnabled = True
        Me.cmbLeft.Items.AddRange(New Object() {"Target", "Alternative", "Control"})
        Me.cmbLeft.Location = New System.Drawing.Point(198, 31)
        Me.cmbLeft.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbLeft.Name = "cmbLeft"
        Me.cmbLeft.Size = New System.Drawing.Size(180, 37)
        Me.cmbLeft.TabIndex = 8
        '
        'cmbMiddle
        '
        Me.cmbMiddle.FormattingEnabled = True
        Me.cmbMiddle.Items.AddRange(New Object() {"Target", "Alternative", "Control"})
        Me.cmbMiddle.Location = New System.Drawing.Point(198, 71)
        Me.cmbMiddle.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbMiddle.Name = "cmbMiddle"
        Me.cmbMiddle.Size = New System.Drawing.Size(180, 37)
        Me.cmbMiddle.TabIndex = 9
        '
        'cmbRight
        '
        Me.cmbRight.FormattingEnabled = True
        Me.cmbRight.Items.AddRange(New Object() {"Target", "Alternative", "Control"})
        Me.cmbRight.Location = New System.Drawing.Point(198, 112)
        Me.cmbRight.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbRight.Name = "cmbRight"
        Me.cmbRight.Size = New System.Drawing.Size(180, 37)
        Me.cmbRight.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 31)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(286, 29)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Phase 1 Duration (min):"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 72)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(286, 29)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Phase 2 Duration (min):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 114)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(286, 29)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Phase 3 Duration (min):"
        '
        'nudPhase1Duration
        '
        Me.nudPhase1Duration.DecimalPlaces = 1
        Me.nudPhase1Duration.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudPhase1Duration.Location = New System.Drawing.Point(305, 29)
        Me.nudPhase1Duration.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudPhase1Duration.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.nudPhase1Duration.Name = "nudPhase1Duration"
        Me.nudPhase1Duration.Size = New System.Drawing.Size(105, 35)
        Me.nudPhase1Duration.TabIndex = 14
        Me.nudPhase1Duration.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'nudPhase2Duration
        '
        Me.nudPhase2Duration.DecimalPlaces = 1
        Me.nudPhase2Duration.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudPhase2Duration.Location = New System.Drawing.Point(305, 70)
        Me.nudPhase2Duration.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudPhase2Duration.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.nudPhase2Duration.Name = "nudPhase2Duration"
        Me.nudPhase2Duration.Size = New System.Drawing.Size(105, 35)
        Me.nudPhase2Duration.TabIndex = 15
        Me.nudPhase2Duration.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'nudPhase3Duration
        '
        Me.nudPhase3Duration.DecimalPlaces = 1
        Me.nudPhase3Duration.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudPhase3Duration.Location = New System.Drawing.Point(305, 112)
        Me.nudPhase3Duration.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudPhase3Duration.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.nudPhase3Duration.Name = "nudPhase3Duration"
        Me.nudPhase3Duration.Size = New System.Drawing.Size(105, 35)
        Me.nudPhase3Duration.TabIndex = 16
        Me.nudPhase3Duration.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 118)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(308, 29)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Min Timeout Duration (s):"
        '
        'nudTimeOutDuration
        '
        Me.nudTimeOutDuration.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudTimeOutDuration.Location = New System.Drawing.Point(338, 116)
        Me.nudTimeOutDuration.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudTimeOutDuration.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.nudTimeOutDuration.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTimeOutDuration.Name = "nudTimeOutDuration"
        Me.nudTimeOutDuration.Size = New System.Drawing.Size(66, 35)
        Me.nudTimeOutDuration.TabIndex = 22
        Me.nudTimeOutDuration.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 158)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(326, 29)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Component Duration (min):"
        '
        'nudComponentDuration
        '
        Me.nudComponentDuration.DecimalPlaces = 1
        Me.nudComponentDuration.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudComponentDuration.Location = New System.Drawing.Point(344, 158)
        Me.nudComponentDuration.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudComponentDuration.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudComponentDuration.Name = "nudComponentDuration"
        Me.nudComponentDuration.Size = New System.Drawing.Size(66, 35)
        Me.nudComponentDuration.TabIndex = 24
        Me.nudComponentDuration.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 156)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(213, 29)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "First Component:"
        '
        'cmbFirstComponent
        '
        Me.cmbFirstComponent.FormattingEnabled = True
        Me.cmbFirstComponent.Items.AddRange(New Object() {"Timeout", "No Timeout"})
        Me.cmbFirstComponent.Location = New System.Drawing.Point(218, 148)
        Me.cmbFirstComponent.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbFirstComponent.Name = "cmbFirstComponent"
        Me.cmbFirstComponent.Size = New System.Drawing.Size(154, 37)
        Me.cmbFirstComponent.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 31)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(176, 29)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Participant ID:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 72)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(259, 29)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Experimenter Initials:"
        '
        'txtParticipantID
        '
        Me.txtParticipantID.Location = New System.Drawing.Point(194, 28)
        Me.txtParticipantID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtParticipantID.Name = "txtParticipantID"
        Me.txtParticipantID.Size = New System.Drawing.Size(178, 35)
        Me.txtParticipantID.TabIndex = 29
        '
        'txtExperimenterID
        '
        Me.txtExperimenterID.Location = New System.Drawing.Point(272, 69)
        Me.txtExperimenterID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtExperimenterID.Name = "txtExperimenterID"
        Me.txtExperimenterID.Size = New System.Drawing.Size(100, 35)
        Me.txtExperimenterID.TabIndex = 30
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 114)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(135, 29)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Session #:"
        '
        'cmbSessionNumber
        '
        Me.cmbSessionNumber.FormattingEnabled = True
        Me.cmbSessionNumber.Items.AddRange(New Object() {"1", "2"})
        Me.cmbSessionNumber.Location = New System.Drawing.Point(144, 110)
        Me.cmbSessionNumber.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbSessionNumber.Name = "cmbSessionNumber"
        Me.cmbSessionNumber.Size = New System.Drawing.Size(64, 37)
        Me.cmbSessionNumber.TabIndex = 32
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cmbSessionNumber)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmbFirstComponent)
        Me.GroupBox1.Controls.Add(Me.txtExperimenterID)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtParticipantID)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(30, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(404, 211)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Session Info"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 31)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(0, 29)
        Me.Label15.TabIndex = 27
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Silver
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.nudComponentDuration)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.nudPhase1Duration)
        Me.GroupBox2.Controls.Add(Me.nudPhase2Duration)
        Me.GroupBox2.Controls.Add(Me.nudPhase3Duration)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(440, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(428, 211)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Duration"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Silver
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cmbLeft)
        Me.GroupBox3.Controls.Add(Me.cmbMiddle)
        Me.GroupBox3.Controls.Add(Me.cmbRight)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(30, 240)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(404, 163)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lever Assignment"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 31)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(0, 29)
        Me.Label16.TabIndex = 27
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 31)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(0, 29)
        Me.Label18.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 31)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(0, 29)
        Me.Label17.TabIndex = 27
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Silver
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.nudScheduleMean)
        Me.GroupBox4.Controls.Add(Me.nudTimeOutDuration)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.nudItems)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(440, 240)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(428, 163)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Reinforcement Schedule"
        '
        'btnChangeParameters
        '
        Me.btnChangeParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeParameters.Location = New System.Drawing.Point(252, 481)
        Me.btnChangeParameters.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnChangeParameters.Name = "btnChangeParameters"
        Me.btnChangeParameters.Size = New System.Drawing.Size(351, 44)
        Me.btnChangeParameters.TabIndex = 36
        Me.btnChangeParameters.Text = "Change Session Parameters"
        Me.btnChangeParameters.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(900, 545)
        Me.Controls.Add(Me.btnChangeParameters)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnStart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmMain"
        Me.Text = "Resurgence & Timeout v. 1.3 2/16/2020"
        CType(Me.nudScheduleMean, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPhase1Duration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPhase2Duration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPhase3Duration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTimeOutDuration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudComponentDuration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnStart As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents nudScheduleMean As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents nudItems As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbLeft As ComboBox
    Friend WithEvents cmbMiddle As ComboBox
    Friend WithEvents cmbRight As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents nudPhase1Duration As NumericUpDown
    Friend WithEvents nudPhase2Duration As NumericUpDown
    Friend WithEvents nudPhase3Duration As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents nudTimeOutDuration As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents nudComponentDuration As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbFirstComponent As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtParticipantID As TextBox
    Friend WithEvents txtExperimenterID As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbSessionNumber As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnChangeParameters As Button
End Class
