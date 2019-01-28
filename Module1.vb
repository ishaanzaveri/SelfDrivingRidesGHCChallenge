Module Module1
    'rayhaan is in
    'stark is in
    'Function RidesAvailble (cordx, cordy) where cordx and cordy are the current x and y coordinates of each car
    'Above function should return array RidesAvailable() where each column shows: x coordinate of ride start, y coordinate of ride start, earliest start
    'When adding data to array RidesAvailable(), don't include rides which are already taken (ie: last column of DataIN() has the value 1)
    Dim rows As Integer = 3
    Dim Cols As Integer = 4
    Dim Vehicles As Integer = 2
    Dim Rides As Integer = 3
    Dim Bonuses As Integer = 2
    Dim Steps As Integer = 10
    Dim DataIN(Rides - 1, 7) As Integer
    Dim DataCar(1, 1000) As Integer
    Dim PlusMinus As Integer = (rows * Cols) * 0.15
    Dim T As Integer = 0

    Sub Main()
        FileReading()
        For i = 0 To 2
            For j = 0 To 7
                Console.Write(DataIN(i, j) & " ")
            Next
            Console.WriteLine()
        Next
        Console.ReadLine()
        SortedbyES()
        Console.ReadLine()
    End Sub

    Sub SortedbyES()
        Dim temp As String ' array
        Dim x As Integer
        Dim sorted(Rides, 7)

        For i = 0 To (Rides - 2)
            If DataIN(i, 4) > DataIN(i + 1, 4) Then
                For x = 0 To 7
                    temp = DataIN(i, x)
                    DataIN(i, x) = DataIN(i + 1, x)
                    DataIN(i + 1, x) = temp
                Next
            End If
        Next
        For i = 0 To (Rides - 1)
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
        fileReader = New IO.StreamReader("a_example.in")
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

    Function RidesAvailable(ByVal SearchAtrributex As Integer, ByVal SearchAtrributey As Integer) As Integer(,)
        Dim RidesArr(99, 2) As Integer
        ' FirstLine number of close rides


        Dim rideCounter = 0
        For i = 1 To Rides - 1
            If DataIN(i, 0) >= SearchAtrributex - PlusMinus And DataIN(i, 0) <= SearchAtrributex + PlusMinus And DataIN(i, 7) = 0 Then
                If DataIN(i, 1) >= SearchAtrributey - PlusMinus And DataIN(i, 1) <= SearchAtrributey + PlusMinus And DataIN(i, 7) = 0 Then
                    RidesArr(rideCounter, 0) = DataIN(i, 0)
                    RidesArr(rideCounter, 1) = DataIN(i, 1)
                    RidesArr(rideCounter, 2) = DataIN(i, 4)
                    rideCounter = rideCounter + 1
                End If
            End If
        Next


        RidesAvailable = RidesArr
    End Function

End Module
