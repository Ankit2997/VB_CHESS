﻿Imports Chess.Form1

Public Class game
    Public board(7, 7) As Integer
    Public can_move(7, 7) As Boolean
    Public check_for_white(7, 7) As Boolean
    Public check_for_black(7, 7) As Boolean


    Public Sub New()
        board = {{5, 4, 3, 2, 1, 3, 4, 5},
                 {6, 6, 6, 6, 6, 6, 6, 6},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {-6, -6, -6, -6, -6, -6, -6, -6},
                 {-5, -4, -3, -2, -1, -3, -4, -5}}
   
    End Sub
    'this is to show images of pieces
    Public Sub show()

        For i As Integer = 0 To 7
            For j As Integer = 0 To 7

                Select Case board(i, j)
                    Case 1
                        Form1.pb(i, j).Image = My.Resources.wKing
                    Case 2
                        Form1.pb(i, j).Image = My.Resources.wQueen
                    Case 3
                        Form1.pb(i, j).Image = My.Resources.Wbishop
                    Case 4
                        Form1.pb(i, j).Image = My.Resources.wKnight
                    Case 5
                        Form1.pb(i, j).Image = My.Resources.wRook
                    Case 6
                        Form1.pb(i, j).Image = My.Resources.wPawn
                    Case -1
                        Form1.pb(i, j).Image = My.Resources.bKing
                    Case -2
                        Form1.pb(i, j).Image = My.Resources.bQueen
                    Case -3
                        Form1.pb(i, j).Image = My.Resources.bBishop
                    Case -4
                        Form1.pb(i, j).Image = My.Resources.bKnight
                    Case -5
                        Form1.pb(i, j).Image = My.Resources.bRook
                    Case -6
                        Form1.pb(i, j).Image = My.Resources.bPawn
                      
                    Case Else
                        Form1.pb(i, j).Image = Nothing

                End Select

            Next
        Next
    End Sub
    'this is to select pic box
    Public Function selection(ByVal x, ByVal y) As String
        If board(x, y) <> 0 Then
            Form1.pb(x, y).BackgroundImage = My.Resources.selection
        End If
        Select Case board(x, y)
            Case 1
                Return "w_king"
            Case 2
                show_possible_move(Form1.w_queen.poss_mov())
                Return "w_queen"
            Case 3
                For i As Integer = 0 To 1
                    If Form1.w_bishop(i).ret_x = x And Form1.w_bishop(i).ret_y = y Then
                        show_possible_move(Form1.w_bishop(i).poss_mov())
                    End If
                Next
                Return "w_bishop"
            Case 4
                For i As Integer = 0 To 1
                    If Form1.w_knight(i).ret_x = x And Form1.w_knight(i).ret_y = y Then
                        show_possible_move(Form1.w_knight(i).poss_mov())
                    End If
                Next
                Return "w_knight"
            Case 5
                For i As Integer = 0 To 1
                    If Form1.w_rook(i).ret_x = x And Form1.w_rook(i).ret_y = y Then
                        show_possible_move(Form1.w_rook(i).poss_mov())
                    End If
                Next
                Return "w_rook"
            Case 6
                For i As Integer = 0 To 7
                    If Form1.w_pawn(i).ret_x = x And Form1.w_pawn(i).ret_y = y Then
                        show_possible_move(Form1.w_pawn(i).poss_mov())
                    End If
                Next
                Return "w_pawn"
            Case -1
                Return "b_king"
            Case -2
                show_possible_move(Form1.b_queen.poss_mov())
                Return "b_queen"
            Case -3
                For i As Integer = 0 To 1
                    If Form1.b_bishop(i).ret_x = x And Form1.b_bishop(i).ret_y = y Then
                        show_possible_move(Form1.b_bishop(i).poss_mov())
                    End If
                Next
                Return "b_bishop"
            Case -4
                For i As Integer = 0 To 1
                    If Form1.b_knight(i).ret_x = x And Form1.b_knight(i).ret_y = y Then
                        show_possible_move(Form1.b_knight(i).poss_mov())
                    End If
                Next
                Return "b_knight"
            Case -5
                For i As Integer = 0 To 1
                    If Form1.b_rook(i).ret_x = x And Form1.b_rook(i).ret_y = y Then
                        show_possible_move(Form1.b_rook(i).poss_mov())
                    End If
                Next
               
                Return "b_rook"
            Case -6
                For i As Integer = 0 To 7
                    If Form1.b_pawn(i).ret_x = x And Form1.b_pawn(i).ret_y = y Then
                        show_possible_move(Form1.b_pawn(i).poss_mov())
                    End If
                Next
                Return "b_pawn"
            Case Else
                Return Nothing
        End Select

    End Function
    Public Sub re_back()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                Form1.pb(i, j).BackgroundImage = Nothing
            Next
        Next
    End Sub
    Public Sub re_can_move()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                can_move(i, j) = False
            Next
        Next
    End Sub
    Public Sub re_chk_white()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                check_for_white(i, j) = False
            Next
        Next
    End Sub
    Public Sub re_chk_black()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                check_for_black(i, j) = False
            Next
        Next
    End Sub

    Public Sub fill_chk_for_black()
        For i As Integer = 0 To 7
            Form1.w_pawn(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Form1.w_pawn(i).check_the_king(j, k) = True Then
                        check_for_black(j, k) = True
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            Form1.w_rook(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Form1.w_rook(i).check_the_king(j, k) = True Then
                        check_for_black(j, k) = True
                    End If
                Next
            Next
        Next
        For i As Integer = 0 To 1
            Form1.w_bishop(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Form1.w_bishop(i).check_the_king(j, k) = True Then
                        check_for_black(j, k) = True
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            Form1.w_knight(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Form1.w_knight(i).check_the_king(j, k) = True Then
                        check_for_black(j, k) = True
                    End If
                Next
            Next
        Next

        Form1.w_queen.fill_chk_king()
        For j As Integer = 0 To 7
            For k As Integer = 0 To 7
                If Form1.w_queen.check_the_king(j, k) = True Then
                    check_for_black(j, k) = True
                End If
            Next
        Next

    End Sub
    Public Sub fill_chk_for_white()
        For i As Integer = 0 To 7
            Form1.b_pawn(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Form1.b_pawn(i).check_the_king(j, k) = True Then
                        check_for_white(j, k) = True
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            Form1.b_rook(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Form1.b_rook(i).check_the_king(j, k) = True Then
                        check_for_white(j, k) = True
                    End If
                Next
            Next
        Next
        For i As Integer = 0 To 1
            Form1.b_bishop(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Form1.b_bishop(i).check_the_king(j, k) = True Then
                        check_for_white(j, k) = True
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            Form1.b_knight(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Form1.b_knight(i).check_the_king(j, k) = True Then
                        check_for_white(j, k) = True
                    End If
                Next
            Next
        Next

        Form1.b_queen.fill_chk_king()
        For j As Integer = 0 To 7
            For k As Integer = 0 To 7
                If Form1.b_queen.check_the_king(j, k) = True Then
                    check_for_white(j, k) = True
                End If
            Next
        Next

    End Sub

    Public Sub show_chk()
        '''''''''''''''''''''''''''''''''''''''''Black Check'''''''''''''''''''''''''''''''''''
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If check_for_black(i, j) = True And Form1.b_king.x_pos = i And Form1.b_king.y_pos = j Then
                    Form1.pb(i, j).BackgroundImage = My.Resources.check
                End If
            Next
        Next

        '''''''''''''''''''''''''''''''''''''''''White Check'''''''''''''''''''''''''''''''''''
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If check_for_white(i, j) = True And Form1.w_king.x_pos = i And Form1.w_king.y_pos = j Then
                    Form1.pb(i, j).BackgroundImage = My.Resources.check
                End If
            Next
        Next
    End Sub
    
    Public Sub show_possible_move(ByVal b As Boolean(,))
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If b(i, j) = True Then
                    Form1.pb(i, j).BackgroundImage = My.Resources.V_Move
                    can_move(i, j) = True
                End If
            Next
        Next
    End Sub
    Public Sub mov(ByVal selected, ByVal x, ByVal y, ByVal pre_x, ByVal pre_y)
        Select Case selected
            Case "w_king"
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
            Case "w_queen"
                Form1.w_queen.change_pos(x, y, pre_x, pre_y)
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
            Case "w_bishop"
                For i As Integer = 0 To 1
                    If Form1.w_bishop(i).ret_x = pre_x And Form1.w_bishop(i).ret_y = pre_y Then
                        Form1.w_bishop(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
            Case "w_knight"
                For i As Integer = 0 To 1
                    If Form1.w_knight(i).ret_x = pre_x And Form1.w_knight(i).ret_y = pre_y Then
                        Form1.w_knight(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
            Case "w_rook"
                For i As Integer = 0 To 1
                    If Form1.w_rook(i).ret_x = pre_x And Form1.w_rook(i).ret_y = pre_y Then
                        Form1.w_rook(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
            Case "w_pawn"
                For i As Integer = 0 To 7
                    If Form1.w_pawn(i).ret_x = pre_x And Form1.w_pawn(i).ret_y = pre_y And board(x, y) <= 0 Then
                        Form1.w_pawn(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()

            Case "b_king"

            Case "b_queen"
                Form1.b_queen.change_pos(x, y, pre_x, pre_y)
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
            Case "b_bishop"
                For i As Integer = 0 To 1
                    If Form1.b_bishop(i).ret_x = pre_x And Form1.b_bishop(i).ret_y = pre_y Then
                        Form1.b_bishop(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
            Case "b_knight"
                For i As Integer = 0 To 1
                    If Form1.b_knight(i).ret_x = pre_x And Form1.b_knight(i).ret_y = pre_y Then
                        Form1.b_knight(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
            Case "b_rook"
                For i As Integer = 0 To 1
                    If Form1.b_rook(i).ret_x = pre_x And Form1.b_rook(i).ret_y = pre_y Then
                        Form1.b_rook(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
            Case "b_pawn"
                For i As Integer = 0 To 7
                    If Form1.b_pawn(i).ret_x = pre_x And Form1.b_pawn(i).ret_y = pre_y And board(x, y) >= 0 Then
                        Form1.b_pawn(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
            Case Else

        End Select


    End Sub
End Class