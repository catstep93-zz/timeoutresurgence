
' Fleshler-Hoffman VI and VR schedules
' M. Perone, WVU Psyc Dept

' Compliled for VB 2010 on July 5, 2012; comments edited on July 19, 2016
' Originally developed in QuickBasic 4.5; a lot of "old school" code remains. Don't judge!

' Note: The user needs only to call NextVI or NextVR; the other procedures are for internal use.

' * * * VARIABLE INTERVAL * * * 

' To use the Vi schedule, call NextVI. This function returns the next interval in a VI schedule; the 
' intervals in the list will be returned in random order. Once all of them have been used, another random-ordered
' list of intervals generated automatically.

' The function requires two arguments: 
' 1. a single-dimension Integer array, and
' 2. the mean of the desired VR schedule in milliseconds

' The upper bound of the array must be be ONE MORE than the number
' of intervals in the desired schedule(e.g., if one wanted a schedule
' with 12 intervals, the Dim statement might be: Dim intMyVI(13) as Integer.

' * * * VARIABLE RATIO * * * 

' To use the VR schedule, call NextVR. This function returns the next ratio in a VR schedule; the 
' ratios in the list are returned in random order. Once all of them have been used, another random-ordered
' list of ratios generated automatically.  

' The function requires two arguments: 
' 1. a single-dimension Integer array, and
' 2. the mean of the desired VR schedule in responses.

' The upper bound of the array must be be ONE MORE than the number
' of ratios in the desired schedule(e.g., if one wanted a schedule
' with 12 ratios, the Dim statement might be: Dim intMyVR(13) as Integer.


