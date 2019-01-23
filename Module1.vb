Module Module1
    Dim rows As Integer = 3
    Dim Cols As Integer = 4
    Dim Vehicles As Integer = 2
    Dim Rides As Integer = 3
    Dim Bonuses As Integer = 2
    Dim Steps As Integer = 10
    Dim Data(6, 5) As Integer
    Sub Main()
        FileReading()
        For i = 0 To 5
            For j = 0 To 4
                Console.WriteLine(Data(i, j) & " ")
            Next
        Next
        Console.ReadLine()
    End Sub
    Sub FileReading()
        Dim FileLine As String = ""
        Dim fileReader As IO.StreamReader
        Dim LastSpace As Integer = 0
        Dim NumTaken As Integer = 0
        Dim Counterj As Integer = 0
        Dim CounterNums As Integer = 0
        fileReader = New IO.StreamReader("a_example1.txt")
        fileReader.ReadLine()
        Do While fileReader.EndOfStream = False
            FileLine = fileReader.ReadLine()
            Console.WriteLine(FileLine)
            LastSpace = 0
            For i = 1 To Len(FileLine)
                If Mid(FileLine, i, 1) = " " Then
                    NumTaken = CInt(Mid(FileLine, LastSpace + 1, i - LastSpace))
                    LastSpace = i
                    Data(Counterj, CounterNums) = NumTaken
                    CounterNums = CounterNums + 1
                End If
            Next
            Counterj = Counterj + 1
        Loop

    End Sub
End Module
