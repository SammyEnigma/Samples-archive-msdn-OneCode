'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Course
    Public Property CourseID As String
    Public Property Title As String
    Public Property Credits As Integer
    Public Property DepartmentID As Integer

    Public Overridable Property StudentGrades As ICollection(Of StudentGrade) = New HashSet(Of StudentGrade)

End Class