Module VI_and_VR

    Dim GetRandomInteger As New Random

    Public Function NextVI(ByRef intVIarray() As Integer, ByRef intVImean As Integer) As Integer

        ' This function returns the next interval in a VI schedule.  The interval
        ' is selected at random from the viArray().  As each interval is used, it
        ' is replaced with a -99 so that it is not used.  In other words, the
        ' intervals are selected at  random without replacement.

        ' The function requires two arguments: a single-dimension Integer array
        ' and the mean of the desired VI schedule in milliseconds.
        ' The array must be dimensioned with an upper boundary equal to the number
        ' of intervals in the desired schedule PLUS ONE (e.g., if one wanted a schedule
        ' with 12 intervals, the Dim statement might be: Dim initVI( 13) as Integer.
        ' The first 12 cells are used for the list of intervals and the 13th
        ' is used as a counter to keep rack of the number of used interval.

        ' The first time the function is called, it will call the SetUpVI sub to
        ' generate the Fleshler-Hoffman VI sequences.  When all of the intervals
        ' have been used, the function will recall SetUpVI to renew the list.  
        ' These calls to SetUpVI are made by the NextVI function; the user need not
        ' worry about it.

        Dim i, intMax As Integer
        Dim intInterval As Integer
        Static intCounter As Integer
        intMax = UBound(intVIarray) - 1
        intCounter = UBound(intVIarray)
        If intVImean < 1000 Then ' illegal call - minimum VI mean is 1000 milliseconds (1 s)
            NextVI = -99 ' returns -99 to flag illegal call
            Exit Function
        End If
        If intVIarray(1) = 0 Then ' array is empty, better fill it
            SetUpVI(intVIarray, intVImean)
            intVIarray(intCounter) = 0 ' reset counter - very important
        End If
        If intVIarray(intCounter) = intMax Then ' array is used up, better refill it
            SetUpVI(intVIarray, intVImean)
            intVIarray(intCounter) = 0 ' reset counter - very important
        End If
        Do
            Randomize()
            i = GetRandomInteger.Next(1, intMax + 1) ' get random integer between 1 and max
            If intVIarray(i) > 0 Then ' interval is okay
                intInterval = intVIarray(i) ' save the okay interval
                intVIarray(i) = -99 ' flag that we've used this interval
                intVIarray(intCounter) = intVIarray(intCounter) + 1 ' keep count - very important
                Exit Do
            End If
        Loop
        NextVI = intInterval
    End Function

    Public Function NextVR(ByRef intVRarray() As Integer, ByRef intVRmean As Integer) As Integer

        ' This function returns the next ratio in a VR schedule.  The ratio
        ' is selected at random from the vrArray().  As each ratio is used, it
        ' is replaced with a -99 so that it is not used.  In other words, the
        ' ratios are selected at  random without replacement.

        ' The function requires two arguments: a single-dimension Integer array
        ' and the mean of the desired VR schedule in responses.
        ' The array must be dimensioned with an upper boundary equal to the number
        ' of ratios in the desired schedule PLUS ONE (e.g., if one wanted a schedule
        ' with 12 ratios, the Dim statement might be: Dim intVR( 13) as Integer.
        ' The first 12 cells are used for the list of ratios and the 13th
        ' is used as a counter to keep rack of the number of used ratios.

        ' The first time the function is called, it will call the SetUpVR sub to
        ' generate the Fleshler-Hoffman VR sequences.  When all of the ratios
        ' have been used, the function will recall SetUpVR to renew the list.  
        ' These calls to SetUpVR are made by the NextVR function; the user need not
        ' worry about it.

        Dim i, intMax As Integer
        Dim intRatio As Integer
        Static intCounter As Integer
        intMax = UBound(intVRarray) - 1
        intCounter = UBound(intVRarray)
        If intVRmean < 5 Then ' illegal call - minimum VR mean is 5 responses)
            NextVR = -99 ' returns -99 to flag illegal call
            Exit Function
        End If
        If intVRarray(1) = 0 Then ' array is empty, better fill it
            SetUpVR(intVRarray, intVRmean)
            intVRarray(intCounter) = 0 ' reset counter - very important
        End If
        If intVRarray(intCounter) = intMax Then ' array is used up, better refill it
            SetUpVR(intVRarray, intVRmean)
            intVRarray(intCounter) = 0 ' reset counter - very important
        End If
        Do
            Randomize()
            i = GetRandomInteger.Next(1, intMax + 1) ' get random integer between 1 and max
            If intVRarray(i) >= 0 Then ' ratio is okay
                intRatio = intVRarray(i) ' save the okay ratio
                intVRarray(i) = -99 ' flag that we've used this ratio
                intVRarray(intCounter) = intVRarray(intCounter) + 1 ' keep count - very important
                Exit Do
            End If
        Loop
        NextVR = intRatio
    End Function

    Private Sub SetUpVI(ByRef intVIarray() As Integer, ByRef intVImean As Integer)

        ' This sub uses Fleshler and Hoffman's (1962) formula to generate a VI
        ' schedule with a mean value of viMean (expressed in milliseconds).
        ' The number of intervals in the schedule is determined by the upper bound of
        ' the intVIarray passed to the sub.  It is assumed that the array's upper boundary
        ' is equal to the number of intervals PLUS ONE (if a schedule with
        ' 12 intervals the Dim statement might be: Dim intVI(13) as Integer). The
        ' last cell of the array is used by NextVI to keep count of the intervals
        ' as they are used.  When all intervals are used, NextVI calls this Sub
        ' to reinitialize the array.

        Dim i, j As Integer
        i = UBound(intVIarray) - 1
        For j = 1 To i - 1
            intVIarray(j) = CInt(intVImean * ((1 + System.Math.Log(i) + (i - j) * (System.Math.Log(i - j)) - (i - j + 1) * (System.Math.Log(i - j + 1)))))
        Next j
        intVIarray(i) = CInt(intVImean * ((1 + (System.Math.Log(i) - System.Math.Log(1)))))
    End Sub

    Private Sub SetUpVR(ByRef intVRarray() As Integer, ByRef intVRmean As Integer)

        ' This sub uses Fleshler and Hoffman's (1962) formula to generate a VI
        ' schedule with a mean value of viMean (expressed in milliseconds).
        ' The number of ratios in the schedule is determined by the upper boundary of
        ' the intVRarray passed to the sub.  It is assumed that the array's upper boundary
        ' is equal to the number of ratios PLUS ONE (if a schedule with
        ' 12 ratios the Dim statement might be: Dim intVR(13) as Integer). The
        ' last cell of the array is used by NextVR to keep count of the ratios
        ' as they are used.  When all ratios are used, NextVR calls this Sub
        ' to reinitialize the array.

        Dim total, i, j, intGoal As Integer
        i = UBound(intVRarray) - 1
        For j = 1 To i - 1
            intVRarray(j) = CInt(intVRmean * ((1 + System.Math.Log(i) + (i - j) * (System.Math.Log(i - j)) - (i - j + 1) * (System.Math.Log(i - j + 1)))))
        Next j
        intVRarray(i) = CInt(intVRmean * ((1 + (System.Math.Log(i) - System.Math.Log(1)))))

        For j = 1 To i
            If intVRarray(j) = 0 Then intVRarray(j) = 1
        Next j
        intGoal = intVRmean * i
        For j = 1 To i
            total = total + intVRarray(j)
        Next j
        If intGoal < total Then
            intVRarray(i) = intVRarray(i) - (total - intGoal) ' add difference to highest ratio
        ElseIf intGoal > total Then
            intVRarray(i) = intVRarray(i) + (intGoal - total) ' subtract difference from highest ratio
        End If
    End Sub

End Module
