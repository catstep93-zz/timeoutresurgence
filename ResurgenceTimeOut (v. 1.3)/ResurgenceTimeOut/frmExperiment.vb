
Imports System.IO

' This version requires the support file entitled
' VI_and_VR.vb

'Program created by Catherine Williams (2020)

Public Class frmExperiment
    Const mc_strPathList As String = "C:\TimeOutPathList.txt"
    Dim m_strDataFilePath As String
    Dim m_strRawDataFileName As String
    Dim m_strSessionStartTime As String
    Dim m_btnButton As Button
    Dim m_intPoints As Integer
    Dim m_intTargetPress As Integer
    Dim m_intAlternativePress As Integer
    Dim m_intControlPress As Integer
    Dim m_boolSR As Boolean
    Dim m_intSchedule() As Integer
    Dim m_intCount As Integer = 0
    Dim m_intTimeLastSR As Integer
    Dim m_strLeftLever As String
    Dim m_strMiddleLever As String
    Dim m_strRightLever As String
    Dim m_intScheduleItem As Integer
    Dim m_intResponseTime As Integer
    Dim m_intPhaseNumber As Integer = 1 '1: Target; 2: Alt; 3: Ext
    Dim m_intSessionStartTime As Integer
    Dim m_boolTimeOut As Boolean
    Dim m_dblTimeinTimeOutSinceSR As Double
    Dim m_intEventsPhase As Integer
    Dim m_intData(1, 0) As Integer
    Dim m_strDurations(1, 10, 0) As String
    Dim m_sngCumulativeTimeinTimeOutDuringComponent As Single
    Dim m_sngCumulativeTimeinConsumatoryDuringComponent As Single
    Dim m_intTargetPressTO As Integer
    Dim m_intAlternativePressTO As Integer
    Dim m_intControlPressTO As Integer
    Dim m_intSR As Integer
    Dim m_intCurrentComponentNumber As Integer
    Dim m_intComponentNumber As Integer
    Dim m_boolCurrentTimeOutStatus As Boolean
    Dim m_boolConsumatory As Boolean
    Public Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vKey As Integer) As Boolean
    Dim m_boolSessionEnded As Boolean = False

    Private Sub btnMiddle_MouseHover(sender As Object, e As EventArgs) Handles btnMiddle.MouseHover, btnRight.MouseHover, btnLeft.MouseHover
        PreventColorChange(btnMiddle)
    End Sub

    Private Sub btnStartExperiment_Click(sender As Object, e As EventArgs) Handles btnStartExperiment.Click
        m_strSessionStartTime = Now
        m_intSessionStartTime = Environment.TickCount
        ActivateButtons(True)
        btnStartExperiment.Visible = False
        lblPoints.Visible = True
        ReDim m_intSchedule(CInt(frmMain.nudItems.Value) + 1)
        CheckSchedule()
        m_strLeftLever = frmMain.cmbLeft.SelectedItem
        m_strMiddleLever = frmMain.cmbMiddle.SelectedItem
        m_strRightLever = frmMain.cmbRight.SelectedItem
        If frmMain.cmbFirstComponent.SelectedItem = "Timeout" Then
            m_boolTimeOut = True
            Me.BackColor = Color.Red
            labelcolor()
        Else
            m_boolTimeOut = False
            Me.BackColor = Color.Blue
            labelcolor()
        End If
        tmrTimeOut.Interval = frmMain.nudTimeOutDuration.Value * 1000
        tmrPhase.Interval = frmMain.nudPhase1Duration.Value * 60000
        tmrComponent.Interval = frmMain.nudComponentDuration.Value * 60000
        tmrPhase.Enabled = True
        tmrComponent.Enabled = True
    End Sub

    Private Sub ActivateButtons(boolOnOff As Boolean)
        btnMiddle.Visible = boolOnOff
        btnRight.Visible = boolOnOff
        btnLeft.Visible = boolOnOff
    End Sub

    Private Sub PreventColorChange(btnButtonName As Button)
        btnButtonName.BackColor = Color.Black
        btnButtonName.ForeColor = Color.Black
    End Sub

    Private Sub tmrClicked_Tick(sender As Object, e As EventArgs) Handles tmrClicked.Tick
        tmrClicked.Enabled = False
        ButtonFeedback(False)
    End Sub

    Private Sub ButtonFeedback(boolOnOff As Boolean)
        If boolOnOff = True Then
            m_btnButton.BackColor = Color.Gray
            m_btnButton.ForeColor = Color.Gray
            tmrClicked.Enabled = True
        Else
            m_btnButton.BackColor = Color.Black
            m_btnButton.ForeColor = Color.Black
            tmrClicked.Enabled = False
        End If
    End Sub

    Private Sub btnLeft_MouseDown(sender As Object, e As MouseEventArgs) Handles btnLeft.MouseDown
        CheckTerminateKey()
        m_btnButton = btnLeft
        ButtonFeedback(True)
        SelectConsequence(m_strLeftLever)
    End Sub

    Private Sub btnMiddle_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMiddle.MouseDown
        m_btnButton = btnMiddle
        ButtonFeedback(True)
        SelectConsequence(m_strMiddleLever)
    End Sub

    Private Sub btnRight_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRight.MouseDown
        m_btnButton = btnRight
        ButtonFeedback(True)
        SelectConsequence(m_strRightLever)
    End Sub

    Private Sub SelectConsequence(strLeverName As String)
        m_intResponseTime = Environment.TickCount
        Dim dblIntervalSinceLastSR As Double
        Dim dblTimeInInterval As Double
        Select Case strLeverName
            Case "Target"
                CollectData("target", intCalcTimeSince())
                If m_intPhaseNumber = 1 Then
                    dblIntervalSinceLastSR = m_intResponseTime - m_intTimeLastSR
                    If dblIntervalSinceLastSR > m_intScheduleItem Then
                        Consumatory(True)
                        m_dblTimeinTimeOutSinceSR = 0
                    End If
                End If
                If m_intPhaseNumber = 2 Then
                    If m_boolTimeOut = True Then
                        dblIntervalSinceLastSR = m_intResponseTime - m_intTimeLastSR 'this if statement makes sure that the requirement is only recalculated if it is not already been met
                        If dblIntervalSinceLastSR < m_intScheduleItem Then
                            'lblPreviousrequirement.Text = m_intScheduleItem 'schedule item before timeout
                            dblTimeInInterval = m_intResponseTime - m_intTimeLastSR 'calculates how much of the interval had passed when timeout started SOMETHING IS WRONG WITH TIMELASTSR
                            m_intScheduleItem = m_intScheduleItem - dblTimeInInterval 'changes interval after timeout to be the portion of the original interval that remains
                            'lblTimeSinceSR.Text = dblTimeInInterval 'time since SR+ at start of time out
                            'lblUpdatedRequirement.Text = m_intScheduleItem 'update time to meet after timeout
                        End If
                        TimeOut(True)
                    End If
                    If tmrTimeOut.Enabled = True Then
                        tmrTimeOut.Enabled = False
                        tmrTimeOut.Enabled = True
                    End If
                End If
                If tmrTimeOut.Enabled = False Then
                    m_intTargetPress += 1
                ElseIf tmrTimeOut.Enabled = True Then
                    m_intTargetPressTO += 1
                End If
            Case "Alternative"
                CollectData("alternative", intCalcTimeSince())
                If m_intPhaseNumber = 2 Then
                    If tmrTimeOut.Enabled = False Then
                        dblIntervalSinceLastSR = m_intResponseTime - m_intTimeLastSR 'm_intTimeLastSR needs to change to time since end of timeout
                        'lblintScheduleItem.Text = CStr(m_intScheduleItem)
                        'lblinttimelastsr.Text = CStr(dblIntervalSinceLastSR)
                        If dblIntervalSinceLastSR > m_intScheduleItem Then
                            Consumatory(True)
                        End If
                    End If
                End If
                If tmrTimeOut.Enabled = False Then
                    m_intAlternativePress += 1
                ElseIf tmrTimeOut.Enabled = True Then
                    m_intAlternativePressTO += 1
                End If
            Case "Control"
                CollectData("control", intCalcTimeSince())
                If tmrTimeOut.Enabled = False Then
                    m_intControlPress += 1
                ElseIf tmrTimeOut.Enabled = True Then
                    m_intControlPressTO += 1
                End If
        End Select
    End Sub

    Private Sub CheckSchedule()
        Dim intScheduleMean As Integer
        If m_intCount > frmMain.nudItems.Value + 1 Then
            ' reset counter
            m_intCount = 1
        End If
        m_intCount += 1
        intScheduleMean = frmMain.nudScheduleMean.Value * 1000 'times 1000 to make second ms
        m_intScheduleItem = NextVI(m_intSchedule, intScheduleMean)
        'ListBox1.Items.Add(CStr(m_intScheduleItem))
        ' reset counter if needed
    End Sub

    Private Sub frmExperiment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrClicked.Interval = 100
    End Sub

    Private Sub btnPoints_Click(sender As Object, e As EventArgs) Handles btnPoints.Click
        m_intPoints += 1
        lblPoints.Text = "Points: " & CStr(m_intPoints)
        Consumatory(False)
        m_intTimeLastSR = Environment.TickCount
    End Sub

    Private Sub Consumatory(OnOff As Boolean)
        Static intTimeStartConsumatory As Integer
        Static intTimeStopConsumatory As Integer
        Dim intTimeinConsumatory As Integer
        grpConsumatory.BackColor = Color.White
        grpConsumatory.Visible = OnOff
        If OnOff = False Then 'this should happen when consumatory turned off
            intTimeStopConsumatory = intCalcTimeSince()
            CollectData("ConRS stop", intTimeStopConsumatory)
            intTimeinConsumatory = intTimeStopConsumatory - intTimeStartConsumatory
            m_sngCumulativeTimeinConsumatoryDuringComponent += intTimeinConsumatory
            'ListBox2.Items.Add(m_sngCumulativeTimeinConsumatoryDuringComponent)
            ActivateButtons(True)
            CheckSchedule() 'gets next interval ready
            m_intSR += 1
            m_boolConsumatory = False
        Else
            intTimeStartConsumatory = intCalcTimeSince()
            CollectData("ConRS start", intTimeStartConsumatory)
            m_boolConsumatory = True
            ActivateButtons(False)
        End If
    End Sub

    Private Sub TimeOut(OnOff As Boolean)
        Static intTimeEndTimeout As Integer
        Static intTimeStartTimeout As Integer
        Dim intTimeInTimeout As Integer
        lblTimeOut.Visible = OnOff
        If OnOff = False Then 'time out ends
            intTimeEndTimeout = intCalcTimeSince()
            CollectData("TO stop", intCalcTimeSince())
            intTimeInTimeout = intTimeEndTimeout - intTimeStartTimeout
            m_sngCumulativeTimeinTimeOutDuringComponent += intTimeInTimeout
            Me.BackColor = Color.Red
            labelcolor()
            m_boolSR = True
            tmrTimeOut.Enabled = False
            m_intTimeLastSR = Environment.TickCount
        Else 'time out starts
            intTimeStartTimeout = intCalcTimeSince()
            CollectData("TO start", intCalcTimeSince())
            Me.BackColor = Color.Silver
            labelcolor()
            m_boolSR = False
            tmrTimeOut.Enabled = True
        End If
    End Sub

    Private Sub labelcolor()
        lblPoints.BackColor = Color.White
        lblTimeOut.BackColor = Color.White
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'CheckSchedule("btnLeft")
    End Sub


    Private Sub frmExperiment_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        CollectData("off screen", intCalcTimeSince())
    End Sub

    Private Sub tmrPhase_Tick(sender As Object, e As EventArgs) Handles tmrPhase.Tick
        tmrPhase.Enabled = False
        m_intPhaseNumber += 1
        Select Case m_intPhaseNumber
            Case 2 'end of target SR+; Start alt SR+
                tmrPhase.Interval = frmMain.nudPhase2Duration.Value * 60000
                tmrPhase.Enabled = True
                'm_intEventsPhase = 0
            Case 3 'end of alter SR+; Start ext
                tmrPhase.Interval = frmMain.nudPhase3Duration.Value * 60000
                tmrPhase.Enabled = True
                'm_intEventsPhase = 0
            Case 4
                m_intPhaseNumber = 3
                CollectData("Session Ended", intCalcTimeSince())
                endSession()
        End Select

    End Sub

    Private Sub tmrComponent_Tick(sender As Object, e As EventArgs) Handles tmrComponent.Tick
        Dim intComponentNumber As Integer
        If m_boolTimeOut = True Then
            If tmrTimeOut.Enabled = True Then
                TimeOut(False)
            End If
            Me.BackColor = Color.Blue
            labelcolor()
            m_intTimeLastSR = Environment.TickCount
            CollectData("Red -> Blue", intCalcTimeSince())
            m_boolTimeOut = False 'changes to other component
            CheckSchedule()
        Else
            Me.BackColor = Color.Red
            labelcolor()
            m_intTimeLastSR = Environment.TickCount
            CollectData("Blue -> Red", intCalcTimeSince())
            m_boolTimeOut = True
            CheckSchedule()
        End If
        If m_boolConsumatory = True Then
            Consumatory(False)
        End If
        intComponentNumber += 1
        m_sngCumulativeTimeinTimeOutDuringComponent = 0
        m_sngCumulativeTimeinConsumatoryDuringComponent = 0
        m_intTargetPress = 0 'added 1/29 3:35pm
        m_intAlternativePress = 0
        m_intControlPress = 0
        m_intTargetPressTO = 0
        m_intAlternativePressTO = 0
        m_intControlPressTO = 0
        m_intSR = 0
    End Sub

    Private Sub tmrTimeOut_Tick(sender As Object, e As EventArgs) Handles tmrTimeOut.Tick
        TimeOut(False)
    End Sub

    Private Sub endSession()
        m_boolSessionEnded = True
        If m_boolTimeOut = True Then
            CalculateComponentData(False)
        Else
            CalculateComponentData(True)
        End If
        tmrComponent.Enabled = False
        tmrPhase.Enabled = False
        tmrTimeOut.Enabled = False
        tmrClicked.Enabled = False
        ActivateButtons(0)
        lblSessionEnd.Location = New System.Drawing.Point(Me.Width / 2 - lblSessionEnd.Width / 2, Me.Height / 2)
        lblSessionEnd.Visible = True
        Me.BackColor = Color.White
        WriteDataFile()
    End Sub

    Public Function TerminateKeyPressed() As Boolean
        If GetAsyncKeyState(System.Windows.Forms.Keys.T) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub CheckTerminateKey()
        If TerminateKeyPressed() = True Then
            If m_intPhaseNumber <> 4 Then
                endSession()
            End If
            Me.Close()
            frmBlack.Close()
            frmMain.Close()
        End If
    End Sub

    '______________________DATA COLLECTION FILES_________________________

    Private Function intCalcTimeSince() As Integer
        Dim intCurrentTime = Environment.TickCount
        Dim intTimeSince As Integer
        intTimeSince = intCurrentTime - m_intSessionStartTime
        Return intTimeSince
    End Function

    Private Sub CollectData(strEvent As String, intTime As Integer)
        Dim intEvent As Integer
        Select Case strEvent
            Case = "target"
                intEvent = 1
            Case = "alternative"
                intEvent = 2
            Case = "control"
                intEvent = 3
            Case = "off screen"
                intEvent = 4
            Case = "TO start"
                intEvent = 5
            Case = "TO stop"
                intEvent = 6
            Case = "ConRS start"
                intEvent = 7
            Case = "ConRS stop"
                intEvent = 8
            Case = "Red -> Blue"
                CalculateComponentData(False) 'false is red, true is blue
                intEvent = 50
            Case = "Blue -> Red"
                CalculateComponentData(True) 'false is red, true is blue
                intEvent = 51
            Case = "Session Ended"
                intEvent = 99
            Case = "Session Terminated"
                intEvent = 98
        End Select
        m_intData(1, m_intEventsPhase) = intTime '1=event time
        m_intData(0, m_intEventsPhase) = intEvent '0=event code 
        m_intEventsPhase += 1 'resets at start of each phase
        ReDim Preserve m_intData(1, m_intEventsPhase)
    End Sub

    Private Sub CalculateComponentData(boolComponent As Boolean)
        Dim intComponent As Integer
        Dim sngTimeIn As Integer
        sngTimeIn = sngCalcTimeIn() 'seconds
        'TextBox1.Text = CStr(boolComponent)
        'TextBox2.Text = m_intCurrentComponentNumber
        If boolComponent = True Then
            intComponent = 0 'blue
        Else intComponent = 1 'red
        End If
        m_strDurations(intComponent, 0, m_intComponentNumber) = (sngTimeIn / 60000).ToString("n2") 'min
        m_strDurations(intComponent, 1, m_intComponentNumber) = (m_intTargetPress / (sngTimeIn / 60000)).ToString("n2") 'per min
        m_strDurations(intComponent, 2, m_intComponentNumber) = (m_intAlternativePress / (sngTimeIn / 60000)).ToString("n2") 'per min
        m_strDurations(intComponent, 3, m_intComponentNumber) = (m_intControlPress / (sngTimeIn / 60000)).ToString("n2") 'per min
        m_strDurations(intComponent, 4, m_intComponentNumber) = (m_sngCumulativeTimeinConsumatoryDuringComponent / 60000).ToString("n2")
        m_strDurations(intComponent, 5, m_intComponentNumber) = (m_sngCumulativeTimeinTimeOutDuringComponent / 60000).ToString("n2")
        m_strDurations(intComponent, 6, m_intComponentNumber) = (m_intTargetPressTO / (sngTimeIn / 60000)).ToString("n2") 'per min
        m_strDurations(intComponent, 7, m_intComponentNumber) = (m_intAlternativePressTO / (sngTimeIn / 60000)).ToString("n2") 'per min
        m_strDurations(intComponent, 8, m_intComponentNumber) = (m_intControlPressTO / (sngTimeIn / 60000)).ToString("n2") 'per min
        m_strDurations(intComponent, 9, m_intComponentNumber) = m_intSR.ToString("n2")
        m_strDurations(intComponent, 10, m_intComponentNumber) = (m_intSR / (sngTimeIn / 60000)).ToString("n2") 'per min
        If m_boolSessionEnded = False Then

            If m_intCurrentComponentNumber = 1 Then 'don't do this if session has ended
                m_intComponentNumber += 1
                ReDim Preserve m_strDurations(1, 10, (m_intComponentNumber))
                m_intCurrentComponentNumber = 0
            Else
                m_intCurrentComponentNumber = 1
            End If
        End If
    End Sub

    Private Function sngCalcTimeIn() As Single
        Dim sngTimeIn As Single
        sngTimeIn = ((tmrComponent.Interval - m_sngCumulativeTimeinTimeOutDuringComponent - m_sngCumulativeTimeinConsumatoryDuringComponent)) 'total time in component-time in timout-time in consumatory respone
        Return sngTimeIn
    End Function

    '______________________RESULT FILE CREATION__________________________

    Private Sub WriteDataFile()
        Dim ReadDataPaths As New StreamReader(New FileStream(mc_strPathList, FileMode.Open, FileAccess.Read))
        m_strDataFilePath = ReadDataPaths.ReadLine
        ReadDataPaths.Close()
        Dim swWriteResults As StreamWriter
        m_strRawDataFileName = m_strDataFilePath & " Results for " & frmMain.txtParticipantID.Text & " for Session " & frmMain.cmbSessionNumber.SelectedItem & ".txt"
        swWriteResults = File.CreateText(m_strRawDataFileName)
        'write header
        swWriteResults.WriteLine(" ")
        swWriteResults.WriteLine("Session Summary_________________________________________________________")
        swWriteResults.WriteLine("  Results for Participant " & frmMain.txtParticipantID.Text & " on " & DateString)
        swWriteResults.WriteLine("  Session Conducted By " & frmMain.txtExperimenterID.Text)
        swWriteResults.WriteLine("  Left Lever: " & CStr(frmMain.cmbLeft.SelectedItem))
        swWriteResults.WriteLine("  Middle Lever: " & CStr(frmMain.cmbMiddle.SelectedItem))
        swWriteResults.WriteLine("  Right Lever: " & CStr(frmMain.cmbRight.SelectedItem))
        swWriteResults.WriteLine("  Phase 1 Duration = " & CStr(frmMain.nudPhase1Duration.Value) & " min")
        swWriteResults.WriteLine("  Phase 2 Duration = " & CStr(frmMain.nudPhase2Duration.Value) & " min")
        swWriteResults.WriteLine("  Phase 3 Duration = " & CStr(frmMain.nudPhase3Duration.Value) & " min")
        swWriteResults.WriteLine("  Component Duration = " & CStr(frmMain.nudComponentDuration.Value) & " min")
        swWriteResults.WriteLine("  First Component: " & CStr(frmMain.cmbFirstComponent.Text))
        swWriteResults.WriteLine("  Minimum Time Out Duration: " & CStr(frmMain.nudTimeOutDuration.Value) & " s")
        swWriteResults.WriteLine("  VI Value = " & CStr(frmMain.nudScheduleMean.Value) & " s")
        swWriteResults.WriteLine("  # VI Values = " & CStr(frmMain.nudItems.Value))
        swWriteResults.WriteLine("  Session Start Time: " & m_strSessionStartTime)
        swWriteResults.WriteLine("  Session End Time: " & Now)
        swWriteResults.WriteLine("")
        swWriteResults.WriteLine("Session Data___________________________________________________________")
        swWriteResults.WriteLine("")
        swWriteResults.WriteLine("No Time Out (Blue) Component_________________________________________________________")
        swWriteResults.WriteLine("Time in(min)  TR Rate  AR Rate  CR Rate  #SR+    SR+/min  Consum(min)    TO(min)  TR Rate(TO)  AR Rate(TO) CR Rate(TO)")
        For i As Integer = 0 To m_intComponentNumber
            swWriteResults.WriteLine(m_strDurations(0, 0, i) & "           " & m_strDurations(0, 1, i) & "    " & m_strDurations(0, 2, i) & "     " & m_strDurations(0, 3, i) & "     " & m_strDurations(0, 9, i) & "        " & m_strDurations(0, 10, i) & "    " & m_strDurations(0, 4, i) & "     " & m_strDurations(0, 5, i) & "       " & m_strDurations(0, 6, i) & "         " & m_strDurations(0, 7, i) & "        " & m_strDurations(0, 8, i))
        Next
        swWriteResults.WriteLine("")
        swWriteResults.WriteLine("Time Out (Red) Component_____________________________________________________________")
        swWriteResults.WriteLine("Time in(min)  TR Rate  AR Rate  CR Rate  #SR+    SR+/min  Consum(min)    TO(min)  TR Rate(TO)  AR Rate(TO) CR Rate(TO)")
        For i As Integer = 0 To m_intComponentNumber
            swWriteResults.WriteLine(m_strDurations(1, 0, i) & "           " & m_strDurations(1, 1, i) & "    " & m_strDurations(1, 2, i) & "     " & m_strDurations(1, 3, i) & "     " & m_strDurations(1, 9, i) & "        " & m_strDurations(1, 10, i) & "    " & m_strDurations(1, 4, i) & "     " & m_strDurations(1, 5, i) & "        " & m_strDurations(1, 6, i) & "         " & m_strDurations(1, 7, i) & "        " & m_strDurations(1, 8, i))
        Next
        swWriteResults.WriteLine("")
        swWriteResults.WriteLine("**Event Codes**")
        swWriteResults.WriteLine("1 = Target Response")
        swWriteResults.WriteLine("2 = Alternative Response")
        swWriteResults.WriteLine("3 = Control Response")
        swWriteResults.WriteLine("4 = Off-Key Response")
        swWriteResults.WriteLine("5 = Start of Time Out")
        swWriteResults.WriteLine("6 = Stop of Time Out")
        swWriteResults.WriteLine("7 = Start of Consumatory Response")
        swWriteResults.WriteLine("8 = End of Consumatory Response")
        swWriteResults.WriteLine("50 = Switch from Red to Blue")
        swWriteResults.WriteLine("51 = Switch from Blue to Red")
        swWriteResults.WriteLine("98 = session ended")
        swWriteResults.WriteLine("99 = session ended")
        For i As Integer = 0 To m_intEventsPhase
            For j As Integer = 0 To 1
                If m_intData(j, i) <> 0 Then
                    swWriteResults.WriteLine(CStr(m_intData(j, i)))
                End If
            Next
        Next

        swWriteResults.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        'WriteDataFile()
        Me.Close()
        frmBlack.Close()
        frmMain.Close()
    End Sub

    Private Sub lblPoints_Click(sender As Object, e As EventArgs) Handles lblPoints.Click
        CheckTerminateKey()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click

    End Sub







    '______________________DATA CALCULATIONS___________________________
End Class