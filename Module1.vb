Module Module1
    'rayhaan is in
    'stark is in
    'Zaveri in 
    'Function RidesAvailble (cordx, cordy) where cordx and cordy are the current x and y coordinates of each car
    'Above function should return array RidesAvailable() where each column shows: x coordinate of ride start, y coordinate of ride start, earliest start
    'When adding data to array RidesAvailable(), don't include rides which are already taken (ie: last column of DataIN() has the value 1)

    'Global variables
    Dim rows As Integer = 799
    Dim Cols As Integer = 999
    Dim Vehicles As Integer = 100
    Dim Rides As Integer = 299
    Dim Bonuses As Integer = 25
    Dim Steps As Integer = 25000
    Dim DataIN(Rides, 7) As Integer
    Dim DataCar(Vehicles, 1000) As Integer
    Dim PlusMinus As Integer = (rows * Cols) * 0.15
    Dim T As Integer = 0
    Dim RidesArr(99) As Integer
    Dim CurrentPos(Vehicles - 1, 1) As Integer

    Sub Main()
        Console.WriteLine()
        Console.WriteLine("Sorted by ES:")
        Console.ReadLine()
        FileReading() ' Inputting all the data into DataIN
        outputingDataIn()

        SortedbyES()
        Console.WriteLine()
        Console.ReadLine()

        For T = 1 To Steps
            'Don't know what will happen in the first iteration of this loop since RidesArr() will be blank
            Decision()
            'If T Mod 10 = 0 Then
            Console.Write(T)
            ' End If
        Next
    End Sub
    Sub outputingDataIn()
        For i = 0 To (Rides) ' outputting DataIN
            For j = 0 To 7
                Console.Write(DataIN(i, j) & " ")
            Next
            Console.WriteLine()
        Next
    End Sub
    Sub SortedbyES() ' Ishaan - I feel Like sorted ES Does'nt work
        Dim temp As Integer ' changed temp to Integer as you were storing strings in the array 
        Dim x, j As Integer
        Dim sorted(Rides, 7)

        For j = 0 To (Rides - 1)
            For i = 0 To (Rides - j)
                If DataIN(i, 4) > DataIN(i + 1, 4) Then
                    For x = 0 To 7
                        temp = DataIN(i, x)
                        DataIN(i, x) = DataIN(i + 1, x)
                        DataIN(i + 1, x) = temp
                    Next
                End If
            Next
        Next
        For i = 0 To Rides
            For j = 0 To 7
                Console.Write(DataIN(i, j) & " ")
            Next
            Console.WriteLine()
        Next
    End Sub

    Function Distance(ByVal cordx1 As Integer, ByVal cordy1 As Integer, ByVal cordx2 As Integer, ByVal cordy2 As Integer) As Integer
        Dim Dis As Integer = 0
        Dis = Math.Abs(cordx1 - cordx2) + Math.Abs(cordy1 - cordy2)
        Return Dis
    End Function

    Sub FileReading()
        Dim FileLine As String = ""
        Dim fileReader As IO.StreamReader
        Dim LastSpace As Integer = 0
        Dim NumTaken As Integer = 0
        Dim Counterj As Integer = 0
        Dim CounterNums As Integer = 0
        Dim RideNo As Integer = 0
        fileReader = New IO.StreamReader("b_should_be_easy.in")
        fileReader.ReadLine()
        Do While fileReader.EndOfStream = False
            FileLine = fileReader.ReadLine()
            'Console.WriteLine(FileLine)
            LastSpace = 0
            CounterNums = 0
            For i = 1 To Len(FileLine)
                If Mid(FileLine, i, 1) = " " Then
                    NumTaken = CInt(Mid(FileLine, LastSpace + 1, i - LastSpace))
                    LastSpace = i
                    DataIN(Counterj, CounterNums) = NumTaken
                    CounterNums = CounterNums + 1
                End If
                If i = Len(FileLine) Then
                    NumTaken = CInt(Right(FileLine, i - LastSpace))
                    DataIN(Counterj, CounterNums) = NumTaken
                End If
            Next
            DataIN(Counterj, 6) = Counterj
            Counterj = Counterj + 1
        Loop

    End Sub

    Sub RidesAvailable(ByVal SearchAtrributex As Integer, ByVal SearchAtrributey As Integer)
        Dim RidesArr(Rides) As Integer ' Maximum number of rides passed can be all rides
        ' FirstLine number of close rides
        Dim rideCounter = 0
        For i = 1 To Rides
            If DataIN(i, 0) >= SearchAtrributex - PlusMinus And DataIN(i, 0) <= SearchAtrributex + PlusMinus And DataIN(i, 7) = 0 Then
                If DataIN(i, 1) >= SearchAtrributey - PlusMinus And DataIN(i, 1) <= SearchAtrributey + PlusMinus And DataIN(i, 7) = 0 Then
                    RidesArr(rideCounter) = DataIN(i, 6)
                    rideCounter = rideCounter + 1
                End If
            End If
        Next
        RidesArr(0) = rideCounter
    End Sub

    Sub Decision() ' RidesArr is a global variable it doesn't need to be passed.
        Dim add As Integer = 0
        Dim cordx As Integer = 0
        Dim cordy As Integer = 0
        Dim Dist As Integer = 0
        Dim LeastDist As Integer = 0
        Dim Waiting As Integer = 0
        Dim LeastWait As Integer = 0
        Dim iterations As Integer = 0
        Dim counter1 As Integer = 0
        Dim counter2 As Integer = 0
        Dim counter3 As Integer = 1
        Dim updatex As Integer = 0
        Dim updatey As Integer = 0
        Dim RideNum As Integer = 0
        LeastDist = 1000000
        LeastWait = 1000000
        For counter = 0 To (Vehicles - 1)
            cordx = CurrentPos(counter, 0)
            cordy = CurrentPos(counter, 1)
            RidesAvailable(cordx, cordy) ' change RideAvailable to a Sub 
            iterations = RidesArr(0) ' based on potential rides 
            LeastDist = 1000000
            LeastWait = 1000000
            For counter1 = 1 To iterations ' counter1 runs through every potential ride
                Dist = Distance(cordx, cordy, RideSearchx(RidesArr(counter1)), RideSearchy(RidesArr(counter1)))
                Waiting = T - Check_E_Start(RidesArr(counter1)) ' UpdateT sub 
                If (Dist < LeastDist) And (Waiting < LeastWait) Then
                    updatex = RideSearchx(RidesArr(counter1))
                    updatey = RideSearchy(RidesArr(counter1))
                    LeastDist = Dist
                    LeastWait = Waiting
                    RideNum = RidesArr(counter1)
                End If
            Next
            DataCar(counter, 0) = DataCar(counter, 0) + 1
            CurrentPos(counter, 0) = updatex
            CurrentPos(counter, 1) = updatey
            Dist = 0
            Waiting = 0
            RideNum = 0
            cordx = 0
            cordy = 0
            updatex = 0
            updatey = 0
        Next
    End Sub
    Sub updateT(ByRef StepsUsedbycar)
        T = T + StepsUsedbycar
    End Sub
    Function RideSearchx(ByVal RideNumber As Integer) As Integer
        Dim cordx As Integer = 0
        Dim scan_array As Integer = 0
        'Can change to While Loop to make more efficient
        For scan_array = 0 To Rides
            If DataIN(scan_array, 6) = RideNumber Then
                cordx = DataIN(scan_array, 2)
            End If
        Next
        RideSearchx = cordx
    End Function

    Function RideSearchy(ByVal RideNumber As Integer) As Integer
        Dim cordy As Integer = 0
        Dim scan_array As Integer = 0
        'Can change to While Loop to make more efficient
        For scan_array = 0 To Rides
            If DataIN(scan_array, 6) = RideNumber Then
                cordy = DataIN(scan_array, 3)
            End If
        Next
        RideSearchy = cordy
    End Function

    Function Check_E_Start(ByVal RideNumber As Integer) As Integer
        Dim e_start As Integer = 0
        Dim scan_array As Integer = 0
        'Can change to While Loop to make more efficient
        For scan_array = 0 To Rides
            If DataIN(scan_array, 6) = RideNumber Then
                e_start = DataIN(scan_array, 4)
            End If
        Next
        Check_E_Start = e_start
    End Function

End Module

