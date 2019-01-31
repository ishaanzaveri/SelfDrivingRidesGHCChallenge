Module Module1
    'rayhaan is in
    'stark is in
    'Function RidesAvailble (cordx, cordy) where cordx and cordy are the current x and y coordinates of each car
    'Above function should return array RidesAvailable() where each column shows: x coordinate of ride start, y coordinate of ride start, earliest start
    'When adding data to array RidesAvailable(), don't include rides which are already taken (ie: last column of DataIN() has the value 1)
    Dim rows As Integer = 799
    Dim Cols As Integer = 999
    Dim Vehicles As Integer = 100
    Dim Rides As Integer = 299
    Dim Bonuses As Integer = 25
    Dim Steps As Integer = 25000
    Dim DataIN(Rides, 7) As Integer
    Dim DataCar(Rides, 1000) As Integer
    Dim PlusMinus As Integer = (rows * Cols) * 0.15
    Dim T As Integer = 0
    Dim RidesArr(99) As Integer
    Dim CurrentPos(Vehicles - 1, 1) As Integer

    Sub Main()
        FileReading()
        For i = 0 To (Rides)
            For j = 0 To 7
                Console.Write(DataIN(i, j) & " ")
            Next
            Console.WriteLine()
        Next
        Console.WriteLine()
        Console.WriteLine("Sorted by ES:")
        Console.ReadLine()
        SortedbyES()
        Console.ReadLine()
        SortedbyES()
        Console.WriteLine()
        Console.ReadLine()
        For T = 1 To Steps
            'Don't know what will happen in the first iteration of this loop since RidesArr() will be blank
            Decision(RidesArr)
        Next
    End Sub

    Sub SortedbyES()
        Dim temp As String ' array
        Dim x As Integer
        Dim sorted(Rides, 7)

        For i = 0 To (Rides - 1)
            If DataIN(i, 4) > DataIN(i + 1, 4) Then
                For x = 0 To 7
                    temp = DataIN(i, x)
                    DataIN(i, x) = DataIN(i + 1, x)
                    DataIN(i + 1, x) = temp
                Next
            End If
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

    Function RidesAvailable(ByVal SearchAtrributex As Integer, ByVal SearchAtrributey As Integer) As Integer()
        Dim RidesArr(Vehicles) As Integer
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

        RidesAvailable = RidesArr
    End Function

    Sub Decision(ByVal RidesArr)
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
        Dim temp_len As Integer = 0
        Dim preserve As String = ""
        Dim write As String = ""
        Dim concat As String = ""
        Dim temp As String = ""
        Dim WriteToFile As String = ""
        Dim FileWriter As IO.StreamWriter
        Dim FileReader As IO.StreamReader
        LeastDist = 1000000
        LeastWait = 1000000
        For counter = 0 To (Vehicles - 1)
            cordx = CurrentPos(counter, 0)
            cordy = CurrentPos(counter, 1)
            RidesAvailable(cordx, cordy)
            iterations = RidesArr(0)
            LeastDist = 1000000
            LeastWait = 1000000
            For counter1 = 1 To iterations
                Dist = Distance(cordx, cordy, RideSearchx(RidesArr(counter1)), RideSearchy(RidesArr(counter1)))
                Waiting = T - Check_E_Start(RidesArr(counter1))
                If (Dist < LeastDist) And (Waiting < LeastWait) Then
                    updatex = RideSearchx(RidesArr(counter1))
                    updatey = RideSearchy(RidesArr(counter1))
                    LeastDist = Dist
                    LeastWait = Waiting
                    RideNum = RidesArr(counter1)
                End If
            Next
            FileReader = New IO.StreamReader("output_file.txt")
            For counter2 = 1 To counter
                FileReader.ReadLine()
            Next
            temp = CStr(FileReader.ReadLine())
            temp_len = Len(temp)
            Do While Mid(temp, counter3, 1) <> " "
                concat = concat & Mid(temp, counter3, 1)
                counter3 = counter3 + 1
            Loop
            preserve = Right(temp, temp_len - counter3)
            add = CInt(concat)
            add = add + 1
            write = CStr(add)
            temp = write & preserve
            FileReader.Close()
            'Incomplete code for writing to file below. Need to figure out how to write to a specific line
            'FileWriter = New IO.StreamWriter("output_file.txt")
            'WriteToFile = temp & ", " & RideNum
            'FileWriter.WriteLine(WriteToFile)
            'FileWriter.Close()
            CurrentPos(counter, 0) = 0
            CurrentPos(counter, 0) = updatex
            CurrentPos(counter, 1) = 0
            CurrentPos(counter, 1) = updatey
            Dist = 0
            Waiting = 0
            RideNum = 0
            cordx = 0
            cordy = 0
            updatex = 0
            updatey = 0
            temp = ""
            WriteToFile = ""
        Next
    End Sub

    Function RideSearchx(ByVal RideNumber As Integer) As Integer
        Dim length As Integer = 0
        Dim cordx As Integer = 0
        Dim scan_array As Integer = 0
        length = DataIN(0, 3)
        'Can change to While Loop to make more efficient
        For scan_array = 1 To length
            If DataIN(scan_array, 6) = RideNumber Then
                cordx = DataIN(scan_array, 2)
            End If
        Next
        RideSearchx = cordx
    End Function

    Function RideSearchy(ByVal RideNumber As Integer) As Integer
        Dim length As Integer = 0
        Dim cordy As Integer = 0
        Dim scan_array As Integer = 0
        length = DataIN(0, 3)
        'Can change to While Loop to make more efficient
        For scan_array = 1 To length
            If DataIN(scan_array, 6) = RideNumber Then
                cordy = DataIN(scan_array, 3)
            End If
        Next
        RideSearchy = cordy
    End Function

    Function Check_E_Start(ByVal RideNumber As Integer) As Integer
        Dim length As Integer = 0
        Dim e_start As Integer = 0
        Dim scan_array As Integer = 0
        length = DataIN(0, 3)
        'Can change to While Loop to make more efficient
        For scan_array = 1 To length
            If DataIN(scan_array, 6) = RideNumber Then
                e_start = DataIN(scan_array, 4)
            End If
        Next
        Check_E_Start = e_start
    End Function

End Module
