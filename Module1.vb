Module Module1
    'rayhaan is in
    Dim rows As Integer = 3
    Dim Cols As Integer = 4
    Dim Vehicles As Integer = 2
    Dim Rides As Integer = 3
    Dim Bonuses As Integer = 2
    Dim Steps As Integer = 10
    Dim Data(3, 6) As Integer
    Sub Main()
        FileReading()
        For i = 0 To 2
            For j = 0 To 5
                Console.Write(Data(i, j) & " ")
            Next
            Console.WriteLine()
        Next
        Console.ReadLine()
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
        fileReader = New IO.StreamReader("a_example.in")
        fileReader.ReadLine()

        Do While fileReader.EndOfStream = False
            FileLine = fileReader.ReadLine()
            Console.WriteLine(FileLine)
            LastSpace = 0
            CounterNums = 0
            For i = 1 To Len(FileLine)
                If Mid(FileLine, i, 1) = " " Then
                    NumTaken = CInt(Mid(FileLine, LastSpace + 1, i - LastSpace))
                    LastSpace = i
                    Data(Counterj, CounterNums) = NumTaken
                    CounterNums = CounterNums + 1
                End If
                If i = Len(FileLine) Then
                    NumTaken = CInt(Right(FileLine, i - LastSpace))
                    Data(Counterj, CounterNums) = NumTaken
                End If
            Next
            Counterj = Counterj + 1
        Loop

    End Sub
End Module
