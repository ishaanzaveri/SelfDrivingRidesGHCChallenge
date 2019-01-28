Module Module1
    Dim fileReader As IO.StreamReader
    Sub Main()
        Dim DataLine(5) As Integer
        Dim RowMax = 0
        Dim ColsMax = 0
        Dim EarliestEarlyStart = 999999999999999
        Dim LatestLateFinish = 0

        fileReader = New IO.StreamReader("e_high_bonus.in")

        DataLine = ReadingAndStoring()
        Console.WriteLine("Rows: " & DataLine(0) & " Cols: " & DataLine(1) & " Vehicles: " & DataLine(2) & " Rides: " & DataLine(3) & " Bonus: " & DataLine(4) & " Steps: " & DataLine(5))

        Do While fileReader.EndOfStream = False
            DataLine = ReadingAndStoring()
            If DataLine(0) > RowMax Then RowMax = DataLine(0)
            If DataLine(1) > ColsMax Then ColsMax = DataLine(1)
            If DataLine(2) > RowMax Then RowMax = DataLine(2)
            If DataLine(3) > ColsMax Then ColsMax = DataLine(3)
            If DataLine(4) < EarliestEarlyStart Then EarliestEarlyStart = DataLine(4)
            If DataLine(5) > LatestLateFinish Then LatestLateFinish = DataLine(5)
        Loop

        Console.WriteLine("Rows: " & RowMax & " Cols: " & ColsMax & " Early Start: " & EarliestEarlyStart & " LateEnd: " & LatestLateFinish)

        Console.ReadLine()
    End Sub
    Function ReadingAndStoring() As Integer()
        Dim DataLine(5) As Integer
        Dim FileLine As String = ""
        Dim LastSpace As Integer = 0
        Dim NumTaken As Integer = 0
        Dim CounterNums As Integer = 0


        FileLine = fileReader.ReadLine()
        LastSpace = 0
        CounterNums = 0
        For i = 1 To Len(FileLine)
            If Mid(FileLine, i, 1) = " " Then
                NumTaken = CInt(Mid(FileLine, LastSpace + 1, i - LastSpace))
                LastSpace = i
                DataLine(CounterNums) = NumTaken
                CounterNums = CounterNums + 1
            End If
            If i = Len(FileLine) Then
                NumTaken = CInt(Right(FileLine, i - LastSpace))
                DataLine(CounterNums) = NumTaken
            End If
        Next
        ReadingAndStoring = DataLine
    End Function
End Module
